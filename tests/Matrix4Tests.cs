using NUnit.Framework;
using System;
using Aiv.Math;

namespace tests
{
	[TestFixture ()]
	public class Matrix4Tests
	{
		[SetUp]
		public void Init ()
		{
			// may look a bit low, but we are testing cameras too...
			GlobalSettings.DefaultFloatingPointTolerance = 0.01f;
		}

		[Test ()]
		public void TestCreation ()
		{
			Matrix4 m = Matrix4.Identity ();
			Assert.AreEqual (m.m11, 1);
			Assert.AreEqual (m.m22, 1);
			Assert.AreEqual (m.m33, 1);
			Assert.AreEqual (m.m44, 1);
		}

		[Test ()]
		public void TestTranslate ()
		{
			Vector3 v = new Vector3 (2, 3, 4);
			Matrix4 m = Matrix4.Translate (10, 5, 1);
			Vector4 vr = m * v;
			Assert.AreEqual (vr.x, 12);
			Assert.AreEqual (vr.y, 8);
			Assert.AreEqual (vr.z, 5);
			Assert.AreEqual (vr.w, 0);
		}

		[Test ()]
		public void TestScale ()
		{
			Vector3 v = new Vector3 (2, 3, 4);
			Matrix4 m = Matrix4.Scale (2, 0.5f, 0.5f);
			Vector4 vr = m * v;
			Assert.AreEqual (vr.x, 4);
			Assert.AreEqual (vr.y, 1.5f);
			Assert.AreEqual (vr.z, 2);
			Assert.AreEqual (vr.w, 0);
		}

		[Test ()]
		public void TestScaleTranslate ()
		{
			Vector3 v = new Vector3 (2, 3, 4);
			Matrix4 ms = Matrix4.Scale (2, 2, 2);
			Matrix4 mt = Matrix4.Translate (10, 5, 1);
			Matrix4 mr = mt * ms;
			Console.WriteLine (mr);
			Vector4 vr = mt * ms * v;
			Assert.AreEqual (vr.x, 14);
			Assert.AreEqual (vr.y, 11);
			Assert.AreEqual (vr.z, 9);
			Assert.AreEqual (vr.w, 0);
		}

		// beware of approximations during rotations !

		[Test ()]
		public void TestRotateZ ()
		{
			Vector4 v = new Vector4 (0, 4.0f, 0, 1);
			Matrix4 m = Matrix4.RotateZ (Utils.Deg2Rad (-90));
			Vector4 vr = m * v;
			Assert.AreEqual (vr.x, 4);
			Assert.AreEqual (vr.y, 0);
			Assert.AreEqual (vr.z, 0);
			Assert.AreEqual (vr.w, 1);
		}

		[Test ()]
		public void TestRotateY ()
		{
			Vector3 v = new Vector3 (0, 0, -17);
			Matrix4 m = Matrix4.RotateY (Utils.Deg2Rad (180));
			Vector4 vr = m * v;
			Assert.AreEqual (vr.x, 0);
			Assert.AreEqual (vr.y, 0);
			Assert.AreEqual (vr.z, 17);
			Assert.AreEqual (vr.w, 0);
		}

		[Test ()]
		public void TestRotateX ()
		{
			Vector3 v = new Vector3 (10, 10, -17);
			Matrix4 m = Matrix4.RotateX (Utils.Deg2Rad (90));
			Vector3 vr = m * v;
			Assert.AreEqual (vr.x, 10);
			Assert.AreEqual (vr.y, 17);
			Assert.AreEqual (vr.z, 10);
		}

		[Test ()]
		public void TestRotateEuler ()
		{
			Vector3 v = new Vector3 (17, -30, -22);
			Matrix4 m = Matrix4.RotateEuler (360, 360, 360);
			Vector3 vr = m * v;
			Assert.AreEqual (vr.x, v.x);
			Assert.AreEqual (vr.y, v.y);
			Assert.AreEqual (vr.z, v.z);
		}

		[Test ()]
		public void TestCamera ()
		{
			Vector3 v = new Vector3 (0, 1, 0);
			Matrix4 m = Matrix4.LookAt (new Vector3 (0, 1, 10), v, Vector3.up);
			Console.WriteLine (m);
			Vector3 vr = m * v;
			Assert.AreEqual (vr.x, 0);
			Assert.AreEqual (vr.y, 0);
			Assert.AreEqual (vr.z, -10);
		}
	}
}
