using System;

namespace Aiv.Math
{

	public struct Vector2
	{
		public float x;
		public float y;

		public Vector2 (float x, float y)
		{
			this.x = x;
			this.y = y;
		}

		public float this [int i] {
			get {
				if (i == 0)
					return this.x;
				if (i == 1)
					return this.y;
				throw new IndexOutOfRangeException ();
			}
			set {
				if (i == 0)
					this.x = value;
				else if (i == 1)
					this.y = value;
				else
					throw new IndexOutOfRangeException ();
			}
		}

		public static Vector2 up = new Vector2 (0, 1);
		public static Vector2 down = new Vector2 (0, -1);
		public static Vector2 left = new Vector2 (-1, 0);
		public static Vector2 right = new Vector2 (1, 0);
		public static Vector2 zero = new Vector2 (0, 0);

		/// <summary>
		/// clone a Vector2 structure
		/// </summary>
		public Vector2 Clone ()
		{
			return new Vector2 (this.x, this.y);
		}

		public float SquareLength ()
		{
			return this.x * this.x + this.y * this.y;
		}

		public float Length ()
		{
			return (float) System.Math.Sqrt (this.SquareLength ());
		}

		public static Vector2 operator+ (Vector2 a, Vector2 b)
		{
			a.x += b.x;
			a.y += b.y;
			return a;
		}

		public static Vector2 operator+ (Vector2 a, float b)
		{
			a.x += b;
			a.y += b;
			return a;
		}

		public static Vector2 operator- (Vector2 a, Vector2 b)
		{
			a.x -= b.x;
			a.y -= b.y;
			return a;
		}

		public static Vector2 operator- (Vector2 a, float b)
		{
			a.x -= b;
			a.y -= b;
			return a;
		}

		public static Vector2 operator* (Vector2 a, Vector2 b)
		{
			a.x *= b.x;
			a.y *= b.y;
			return a;
		}

		public static Vector2 operator* (Vector2 a, float b)
		{
			a.x *= b;
			a.y *= b;
			return a;
		}

		public static Vector2 operator/ (Vector2 a, Vector2 b)
		{
			a.x /= b.x;
			a.y /= b.y;
			return a;
		}

		public static Vector2 operator/ (Vector2 a, float b)
		{
			a.x /= b;
			a.y /= b;
			return a;
		}

		public static bool operator== (Vector2 a, Vector2 b)
		{
			return (a.x == b.x) && (a.y == b.y);
		}

		public static bool operator!= (Vector2 a, Vector2 b)
		{
			return !((a.x == b.x) && (a.y == b.y));
		}

		/// <summary>
		/// add a Vector2 structure
		/// </summary>
		public Vector2 Add (Vector2 v)
		{
			return new Vector2 (this.x + v.x, this.y + v.y);
		}

		/// <summary>
		/// subtract a Vector2 structure
		/// </summary>
		public Vector2 Sub (Vector2 v)
		{
			return new Vector2 (this.x - v.x, this.y - v.y);
		}

		public override bool Equals (Object o)
		{
			if (!(o is Vector2))
				return false;
			Vector2 v = (Vector2) o;
			return (this.x == v.x) && (this.y == v.y);
		}

		public override int GetHashCode ()
		{
			int hash = 17;
			hash = hash * 23 + this.x.GetHashCode();
			hash = hash * 23 + this.y.GetHashCode();
			return hash;
		}


	}

}
