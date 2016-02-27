using System;

namespace GameServer.Logic
{
	public struct Vector3
	{
		//
		// Fields
		//
		public float z;

		public float y;

		public float x;

		//
		// Static Properties
		//
		public static Vector3 back
		{
			get
			{
				return new Vector3 (0f, 0f, -1f);
			}
		}

		public static Vector3 down
		{
			get
			{
				return new Vector3 (0f, -1f, 0f);
			}
		}

		public static Vector3 forward
		{
			get
			{
				return new Vector3 (0f, 0f, 1f);
			}
		}

		[Obsolete ("Use Vector3.forward instead.")]
		public static Vector3 fwd
		{
			get
			{
				return new Vector3 (0f, 0f, 1f);
			}
		}

		public static Vector3 left
		{
			get
			{
				return new Vector3 (-1f, 0f, 0f);
			}
		}

		public static Vector3 one
		{
			get
			{
				return new Vector3 (1f, 1f, 1f);
			}
		}

		public static Vector3 right
		{
			get
			{
				return new Vector3 (1f, 0f, 0f);
			}
		}

		public static Vector3 up
		{
			get
			{
				return new Vector3 (0f, 1f, 0f);
			}
		}

		public static Vector3 zero
		{
			get
			{
				return new Vector3 (0f, 0f, 0f);
			}
		}

		//
		// Properties
		//
		public float magnitude
		{
			get
			{
				return (float)Math.Sqrt (this.x * this.x + this.y * this.y + this.z * this.z);
			}
		}

		public float sqrMagnitude
		{
			get
			{
				return this.x * this.x + this.y * this.y + this.z * this.z;
			}
		}

		//
		// Constructors
		//
		public Vector3 (float x, float y)
		{
			this.x = x;
			this.y = y;
			this.z = 0f;
		}

		public Vector3 (float x, float y, float z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public static Vector3 Cross (Vector3 lhs, Vector3 rhs)
		{
			return new Vector3 (lhs.y * rhs.z - lhs.z * rhs.y, lhs.z * rhs.x - lhs.x * rhs.z, lhs.x * rhs.y - lhs.y * rhs.x);
		}

		public static float Distance (Vector3 a, Vector3 b)
		{
			Vector3 vector = new Vector3 (a.x - b.x, a.y - b.y, a.z - b.z);

			return (float)Math.Sqrt (vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
		}

		public static float Dot (Vector3 lhs, Vector3 rhs)
		{
			return lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z;
		}

		public static Vector3 Max (Vector3 lhs, Vector3 rhs)
		{
			return new Vector3 (Math.Max (lhs.x, rhs.x), Math.Max (lhs.y, rhs.y), Math.Max (lhs.z, rhs.z));
		}

		public static Vector3 Min (Vector3 lhs, Vector3 rhs)
		{
			return new Vector3 (Math.Min (lhs.x, rhs.x), Math.Min (lhs.y, rhs.y), Math.Min (lhs.z, rhs.z));
		}

		public static Vector3 MoveTowards (Vector3 current, Vector3 target, float maxDistanceDelta)
		{
			Vector3 a = target - current;

			float magnitude = a.magnitude;

			if (magnitude <= maxDistanceDelta || magnitude == 0f)
			{
				return target;
			}
			return current + a / magnitude * maxDistanceDelta;
		}

		public void Scale (Vector3 scale)
		{
			this.x *= scale.x;
			this.y *= scale.y;
			this.z *= scale.z;
		}

		public void Set (float new_x, float new_y, float new_z)
		{
			this.x = new_x;
			this.y = new_y;
			this.z = new_z;
		}

		//
		// Operators
		//
		public static Vector3 operator + (Vector3 a, Vector3 b)
		{
			return new Vector3 (a.x + b.x, a.y + b.y, a.z + b.z);
		}

		public static Vector3 operator / (Vector3 a, float d)
		{
			return new Vector3 (a.x / d, a.y / d, a.z / d);
		}

		public static Vector3 operator * (float d, Vector3 a)
		{
			return new Vector3 (a.x * d, a.y * d, a.z * d);
		}

		public static Vector3 operator * (Vector3 a, float d)
		{
			return new Vector3 (a.x * d, a.y * d, a.z * d);
		}

		public static Vector3 operator - (Vector3 a, Vector3 b)
		{
			return new Vector3 (a.x - b.x, a.y - b.y, a.z - b.z);
		}

		public static Vector3 operator - (Vector3 a)
		{
			return new Vector3 (-a.x, -a.y, -a.z);
		}
	}
}
