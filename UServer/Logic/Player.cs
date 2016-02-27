using System;
using Share_Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GameServer.Event;
using GameServer.NetWork;
using GameShare.Common;
using GameServer.DataBase;

namespace GameServer.Logic
{
    class Player : Creature
    {
        // Member for system
        private System.Threading.Timer m_Timer;
        // Member for player 
		private int m_PlayerId = 0;
		private NetWork.Session m_Session = null;
		// Member for database and communication
        private Stuff_Player m_StuffPlayer = new Stuff_Player();

        /**
        * Constructor
        * */
        public Player()
        {
			
        }

		public Player(int paraPlayerId) : base(paraPlayerId)
        {
			this.m_PlayerId = paraPlayerId;
        }

        public Player(int paraID, Vector3 paraPosition, int paraRadius) : base(paraID, paraPosition, paraRadius)
        {
			this.m_PlayerId = paraID;
            this.m_Radius = paraRadius;
			this.m_Creature.Position.x = paraPosition.x;
			this.m_Creature.Position.y = paraPosition.y;
			this.m_Creature.Position.z = paraPosition.z;
        }

        /**
        * Deconstructor
        * */
        ~Player()
        {
            this.SavePlayer();
        }
        /**
        * Start timer and init other data.
        * */
        private void Start()
        {
			m_Timer = new System.Threading.Timer(new TimerCallback(Update), null, 0, 10000);

           //EventManager.Instance().AddEventHandler(new SceneChangedEvent(), SceneChanged);
        }
        /**
        * Timer call back, like a heart beats
        * */
        public void Update(System.Object info)
        {
			m_Timer.Dispose ();
        }

        public Stuff_Player GetPlayer()
        {
            return this.m_StuffPlayer;
        }

        public void SavePlayer()
        {
			RedisManager.GetClient().Set<Stuff_Player>("Player:" + this.m_PlayerId.ToString(), this.m_StuffPlayer);
        }

		public override void Load() 
		{
			base.Load ();

			this.m_StuffPlayer = RedisManager.GetClient().Get<Stuff_Player>("Player:" + this.m_PlayerId.ToString());
		}

        public bool OnPlayerLogin()
        {
            

            return true;
        }
        /**
        * After client loaded resources, then entering scene
        * */
        public void OnEnterScene()
        {
			Vector3 position = new Vector3 (this.m_StuffPlayer.Position.x, this.m_StuffPlayer.Position.y, this.m_StuffPlayer.Position.z);
			SceneManager.Insert (m_PlayerId, position);

            this.Start();
        }

		public void SetSession(Session paraSession)
		{
			this.m_Session = paraSession;
		}

        public void SceneChanged(object sender, BaseEventArgs e)
        {
            
        }

		public void Send(byte[] contents)
		{
			this.m_Session.Send (contents, 0, contents.Length);
		}

		public bool SendPb(ProtoBuf.IExtensible proto)
		{

			this.SendPb (proto);
			return true;
		}

        public virtual void MessageHandler() 
        {

        }
        // End of class Player
    }
    // End of namespace GameServer.Logic
}
