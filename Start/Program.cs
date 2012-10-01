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
