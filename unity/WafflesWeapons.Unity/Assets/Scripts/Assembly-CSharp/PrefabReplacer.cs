using UnityEngine;

[DefaultExecutionOrder(-20)]
public class PrefabReplacer : MonoBehaviour
{
	public static bool ForceDisable;

	public static PrefabReplacer Instance;

	private void Awake()
	{
	}

	public GameObject LoadPrefab(string address)
	{
		return null;
	}

	private void PerformSwap(PlaceholderPrefab placeholder)
	{
	}

	public void ReplacePrefab(PlaceholderPrefab placeholder)
	{
	}
}
