using UnityEngine;

public class BeamgunBeam : MonoBehaviour
{
	public bool active;

	[SerializeField]
	private LineRenderer line;

	[HideInInspector]
	public Vector3 fakeStartPoint;

	[SerializeField]
	private ParticleSystem hitParticle;

	private EnemyIdentifierIdentifier hitTarget;

	private Vector3 hitPosition;

	public bool canHitPlayer;

	private float beamCheckTime;

	public float beamCheckSpeed;

	private float playerDamageCooldown;

	public float beamWidth;

	private void Start()
	{
	}

	private void FixedUpdate()
	{
	}

	private void Update()
	{
	}
}
