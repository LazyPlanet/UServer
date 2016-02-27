/**
 * 
 * Scene class includes all game objects in the scene/world, what is pair of scene in unity.
 * 
 * All operations in scene need defineded in this file.
 * 
 * @author lazy
 *
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameServer.Logic
{
    class Scene
    {
        // Member 
        public LinkedList<Creature> m_XObjList = null;
        public LinkedList<Creature> m_ZObjList = null;
        public Dictionary<int, Creature> m_Creatures = null;

        public Dictionary<int, Creature> m_MoveMap = null;
        public Dictionary<int, Creature> m_EnterMap = null;
        public Dictionary<int, Creature> m_LeaveMap = null;

        /**
        * Constructor
        * */
        public Scene()
        {
            m_XObjList = new LinkedList<Creature>();
            m_ZObjList = new LinkedList<Creature>();
            m_Creatures = new Dictionary<int, Creature>();

            m_MoveMap = new Dictionary<int, Creature>();
            m_EnterMap = new Dictionary<int, Creature>();
            m_LeaveMap = new Dictionary<int, Creature>();
        }
        /**
        * Add objects to scene when entered
        * */
        public void Insert(int paraID, Vector3 paraVec3, int paraDistance = 5)
        {
            if (this.m_Creatures.ContainsKey(paraID)) return;

            Creature obj = new Creature(paraID, paraVec3, paraDistance);
            this.m_Creatures[paraID] = obj;
            
            // Iterator x-axis object list
            bool flag = false;
            Dictionary<int, Creature> xMap = new Dictionary<int, Creature>();
            LinkedListNode<Creature> pos = null;

            for (LinkedListNode<Creature> node = m_XObjList.First; node != null; node = node.Next)
            {
				float diff = node.Value.GetPosition().x - obj.GetPosition().x;
                if (Math.Abs(diff) <= paraDistance)
                {
					xMap[node.Value.m_CreatureId] = node.Value;
                }
                if (!flag && diff > 0.0f)
                {
                    flag = true;
                    pos = node;
                }

                if (diff > paraDistance) break;
            }

            if (flag) 
            {
                m_XObjList.AddAfter(pos, obj);
                obj.m_XPos = pos.Previous;
            } 
            else 
            {
                m_XObjList.AddFirst(obj);
                obj.m_XPos = m_XObjList.First;
            }

            // Iterator z-axis object list
            flag = false;
            for (LinkedListNode<Creature> node = m_ZObjList.First; node != null; node = node.Next)
            {
				float diff = node.Value.GetPosition().y - obj.GetPosition().y;
				if (Math.Abs(diff) <= paraDistance && !xMap.ContainsKey(node.Value.m_CreatureId))
                {
					m_EnterMap[node.Value.m_CreatureId] = node.Value;
                }
                if (!flag && diff > 0.0f)
                {
                    flag = true;
                    pos = node;
                }

                if (diff > paraDistance) break;
            }

            if (flag) 
            {
                m_ZObjList.AddAfter(pos, obj);
                obj.m_ZPos = pos.Previous;
            } 
            else 
            {
                m_ZObjList.AddFirst(obj);
                obj.m_ZPos = m_ZObjList.First;
            }

            Update(obj);
        }
        /**
        * Object moves to scene
        * */
        public void Move(int paraID, Vector3 paraVec3)
        {
            if (!this.m_Creatures.ContainsKey(paraID)) return;

            Creature obj = this.m_Creatures[paraID];
            Dictionary<int, Creature> oldSet = new Dictionary<int, Creature>();
            Dictionary<int, Creature> newSet = new Dictionary<int, Creature>();
            
            GetRangeSet(obj, oldSet);
            UpdateObjectPosition(obj, paraVec3.x, paraVec3.z);
            GetRangeSet(obj, newSet);

            foreach (int key in oldSet.Keys)
            {
                if (!newSet.ContainsKey(key))
                {
                    m_MoveMap[key] = oldSet[key];
                }

                if (!m_MoveMap.ContainsKey(key))
                {
                    m_LeaveMap[key] = oldSet[key];
                }
            }

            foreach (int key in newSet.Keys)
            {
                if (!m_MoveMap.ContainsKey(key))
                {
                    m_EnterMap[key] = newSet[key];
                }
            }

            Update(obj);
        }
        /**
        * Object leaves to scene
        * */
        public void Leave(int paraID)
        {
            if (!m_Creatures.ContainsKey(paraID)) return;

            Creature obj = m_Creatures[paraID];

            GetRangeSet(obj, m_LeaveMap);
            Update(obj);

            m_XObjList.Remove(obj.m_XPos);
            m_ZObjList.Remove(obj.m_ZPos);
			m_Creatures.Remove(obj.m_CreatureId);
        }
        /**
        * Send message to object needed
        * */
        public void Update(Creature paraObj)
        {
            // Send enter msg
            foreach (int key in m_EnterMap.Keys)
            {
                Creature baseObj = m_EnterMap[key];
				/*
                Console.WriteLine("Send [{0}, {1}:{2}]\t enter msg to obj [{3}, {4}:{5}]\n",
					paraObj.m_CreatureId, paraObj.m_Position.x, paraObj.m_Position.z, baseObj.m_CreatureId, baseObj.m_Position.x, baseObj.m_Position.z);

                Console.WriteLine("Send [{0}, {1}:{2}]\t enter msg to obj [{3}, {4}:{5}]\n",
					baseObj.m_CreatureId, baseObj.m_Position.y, baseObj.m_Position.z, paraObj.m_CreatureId, paraObj.m_Position.x, paraObj.m_Position.z);
					*/
            }
            // Send move msg
            foreach (int key in m_MoveMap.Keys)
            {
                Creature baseObj = m_MoveMap[key];
				/*
                Console.WriteLine("Send [{0}, {1}:{2}]\t move msg to obj [{3}, {4}:{5}]\n",
					paraObj.m_CreatureId, paraObj.m_Position.x, paraObj.m_Position.z, baseObj.m_CreatureId, baseObj.m_Position.x, baseObj.m_Position.z);
					*/
            }
            // Send leave msg
            foreach (int key in m_LeaveMap.Keys)
            {
                Creature baseObj = m_LeaveMap[key];
				/*
                Console.WriteLine("Send [{0}, {1}:{2}]\t leave msg to obj [{3}, {4}:{5}]\n",
					paraObj.m_CreatureId, paraObj.m_Position.x, paraObj.m_Position.z, baseObj.m_CreatureId, baseObj.m_Position.x, baseObj.m_Position.z);
					*/
            }

            m_MoveMap.Clear();
            m_EnterMap.Clear();
            m_LeaveMap.Clear();
        }
        /**
        * Get range set
        * */
        public void GetRangeSet(Creature paraObj, Dictionary<int, Creature> paraMap)
        {
            Dictionary<int, Creature> xSet = new Dictionary<int, Creature>();
            LinkedListNode<Creature> iter = null;
            
            int distance = paraObj.m_Radius;

            // Iterator x-axis object list
            if (paraObj.m_XPos != null) 
            {
                iter = paraObj.m_XPos;
                while (true) 
                {
                    if (iter == null) break;
                    iter = iter.Next;
					if (iter == null || paraObj.GetPosition().x - iter.Value.GetPosition().x > distance) break;
					xSet[iter.Value.m_CreatureId] = iter.Value;
                }
            }
            if (paraObj.m_XPos != m_XObjList.First) 
            {
                iter = paraObj.m_XPos;
                while (true) 
                {
                    if (iter == null) break;
                    iter = iter.Previous;
					if (iter == null || iter.Value.GetPosition().x - paraObj.GetPosition().x > distance) break;
					xSet[iter.Value.m_CreatureId] = iter.Value;
                }
            }

            // Iterator z-axis object list
            if (paraObj.m_ZPos != null) 
            {
                iter = paraObj.m_ZPos;
                while (true) 
                {
                    if (iter == null) break;
                    iter = iter.Next;
					if (iter == null || paraObj.GetPosition().z - iter.Value.GetPosition().z > distance) break;
					if (xSet.ContainsKey(iter.Value.m_CreatureId)) 
                    {
						paraMap[iter.Value.m_CreatureId] = iter.Value;
                    }
                }
            }
            if (paraObj.m_ZPos != m_ZObjList.First) 
            {
                iter = paraObj.m_ZPos;
                while (true)
                {
                    if (iter == null) break;
                    iter = iter.Previous;
					if (iter == null || iter.Value.GetPosition().z - paraObj.GetPosition().z > distance) break;
					if (xSet.ContainsKey(iter.Value.m_CreatureId))
                    {
						paraMap[iter.Value.m_CreatureId] = iter.Value;
                    }
                }
            }
        }
        /**
        * Update object position
        * */
        public void UpdateObjectPosition(Creature paraObj, float paraX, float paraZ)
        {
			float old_x = paraObj.GetPosition().x;
			float old_z = paraObj.GetPosition().z;

			paraObj.SetPosition (new Vector3(paraX, 0, paraZ));

            LinkedListNode<Creature> iter = null;
            LinkedListNode<Creature> pos = null;
           
            // Find the new x pos
            if (paraX > old_x) 
            {
                if (paraObj.m_XPos != null) 
                {
                    iter = paraObj.m_XPos;
                    m_XObjList.Remove(paraObj.m_XPos);
                    if (iter == null) return;

                    iter = iter.Next;
                    while (iter != null) 
                    {
						if (paraObj.GetPosition().x - iter.Value.GetPosition().x < 0) 
                        {
                            pos = iter;
                            break;
                        }
                        iter = iter.Next;
                    }
                    if (iter != null) 
                    {
                        m_XObjList.AddAfter(pos, paraObj);
                        paraObj.m_XPos = pos.Previous;
                    } 
                    else 
                    {
                        m_XObjList.AddLast(paraObj);
                        paraObj.m_XPos = m_XObjList.Last;
                    }
                }
            }
            else if (paraX < old_x) 
            {
                if (paraObj.m_XPos != m_XObjList.First) 
                {
                    iter = paraObj.m_XPos;
                    m_XObjList.Remove(paraObj.m_XPos);
                    if (iter == null) return;
                    
                    iter = iter.Previous;
                    while (iter != null)
                    {
						if (paraObj.GetPosition().x - iter.Value.GetPosition().x > 0) 
                        {
                            pos = iter.Next;
                            break;
                        }
                        iter = iter.Previous;
                    }
                    if (iter != null) 
                    {
                        m_XObjList.AddAfter(pos, paraObj);
                        paraObj.m_XPos = pos.Previous;
                    } 
                    else 
                    {
                        m_XObjList.AddFirst(paraObj);
                        paraObj.m_XPos = m_XObjList.First;
                    }
                }
            }

            // Find the new z pos
            if (paraZ > old_z) 
            {
                if (paraObj.m_ZPos != null) 
                {
                    iter = paraObj.m_ZPos;
                    m_ZObjList.Remove(paraObj.m_ZPos);
                    if (iter == null) return;
                    
                    iter = iter.Next;
                    while (iter != null) 
                    {
						if (paraObj.GetPosition().z - iter.Value.GetPosition().z < 0) 
                        {
                            pos = iter;
                            break;
                        }
                        iter = iter.Next;
                    }
                    if (iter != null) 
                    {
                        m_ZObjList.AddAfter(pos, paraObj);
                        paraObj.m_ZPos = pos.Previous;
                    } 
                    else 
                    {
                        m_ZObjList.AddLast(paraObj);
                        paraObj.m_ZPos = m_ZObjList.Last;
                    }
                }
            }
            else if (paraZ < old_z) 
            {
                if (paraObj.m_ZPos != m_ZObjList.First)
                {
                    iter = paraObj.m_ZPos;
                    m_ZObjList.Remove(paraObj.m_ZPos);
                    if (iter == null) return;

                    iter = iter.Previous;
                    while (iter != null) 
                    {
						if (paraObj.GetPosition().z - iter.Value.GetPosition().z > 0) 
                        {
                            pos = iter.Next;
                            break;
                        }
                        iter = iter.Previous;
                    }
                    if (iter != null) 
                    {
                        m_ZObjList.AddAfter(pos, paraObj);
                        paraObj.m_ZPos = pos.Previous;
                    } 
                    else 
                    {
                        m_ZObjList.AddFirst(paraObj);
                        paraObj.m_ZPos = m_ZObjList.First;
                    }
                }
            }
        }
        // End of class Scence
    }
    // End of namespace GameServer.Logic
}
