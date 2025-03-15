using UnityEngine;
using UnityEngine.AddressableAssets;

namespace ScriptableObjects
{
	[CreateAssetMenu(fileName = "Altars", menuName = "ULTRAKILL/Altars")]
	public class Altars : ScriptableObject
	{
		public AssetReference[] altarPrefabs;
	}
}
