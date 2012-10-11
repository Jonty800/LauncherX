using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Globalization;

namespace LauncherX
{
    public class LoginData
    {
        public string serveraddress;
        public int port;
        public string mppass;
    }
    public interface ILoginClient
    {
        LoginData Login(string username, string password, string gameurl);
    }
    public class LoginClientDummy : ILoginClient
    {
        #region ILoginClient Members
        public LoginData Login(string username, string password, string gameurl)
        {
            return null;
        }
        #endregion
    }
    public class ServerInfo
    {
        public string Url;
        public string Name;
        public int Players;
        public int PlayersMax;
    }
    public class ProgressEventArgs : EventArgs
    {
        public int ProgressPercent;
    }
    public class LoginClientMinecraft : ILoginClient
    {
        public event EventHandler<ProgressEventArgs> Progress;

        public List<ServerInfo> ServerList(string username, string password)
        {
            ReportProgress(0);
            List<ServerInfo> l = new List<ServerInfo>();
            string url = "http://minecraft.net/classic/list";
            string html = LoginAndReadPage(username, password, url);

            //inspired by ChargedMinersLauncher by fragmer and uses its Regex to parse the values from the html
            //https://github.com/mcdevs/ChargedMinersLauncher/blob/b03026c78a8bc8623ab26b7a634d86e83e4b060c/ChargedMinersLauncher/ServerList.cs
            Regex ServerListEntry = new Regex(@"<a href=""/classic/play/([0-9a-f]+)"">([^<]+)</a>\s+</td>\s+<td>(\d+)</td>\s+<td>(\d+)</td>\s+<td>(\d+\w)</td>");

            int matchNumber = 0;
            foreach (Match match in ServerListEntry.Matches(html))
            {
                string hash = match.Groups[1].Value;
                // minecraft.net escaping bug workaround
                string name = Uri.UnescapeDataString(match.Groups[2].Value).Replace("&hellip;", "…");
                int players;
                if (!Int32.TryParse(match.Groups[3].Value, out players))
                {
                    continue;
                }
                int maxPlayers;
                if (!Int32.TryParse(match.Groups[4].Value, out maxPlayers))
                {
                    continue;
                }
                l.Add(new ServerInfo() { Url = "http://minecraft.net/classic/play/" + hash, Name = name, Players = players, PlayersMax = maxPlayers });
                matchNumber++;
            }
            ReportProgress(1);
            return l;
        }
        private void ReportProgress(double progress)
        {
            if (Progress != null) { Progress(this, new ProgressEventArgs() { ProgressPercent = (int)(progress * 100) }); };
        }
        //Three Steps
        public LoginData Login(string username, string password, string gameurl)
        {
            string html = LoginAndReadPage(username, password, gameurl);
            if (html.Length < 1) return null;
            string serveraddress = ReadValue(html.Substring(html.IndexOf("\"server\""), 40));
            string port = ReadValue(html.Substring(html.IndexOf("\"port\""), 40));
            string mppass = ReadValue(html.Substring(html.IndexOf("\"mppass\""), 80));
            return new LoginData() { serveraddress = serveraddress, port = int.Parse(port), mppass = mppass };
        }
        private string LoginAndReadPage(string username, string password, string gameurl)
        {
            if (this.username != username || this.password != password || loggedincookie.Count == 0)
            {
                this.username = username;
                this.password = password;
                //Step 1 and Step 2.
                LoginCookie();
            }
            //Step 3.
            //---
            //Go to game url and GET using JSESSIONID cookie and _uid cookie.
            //Parse the page to find server, port, mpass strings.
            //---
            WebRequest step3Request = (HttpWebRequest)HttpWebRequest.Create(gameurl);
            //step3Request.Timeout = 10000;
            foreach (string cookie in loggedincookie)
            {
                step3Request.Headers.Add(cookie);
            }
            using (var s4 = step3Request.GetResponse().GetResponseStream())
            {
                try
                {
                    //s4.ReadTimeout = 10000;
                    var r = step3Request.GetResponse();
                    foreach (string s in r.Headers.AllKeys)
                    {
                        //update logged in cookie.
                        bool cleared = false;
                        if (s.Contains("Set-Cookie"))
                        {
                            if (!cleared)
                            {
                                loggedincookie.Clear();
                                cleared = true;
                            }
                            loggedincookie.Add("Cookie: " + r.Headers[s]);
                        }
                    }
                    string html = new StreamReader(s4).ReadToEnd();
                    return html;
                }
                catch
                {
                    throw new WebException();
                }
            }
        }
        private static string ReadValue(string s)
        {
            string start = "value=\"";
            string end = "\"";
            string ss = s.Substring(s.IndexOf(start) + start.Length);
            ss = ss.Substring(0, ss.IndexOf(end));
            return ss;
        }
        List<string> loggedincookie = new List<string>();
        string username;
        string password;

        void LoginCookie()
        {
            //Step 1.
            //---
            //Go to http://minecraft.net/login and GET, you will receive JSESSIONID cookie.
            //---
            string loginurl = "https://minecraft.net/login";
            string data11 = string.Format("username={0}&password={1}", username, password);
            string sessionidcookie;
            {
                using (WebClient c = new WebClient())
                {
                    try
                    {
                        string html = c.DownloadString(loginurl);
                        sessionidcookie = c.ResponseHeaders[HttpResponseHeader.SetCookie];
                        string sessionid;
                        sessionid = sessionidcookie.Substring(0, sessionidcookie.IndexOf(";"));
                        sessionid = sessionid.Substring(sessionid.IndexOf("=") + 1);
                    }
                    catch
                    {
                        System.Windows.Forms.MessageBox.Show("Unable to log you in: Check if Minecraft.net is up");
                        Environment.Exit(1);
                        return;
                    }
                }
            }
            ReportProgress(1.0 / 3);
            //Step 2.
            //---
            //Go to http://minecraft.net/login and POST "username={0}&password={1}" using JSESSIONID cookie.
            //You will receive logged in cookie ("_uid").
            //Because of multipart http page, HttpWebRequest has some trouble receiving cookies in step 2,
            //so it is easier to just use raw TcpClient for this.
            //---
            {
                using (TcpClient step2Client = new TcpClient("minecraft.net", 80))
                {
                    var stream = step2Client.GetStream();
                    StreamWriter sw = new StreamWriter(stream);
                    //stream.ReadTimeout = 10000;
                    sw.WriteLine("POST /login HTTP/1.0");
                    sw.WriteLine("Host: minecraft.net");
                    sw.WriteLine("Content-Type: application/x-www-form-urlencoded");
                    sw.WriteLine("Set-Cookie: " + sessionidcookie);
                    sw.WriteLine("Content-Length: " + data11.Length);
                    sw.WriteLine("");
                    sw.WriteLine(data11);

                    sw.Flush();
                    StreamReader sr = new StreamReader(stream);
                    loggedincookie.Clear();
                    for (; ; )
                    {
                        var s = sr.ReadLine();
                        if (s == null)
                        {
                            break;
                        }
                        //System.Windows.Forms.MessageBox.Show(s);
                        if (s.Contains("Set-Cookie"))
                        {
                            loggedincookie.Add(s);
                        }
                    }
                }
            }
            for (int i = 0; i < loggedincookie.Count; i++)
            {
                loggedincookie[i] = loggedincookie[i].Replace("Set-", "");
            }
            ReportProgress(2.0 / 3);
        }
    }
}