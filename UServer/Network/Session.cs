using System;
using System.Text;
using GameShare.Common;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace GameServer.NetWork
{
	public class Session : AppSession<Session, BinaryRequestInfo> 
	{
        public int roomId = -1; 
        public long uid = 0;    

        protected override void OnSessionStarted() 
		{
            uid = 0;
            roomId = -1;
        }

        protected override void OnSessionClosed(CloseReason reason) 
		{
            uid = 0;
            roomId = -1;
            base.OnSessionClosed(reason);
        }

        protected override void HandleException(Exception e) 
		{
            this.Send("Application error: {0}", e.Message);
        }

        protected override void HandleUnknownRequest(BinaryRequestInfo requestInfo) 
		{
            this.Send("Unknow request");
        }

		public void SendBytes(byte[] contents)
		{
			this.Send (contents, 0, contents.Length);
		}

		public bool SendPb(ProtoBuf.IExtensible proto)
		{
			ByteBuffer buff = new ByteBuffer ();
			byte[] contents = ProtoUtil.Serialize (proto);

			buff.WriteShort ((ushort)(contents.Length + 2));
			buff.WriteShort ((ushort)ProtoUtil.GetProtoType (proto));
			buff.WriteBytes (contents);

			this.SendBytes (buff.ToBytes ());
			return true;
		}

    }
}
