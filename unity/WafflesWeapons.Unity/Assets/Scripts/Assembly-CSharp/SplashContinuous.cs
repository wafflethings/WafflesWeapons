using UnityEngine;
using UnityEngine.AI;

public class SplashContinuous : MonoBehaviour
{
	private bool active;

	private float cooldown;

	[SerializeField]
	private Water.WaterGOType waterGOType;

	[SerializeField]
	private ParticleSystem particles;

	[SerializeField]
	private GameObject wadingSound;

	[SerializeField]
	private AudioClip[] wadingSounds;

	[SerializeField]
	private float wadingSoundPitch;

	private Vector3 previousPosition;

	[SerializeField]
	private float movingEmissionRate;

	[SerializeField]
	private float stillEmissionRate;

	[HideInInspector]
	public NavMeshAgent nma;

	private PooledWaterStore waterStore;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void FixedUpdate()
	{
	}

	public void ReturnSoon()
	{
	}

	private void ReturnToQueue()
	{
	}
}
