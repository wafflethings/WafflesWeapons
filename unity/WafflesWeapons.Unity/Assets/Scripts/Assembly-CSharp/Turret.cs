using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using plog;

public class Turret : MonoBehaviour
{
	private static readonly plog.Logger Log;

	public bool stationary;

	public bool quickStart;

	private Vector3 stationaryPosition;

	private NavMeshPath path;

	private Vector3 aimPos;

	[HideInInspector]
	public bool lodged;

	[HideInInspector]
	public bool aiming;

	private float outOfSightTimer;

	private float aimTime;

	private float maxAimTime;

	private float flashTime;

	private float nextBeepTime;

	private bool whiteLine;

	private Color defaultColor;

	private Vector3 lastPlayerPosition;

	private int shotsInARow;

	private TimeSince sinceLastBeep;

	private int difficulty;

	private float cooldown;

	private float kickCooldown;

	[HideInInspector]
	public bool inAction;

	private bool bodyRotate;

	private bool bodyTrackPlayer;

	private bool bodyReset;

	private Quaternion currentBodyRotation;

	private bool walking;

	private Vector3 walkTarget;

	public Color defaultLightsColor;

	public Color attackingLightsColor;

	private float lightsIntensityTarget;

	private float currentLightsIntensity;

	[Header("Defaults")]
	[SerializeField]
	private Transform torso;

	[SerializeField]
	private Transform turret;

	[SerializeField]
	private Transform shootPoint;

	[SerializeField]
	private LineRenderer aimLine;

	[SerializeField]
	private RevolverBeam beam;

	[SerializeField]
	private GameObject warningFlash;

	[SerializeField]
	private ParticleSystem antennaFlash;

	[SerializeField]
	private Light antennaLight;

	[SerializeField]
	private AudioSource antennaSound;

	[SerializeField]
	private Animator anim;

	[SerializeField]
	private Machine mach;

	[SerializeField]
	private EnemyIdentifier eid;

	[SerializeField]
	private GameObject head;

	[SerializeField]
	private NavMeshAgent nma;

	public GameObject antenna;

	public List<Transform> interruptables;

	[SerializeField]
	private AudioSource interruptSound;

	[SerializeField]
	private AudioSource cancelSound;

	[SerializeField]
	private AudioSource footStep;

	[SerializeField]
	private AudioSource extendSound;

	[SerializeField]
	private AudioSource thunkSound;

	[SerializeField]
	private AudioSource kickWarningSound;

	[SerializeField]
	private AudioSource aimWarningSound;

	private AudioSource currentSound;

	[SerializeField]
	private GameObject rubble;

	[SerializeField]
	private GameObject rubbleLeft;

	[SerializeField]
	private GameObject rubbleRight;

	private bool leftLodged;

	private bool rightLodged;

	[SerializeField]
	private SkinnedMeshRenderer smr;

	[SerializeField]
	private GameObject unparryableFlash;

	[SerializeField]
	private SwingCheck2 sc;

	[SerializeField]
	private TrailRenderer tr;

	private EnemyTarget target => null;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void UpdateBuff()
	{
	}

	private void OnEnable()
	{
	}

	private void SlowUpdate()
	{
	}

	private void Update()
	{
	}

	private void LateUpdate()
	{
	}

	private void StartWindup()
	{
	}

	private void BodyTrack()
	{
	}

	private void BodyFreeze()
	{
	}

	private void BodyReset()
	{
	}

	private void StartAiming()
	{
	}

	private void Kick()
	{
	}

	private void StopAction()
	{
	}

	private void AimAt(Vector3 position)
	{
	}

	private void Shoot()
	{
	}

	private void PreReAim()
	{
	}

	private void ReAim()
	{
	}

	private void ChangeLineColor(Color clr)
	{
	}

	public void CancelAim(bool instant = false)
	{
	}

	public void LodgeFoot(int type)
	{
	}

	public void UnlodgeFoot(int type)
	{
	}

	public void Unlodge()
	{
	}

	public void Interrupt()
	{
	}

	public void OnDeath()
	{
	}

	private void FootStep(float targetPitch)
	{
	}

	private void Thunk()
	{
	}

	private void ExtendBarrel()
	{
	}

	private void GotParried()
	{
	}

	public void UnparryableFlash()
	{
	}

	public void DamageStart()
	{
	}

	public void DamageStop()
	{
	}

	public void ChangeLightsColor(Color target)
	{
	}

	public void ChangeLightsIntensity(float amount)
	{
	}
}
