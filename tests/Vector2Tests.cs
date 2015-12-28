using NUnit.Framework;
using System;
using Aiv.Math;

namespace tests
{
	[TestFixture ()]
	public class Vector2Tests
	{
		[Test ()]
		public void TestCreation ()
		{
			Vector2 v;
			v.x = 17;
			v.y = 30;
			Assert.AreEqual (v.x, 17);
			Assert.AreEqual (v.y, 30);
			Assert.AreNotEqual (v.x, -17);
			Assert.AreNotEqual (v.y, -30);
		}

		[Test ()]
		public void TestIndexing ()
		{
			Vector2 v = new Vector2 (17, 22);
			Assert.AreEqual (v[0], 17);
			Assert.AreEqual (v[1], 22);
			v [1] = 30;
			Assert.AreEqual (v[1], 30);
		}

		[Test ()]
		[ExpectedException(typeof(IndexOutOfRangeException))]
		public void TestOutOfRange ()
		{
			Vector2 v = new Vector2 (0, 0);
			v [2] = -1;
		}

		[Test ()]
		public void TestCloning ()
		{
			Vector2 v = new Vector2 (17, 22);
			Vector2 v1 = v.Clone ();
			Assert.AreEqual (v.x, v1.x);
			Assert.AreEqual (v.y, v1.y);
		}

		[Test ()]
		public void TestSum ()
		{
			Vector2 v = new Vector2 (17, 22);
			Vector2 v1 = new Vector2 (30, 26);
			Vector2 v2 = v + v1;
			Assert.AreEqual (v2.x, 47);
			Assert.AreEqual (v2.y, 48);
			Vector2 v3 = v2 + 3;
			Assert.AreEqual (v3.x, 50);
			Assert.AreEqual (v3.y, 51);
		}

		[Test ()]
		public void TestSub ()
		{
			Vector2 v = new Vector2 (17, 22);
			Vector2 v1 = new Vector2 (30, 26);
			Vector2 v2 = v - v1;
			Assert.AreEqual (v2.x, -13);
			Assert.AreEqual (v2.y, -4);
			Vector2 v3 = v2 - 3;
			Assert.AreEqual (v3.x, -16);
			Assert.AreEqual (v3.y, -7);
		}

		[Test ()]
		public void TestMul ()
		{
			Vector2 v = new Vector2 (17, 22);
			Vector2 v1 = new Vector2 (2, 1);
			Vector2 v2 = v * v1;
			Assert.AreEqual (v2.x, 34);
			Assert.AreEqual (v2.y, 22);
			Vector2 v3 = v2 * 3;
			Assert.AreEqual (v3.x, 102);
			Assert.AreEqual (v3.y, 66);
		}

		[Test ()]
		public void TestCmp ()
		{
			Vector2 v = new Vector2 (17, 22);
			Vector2 v1 = new Vector2 (17, 22);
			Assert.False (v != v1);
			Assert.True (v == v1);
		}

		[Test ()]
		public void TestDiv ()
		{
			Vector2 v = new Vector2 (17, 22);
			Vector2 v1 = new Vector2 (1, 1);
			Vector2 v2 = v / v1;
			Assert.AreEqual (v2.x, 17);
			Assert.AreEqual (v2.y, 22);
			Vector2 v3 = v2 / 2;
			Assert.AreEqual (v3.x, 8.5f);
			Assert.AreEqual (v3.y, 11);
		}

		[Test ()]
		public void TestAdd ()
		{
			Vector2 v = new Vector2 (17, 22);
			Vector2 v1 = new Vector2 (30, 26);
			Vector2 v2 = v.Add(v1);
			Assert.AreEqual (v2.x, 47);
			Assert.AreEqual (v2.y, 48);
			Assert.AreEqual (v.x, 17);
			Assert.AreEqual (v.y, 22);
		}

	}
}

