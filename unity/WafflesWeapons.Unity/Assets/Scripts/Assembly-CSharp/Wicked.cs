using UnityEngine;
using UnityEngine.AI;

public class Wicked : MonoBehaviour
{
	public Transform[] patrolPoints;

	public Transform targetPoint;

	private GameObject player;

	public float playerSpotTime;

	private AudioSource aud;

	private NavMeshAgent nma;

	private Animator anim;

	public GameObject hitSound;

	private bool lineOfSight;

	private EnemyIdentifier eid;

	public bool alwaysRunning;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void GetHit()
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
	}

	public void AlwaysRunning(bool isOn)
	{
	}
}
