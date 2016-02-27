using System;
using GameServer.Logic;
using GameServer.Config;

namespace GameServer
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			if (!ConfigManager.Load ()) 
			{
				Console.WriteLine ("Load config failed.");
				return;
			}

			LogicServer logic = new LogicServer ();
			logic.Setup (ConfigManager.m_LogicServerPort);
			logic.Start ();

			System.Console.WriteLine("Start server success.");
			while(true) {}
		}
	}
}
