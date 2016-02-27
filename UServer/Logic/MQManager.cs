using System;
using Share_Common;
using GameShare.Common;
using System.Collections.Generic;

namespace GameServer.Logic
{
	public class SendThread : BaseThread
	{
		public override void run ()
		{
			while (true) 
			{
				MQManager.DispatherMessage ();
			}
		}
	}
	
	public class MQManager
	{
		private static Stuff_Message_Queue s_Unicast = new Stuff_Message_Queue();
		private static Stuff_Message_Queue s_Muticast = new Stuff_Message_Queue();
		private static Stuff_Message_Queue s_Broadcast = new Stuff_Message_Queue();

		private static SendThread m_SendThread = new SendThread();

		public MQManager ()
		{
			
		}

		public static void Start ()
		{
			m_SendThread.Start ();
		}

		public static void SendMessage (Stuff_Message paraMessage)
		{
			s_Unicast.contents.Add (paraMessage);
		}

		public static void BroadCast (Stuff_Message paraMessage)
		{
			int source = paraMessage.source;
			Dictionary<int, Creature> creatures = SceneManager.GetRangeSet (source);

			foreach (int creature in creatures.Keys) 
			{
				paraMessage.target = creature;
				s_Broadcast.contents.Add (paraMessage);
			}
		}

		public static List<Stuff_Message> GetUnicast()
		{
			return s_Unicast.contents;
		}

		public static List<Stuff_Message> GetMuticast()
		{
			return s_Muticast.contents;
		}

		public static List<Stuff_Message> GetBroadcast()
		{
			return s_Broadcast.contents;
		}

		public static void DispatherMessage()
		{
			for (int i = 0; i < s_Unicast.contents.Count; ++i) 
			{
				Stuff_Message message = s_Unicast.contents [i];
				bool result = OnDispatherMessage (message);
				if (result) s_Unicast.contents.RemoveAt (i);
			}

			for (int i = 0; i < s_Muticast.contents.Count; ++i) 
			{
				Stuff_Message message = s_Muticast.contents [i];
				bool result = OnDispatherMessage (message);
				if (result) s_Muticast.contents.RemoveAt (i);
			}

			for (int i = 0; i < s_Broadcast.contents.Count; ++i) 
			{
				Stuff_Message message = s_Broadcast.contents [i];
				bool result = OnDispatherMessage (message);
				if (result) s_Broadcast.contents.RemoveAt (i);
			}
		}

		public static bool OnDispatherMessage(Stuff_Message paraMessage)
		{
			int target = paraMessage.target;
			Creature creature = SceneManager.GetCreature (target);
			if (creature == null) return false;
			if (!creature.IsOnline()) return false;
			creature.OnDispatherMessage (paraMessage);
			return true;
		}

		public static void Save2Db()
		{
			
		}

	}
}

