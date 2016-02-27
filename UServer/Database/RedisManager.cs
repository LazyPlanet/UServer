using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack;
using ServiceStack.Redis;

namespace GameServer.DataBase
{
    public class RedisManager
    {
        // Configuration
        private static readonly RedisConfigInfo RedisConfigInfo = RedisConfigInfo.GetConfig();

        private static PooledRedisClientManager _prcm;

        /**
        * Constructor
        * */
        static RedisManager()
        {
            CreateManager();
        }
        
        /**
        * Create connected pool objects
        * */
        private static void CreateManager()
        {
            var writeServerList = SplitString(RedisConfigInfo.WriteServerList, ",");
            var readServerList = SplitString(RedisConfigInfo.ReadServerList, ",");

            _prcm = new PooledRedisClientManager(writeServerList,readServerList,
                        new RedisClientManagerConfig
                        {
                            MaxWritePoolSize = RedisConfigInfo.MaxWritePoolSize,
                            MaxReadPoolSize = RedisConfigInfo.MaxReadPoolSize,
                            AutoStart = RedisConfigInfo.AutoStart,
                        });
        }

        private static IEnumerable<string> SplitString(string strSource, string split)
        {
            return strSource.Split(split.ToArray());
        }

        /**
        * Client cache operator object
        * */
        public static IRedisClient GetClient()
        {
            if (_prcm == null)
            {
                CreateManager();
            }
            return _prcm.GetClient();
        }

    }
}

