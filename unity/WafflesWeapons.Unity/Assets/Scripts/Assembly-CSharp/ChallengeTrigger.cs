using UnityEngine;

public class ChallengeTrigger : MonoBehaviour
{
	public ChallengeType type;

	public bool checkForNoEnemies;

	public bool evenIfPlayerDead;

	private bool colliderless;

	public bool disableOnExit;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnTriggerExit(Collider other)
	{
	}

	public void Entered()
	{
	}

	public void Exited()
	{
	}
}
