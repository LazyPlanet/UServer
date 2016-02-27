using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameServer.Event
{
    public enum EventType
    {
        EventNull,

    }

    public class BaseEventArgs : EventArgs
    {
        public EventType m_Type;
        public String m_Name;
    }
}
