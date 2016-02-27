using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameServer.Event
{
    public delegate void ServerEventHandler(object sender, BaseEventArgs e);

    public class EventManager
    {
        private Sender m_Sender = new Sender();

        private static EventManager m_Instance = new EventManager();

        public static EventManager Instance()
        {
            if (m_Instance == null)
            {
                m_Instance = new EventManager(); 
            }
            return m_Instance;
        }

        public void RaiseEvent(BaseEventArgs e)
        {
            m_Sender.RaiseEvent(e);
        }

        public void AddEventHandler(BaseEventArgs e, ServerEventHandler action)
        {
            m_Sender.handler += new ServerEventHandler(action);
        }

        public void RemoveEventHandler(BaseEventArgs e, ServerEventHandler action)
        {
            m_Sender.handler -= new ServerEventHandler(action);
        }

    }

    public class Sender
    {

        public event ServerEventHandler handler;

        public virtual void RaiseEvent(BaseEventArgs e)
        {
            if (handler != null) handler(this, e);
        }
    }

}
