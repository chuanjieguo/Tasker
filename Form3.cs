using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Tasker
{
    public enum TipsType { HTML, TEXT, EXE};

    public enum TimeType { EVERYDAY, EVERYWEEK, EVERYMONTH, SOMETIMES };

    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private int h = 0;

        private void Form3_Load(object sender, EventArgs e)
        {
            h = this.Height;

            this.Height = 0;

            Screen[] screens = Screen.AllScreens;　　　　　
            Screen screen = screens[0];                     
            this.Location = new Point(screen.WorkingArea.Width - this.Width, screen.WorkingArea.Height);

            wbContent.ScriptErrorsSuppressed = true;    
            wbContent.IsWebBrowserContextMenuEnabled = false;  
            wbContent.WebBrowserShortcutsEnabled = false;  
            wbContent.AllowWebBrowserDrop = false;
            wbContent.ScrollBarsEnabled = false;
        }

        private string innerHtml;

        public string InnerHtml
        {
            get { return innerHtml; }
            set { innerHtml = value; }
        }

        private string innerStr;

        public string InnerStr
        {
            get { return innerStr; }
            set { innerStr = value; }
        }


        public void UpShow(TaskEle ele, string content)
        {
            int steps = 100;
            string href = "";
            if (!String.IsNullOrEmpty(ele.Url))
            {
                href = string.Format("</br><a href='{0}' target='_blank'>访问原链接</a>", ele.Url);
            }
            if (ele.Type == TipsType.HTML)
            {
                if (string.IsNullOrEmpty(ele.RegBegin) && string.IsNullOrEmpty(ele.RegEnd))
                    wbContent.Navigate(ele.Url);
                else
                    wbContent.DocumentText = content + href;
            }
            else
            {
                wbContent.DocumentText = "<table width=\"" + (wbContent.Width - 50) + "\" height=\"" + (wbContent.Height - 50) + "\"  align=\"center\" style=\"font:bold 30px 宋体;text-align:center;color:#00F;word-break:break-all\"><tr><td>" + content + "</tr></td></table>" + href;
            }
            this.Text = "玲娜贝儿提醒你：" + ele.Title;
            Screen[] screens = Screen.AllScreens;
            Screen screen = screens[0];
            this.TopMost = true;
            this.Show();
            while (true)
            {
                if (this.Height < h)
                {
                    this.Height += steps;
                    this.Location = new Point(this.Location.X, this.Location.Y - steps);
                }
                else
                {
                    this.Height = h;
                    this.Location = new Point(screen.WorkingArea.Width - this.Width, screen.WorkingArea.Height - this.Height);
                    break;
                }

                //Thread.Sleep(5);
            }
        }

        private void wbContent_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
