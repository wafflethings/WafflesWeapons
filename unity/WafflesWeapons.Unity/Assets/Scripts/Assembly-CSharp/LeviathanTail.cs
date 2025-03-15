using UnityEngine;

public class LeviathanTail : MonoBehaviour, IHitTargetCallback
{
	private SwingCheck2[] tails;

	public Vector3[] spawnPositions;

	public Vector3[] secondSpawnPositions;

	private int previousSpawnPosition;

	private Animator anim;

	[HideInInspector]
	public LeviathanController lcon;

	[SerializeField]
	private AudioSource swingSound;

	[SerializeField]
	private AudioSource[] spawnAuds;

	[SerializeField]
	private AudioClip swingHighSound;

	[SerializeField]
	private AudioClip swingLowSound;

	private bool idling;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public void TargetBeenHit()
	{
	}

	private void SwingStart()
	{
	}

	public void SwingEnd()
	{
	}

	private void ActionOver()
	{
	}

	public void ChangePosition()
	{
	}

	private void BigSplash()
	{
	}

	private float GetAnimSpeed()
	{
		return 0f;
	}

	public void Death()
	{
	}
}
