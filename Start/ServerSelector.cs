using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Win32;

namespace LauncherX
{
    public partial class ServerSelector : Form
    {
        public static Start.PleaseWait w;
        int CycleTimeout = 1000; // 10 seconds (100ms 1000 times)
        const string userRoot = "Software\\JavaSoft\\Prefs\\minecraft";
        LoginClientMinecraft c;
        List<ServerInfo> items;
        string SelectedServer = null;
        string Cookie;
        string LoginIp;
        string LoginPort;
        string LoginUser;
        string LoginPassword;

        public ServerSelector()
        {
            InitializeComponent();
            if (!File.Exists("wom.exe"))
            {
                MessageBox.Show("wom.exe could not be found in the folder");
                Environment.Exit(1);
                return;
            }
            RemoveControlBoxItems();
            new Thread(new ThreadStart(Start.UpdateChecker.UpdateCheck)).Start();
        }

        public void RemoveControlBoxItems()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        #region Server List

        private void ServerSelector_Load(object sender, EventArgs e){
            LoadPassword();
        }

        void SearchServerList(string Cont){
            if(Cont == null || Cont.Length < 1) return;
            if (items.Count == 0){
                return;
            }
            for (int i = 0; i < items.Count; i++){
                if (items[i].Name.ToLower().Contains(Cont.ToLower())){
                    string[] row = { items[i].Name, items[i].Players.ToString(), items[i].PlayersMax.ToString(),
                                   items[i].Url};
                    GridBox1.Rows.Add(row);
                }
            }
            foreach (DataGridViewColumn column in GridBox1.Columns){
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        void DrawServerList(){
            if (items == null || items.Count < 1){
                try{
                    items = c.ServerList(textBox2.Text, textBox3.Text);
                }
                catch (Exception e) { 
                    MessageBox.Show("Unable to log you in. " + e.Message);
                    Environment.Exit(1);
                }
            }
            if (items == null) return;
            if (items.Count == 0){
                MessageBox.Show("Could not retrieve server list\n" +
                    "Either Minecraft.net is down or your username and password\nare incorrect");
                Environment.Exit(1);
            }
            for (int i = 0; i < items.Count; i++){
                string[] row = { items[i].Name, items[i].Players.ToString(), items[i].PlayersMax.ToString(),
                                   items[i].Url};
                GridBox1.Rows.Add(row);
            }
            foreach (DataGridViewColumn column in GridBox1.Columns){
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
            SearchBox.Enabled = true;
        }

        void c_Progress(object sender, ProgressEventArgs e){
            progressBar1.Refresh();
            progressBar1.Value = e.ProgressPercent;
            progressBar1.CreateGraphics().DrawString(e.ProgressPercent+"%",
            new Font("Times New Roman", (float)12, FontStyle.Bold),
            Brushes.Black, new PointF(progressBar1.Width / 2 - 10,
                progressBar1.Height / 2 - 7));
        }
       
        private void SetLoginData(string url){
            LoginClientMinecraft c = new LoginClientMinecraft();
            LoginData logindata = c.Login(textBox2.Text, textBox3.Text, url);
            if (logindata == null)
            {
                MessageBox.Show("Error logging you in, check if minecraft.net is up or try again later");
                return;
            }
            this.LoginIp = logindata.serveraddress;
            this.LoginPassword = logindata.mppass;
            this.LoginPort = logindata.port.ToString();
            this.LoginUser = textBox2.Text;
        }

        void LoadPassword(){
            using (RegistryKey Key = Registry.CurrentUser.OpenSubKey(userRoot, true)){
                string s = (string)Key.GetValue("login");
                if (s.Length > 1)
                {
                    if (s.StartsWith("/"))
                    {
                        s = s.Replace("/", "");
                    }
                    string user = s.Substring(0, s.IndexOf("|"));
                    s = s.Replace(user, "").Replace("|", "");
                    textBox2.Text = user; textBox3.Text = s;
                }
            }
        }

        void SavePassword(){
            using (RegistryKey Key = Registry.CurrentUser.OpenSubKey(userRoot, true)){
                try{
                    string user = "", pass = "|", full = "";
                    if (textBox2.Text.Length > 1 && textBox3.Text.Length > 1){
                        user += textBox2.Text; pass += textBox3.Text;
                        full = "/" + user + pass;
                    }
                    Key.SetValue("login", full, RegistryValueKind.String);
                }
                catch { MessageBox.Show("Error updating registry"); }
            }
        }

        private void Button2_Click_3(object sender, EventArgs e){
            if (textBox2.Text == "" || textBox3.Text == ""){
                MessageBox.Show("Enter username and password.");
                return;
            }
            StartServerList();
        }

        void StartServerList(){
            if (c == null){
                c = new LoginClientMinecraft();
                c.Progress += new EventHandler<ProgressEventArgs>(c_Progress);
                DrawServerList();
                TabControl1.SelectTab(1);
            }
        }

        private void SearchBox_TextChanged_2(object sender, EventArgs e){
            if (c == null) return;
            if (SearchBox.Text.Length < 1){
                DrawServerList();
                return;
            }
            GridBox1.Rows.Clear();
            SearchServerList(SearchBox.Text);
        }

        private void Button3_Click_1(object sender, EventArgs e){
            if (textBox2.Text == "" || textBox3.Text == ""){
                MessageBox.Show("Enter username and password.");
                return;
            }
            SetLoginData(SelectedServer);
        }

        private void GridBox1_SelectionChanged(object sender, EventArgs e){
            if (GridBox1.SelectedRows.Count < 1) return;
            int index = GridBox1.SelectedRows[0].Index;
            if (index == -1) return;
            SelectedServer = GridBox1.Rows[index].Cells[3].Value.ToString();
        }

        #endregion

        #region InteropServices Methods
        private const int LEFTDOWN = 0x00000002, LEFTUP = 0x00000004;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern long SendMessage(IntPtr hWnd, int Msg, int
        wParam, int lParam);

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        static extern bool mouse_event(int dwFlags, int dx, int dy, int dwData, UIntPtr dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern long GetWindowRect(IntPtr hWnd, ref Rectangle lpRect);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("User32.dll")]
        public static extern IntPtr FindWindow(String lpClassName, String lpWindowName);

        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        #endregion 

        #region WoM Launcher
        IntPtr wnd = IntPtr.Zero;
        Rectangle rect = new Rectangle(0, 0, 0, 0);

        private void button1_Click_1(object sender, EventArgs e){
            LaunchWoM(false);
        }

        void LaunchWoM(bool resume){
            if (textBox2.Text == "" || textBox3.Text == ""){
                MessageBox.Show("Enter username and password.");
                return;
            }
            w.TopMost = true;
            w.Show();
            w.progressBar1.PerformStep();
            if (!resume){
                SetLoginData(SelectedServer);
                    using (RegistryKey Key = Registry.CurrentUser.OpenSubKey(userRoot, true)){
                        try{
                            Key.SetValue("mppass", LoginPassword, RegistryValueKind.String);
                            Key.SetValue("port", LoginPort, RegistryValueKind.String);
                            Key.SetValue("server", LoginIp, RegistryValueKind.String);
                        }
                        catch { MessageBox.Show("Error updating registry"); }
                }
            }
            Process.Start("wom.exe");
            w.progressBar1.PerformStep();
            w.progressBar1.PerformStep();
            Thread.Sleep(1200);
            w.progressBar1.PerformStep();
            w.progressBar1.PerformStep();

            Thread t = new Thread(new ThreadStart(WaitCheckLaunch));
            t.Start();
        }

        void WaitCheckLaunch(){
            int CycleCount = 0;
            while (rect.Width == 0 || wnd == IntPtr.Zero){
                Thread.Sleep(100);
                if (rect.Width > 0 && wnd != IntPtr.Zero){
                    break;
                }else{
                    CycleCount++;
                    if (CycleCount > CycleTimeout){
                        throw new Exception("Launching of WoM timed out after 10 seconds");
                    }
                    if(rect.Width < 1)
                        GetWindowRect(wnd, ref rect);
                    if(wnd == IntPtr.Zero)
                        wnd = FindWindow(null, "Login");
                }
            }
            int OCurX = Cursor.Position.X;
            int OCurY = Cursor.Position.Y;
            
            SetForegroundWindow(wnd);
            SetCursorPos(rect.X + 288, rect.Y + 210);
            mouse_event(LEFTDOWN | LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, UIntPtr.Zero);
            SetCursorPos(OCurX, OCurY);
            w.Hide();
            this.WindowState = FormWindowState.Minimized;
            SavePassword();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            LaunchWoM(true);
        }
        #endregion

        #region Clickable links
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e){
            Process.Start("http://au70.net");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e){
            Process.Start("http://charged-miners.com/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e){
            Process.Start("https://github.com/GlennMR/800Craft-Client/downloads");
        }
        #endregion
    }
}