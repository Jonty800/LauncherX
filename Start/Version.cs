using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace Start
{
    public class UpdateChecker
    {
        public static int Version = 3;
        public static string ReleaseType = "Release 3";
        public static int WebVersion = 0;
        public static string DownloadLocation = null;
        public static void UpdateCheck()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    using (Stream stream = client.OpenRead("http://forums.au70.net/updatelauncher.txt"))
                    {
                        stream.ReadTimeout = 1000;
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            WebVersion = int.Parse(reader.ReadLine());
                            DownloadLocation = reader.ReadLine();
                        }
                    }
                    if (WebVersion != 0 && DownloadLocation != null)
                    {
                        if (WebVersion > Version)
                        {
                            if (MessageBox.Show("An update is available! \nDo you wish to download it?", "Update available!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                System.Diagnostics.Process.Start(DownloadLocation);
                                Environment.Exit(1);
                            }
                            else
                            {
                                Application.OpenForms["ServerSelector"].BringToFront(); //silly bugfix
                                return;
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }
    }
}