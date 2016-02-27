using System;
using ServiceStack.Redis;

namespace GameServer.DataBase
{
    public abstract class RedisOperatorBase : IDisposable
    {
        protected IRedisClient Redis { get; private set; }
        private bool _disposed = false;

        protected RedisOperatorBase()
        {
            Redis = RedisManager.GetClient();
        }        
        
		protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    Redis.Dispose();
                    Redis = null;
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            Redis.Save();
        }

		public void SaveAsync()
        {
            Redis.SaveAsync();
        }
    }
}

