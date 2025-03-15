using System.Collections.Generic;
using UnityEngine;

namespace Randomness
{
	public abstract class RandomBase<T> : MonoBehaviour where T : RandomEntry, new()
	{
		public bool randomizeOnEnable;

		public bool ensureNoRepeats;

		public int toBeEnabledCount;

		public T[] entries;

		private T lastPicked;

		private bool firstDeserialization;

		private int arrayLength;

		private void OnEnable()
		{
		}

		public virtual void Randomize()
		{
		}

		public virtual void RandomizeWithCount(int count)
		{
		}

		public static T WeightedPick(List<T> pool)
		{
			return null;
		}

		public abstract void PerformTheAction(RandomEntry entry);

		private void OnValidate()
		{
		}
	}
}
