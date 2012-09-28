using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Diagnostics;
using System.Windows.Forms;
using System.Net;
using System.Threading;

namespace Start
{
    class Program
    {
        static string tempfile;

        [STAThread]
        static void Main(string[] args)
        {
            tempfile = Path.Combine(Path.GetTempPath(), "tmp.mdlink");
            var f = new LauncherX.ServerSelector();
            var g = new Start.PleaseWait();
            g.Hide();
            LauncherX.ServerSelector.w = g;
            System.Windows.Forms.Application.Run(f);
            System.Windows.Forms.Application.Exit();
            if (File.Exists(tempfile))
            {
                File.Delete(tempfile);
            }
            if (f.SelectedServer != null)
            {
                try
                {
                    string ip = f.LoginIp;
                    string port = f.LoginPort;
                    string user = f.LoginUser;
                    string password = f.LoginPassword;
                    string s = string.Format(@"<?xml version=""1.0""?>
                    <LauncherXLink>
	                    <Ip>{0}</Ip>
	                    <Port>{1}</Port>
	                    <GameMode>Mine</GameMode>
	                    <User>{2}</User>
                        <Password>{3}</Password>
                    </LauncherXLink>", ip, port, user, password);
                    File.WriteAllText(tempfile, s);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }
    }
    public class XmlTool
    {
        public static string XmlVal(XmlDocument d, string path)
        {
            XPathNavigator navigator = d.CreateNavigator();
            XPathNodeIterator iterator = navigator.Select(path);
            foreach (XPathNavigator n in iterator)
            {
                return n.Value;
            }
            return null;
        }
        public static IEnumerable<string> XmlVals(XmlDocument d, string path)
        {
            XPathNavigator navigator = d.CreateNavigator();
            XPathNodeIterator iterator = navigator.Select(path);
            foreach (XPathNavigator n in iterator)
            {
                yield return n.Value;
            }
        }
    }
}
