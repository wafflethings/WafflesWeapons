using UnityEngine;

public class GibDestroyer : MonoBehaviour
{
	[SerializeField]
	private AudioSource soundEffect;

	[SerializeField]
	private AudioSource rareSoundEffect;

	private TimeSince lastSound;

	private void OnTriggerEnter(Collider col)
	{
	}

	public static void LimbBegone(Collider col)
	{
	}
}
