using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ServiceStack;
using ServiceStack.Redis;

namespace GameServer.DataBase
{
    class DataBaseManager
    {
        RedisClient client = new RedisClient("127.0.0.1", 6379);  
        public DataBaseManager()
        {
               
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //存储用户名和密码
            client.Set<String>("username", "524300045@qq.com");
            client.Set<int>("pwd", 123456);
            String username = client.Get<String>("username");
            int pwd = client.Get<int>("pwd");

            client.Set<decimal>("price", 12.10M);
            decimal price = client.Get<decimal>("price");

        }
    }
}
