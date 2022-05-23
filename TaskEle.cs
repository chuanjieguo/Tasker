using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tasker
{
    public class TaskEle
    {
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private TipsType type;

        public TipsType Type
        {
            get { return type; }
            set { type = value; }
        }

        private TimeType timeType;

        public TimeType TimeType
        {
            get { return timeType; }
            set { timeType = value; }
        }

        private List<string> timeList = new List<string>();

        public List<string> TimeList
        {
            get { return timeList; }
            set { timeList = value; }
        }

        private string tips;

        public string Tips
        {
            get { return tips; }
            set { tips = value; }
        }

        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        private string encoding;

        public string Encoding
        {
            get { return encoding; }
            set { encoding = value; }
        }

        private string method;

        public string Method
        {
            get { return method; }
            set { method = value; }
        }


        private string regBegin;

        public string RegBegin
        {
            get { return regBegin; }
            set { regBegin = value; }
        }

        private string regEnd;

        public string RegEnd
        {
            get { return regEnd; }
            set { regEnd = value; }
        }

        private bool bDone = false;

        public bool BDone
        {
            get { return bDone; }
            set { bDone = value; }
        }

        private string data;

        public string Data
        {
            get { return data; }
            set { data = value.Replace('\r', ' ').Replace('\n', ' '); }
        }



        public string GetTimeStr()
        {
            string str = "";
            if (timeList.Count > 0)
            {
                str = String.Join("|", TimeList);
            }
            return str;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("");
            sb.Append("--Task--\r\n");
            sb.Append("Title=" + title + "\r\n");
            sb.Append("Type=");
            switch (this.Type)
            {
                case TipsType.TEXT:
                    sb.Append("TipsTask\r\n");
                    break;
                case TipsType.HTML:
                    sb.Append("WebTask\r\n");
                    break;
                case TipsType.EXE:
                    sb.Append("ExeTask\r\n");
                    break;
            }

            sb.Append("TimeType=");
            switch (this.TimeType)
            {
                case TimeType.EVERYDAY:
                    sb.Append("EveryDay\r\n");
                    break;
                case TimeType.SOMETIMES:
                    sb.Append("Sometimes\r\n");
                    break;
                case TimeType.EVERYWEEK:
                    sb.Append("EveryWeek\r\n");
                    break;
                case TimeType.EVERYMONTH:
                    sb.Append("EveryMonth\r\n");
                    break;
            }

            sb.Append("Times=" + GetTimeStr() + "\r\n");
            sb.Append("Tips=" + tips + "\r\n");
            sb.Append("Url=" + url + "\r\n");
            sb.Append("Method=" + method + "\r\n");
            sb.Append("Data=" + data + "\r\n");
            sb.Append("Encoding=" + encoding + "\r\n");
            sb.Append("RegBegin=" + regBegin + "\r\n");
            sb.Append("RegEnd=" + regEnd + "\r\n");
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            TaskEle ele = obj as TaskEle;
            if (ele == null)
                return false;

            bool tmp = title == ele.title &&
                   type == ele.type &&
                   timeType == ele.timeType &&
                   tips == ele.tips &&
                   url == ele.url &&
                   encoding == ele.encoding &&
                   method == ele.method &&
                   regBegin == ele.regBegin &&
                   regEnd == ele.regEnd &&
                   data == ele.data;
            if (!tmp)
                return false;
            if (timeList.Count != ele.timeList.Count)
                return false;
            for (int i = 0; i < timeList.Count; i++)
            {
                if (timeList[i] != ele.timeList[i])
                    return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = -856837774;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(title);
            hashCode = hashCode * -1521134295 + type.GetHashCode();
            hashCode = hashCode * -1521134295 + timeType.GetHashCode();
            foreach(string tmp in timeList)
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(tmp);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(tips);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(url);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(encoding);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(method);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(regBegin);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(regEnd);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(data);
            return hashCode;
        }
    }
}
