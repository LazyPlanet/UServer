using System;
using System.Text;
using Share_Common;
using GameShare.Common;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;

namespace GameServer.Logic 
{
	class LogicServer : AppServer<NetWork.Session, BinaryRequestInfo> 
	{
		public LogicServer() : base(new DefaultReceiveFilterFactory<NetWork.ReceiveFilter, BinaryRequestInfo>()) 
		{
			// Init resources and thread
			MQManager.Start ();
        }

        protected override bool Setup(IRootConfig rootConfig, IServerConfig config) 
		{
            return base.Setup(rootConfig, config);
        }

        protected override void OnStarted() 
		{
            base.OnStarted();
			this.NewSessionConnected += new SessionHandler<NetWork.Session>(OnSessionConnected);
			this.NewRequestReceived += new RequestHandler<NetWork.Session, BinaryRequestInfo>(OnRequestReceived);
        }

        protected override void OnStopped() 
		{
            base.OnStopped();
			this.NewSessionConnected -= new SessionHandler<NetWork.Session>(OnSessionConnected);
			this.NewRequestReceived -= new RequestHandler<NetWork.Session, BinaryRequestInfo>(OnRequestReceived);
        }

		void OnSessionConnected(NetWork.Session session) 
		{
			Console.WriteLine ("Client {0} connected server success...", session.RemoteEndPoint);
        }

		void OnRequestReceived(NetWork.Session session, BinaryRequestInfo requestInfo) 
		{
			Console.WriteLine ("OnRequestReceived success.");

			ByteBuffer buffer = new ByteBuffer(requestInfo.Body);
			if (buffer == null) 
			{
				Console.WriteLine ("----------Error data");
				return;
			}

			try 
			{
				//int length = buffer.ReadShort ();
				int length = 0;
				C2S_Proto_Type protoType = (C2S_Proto_Type)buffer.ReadShort();
				Console.WriteLine ("Receive proto size : {0}, name : {1}", length, protoType);
				switch (protoType)
				{
				case C2S_Proto_Type.Proto_Stuff_Login:
					{
						Stuff_Login login = ProtoUtil.Deserialize<Stuff_Login>(buffer);     

						if (CheckAuthentication(login))
						{
							Player player = new Player(login.PlayerId);
							player.SetSession(session);
							player.OnPlayerLogin();
						}
					}
					break;

				case C2S_Proto_Type.Proto_Stuff_Account:
					{
						Stuff_Account account = ProtoUtil.Deserialize<Stuff_Account>(buffer);     
						Console.WriteLine (account.UserName + account.PassWord);


					}
					break;

					default:
					break;
				}
			}
			catch (Exception ex) 
			{
				Console.WriteLine ("Deserialize exception : {0}", ex.Message);
			}
		}

		// Connect Au server to authentication username and password
		private bool CheckAuthentication(Stuff_Login login)
		{
			return true;
		}
    }
}
