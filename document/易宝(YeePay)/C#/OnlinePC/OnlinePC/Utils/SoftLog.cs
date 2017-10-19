using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

 
    public static class SiteLog
    {
        private static Log _log = new Log(HttpContext.Current.Server.MapPath("~/_______SiteLog/"));

        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="vlog">日志内容</param>
        /// <param name="dirName">区分目录名,如果是多级,可用dir1/dir2来表明</param>
        /// <param name="useMonthDir">日志存放在当前月的目录里,如2013_01</param>
        /// <param name="useHourFileName">日志存放在当前小时段的目录里</param>
        public static void LogStr(string vlog, string dirName, bool useMonthDir, bool useHourFileName)
        {
            _log.LogStr(vlog, dirName, false, useMonthDir, useHourFileName);
        }
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="vlog">日志内容</param>
        /// <param name="dirName">目录名称</param>
        public static void LogStr(string vlog, string dirName)
        {
            LogStr(vlog, dirName, true, false);
        }
    }
    public static class SoftLog
    {
        private static Log _log = new Log(@"c:\log\YeePay\OnlinePC");

        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="vlog">日志内容</param>
        /// <param name="dirName">区分目录名,如果是多级,可用dir1/dir2来表明</param>
        /// <param name="useMonthDir">日志存放在当前月的目录里,如2013_01</param>
        /// <param name="useHourFileName">日志存放在当前小时段的目录里</param>
        public static void LogStr(string vlog, string dirName, bool useMonthDir, bool useHourFileName)
        {
            _log.LogStr(vlog, dirName, false, useMonthDir, useHourFileName);
        }
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="vlog">日志内容</param>
        /// <param name="dirName">目录名称</param>
        public static void LogStr(string vlog, string dirName)
        {
            LogStr(vlog, dirName, true, false);
        }
    }
    public class Log
    {

        private object lockObj = new object();

        private string _rootDir;
        public Log(string rootDir)
        {
            _rootDir = new DirectoryInfo(rootDir).FullName + "\\";
        }
        private string GetDirName(string name)
        {
            return name.Replace(".", "_").Replace("/", "\\");
        }
        private string GetDateDir(bool useHourFileName)
        {
            return DateTime.Now.ToString("yyyy_MM_dd" + (useHourFileName ? "_HH" : ""));
        }
        public void LogStr(string vlog, string dirName, bool useIpDir, bool useMonthDir, bool useHourFileName)
        {
            try
            {
                DateTime now = DateTime.Now;

                string ip = HttpContext.Current != null ? HttpContext.Current.Request.UserHostAddress : string.Empty;
                if (string.IsNullOrEmpty(ip)) ip = string.Empty;
                string ipDir = ip.Replace(":", "_").Replace(".", "_");
                string fileName = _rootDir
                    + (string.IsNullOrEmpty(dirName) ? "" : "\\" + GetDirName(dirName))
                    + (useIpDir ? "\\" + ipDir : "")
                    + (useMonthDir ? "\\" + now.Year + "_" + now.Month.ToString("00") : "")
                    + "\\" + GetDateDir(useHourFileName) + ".txt";
                lock (lockObj)
                {
                    WriteFile(fileName, "[" + (useIpDir ? "" : (!string.IsNullOrEmpty(ip) ? "IP:" + ip + "," : "")) + "Date:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff") + "]" + vlog + "\r\n", true, System.Text.Encoding.Default);
                }
            }
            catch { }
        }

        private bool WriteFile(string filePath, string content, bool append, Encoding charset)
        {
            string folder = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            try
            {
                using (FileStream fs = new FileStream(filePath, (append ? FileMode.Append : FileMode.Create), FileAccess.Write, FileShare.ReadWrite))
                {
                    var data = charset.GetBytes(content + "\r\n");
                    fs.Write(data, 0, data.Length);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
 