using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using GameServer.Config;

namespace GameServer.Log
{
    class LogWriter
    {
        // Member
        private static object LockWriter = new object();

        public enum LogType
        {
            INFO,
            CHAT,
            CASH,
            TRACE,
            FORMAT,
            ACTION,
            WARNING,
            ERROR,
        }
        /**
        * Writer log to files.
        * */
        public static void WriteTo(LogType type, String content)
        {
            String dir = System.DateTime.Now.ToString("yyyy-MM-dd");

            lock (LockWriter)
            {
                try
                {
                    StringBuilder fileName = new StringBuilder();
                    fileName.Append(type.ToString().ToLower()).Append(".log");
                    StringBuilder dirName = new StringBuilder(ConfigManager.m_LogPath);
                    dirName.Append("\\").Append(dir).Append("\\");
                    String fullName = dirName.ToString() + fileName.ToString();
                    FileInfo fi = new FileInfo(fullName);
                    var di = fi.Directory;
                    if (!di.Exists) di.Create();

                    using (FileStream fs = File.Open(fullName, FileMode.OpenOrCreate | FileMode.Append))
                    {
                        StringBuilder contents = new StringBuilder();
                        contents.Append(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        contents.Append(" : ").Append(content).Append("\r\n");
                        Byte[] info = new UTF8Encoding(true).GetBytes(contents.ToString());
                        fs.Write(info, 0, info.Length);
                    }
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine("Write log error : " + ex.Message);
                }
            }
        }
        // End of class LogWriter
    }
    // End of namespace GameServer.Log
}
