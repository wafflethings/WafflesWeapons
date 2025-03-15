using UnityEngine;

public class DeathSequence : MonoBehaviour
{
	private UnscaledTimeSince timeSinceDeath;

	[SerializeField]
	private GameObject deathScreen;

	private bool sequenceOver;

	private AudioSource aud;

	private TextAppearByLines tabl;

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	public void EndSequence()
	{
	}

	private void OnDisable()
	{
	}
}
