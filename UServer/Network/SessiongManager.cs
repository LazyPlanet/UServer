using System;
using System.Linq;
using System.Text;
using System.Net;
using System.Collections;
using System.Collections.Generic;

namespace GameServer.NetWork
{
    /**
	* Manager Session
	* */
    public class SessiongManager
    {
		private static Dictionary<int, Session> m_Clients = new Dictionary<int, Session>();

		public static bool AddSession(int playerId, Session session)
		{
			if (m_Clients.ContainsKey (playerId)) return false;
			m_Clients.Add (playerId, session);
			return true;
		}

		public static bool RemoveSession(int playerId)
		{
			if (m_Clients.ContainsKey (playerId)) return false;
			m_Clients.Remove (playerId);
			return true;
		}

		public static Session GetSession(int playerId)
		{
			Session session = new Session();
			m_Clients.TryGetValue (playerId, out session);
			return session;
		}

        // End of class SessiongManager
    }

    // End of namespace GameServer.NetWork
}
