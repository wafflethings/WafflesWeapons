using UnityEngine;
using UnityEngine.AI;

public class FollowNavMesh : MonoBehaviour
{
	public Transform target;

	private NavMeshAgent nma;

	public float trackFrequency;

	public bool chaseEnemies;

	public float chaseEnemiesRange;

	private void Start()
	{
	}

	private void Track()
	{
	}
}
