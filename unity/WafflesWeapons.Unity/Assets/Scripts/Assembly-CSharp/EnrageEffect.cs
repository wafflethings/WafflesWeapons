using UnityEngine;

public class EnrageEffect : MonoBehaviour
{
	public GameObject endSound;

	public bool noParticle;

	[HideInInspector]
	public bool activated;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}
}
