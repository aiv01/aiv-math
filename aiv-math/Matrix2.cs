using System;

namespace Aiv.Math
{
	public struct Matrix2
	{
		public float[] m;

		public float m11 { get { return this.m [0]; } set { this.m [0] = value; } }

		public float m12 { get { return this.m [1]; } set { this.m [1] = value; } }

		public float m21 { get { return this.m [2]; } set { this.m [3] = value; } }

		public float m22 { get { return this.m [3]; } set { this.m [3] = value; } }

		public float this [int i] {
			get {
				return this.m [i];
			}
			set {
				this.m [i] = value;
			}
		}

		public float this [int i, int j] {
			get {
				int pos = i * 2 + j;
				return this.m [pos];
			}
			set {
				int pos = i * 2 + j;
				this.m [pos] = value;
			}
		}

		public static Matrix2 Identity ()
		{
			Matrix2 m2;
			m2.m = new float[4];
			m2.m [0] = 1;
			m2.m [3] = 1;
			return m2;
		}

		public static Matrix2 Zero ()
		{
			Matrix2 m2;
			m2.m = new float[4];
			return m2;
		}

		public static Matrix2 Scale (float x, float y)
		{
			Matrix2 m2 = Matrix2.Zero ();
			m2 [0] = x;
			m2 [2] = y;
			return m2;
		}

		public static Matrix2 Scale (Vector2 v)
		{
			return Matrix2.Scale (v.x, v.y);
		}
			

		public static Matrix2 Rotate (float r)
		{
			Matrix2 m2 = Matrix2.Identity ();
			m2.m11 = (float)System.Math.Cos (r);
			m2.m12 = (float)System.Math.Sin (r);
			m2.m21 = (float)-System.Math.Sin (r);
			m2.m22 = (float)System.Math.Cos (r);
			return m2;
		}
			
		public static Matrix2 RotateEuler (float r)
		{
			return Matrix2.Rotate (Utils.Deg2Rad (r));
		}

		public override string ToString ()
		{
			return string.Format ("{0} {1}\n{2} {3}\n", m11, m12, m21, m22);
		}
			
		public static Vector2 operator* (Matrix2 m, Vector2 v)
		{
			Vector2 vr;
			vr.x = m.m11 * v.x + m.m12 * v.y;
			vr.y = m.m21 * v.x + m.m22 * v.y;
			return vr;

		}

		public static Matrix2 operator* (Matrix2 m0, Matrix2 m1)
		{
			Matrix2 mr;
			mr.m = new float[4];

			mr.m11 = m0.m11 * m1.m11 + m0.m12 * m1.m21;
			mr.m12 = m0.m11 * m1.m12 + m0.m12 * m1.m22;

			mr.m21 = m0.m21 * m1.m11 + m0.m22 * m1.m21;
			mr.m22 = m0.m21 * m1.m12 + m0.m22 * m1.m22;


			return mr;

		}



	}
}

