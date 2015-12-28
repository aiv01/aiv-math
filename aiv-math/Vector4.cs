using System;

namespace Aiv.Math
{
	public struct Vector4
	{
		public float x;
		public float y;
		public float z;
		public float w;

		public Vector4 (float x, float y, float z, float w)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}

		public override string ToString ()
		{
			return string.Format ("{0}, {1}, {2}, {3}", this.x, this.y, this.z, this.w);
		}

		public static implicit operator Vector3(Vector4 v){
			return new Vector3(v.x, v.y, v.z);
		}
	}
}

