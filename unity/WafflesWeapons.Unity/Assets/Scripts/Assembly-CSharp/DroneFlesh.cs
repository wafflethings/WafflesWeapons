using UnityEngine;

public class DroneFlesh : MonoBehaviour
{
	public GameObject beam;

	public GameObject warningBeam;

	public GameObject chargeEffect;

	private GameObject currentWarningBeam;

	private GameObject currentChargeEffect;

	private AudioSource ceAud;

	private Light ceLight;

	private float cooldown;

	private bool inAction;

	private Drone drn;

	private EnemyIdentifier eid;

	private bool tracking;

	public Transform shootPoint;

	public float predictionAmount;

	public Vector3 rotationOffset;

	private int difficulty;

	private float difficultySpeedModifier;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void PrepareBeam()
	{
	}

	private void StopTracking()
	{
	}

	private void ShootBeam()
	{
	}

	public void Explode()
	{
	}
}
