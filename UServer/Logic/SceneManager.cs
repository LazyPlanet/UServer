using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameServer.Logic
{
    class SceneManager
    {
        private static Scene m_Scene = new Scene();

        public SceneManager()
        {
            
        }

        public static void Insert(int paraID, Vector3 paraPos)
        {
            m_Scene.Insert(paraID, paraPos);
        }

        public static void Move(int paraID, Vector3 paraPos)
        {
            m_Scene.Move(paraID, paraPos);
        }

        public static void Leave(int paraID)
        {
            m_Scene.Leave(paraID);
        }

        public static Dictionary<int, Creature> GetPlayers()
        {
            return m_Scene.m_Creatures;
        }

        public static Creature GetPlayer(int paraID)
        {
            if (!m_Scene.m_Creatures.ContainsKey(paraID)) return null;
            return m_Scene.m_Creatures[paraID];
        }
        
		public static Creature GetCreature(int paraID)
		{
			if (!m_Scene.m_Creatures.ContainsKey(paraID)) return null;
			return m_Scene.m_Creatures[paraID];
		}

		public static Dictionary<int, Creature> GetRangeSet(int paraCreatureId)
		{
			Creature creature = SceneManager.GetCreature (paraCreatureId);
			if (creature == null || !creature.IsOnline ()) return null;
			Dictionary<int, Creature> creatures = new Dictionary<int, Creature>();
			m_Scene.GetRangeSet(creature, creatures);
			return creatures;
		}

        // End of class SceneManager
    }
    // End of namespace GameServer.Logic
}
