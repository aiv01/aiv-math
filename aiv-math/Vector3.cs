using System;

namespace Aiv.Math
{
	public struct Vector3
	{
		public float x;
		public float y;
		public float z;

		public static Vector3 up = new Vector3 (0, 1, 0);
		public static Vector3 down = new Vector3 (0, -1, 0);
		public static Vector3 left = new Vector3 (-1, 0, 0);
		public static Vector3 right = new Vector3 (1, 0, 0);
		public static Vector3 zero = new Vector3 (0, 0, 0);
		public static Vector3 forward = new Vector3 (0, 0, 1);

		public Vector3 (float x, float y, float z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public static implicit operator Vector4 (Vector3 v)
		{
			return new Vector4 (v.x, v.y, v.z, 0);
		}

		public float SquareLength ()
		{
			return this.x * this.x + this.y * this.y + this.z * this.z;
		}

		public float Length ()
		{
			return (float) System.Math.Sqrt (this.SquareLength ());
		}

		public static Vector3 Cross (Vector3 v0, Vector3 v1)
		{
			Vector3 vr;
			vr.x = v0.y * v1.z - v0.z * v1.y;
			vr.y = v0.z * v1.x - v0.x * v1.z;
			vr.z = v0.x * v1.y - v0.y * v1.x;
			return vr;
		}

		public Vector3 Normalize ()
		{
			return this / this.Length ();
		}

		public override string ToString ()
		{
			return string.Format ("{0}, {1}, {2}", this.x, this.y, this.z);
		}

		public static Vector3 operator+ (Vector3 a, Vector3 b)
		{
			a.x += b.x;
			a.y += b.y;
			a.z += b.z;
			return a;
		}

		public static Vector3 operator+ (Vector3 a, float b)
		{
			a.x += b;
			a.y += b;
			a.z += b;
			return a;
		}

		public static Vector3 operator- (Vector3 a, Vector3 b)
		{
			a.x -= b.x;
			a.y -= b.y;
			a.z -= b.z;
			return a;
		}

		public static Vector3 operator- (Vector3 a, float b)
		{
			a.x -= b;
			a.y -= b;
			a.z -= b;
			return a;
		}

		public static Vector3 operator* (Vector3 a, Vector3 b)
		{
			a.x *= b.x;
			a.y *= b.y;
			a.z *= b.z;
			return a;
		}

		public static Vector3 operator* (Vector3 a, float b)
		{
			a.x *= b;
			a.y *= b;
			a.z *= b;
			return a;
		}

		public static Vector3 operator/ (Vector3 a, Vector3 b)
		{
			a.x /= b.x;
			a.y /= b.y;
			a.z /= b.z;
			return a;
		}

		public static Vector3 operator/ (Vector3 a, float b)
		{
			a.x /= b;
			a.y /= b;
			a.z /= b;
			return a;
		}
	}
}

