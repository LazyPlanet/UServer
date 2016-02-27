using System;
using System.Linq;
using System.Text;
using Share_Common;
using System.Collections.Generic;

namespace GameServer.Logic
{
	
    public class Creature
    {
        public int m_CreatureId = 0;
        public int m_Radius = 0;
		public bool m_IsOnline = false;

        public LinkedListNode<Creature> m_XPos;
        public LinkedListNode<Creature> m_ZPos;

		public Stuff_Creature m_Creature = new Stuff_Creature();
        // Virtual function defination
		public virtual void SendMessage(Stuff_Message paraMsg) { }
		public virtual void MessageHandler(Stuff_Message paraMsg) { }

        public Creature()
        {

        }

		public Creature(int paraCreatureId) 
		{
			this.m_CreatureId = paraCreatureId;
		}

        public Creature(int paraID, Vector3 paraPosition, int paraRadius) 
        {
			this.m_CreatureId = paraID;
            this.m_Radius = paraRadius;
			this.m_Creature.Position.x = paraPosition.x;
			this.m_Creature.Position.y = paraPosition.y;
			this.m_Creature.Position.z = paraPosition.z;
        }

		public virtual bool IsOnline()
		{
			return this.m_IsOnline;
		}

		public virtual bool IsPlayer()
		{
			return this.m_Creature.Variety == Creature_Variety.CV_Player;
		}

		public virtual bool IsNPC()
		{
			return this.m_Creature.Variety == Creature_Variety.CV_NPC;
		}

		public virtual Vector3 GetPosition()
		{
			Vector3 position = new Vector3 (this.m_Creature.Position.x, this.m_Creature.Position.y, this.m_Creature.Position.z);
			return position;
		}

		public virtual void SetPosition(Vector3 paraPosition)
		{
			this.m_Creature.Position.x = paraPosition.x;
			this.m_Creature.Position.y = paraPosition.y;
			this.m_Creature.Position.z = paraPosition.z;
		}

		public virtual void OnDispatherMessage(Stuff_Message paraMsg) 
        {
            this.MessageHandler(paraMsg);
        }

		public virtual void Load()
		{
			this.m_IsOnline = true;
		}

    }
}
