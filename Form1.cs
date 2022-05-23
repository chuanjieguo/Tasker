using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.IO.Compression;
using System.Net;
using System.Text.RegularExpressions;

namespace Tasker
{
    public partial class Form1 : Form
    {
        private bool bLog = true;

        private List<TaskEle> taskList = new List<TaskEle>();

        public Form1()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void contextMenuStrip1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                //this.Hide();        
                this.Visible = false;
                this.notifyIcon1.Visible = true;
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
            this.Visible = false;
            this.notifyIcon1.Visible = true;
        }

        private void notifyIcon1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.Visible)
                {
                    this.Visible = false;
                    this.WindowState = FormWindowState.Minimized;
                }
                else
                {
                    this.Visible = true;
                    this.WindowState = FormWindowState.Normal;
                }
            }

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DumpToFile();
            Environment.Exit(0);
        }

        private void clear()
        {
            cbType.SelectedIndex = 0;
            tbTips.Enabled = false;

            tbTitle.Text = "";
            tbUrl.Text = "";
            tbRegBegin.Text = "";
            tbRegEnd.Text = "";
            tbEncoding.Text = "";
            cbTimeType.SelectedIndex = 0;
            cbMethod.SelectedIndex = 0;
            cbWeek.SelectedIndex = 0;
            tbData.Text = "";
            tbPreview.Text = "";

            DateTime dt = DateTime.Now;
            tbYear.Text = dt.Year.ToString();
            tbMonth.Text = dt.Month.ToString();
            tbDay.Text = dt.Day.ToString();
            tbHour.Text = dt.Hour.ToString();
            tbMinute.Text = dt.Minute.ToString();
            tbSecond.Text = dt.Second.ToString();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string title = tbTitle.Text,
            tips = tbTips.Text,
            url = tbUrl.Text,
            encoding = tbEncoding.Text,
            regBegin = tbRegBegin.Text,
            regEnd = tbRegEnd.Text,
            method = cbMethod.Text,
            data = tbData.Text;
            switch (cbType.SelectedIndex)
            {
                case 0:
                    if (String.IsNullOrEmpty(title) || String.IsNullOrEmpty(url))
                    {
                        MessageBox.Show("需要填写Title/Tips/URL字段", "玲娜贝儿提示你");
                        return;
                    }
                    break;
                case 1:
                    if (String.IsNullOrEmpty(title) || String.IsNullOrEmpty(tips))
                    {
                        MessageBox.Show("需要填写Title/Tips", "玲娜贝儿提示你");
                        return;
                    }
                    break;
                case 2:
                    if (String.IsNullOrEmpty(title) || String.IsNullOrEmpty(tips) || String.IsNullOrEmpty(url))
                    {
                        MessageBox.Show("需要填写Title/Tips/URL(exe所在路径)", "玲娜贝儿提示你");
                        return;
                    }
                    break;
            }

            TaskEle te;
            bool ret = view(false, out te, true);
            if (!ret)
            {
                MessageBox.Show("Format error.", "玲娜贝儿提示你");
                return;
            }

            DialogResult dRet = MessageBox.Show(String.Format("是否新增任务“{0}”？", te.Title), "玲娜贝儿提示你", MessageBoxButtons.OKCancel);
            if (dRet == DialogResult.Cancel)
                return;
            if (!AddTask(te))
            {
                MessageBox.Show("The task exits!", "玲娜贝儿提示你");
                return;
            }
            clear();
            UpdateTable();

            DumpToFile();
            SelectOne(te);
        }

        private void SelectOne(TaskEle ele)
        {
            foreach(DataGridViewRow r in dgTasks.Rows)
            {
                TaskEle re = RowToEle(r);
                if (ele.ToString() == re.ToString())
                {
                    r.Selected = true;
                    break;
                }
            }
            
        }

        private bool AddTask(TaskEle ele)
        {
            foreach (TaskEle e in taskList)
            {
                if (e.ToString().Equals(ele.ToString()))
                    return false;
            }
            taskList.Add(ele);
            return true;
        }

        private bool DeleteTask(TaskEle ele)
        {
            for (int i = 0; i < taskList.Count; i++)
            {
                if (taskList[i].ToString().Equals(ele.ToString()))
                {
                    taskList.RemoveAt(i);
                    return true;
                }
            }
            return false;

        }

        private bool EditTask(TaskEle oEle, TaskEle nEle)
        {
            for (int i = 0; i < taskList.Count; i++)
            {
                if (taskList[i].ToString().Equals(oEle.ToString()))
                {
                    taskList[i] = nEle;
                    return true;
                }
            }
            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (LoadFromFile())
            {
                DataTable dtt = ToTable();
                dgTasks.DataSource = dtt;
            }

            tbTitle.Text = "";
            tbPreview.Text = "";
            cbType.SelectedIndex = 0;
            tbTips.Enabled = false;

            tbUrl.Text = "";
            tbRegBegin.Text = "";
            tbRegEnd.Text = "";
            tbEncoding.Text = "";
            cbTimeType.SelectedIndex = 0;
            cbMethod.SelectedIndex = 0;
            cbWeek.SelectedIndex = 0;
            tbData.Text = "";

            thTask = new Thread(new ThreadStart(Working));
            thTask.SetApartmentState(ApartmentState.STA);
            thTask.IsBackground = true;
            thTask.Start();

            DateTime dt = DateTime.Now;
            tbYear.Text = dt.Year.ToString();
            tbMonth.Text = dt.Month.ToString();
            tbDay.Text = dt.Day.ToString();
            tbHour.Text = dt.Hour.ToString();
            tbMinute.Text = dt.Minute.ToString();
            tbSecond.Text = dt.Second.ToString();

            UpDown(true);
            //http://blog.csdn.net/xuehuic/article/details/6426284
        }


        private DataTable ToTable()
        {
            DataTable dt = new DataTable();
            string[] cols = new string[] { "标题", "任务类型", "时间类型", "时间", "文本提示", "URL", "Encoding", "Method", "PostData", "RegBegin", "RegEnd" };
            int sizeCount = cols.Length;
            foreach (string col in cols)
            {
                DataColumn dc = new DataColumn(col);
                dt.Columns.Add(dc);
            }

            DataRow dr;
            foreach (TaskEle ele in taskList)
            {
                dr = dt.NewRow();
                dr[0] = ele.Title;
                switch (ele.Type)
                {
                    case TipsType.TEXT:
                        dr[1] = "TipsTask";
                        break;
                    case TipsType.HTML:
                        dr[1] = "WebTask";
                        break;
                    case TipsType.EXE:
                        dr[1] = "ExeTask";
                        break;
                }


                switch (ele.TimeType)
                {
                    case TimeType.EVERYDAY:
                        dr[2] = "Everyday";
                        break;
                    case TimeType.EVERYWEEK:
                        dr[2] = "Everyweek";
                        break;
                    case TimeType.EVERYMONTH:
                        dr[2] = "Everymonth";
                        break;
                    case TimeType.SOMETIMES:
                        dr[2] = "Sometimes";
                        break;
                }

                dr[3] = ele.GetTimeStr();
                dr[4] = ele.Tips;
                dr[5] = ele.Url;
                dr[6] = ele.Encoding;
                dr[7] = ele.Method;
                dr[8] = ele.Data;
                dr[9] = ele.RegBegin;
                dr[10] = ele.RegEnd;
                dt.Rows.Add(dr);
            }

            return dt;
        }

        private string taskFileName = "Task.txt";

        private bool LoadFromFile()
        {
            string content, fileName = taskFileName, block = "--Task--";
            StreamReader taskFile = null;
            try
            {
                if (!File.Exists(fileName))
                {
                    File.Create(fileName);
                    return true;
                }
                taskFile = new StreamReader(fileName, System.Text.Encoding.UTF8);
                content = taskFile.ReadToEnd();
                taskFile.Close();
            }
            catch (IOException)
            {
                if (taskFile != null)
                    taskFile.Close();
                return false;
            }

            string[] eles = content.Split(new string[] { block }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string ele in eles)
            {
                TaskEle te;
                if (Parse(ele, out te))
                {
                    taskList.Add(te);
                }
            }

            return true;
        }

        private bool Parse(string content, out TaskEle ele)
        {
            ele = new TaskEle();
            string[] lines = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (string line in lines)
            {
                int i = line.IndexOf('=');
                if (i > 0)
                {
                    string l = line.Substring(0, i).Trim(), r;
                    if (line.Length - i > 1)
                    {
                        r = line.Substring(i + 1, line.Length - i - 1);
                    }
                    else
                    {
                        r = "";
                    }
                   if (!dic.Keys.Contains(l))
                       dic.Add(l, r);
                }
            }
            string outStr;
            if (dic.TryGetValue("Type", out outStr))
            {
                switch (outStr.ToLower())
                {
                    case "webtask":
                        ele.Type = TipsType.HTML;
                        break;

                    case "tipstask":
                        ele.Type = TipsType.TEXT;
                        break;
                    case "exetask":
                        ele.Type = TipsType.EXE;
                        break;
                    default:
                        return false;
                }
            }
            else
                return false;

            if (dic.TryGetValue("TimeType", out outStr))
            {
                switch (outStr.ToLower())
                {
                    case "everyday":
                        ele.TimeType = TimeType.EVERYDAY;
                        break;
                    case "everyweek":
                        ele.TimeType = TimeType.EVERYWEEK;
                        break;
                    case "everymonth":
                        ele.TimeType = TimeType.EVERYMONTH;
                        break;
                    case "sometimes":
                        ele.TimeType = TimeType.SOMETIMES;
                        break;
                    default:
                        return false;
                }
            }
            else
                return false;


            if (dic.TryGetValue("Times", out outStr))
            {
                string [] times = outStr.Split(new char[]{ '|' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string time in times)
                {
                    ele.TimeList.Add(time);
                }
            }
            else
                return false;

            if (dic.TryGetValue("Url", out outStr))
            {
                ele.Url = outStr;
            }
            else
                return false;

             if (dic.TryGetValue("RegBegin", out outStr))
            {
                ele.RegBegin = outStr;
            }
            else
                return false;


             if (dic.TryGetValue("RegEnd", out outStr))
            {
                ele.RegEnd = outStr;
            }
            else
                return false;

             if (dic.TryGetValue("Tips", out outStr))
            {
                ele.Tips = outStr;
            }
            else
                return false;

             if (dic.TryGetValue("Title", out outStr))
             {
                 ele.Title = outStr;
             }
             else
                 return false;

             if (dic.TryGetValue("Encoding", out outStr))
             {
                 ele.Encoding = outStr;
             }
             else
                 return false;

             if (dic.TryGetValue("Method", out outStr))
             {
                 ele.Method = outStr;
             }
             else
                 return false;

             if (dic.TryGetValue("Data", out outStr))
             {
                 ele.Data = outStr;
             }
             else
                 return false;

            return true;
        }

        private bool getTime(out TimeType tType, out string tStr)
        {
            DateTime now = DateTime.Now;
            tType = TimeType.EVERYDAY;
            tStr = "";
            DateTime t;
            try
            {
                switch (cbTimeType.SelectedIndex)
                {
                    case 0:
                        tStr = tbHour.Text + ":" + tbMinute.Text + ":" + tbSecond.Text;
                        tType = TimeType.EVERYDAY;
                        t = DateTime.Parse(string.Format("{0}-{1}-{2} {3}:{4}:{5}", now.Year, now.Month, now.Day, tbHour.Text, tbMinute.Text, tbSecond.Text));
                        break;
                    case 1:
                        tStr = cbWeek.Text + " " + tbHour.Text + ":" + tbMinute.Text + ":" + tbSecond.Text;
                        tType = TimeType.EVERYWEEK;
                        t = DateTime.Parse(string.Format("{0}-{1}-{2} {3}:{4}:{5}", now.Year, now.Month, now.Day, tbHour.Text, tbMinute.Text, tbSecond.Text));
                        break;
                    case 2:
                        tStr = tbDay.Text + " " + tbHour.Text + ":" + tbMinute.Text + ":" + tbSecond.Text;
                        tType = TimeType.EVERYMONTH;
                        t = DateTime.Parse(string.Format("{0}-{1}-{2} {3}:{4}:{5}", now.Year, now.Month, tbDay.Text, tbHour.Text, tbMinute.Text, tbSecond.Text));
                        break;
                    case 3:
                        tType = TimeType.SOMETIMES;
                        tStr = tbYear.Text + "-" + tbMonth.Text + "-" + tbDay.Text + " " + tbHour.Text + ":" + tbMinute.Text + ":" + tbSecond.Text;
                        t = DateTime.Parse(string.Format("{0}-{1}-{2} {3}:{4}:{5}", tbYear.Text, tbMonth.Text, tbDay.Text, tbHour.Text, tbMinute.Text, tbSecond.Text));
                        break;
                }
            }
            catch (Exception ex)
            {                
                return false;
            }
            return true;
        }

        private void btnAddTime_Click(object sender, EventArgs e)
        {
            TaskEle te;
            bool ret = view(false, out te, true);
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch (cbType.SelectedIndex)
            {
                case 1:
                    tbUrl.Enabled = false;
                    tbRegBegin.Enabled = false;
                    tbRegEnd.Enabled = false;
                    tbEncoding.Enabled = false;
                    cbMethod.Enabled = false;
                    tbData.Enabled = false;
                    tbTips.Enabled = true;

                    tbUrl.Text = "";
                    tbRegBegin.Text = "";
                    tbRegEnd.Text = "";
                    tbEncoding.Text = "";
                    break;
                case 0:
                    tbUrl.Enabled = true;
                    tbRegBegin.Enabled = true;
                    tbRegEnd.Enabled = true;
                    tbEncoding.Enabled = true;
                    tbTips.Enabled = false;
                    cbMethod.Enabled = true;
                    tbData.Enabled = true;

                    tbTips.Text = "";
                    break;
                case 2:
                    tbUrl.Enabled = true;
                    tbRegBegin.Enabled = false;
                    tbRegEnd.Enabled = false;
                    tbEncoding.Enabled = false;
                    cbMethod.Enabled = false;
                    tbData.Enabled = false;
                    tbTips.Enabled = true;

                    tbRegBegin.Text = "";
                    tbRegEnd.Text = "";
                    tbEncoding.Text = "";
                    break;
            }
        }

        private void cbTimeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaskEle te;
            bool ret = view(true, out te, false);
            switch (cbTimeType.SelectedIndex)
            {
                case 0:
                    tbYear.Enabled = false;
                    tbMonth.Enabled = false;
                    tbDay.Enabled = false;
                    cbWeek.Enabled = false;
                    tbHour.Enabled = true;
                    tbMinute.Enabled = true;
                    tbSecond.Enabled = true;
                    break;
                case 1:
                    tbYear.Enabled = false;
                    tbMonth.Enabled = false;
                    tbDay.Enabled = false;
                    cbWeek.Enabled = true;
                    tbHour.Enabled = true;
                    tbMinute.Enabled = true;
                    tbSecond.Enabled = true;
                    break;
                case 2:
                    tbYear.Enabled = false;
                    tbMonth.Enabled = false;
                    tbDay.Enabled = true;
                    cbWeek.Enabled = false;
                    tbHour.Enabled = true;
                    tbMinute.Enabled = true;
                    tbSecond.Enabled = true;
                    break;
                case 3:
                    tbYear.Enabled = true;
                    tbMonth.Enabled = true;
                    tbDay.Enabled = true;
                    cbWeek.Enabled = false;
                    tbHour.Enabled = true;
                    tbMinute.Enabled = true;
                    tbSecond.Enabled = true;
                    break;
            }
        }


        private void delRows()
        {
            DataGridViewSelectedRowCollection col = dgTasks.SelectedRows;

            if (col == null || col.Count == 0)
            {
                MessageBox.Show("Please select the row you want to del!", "玲娜贝儿提示你");
                return;
            }
            DataGridViewRow row = col[0];

            TaskEle ele = RowToEle(row);

            if (ele == null)
            {
                MessageBox.Show("Row format error!", "玲娜贝儿提示你");
                return;
            }

            DialogResult dRet = MessageBox.Show(String.Format("是否删除任务“{0}”？", ele.Title), "玲娜贝儿提示你", MessageBoxButtons.OKCancel);
            if (dRet == DialogResult.Cancel)
                return;

            if (!DeleteTask(ele))
            {
                MessageBox.Show("Delete fail!", "玲娜贝儿提示你");
                return;
            }

            UpdateTable();
            DumpToFile();
            MessageBox.Show("Delete successful!", "玲娜贝儿提示你");
        }

        private void btnDelTask_Click(object sender, EventArgs e)
        {            
            delRows();
        }

        private void UpdateTable()
        {          
            List<TaskEle> doneList = new List<TaskEle>();
            int lastTrue = -1, lastFalse = -1;
            for (int i = 0; i < taskList.Count(); i++)
            {
                if (taskList[i].BDone == true)
                {
                    lastTrue = i;
                    doneList.Add(taskList[i]);
                }
                else
                    lastFalse = i;
            }

            if (lastFalse > lastTrue)
            {
                List<TaskEle> tmpList;
                tmpList = taskList.Except(doneList).ToList();
                tmpList.AddRange(doneList);

                taskList.Clear();
                taskList = tmpList;
            }
            DataTable dt = ToTable();
            dgTasks.DataSource = dt;
            //对已经完成的任务，将文字设置为灰色
            foreach (DataGridViewRow row in dgTasks.Rows)
            {
                TaskEle ele = RowToEle(row);
                foreach(TaskEle tmp in taskList)
                {
                    if (ele.ToString() == tmp.ToString() && tmp.BDone)
                    {
                        row.DefaultCellStyle.ForeColor = System.Drawing.Color.Gray;
                        break;
                    }
                }
            }
        }

        private TaskEle RowToEle(DataGridViewRow row)
        {
            DataGridViewCellCollection cells = row.Cells;
            if (cells == null || cells.Count != 11)
                return null;

            StringBuilder sb = new StringBuilder("");
            sb.Append("Title=" + cells[0].Value.ToString() + "\r\n");
            sb.Append("Type=" + cells[1].Value.ToString() + "\r\n");
            sb.Append("TimeType=" + cells[2].Value.ToString() + "\r\n");
            sb.Append("Times=" + cells[3].Value.ToString() + "\r\n");
            sb.Append("Tips=" + cells[4].Value.ToString() + "\r\n");
            sb.Append("Url=" + cells[5].Value.ToString() + "\r\n");
            sb.Append("Encoding=" + cells[6].Value.ToString() + "\r\n");
            sb.Append("Method=" + cells[7].Value.ToString() + "\r\n");
            sb.Append("Data=" + cells[8].Value.ToString() + "\r\n");
            sb.Append("RegBegin=" + cells[9].Value.ToString() + "\r\n");
            sb.Append("RegEnd=" + cells[10].Value.ToString() + "\r\n");

            TaskEle ele = null;
            Parse(sb.ToString(), out ele);
            return ele;
        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {
            if (!bEditMode)
            {
                MessageBox.Show("Please double click the row you want to edit!", "玲娜贝儿提示你");
                return;
            }

            DataGridViewSelectedRowCollection col = dgTasks.SelectedRows;

            if (col == null || col.Count == 0)
            {
                return;
            }
            DataGridViewRow row = col[0];

            TaskEle oEle = RowToEle(row);

            if (oEle == null)
            {
                MessageBox.Show("Row format error!", "玲娜贝儿提示你");
                return;
            }

            TaskEle te;
            bool ret = view(false, out te, true);
            if (!ret)
            {
                MessageBox.Show("Format error.", "玲娜贝儿提示你");
                return;
            }

            DialogResult dRet = MessageBox.Show(String.Format("是否更新任务“{0}”？", te.Title), "玲娜贝儿提示你", MessageBoxButtons.OKCancel);
            if (dRet == DialogResult.Cancel)
                return;

            if (!EditTask(oEle, te))
            {
                MessageBox.Show("Edit task error!", "玲娜贝儿提示你");
                return;
            }
            clear();

            UpdateTable();
            bEditMode = false;

            DumpToFile();
            SelectOne(te);

            MessageBox.Show("Edit successful!", "玲娜贝儿提示你");
        }

        private bool bEditMode = false;

        private void toEditMode()
        {
            DataGridViewSelectedRowCollection col = dgTasks.SelectedRows;

            if (col == null || col.Count == 0)
            {
                return;
            }
            DataGridViewRow row = col[0];

            TaskEle ele = RowToEle(row);

            if (ele == null)
            {
                MessageBox.Show("Row format error!", "玲娜贝儿提示你");
                return;
            }


            tbTitle.Text = ele.Title;
            switch (ele.Type)
            {
                case TipsType.TEXT:
                    cbType.SelectedIndex = 1;
                    break;
                case TipsType.HTML:
                    cbType.SelectedIndex = 0;
                    break;
                case TipsType.EXE:
                    cbType.SelectedIndex = 2;
                    break;
            }
            Regex rg;
            Match mt;
            switch (ele.TimeType)
            {
                case TimeType.EVERYDAY:
                    cbTimeType.SelectedIndex = 0;
                    rg = new Regex(@"(\d+):(\d+):(\d+)");
                    mt = rg.Match(ele.TimeList[0]);
                    if (mt.Success)
                    {
                        tbHour.Text = mt.Groups[1].Value;
                        tbMinute.Text = mt.Groups[2].Value;
                        tbSecond.Text = mt.Groups[3].Value;
                    }
                    break;
                case TimeType.EVERYWEEK:
                    cbTimeType.SelectedIndex = 1;
                    rg = new Regex(@"([a-zA-Z]+)\s+(\d+):(\d+):(\d+)");
                    mt = rg.Match(ele.TimeList[0]);
                    if (mt.Success)
                    {
                        string ws = mt.Groups[1].Value;
                        int wi = Week2Int(ws);
                        if (wi >= 0)
                        {
                            cbWeek.SelectedIndex = wi;
                        }
                        tbHour.Text = mt.Groups[2].Value;
                        tbMinute.Text = mt.Groups[3].Value;
                        tbSecond.Text = mt.Groups[4].Value;
                    }
                    break;
                case TimeType.EVERYMONTH:
                    cbTimeType.SelectedIndex = 2;
                    rg = new Regex(@"(\d+)\s+(\d+):(\d+):(\d+)");
                    mt = rg.Match(ele.TimeList[0]);
                    if (mt.Success)
                    {
                        tbDay.Text = mt.Groups[1].Value;
                        tbHour.Text = mt.Groups[2].Value;
                        tbMinute.Text = mt.Groups[3].Value;
                        tbSecond.Text = mt.Groups[4].Value;
                    }
                    break;
                case TimeType.SOMETIMES:
                    cbTimeType.SelectedIndex = 3;
                    rg = new Regex(@"(\d+)\-(\d+)\-(\d+)\s+(\d+):(\d+):(\d+)");
                    mt = rg.Match(ele.TimeList[0]);
                    if (mt.Success)
                    {
                        tbYear.Text = mt.Groups[1].Value;
                        tbMonth.Text = mt.Groups[2].Value;
                        tbDay.Text = mt.Groups[3].Value;
                        tbHour.Text = mt.Groups[4].Value;
                        tbMinute.Text = mt.Groups[5].Value;
                        tbSecond.Text = mt.Groups[6].Value;
                    }
                    break;
            }

            switch (ele.Method)
            {
                case "GET":
                    cbMethod.SelectedIndex = 0;
                    break;
                case "POST":
                    cbMethod.SelectedIndex = 1;
                    break;
                default:
                    cbMethod.SelectedIndex = 0;
                    break;
            }

            tbTips.Text = ele.Tips;
            tbUrl.Text = ele.Url;
            tbEncoding.Text = ele.Encoding;
            tbRegBegin.Text = ele.RegBegin;
            tbRegEnd.Text = ele.RegEnd;
            tbData.Text = ele.Data;

            bEditMode = true;
            tbPreview.Text = ele.ToString();
        }

        private void dgTasks_DoubleClick(object sender, EventArgs e)
        {
            toEditMode();
        }

        private bool DumpToFile()
        {
            StreamWriter sw = new StreamWriter(taskFileName, false, Encoding.UTF8);
            string sb = "";
            foreach (TaskEle ele in taskList)
            {
                sb += ele.ToString();
            }
            try
            {
                sw.Write(sb);
                sw.Close();
            }
            catch (IOException)
            {
                sw.Close();
                MessageBox.Show("Dump to file error!", "玲娜贝儿提示你");
                return false;
            }

            return true;
        }

        Thread thTask = null;

        private int Week2Int(DayOfWeek dw)
        {
            int wi = (int)dw;
            wi -= 1;
            if (wi == -1)
            {
                wi = 6;
            }
            return wi;
        }

        private int Week2Int(string str)
        {
            int wi = -1;
            str = str.Trim().ToLower();
            switch (str)
            {
                case "mon":
                    wi = 0;
                    break;
                case "tues":
                    wi = 1;
                    break;
                case "wed":
                    wi = 2;
                    break;
                case "thur":
                    wi = 3;
                    break;
                case "fri":
                    wi = 4;
                    break;
                case "sat":
                    wi = 5;
                    break;
                case "sun":
                    wi = 6;
                    break;
            }
            return wi;
        }

        private void Working()
        {
            while (true)
            {
                DateTime now = DateTime.Now;
                int curDay = now.Day;
                int curWeek = Week2Int(now.DayOfWeek);
                int tc = taskList.Count;
                bool update = false;
                if (now.Second == 0)
                {
                    Log("Checking task list.");
                }
                
                for (int i = 0; i < tc; i ++)
                {
                    TaskEle ele = taskList[i];

                    if (ele.BDone)
                    {
                        continue;
                    }

                    List<DateTime> tList = new List<DateTime>();

                    switch (ele.TimeType)
                    {
                        case TimeType.EVERYDAY:
                            foreach (string ts in ele.TimeList)
                            {
                                Regex rg = new Regex(@"(\d+):(\d+):(\d+)");
                                Match mt = rg.Match(ts.Trim());
                                if (mt.Success)
                                {
                                    int hi = int.Parse(mt.Groups[1].Value);
                                    int mi = int.Parse(mt.Groups[2].Value);
                                    int si = int.Parse(mt.Groups[3].Value);
                                    try
                                    {
                                        DateTime t = new DateTime(now.Year, now.Month, now.Day, hi, mi, si);
                                        tList.Add(t);
                                    }
                                    catch (Exception)
                                    {
                                        continue;
                                    }
                                }
                            }
                            break;
                        case TimeType.EVERYWEEK:
                            foreach (string ts in ele.TimeList)
                            {
                                Regex rg = new Regex(@"([a-zA-Z]+)\s+(\d+):(\d+):(\d+)");
                                Match mt = rg.Match(ts.Trim());
                                if (mt.Success)
                                {
                                    string ws = mt.Groups[1].Value;
                                    int wi = Week2Int(ws);
                                    if (wi < 0 || wi != curWeek)
                                    {
                                        continue;
                                    }
                                    int hi = int.Parse(mt.Groups[2].Value);
                                    int mi = int.Parse(mt.Groups[3].Value);
                                    int si = int.Parse(mt.Groups[4].Value);
                                    try
                                    {
                                        DateTime t = new DateTime(now.Year, now.Month, now.Day, hi, mi, si);
                                        tList.Add(t);
                                    }
                                    catch (Exception)
                                    {
                                        continue;
                                    }
                                }
                            }
                            break;
                        case TimeType.EVERYMONTH:
                            foreach (string ts in ele.TimeList)
                            {
                                Regex rg = new Regex(@"(\d+)\s+(\d+):(\d+):(\d+)");
                                Match mt = rg.Match(ts.Trim());
                                if (mt.Success)
                                {
                                    int di = int.Parse(mt.Groups[1].Value);
                                    if (di != curDay)
                                        continue;
                                    int hi = int.Parse(mt.Groups[2].Value);
                                    int mi = int.Parse(mt.Groups[3].Value);
                                    int si = int.Parse(mt.Groups[4].Value);
                                    try
                                    {
                                        DateTime t = new DateTime(now.Year, now.Month, now.Day, hi, mi, si);
                                        tList.Add(t);
                                    }
                                    catch (Exception)
                                    {
                                        continue;
                                    }
                                }
                            }
                            break;
                        case TimeType.SOMETIMES:
                            foreach (string ts in ele.TimeList)
                            {
                                Regex rg = new Regex(@"(\d+)\-(\d+)\-(\d+)\s+(\d+):(\d+):(\d+)");
                                Match mt = rg.Match(ts.Trim());
                                if (mt.Success)
                                {
                                    int yi = int.Parse(mt.Groups[1].Value);
                                    int ni = int.Parse(mt.Groups[2].Value);
                                    int di = int.Parse(mt.Groups[3].Value);
                                    int hi = int.Parse(mt.Groups[4].Value);
                                    int mi = int.Parse(mt.Groups[5].Value);
                                    int si = int.Parse(mt.Groups[6].Value);
                                    try
                                    {
                                        DateTime t = new DateTime(yi, ni, di, hi, mi, si);
                                        tList.Add(t);
                                    }
                                    catch (Exception)
                                    {
                                        continue;
                                    }
                                }
                            }
                            break;
                        default:
                            continue;
                    }
                    

                    bool bw = false;
                    int dc = 0;
                    foreach (DateTime dt in tList)
                    {
                        TimeSpan ts = now.Subtract(dt);
                        
                        if (ts.TotalMilliseconds >= 0 && ts.TotalMilliseconds < 1000)
                        {
                            //Console.WriteLine(dt.ToString() + "#" + now.ToString() + "#" + ts.ToString());
                            bw = true;                            
                        }

                        if (dt < now && ele.TimeType == TimeType.SOMETIMES)
                            dc += 1;
                    }
                    
                    if (dc == ele.TimeList.Count)
                    {
                        ele.BDone = true;
                        update = true;
                    }

                    if (bw)
                    {
                        Thread th = new Thread(new ParameterizedThreadStart(DoTask));
                        th.SetApartmentState(ApartmentState.STA);
                        th.IsBackground = true;
                        th.Start(ele);
                    }
                }

                if (update)
                    UpdateTable();
                
                Thread.Sleep(1000);                
            }
        }


        private void DoTask(object obj)
        {
            TaskEle ele = obj as TaskEle;
            if (ele == null)
                return;
            Log(ele.Title);
            Form3 f3 = new Form3();
            string content = "";
            switch (ele.Type)
            {
                case TipsType.TEXT:
                    content = ele.Tips;
                    break;

                case TipsType.EXE:
                    System.Diagnostics.ProcessStartInfo pInfo = new System.Diagnostics.ProcessStartInfo();
                    pInfo.FileName = ele.Url;
                    int ii = ele.Url.LastIndexOf('\\');
                    if (ii > 0)
                        pInfo.WorkingDirectory = ele.Url.Substring(0, ii);

                    if (!String.IsNullOrEmpty(ele.Tips))
                        pInfo.Arguments = ele.Tips;

                    System.Diagnostics.Process proc;
                    try
                    {
                        proc = System.Diagnostics.Process.Start(pInfo);
                        Log("Start : " + ele.Url);
                    }
                    catch (Exception e)
                    {
                        Log("Start Fail: " + ele.Url);
                        return;
                    }

                    break;

                case TipsType.HTML:
                   
                    if (GetUrl(ele, out content))
                    {
                        if (bDebug)
                            Log("\n--------------HTML Source----------------\n\n" + content);
                        bool bf = true;
                        if (!string.IsNullOrEmpty(ele.RegBegin) && !string.IsNullOrEmpty(ele.RegEnd))
                        {
                            int li = 0, ri = 0;
                            Regex rg = new Regex(ele.RegBegin);
                            Match mt = rg.Match(content);

                            
                            if (mt.Success)
                            {
                                li = mt.Index;

                                rg = new Regex(ele.RegEnd);
                                mt = rg.Match(content, li);

                                if (mt.Success)
                                {
                                    ri = mt.Index;
                                    //content = content.Substring(li, ri + ele.RegEnd.Length - li);
                                    content = content.Substring(li, ri + mt.Value.Length - li);

                                    if (bDebug)
                                        Log("\n--------------HTML Match----------------\n\n" + content);

                                }
                                else
                                    bf = false;
                            }
                            else
                                bf = false;
                        }

                        if (!bf)
                        {
                            content = "Region not find!<br>" + ele.ToString();
                            Log("Region not find!\r\n" + ele.ToString());
                        }
                    }
                    else
                    {
                        content += "<br>" + ele.ToString();
                    }
                        //if (GetUrl(ele.Url, out content))
                        //{
                        //    int li = 0, ri = 0;
                        //    li = content.IndexOf(ele.RegBegin);

                        //    bool bf = true;
                        //    if (li > 0)
                        //    {
                        //        ri = content.IndexOf(ele.RegEnd, li);

                        //        if (ri > 0)
                        //        {
                        //            content = content.Substring(li, ri + ele.RegEnd.Length - li);
                        //        }
                        //        else
                        //            bf = false;
                        //    }
                        //    else
                        //        bf = false;

                        //    if (!bf)
                        //        content = "Region not find!<br>" + ele.ToString();
                        //}
                        //else
                        //{
                        //    content += "<br>" + ele.ToString();
                        //}
                    
                    break;
            }

            if (ele.Type != TipsType.EXE)
            {
                f3.UpShow(ele, content);
                Application.Run(f3);
            }
                


            //http://zhidao.baidu.com/question/206761887.html
        }


        private bool GetUrl(TaskEle ele, out string content)
        {

            HttpWebRequest myReq = null;
            HttpWebResponse httpWResp = null;
            Stream myStream = null;
            StreamReader sr = null;
            content = "";
            bool bSuc = false;

            int cTry = 0, maxTry = 6, interval = 300000;

            while (cTry < maxTry)
            {
                try
                {
                    if (ele.Url.ToLower().StartsWith("https"))
                    {
                        //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
                        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                        //https://blog.csdn.net/fei0700/article/details/108831594
                    }
                    myReq = (HttpWebRequest)WebRequest.Create(ele.Url);

                    myReq.AllowAutoRedirect = true;
                    myReq.Method = ele.Method;
                    myReq.Accept = "text/html, application/xml;q=0.9, application/xhtml+xml, image/png, image/webp, image/jpeg, image/gif, image/x-xbitmap, */*;q=0.1";
                    myReq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/98.0.4758.102 Safari/537.36";
                    myReq.ContentType = "application/x-www-form-urlencoded";
                    

                    if (ele.Method.ToUpper() == "POST")
                    {
                        ASCIIEncoding dateEnc = new ASCIIEncoding();
                        byte[] postData = dateEnc.GetBytes(ele.Data);
                        myReq.ContentLength = postData.Length;
                        Stream reqStream = myReq.GetRequestStream();
                        reqStream.Write(postData, 0, postData.Length);
                        reqStream.Close();
                    }

                    httpWResp = (HttpWebResponse)myReq.GetResponse();
                    myStream = httpWResp.GetResponseStream();

                    if (httpWResp.ContentEncoding.ToLower().Contains("gzip"))
                    {
                        myStream = new GZipStream(myStream, CompressionMode.Decompress);
                    }
                    Encoding encoding = Encoding.GetEncoding(ele.Encoding);
                    sr = new StreamReader(myStream, encoding);
                    content = sr.ReadToEnd();

                    //及时关闭，避免出错后下一个请求阻塞
                    if (httpWResp != null)
                        httpWResp.Close();
                    if (myReq != null)
                        myReq.Abort();
                    if (myStream != null)
                        myStream.Close();
                    if (sr != null)
                        sr.Close();
                    bSuc = true;

                    break;
                }
                catch (Exception exp)
                {
                    Log("Retrying " + ele.Url);
                    content = exp.Message;
                    cTry++;
                    //及时关闭，避免出错后下一个请求阻塞
                    if (httpWResp != null)
                        httpWResp.Close();
                    if (myReq != null)
                        myReq.Abort();
                    if (myStream != null)
                        myStream.Close();
                    if (sr != null)
                        sr.Close();
                }

                Thread.Sleep(interval);
            }

            return bSuc;
        }

        private void Log(string txt)
        {
            if (bDebug)
            {
                try
                {
                    string info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + txt + "\r\n";
                    tbLog.AppendText(info);
                    StreamWriter sw = new StreamWriter("log.txt", true, Encoding.UTF8);
                    sw.Write(info);
                    sw.Close();
                }
                catch (IOException)
                {
                    return;
                }
            }
                

        }

        private bool view(bool bClear, out TaskEle te, bool bCombine)
        {
            te = new TaskEle();

            TaskEle oTe = new TaskEle();
            if (!string.IsNullOrEmpty(tbPreview.Text.Trim()) && bCombine)
            {
                bCombine = Parse(tbPreview.Text, out te);                
            }
                


            te.Title = tbTitle.Text;
            te.Tips = tbTips.Text;
            te.Url = tbUrl.Text;
            te.Encoding = tbEncoding.Text;
            te.RegBegin = tbRegBegin.Text;
            te.RegEnd = tbRegEnd.Text;
            te.Method = cbMethod.Text;
            te.Data = tbData.Text;
            switch (cbType.SelectedIndex)
            {
                case 0:
                    te.Type = TipsType.HTML;
                    te.Tips = "";

                    break;
                case 1:
                    te.Type = TipsType.TEXT;
                    te.Url = "";
                    te.Encoding = "";
                    te.RegBegin = "";
                    te.RegEnd = "";
                    te.Method = "";
                    te.Data = "";
                    break;
                case 2:
                    te.Type = TipsType.EXE;
                    te.Encoding = "";
                    te.RegBegin = "";
                    te.RegEnd = "";
                    te.Method = "";
                    te.Data = "";
                    break;
            }
            if (bClear)
                te.TimeList.Clear();
            else
            {
                string tStr = "";
                TimeType tType = TimeType.EVERYDAY;
                bool ret = getTime(out tType, out tStr);
                if (ret)
                {
                    if (bCombine)
                    {
                        if (oTe.TimeType == tType)
                        {
                            foreach (string tmp in oTe.TimeList)
                                te.TimeList.Add(tmp);
                        }
                    }
                    if (!te.TimeList.Contains(tStr))
                        te.TimeList.Add(tStr);
                    te.TimeType = tType;
                }
                else
                {
                    MessageBox.Show("Time format error!", "玲娜贝儿提示你");
                    return false;
                }
            }
            
            
            tbPreview.Text = te.ToString();
            return true;
        }

        private void btnClearTime_Click(object sender, EventArgs e)
        {
            TaskEle te;
            bool ret = view(true, out te, false);
        }

        private void btnUpDown_Click(object sender, EventArgs e)
        {
            if (btnUpDown.Text.Equals("↑"))
            {
                UpDown(true);
                btnUpDown.Text = "↓";
            }
            else
            {
                UpDown(false);
                btnUpDown.Text = "↑";
            }
        }


        private void UpDown(bool bUp)
        {
            if (bUp)
            {
                this.Size = new Size(1110, 480);
            }
            else
            {
                this.Size = new Size(1110, 625);
            }
        }

        private void btnDoItNow_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection col = dgTasks.SelectedRows;

            if (col == null || col.Count == 0)
            {
                MessageBox.Show("Please select the task you want to do!", "玲娜贝儿提示你");
                return;
            }
            DataGridViewRow row = col[0];

            TaskEle ele = RowToEle(row);

            Thread th = new Thread(new ParameterizedThreadStart(DoItNow));
            th.SetApartmentState(ApartmentState.STA);
            th.IsBackground = true;
            th.Start(ele);

            

            
        }

        private void DoItNow(object obj)
        {
            DoTask(obj);
        }

        private void cbDebug_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDebug.Checked)
                bDebug = true;
            else
                bDebug = false;
        }

        private bool bDebug = true;

        private void tsEdit_Click(object sender, EventArgs e)
        {
            toEditMode();
        }

        private void tsDel_Click(object sender, EventArgs e)
        {
            delRows();
        }

        private void dgTasks_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (dgTasks.Rows[e.RowIndex].Selected == false)
                {
                    dgTasks.ClearSelection();
                    dgTasks.Rows[e.RowIndex].Selected = true;
                }
                if (e.RowIndex >= 0)
                {
                    contextMenuStrip2.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }
    }
}