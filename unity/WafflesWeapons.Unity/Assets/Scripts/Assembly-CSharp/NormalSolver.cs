using UnityEngine;

public static class NormalSolver
{
	private struct VertexKey
	{
		private readonly long _x;

		private readonly long _y;

		private readonly long _z;

		private const int Tolerance = 100000;

		private const long FNV32Init = 2166136261L;

		private const long FNV32Prime = 16777619L;

		public VertexKey(Vector3 position)
		{
			_x = 0L;
			_y = 0L;
			_z = 0L;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}

	private struct VertexEntry
	{
		public int MeshIndex;

		public int TriangleIndex;

		public int VertexIndex;

		public VertexEntry(int meshIndex, int triIndex, int vertIndex)
		{
			MeshIndex = 0;
			TriangleIndex = 0;
			VertexIndex = 0;
		}
	}

	public static void RecalculateNormals(this Mesh mesh, float angle)
	{
	}
}
