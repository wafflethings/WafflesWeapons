using System.Collections.Generic;
using NewBlood.Rendering;
using UnityEngine;

namespace ULTRAKILL.Cheats
{
	public class NonConvexJumpDebug : ICheat
	{
		private static NonConvexJumpDebug _lastInstance;

		private List<GameObject> _debugObjects;

		public static bool Active => false;

		public string LongName => null;

		public string Identifier => null;

		public string ButtonEnabledOverride { get; }

		public string ButtonDisabledOverride { get; }

		public string Icon => null;

		public bool IsActive { get; private set; }

		public bool DefaultState { get; }

		public StatePersistenceMode PersistenceMode => default(StatePersistenceMode);

		public void Enable(CheatsManager manager)
		{
		}

		public void Disable()
		{
		}

		public static void Reset()
		{
		}

		public static void CreateBall(Color color, Vector3 position, float size = 1f)
		{
		}

		public static void CreateTri(Vector3 normal, Triangle<Vector3> triangle, Color color)
		{
		}
	}
}
