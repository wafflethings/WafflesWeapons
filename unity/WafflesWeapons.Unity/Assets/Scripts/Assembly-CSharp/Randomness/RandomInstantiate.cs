using System.Collections.Generic;
using UnityEngine;

namespace Randomness
{
	public class RandomInstantiate : RandomBase<RandomGameObjectEntry>
	{
		public bool removePreviousOnRandomize;

		[SerializeField]
		private InstantiateObjectMode mode;

		public bool reParent;

		public bool useOwnPosition;

		public bool useOwnRotation;

		private List<GameObject> createdObjects;

		public override void PerformTheAction(RandomEntry entry)
		{
		}

		public override void RandomizeWithCount(int count)
		{
		}
	}
}
