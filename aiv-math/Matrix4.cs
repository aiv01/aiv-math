using System;

namespace Aiv.Math
{
	public struct Matrix4
	{
		public float[] m;

		public float m11 { get { return this.m [0]; } set { this.m [0] = value; } }

		public float m12 { get { return this.m [1]; } set { this.m [1] = value; } }

		public float m13 { get { return this.m [2]; } set { this.m [2] = value; } }

		public float m14 { get { return this.m [3]; } set { this.m [3] = value; } }

		public float m21 { get { return this.m [4]; } set { this.m [4] = value; } }

		public float m22 { get { return this.m [5]; } set { this.m [5] = value; } }

		public float m23 { get { return this.m [6]; } set { this.m [6] = value; } }

		public float m24 { get { return this.m [7]; } set { this.m [7] = value; } }

		public float m31 { get { return this.m [8]; } set { this.m [8] = value; } }

		public float m32 { get { return this.m [9]; } set { this.m [9] = value; } }

		public float m33 { get { return this.m [10]; } set { this.m [10] = value; } }

		public float m34 { get { return this.m [11]; } set { this.m [11] = value; } }

		public float m41 { get { return this.m [12]; } set { this.m [12] = value; } }

		public float m42 { get { return this.m [13]; } set { this.m [13] = value; } }

		public float m43 { get { return this.m [14]; } set { this.m [14] = value; } }

		public float m44 { get { return this.m [15]; } set { this.m [15] = value; } }

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
				int pos = i * 4 + j;
				return this.m [pos];
			}
			set {
				int pos = i * 4 + j;
				this.m [pos] = value;
			}
		}

		public static Matrix4 Identity ()
		{
			Matrix4 m4;
			m4.m = new float[16];
			m4 [0] = 1;
			m4 [5] = 1;
			m4 [10] = 1;
			m4 [15] = 1;
			return m4;
		}

		public static Matrix4 Zero ()
		{
			Matrix4 m4;
			m4.m = new float[16];
			return m4;
		}

		public static Matrix4 Translate (float x, float y, float z)
		{
			Matrix4 m4 = Matrix4.Identity ();
			m4.m14 = x;
			m4.m24 = y;
			m4.m34 = z;
			return m4;
		}

		public static Matrix4 Translate (Vector3 v)
		{
			return Matrix4.Translate (v.x, v.y, v.z);
		}

		public static Matrix4 Scale (float x, float y, float z)
		{
			Matrix4 m4 = Matrix4.Zero ();
			m4 [0] = x;
			m4 [5] = y;
			m4 [10] = z;
			m4 [15] = 1;
			return m4;
		}

		public static Matrix4 Scale (Vector3 v)
		{
			return Matrix4.Scale (v.x, v.y, v.z);
		}

		public static Matrix4 RotateX (float r)
		{
			Matrix4 m4 = Matrix4.Identity ();
			m4.m22 = (float)System.Math.Cos (r);
			m4.m23 = (float)-System.Math.Sin (r);
			m4.m32 = (float)System.Math.Sin (r);
			m4.m33 = (float)System.Math.Cos (r);
			return m4;
		}

		public static Matrix4 RotateY (float r)
		{
			Matrix4 m4 = Matrix4.Identity ();
			m4.m11 = (float)System.Math.Cos (r);
			m4.m13 = (float)System.Math.Sin (r);
			m4.m31 = (float)-System.Math.Sin (r);
			m4.m33 = (float)System.Math.Cos (r);
			return m4;
		}

		public static Matrix4 RotateZ (float r)
		{
			Matrix4 m4 = Matrix4.Identity ();
			m4.m11 = (float)System.Math.Cos (r);
			m4.m12 = (float)-System.Math.Sin (r);
			m4.m21 = (float)System.Math.Sin (r);
			m4.m22 = (float)System.Math.Cos (r);
			return m4;
		}

		public static Matrix4 Rotate (float x, float y, float z)
		{
			return Matrix4.RotateX (x) * Matrix4.RotateX (y) * Matrix4.RotateX (z);
		}

		public static Matrix4 Rotate (Vector3 v)
		{
			return Matrix4.Rotate (v.x, v.y, v.z);
		}

		public static Matrix4 RotateEuler (float x, float y, float z)
		{
			return Matrix4.RotateX (Utils.Deg2Rad (x)) * Matrix4.RotateX (Utils.Deg2Rad (y)) * Matrix4.RotateX (Utils.Deg2Rad (z));
		}

		public static Matrix4 RotateEuler (Vector3 v)
		{
			return Matrix4.RotateEuler (v.x, v.y, v.z);
		}

		public override string ToString ()
		{
			return string.Format ("{0} {1} {2} {3}\n{4} {5} {6} {7}\n{8} {9} {10} {11}\n{12} {13} {14} {15}\n", m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34, m41, m42, m43, m44);
		}

		public static Vector4 operator* (Matrix4 m, Vector4 v)
		{
			Vector4 vr;
			vr.x = m.m11 * v.x + m.m12 * v.y + m.m13 * v.z + m.m14 * v.w;
			vr.y = m.m21 * v.x + m.m22 * v.y + m.m23 * v.z + m.m24 * v.w;
			vr.z = m.m31 * v.x + m.m32 * v.y + m.m33 * v.z + m.m34 * v.w;
			vr.w = m.m41 * v.x + m.m42 * v.y + m.m43 * v.z + m.m44 * v.w;
			return vr;

		}

		public static Vector3 operator* (Matrix4 m, Vector3 v)
		{
			Vector3 vr;
			vr.x = m.m11 * v.x + m.m12 * v.y + m.m13 * v.z + m.m14;
			vr.y = m.m21 * v.x + m.m22 * v.y + m.m23 * v.z + m.m24;
			vr.z = m.m31 * v.x + m.m32 * v.y + m.m33 * v.z + m.m34;
			return vr;

		}

		public static Matrix4 operator* (Matrix4 m0, Matrix4 m1)
		{
			Matrix4 mr;
			mr.m = new float[16];

			mr.m11 = m0.m11 * m1.m11 + m0.m12 * m1.m21 + m0.m13 * m1.m31 + m0.m14 * m1.m41;
			mr.m12 = m0.m11 * m1.m12 + m0.m12 * m1.m22 + m0.m13 * m1.m32 + m0.m14 * m1.m42;
			mr.m13 = m0.m11 * m1.m13 + m0.m12 * m1.m23 + m0.m13 * m1.m33 + m0.m14 * m1.m43;
			mr.m14 = m0.m11 * m1.m14 + m0.m12 * m1.m24 + m0.m13 * m1.m34 + m0.m14 * m1.m44;

			mr.m21 = m0.m21 * m1.m11 + m0.m22 * m1.m21 + m0.m23 * m1.m31 + m0.m24 * m1.m41;
			mr.m22 = m0.m21 * m1.m12 + m0.m22 * m1.m22 + m0.m23 * m1.m32 + m0.m24 * m1.m42;
			mr.m23 = m0.m21 * m1.m13 + m0.m22 * m1.m23 + m0.m23 * m1.m33 + m0.m24 * m1.m43;
			mr.m24 = m0.m21 * m1.m14 + m0.m22 * m1.m24 + m0.m23 * m1.m34 + m0.m24 * m1.m44;

			mr.m31 = m0.m31 * m1.m11 + m0.m32 * m1.m21 + m0.m33 * m1.m31 + m0.m34 * m1.m41;
			mr.m32 = m0.m31 * m1.m12 + m0.m32 * m1.m22 + m0.m33 * m1.m32 + m0.m34 * m1.m42;
			mr.m33 = m0.m31 * m1.m13 + m0.m32 * m1.m23 + m0.m33 * m1.m33 + m0.m34 * m1.m43;
			mr.m34 = m0.m31 * m1.m14 + m0.m32 * m1.m24 + m0.m33 * m1.m34 + m0.m34 * m1.m44;

			mr.m41 = m0.m41 * m1.m11 + m0.m42 * m1.m21 + m0.m43 * m1.m31 + m0.m44 * m1.m41;
			mr.m42 = m0.m41 * m1.m12 + m0.m42 * m1.m22 + m0.m43 * m1.m32 + m0.m44 * m1.m42;
			mr.m43 = m0.m41 * m1.m13 + m0.m42 * m1.m23 + m0.m43 * m1.m33 + m0.m44 * m1.m43;
			mr.m44 = m0.m41 * m1.m14 + m0.m42 * m1.m24 + m0.m43 * m1.m34 + m0.m44 * m1.m44;


			return mr;

		}


		public static Matrix4 LookAt (Vector3 eye, Vector3 target, Vector3 up)
		{
			// first of all find the forward vector (normalized, as it is a direction)
			Vector3 fwd = (target - eye).Normalize ();

			// find the side vector (normalized)
			Vector3 side = Vector3.Cross (fwd, up).Normalize ();

			// and recompute the up vector (no need of normalization as both fwd and right are normalized)
			up = Vector3.Cross (side, fwd);

			Matrix4 m4;
			m4.m = new float[16];

			m4.m11 = side.x;
			m4.m21 = side.y;
			m4.m31 = side.z;
			m4.m41 = 0;

			m4.m12 = up.x;
			m4.m22 = up.y;
			m4.m32 = up.z;
			m4.m42 = 0;

			m4.m13 = -fwd.x;
			m4.m23 = -fwd.y;
			m4.m33 = -fwd.z;
			m4.m43 = 0;

			m4.m14 = -eye.x;
			m4.m24 = -eye.y;
			m4.m34 = -eye.z;
			m4.m44 = 1;

			return m4;

		}

		public static Matrix4 Frustum (float left, float right, float top, float bottom, float near, float far)
		{
			Matrix4 m4;
			m4.m = new float[16];

			float x = 2 * near / (right - left);
			float y = 2 * near / (top - bottom);

			float a = (right + left) / (right - left);
			float b = (top + bottom) / (top - bottom);
			float c = -(far + near) / (far - near);
			float d = -2 * far * near / (far - near);

			m4.m11 = x;
			m4.m13 = a;

			m4.m22 = y;
			m4.m23 = b;

			m4.m33 = c;
			m4.m34 = d;

			m4.m43 = -1;

			return m4;
		}

		public static Matrix4 Perspective (float fov, float aspect, float near, float far)
		{
			float ymax = near * (float)System.Math.Tan (fov);
			float ymin = -ymax;
			float xmin = ymin * aspect;
			float xmax = ymax * aspect;

			return Matrix4.Frustum (xmin, xmax, ymin, ymax, near, far);
		}
	}
}

