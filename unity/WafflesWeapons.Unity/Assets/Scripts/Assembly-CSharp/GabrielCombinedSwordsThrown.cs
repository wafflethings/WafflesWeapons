using UnityEngine;

public class GabrielCombinedSwordsThrown : MonoBehaviour
{
	public Transform justice;

	public Transform splendor;

	public GameObject teleportSword;

	[HideInInspector]
	public GabrielSecond gabe;

	private Transform parent;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void CreateTrail(Transform start, Transform target)
	{
	}
}
