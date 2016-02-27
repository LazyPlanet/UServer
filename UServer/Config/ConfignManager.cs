using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace GameServer.Config
{
    public class ConfigManager
    {
        // Log Server
        public static String m_LogServerIp = "127.0.0.1";
        public static int m_LogServerPort = 0;
        public static String m_LogPath = "F:\\Project\\Cpp\\GameServer\\GameServer";

        // Logic Server
        public static String m_LogicServerIp = "127.0.0.1";
        public static int m_LogicServerPort = 0;
        public static String m_LogicPath = "F:\\Project\\Cpp\\GameServer\\GameServer";
        
        // DataBase 
        public static String m_DbPath = "";

        /**
        * Constructor
        * */
        public ConfigManager()
        {

        }
        /**
        * Load game resources 
        * */
        public static bool Load()
        {
            ConfigManager.m_LogServerIp = ConfigurationManager.AppSettings["LogServerAddress"];
            bool ret = int.TryParse(ConfigurationManager.AppSettings["LogServerPort"], out ConfigManager.m_LogServerPort);
            if (!ret) return false;
            
            ConfigManager.m_LogicServerIp = ConfigurationManager.AppSettings["LogicServerAddress"];
            ret = int.TryParse(ConfigurationManager.AppSettings["LogicServerPort"], out ConfigManager.m_LogicServerPort);
            if (!ret) return false;
            
            return true;
        }
    }
}
