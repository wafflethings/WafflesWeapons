using System.Collections.Generic;
using UnityEngine;

public class ThrownSword : MonoBehaviour
{
	public EnemyIdentifier thrownBy;

	public Vector3 targetPos;

	public Transform returnTransform;

	public bool active;

	public float speed;

	private bool returning;

	private bool calledReturn;

	public int type;

	public bool friendly;

	public bool deflected;

	private bool hittingPlayer;

	[HideInInspector]
	public bool thrownAtVoid;

	private TimeSince timeSince;

	private List<EnemyIdentifier> hitEnemies;

	private int difficulty;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void SetPoints(Vector3 target, Transform origin)
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void RecheckPlayerHit()
	{
	}

	private void Return()
	{
	}

	public void GetParried()
	{
	}
}
