// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using GameServer.Logic;

namespace Terrain
{
	/*
	 * Grid manager slice, mapping to terrain.
	 */
	public class Grid
	{
		public List<Slice> m_SliceList = new List<Slice>();

		public Grid ()
		{

		}

		public Slice GetSlice(int index)
		{
			if (index < m_SliceList.Count) return null;

			return m_SliceList[index];
		}

		public Slice GetSlice(Point point)
		{
			foreach (Slice slice in m_SliceList) 
			{
				if (slice.GetPosition() == point) return slice;
			}
			return null;
		}

		public Slice GetSlice(int x, int z)
		{
			Point point = new Point (x, z);
			return GetSlice(point);
		}

		//public bool MoveBetweenSlice(Player player, Slice src, Slice des)
		//{

		//}
		// End of class Grid
	}
}

