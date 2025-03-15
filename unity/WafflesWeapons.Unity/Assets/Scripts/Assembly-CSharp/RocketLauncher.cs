using UnityEngine;
using UnityEngine.UI;

public class RocketLauncher : MonoBehaviour
{
	public int variation;

	public GameObject rocket;

	public GameObject clunkSound;

	public float rateOfFire;

	private float cooldown;

	private bool lookingForValue;

	private AudioSource aud;

	private Animator anim;

	private WeaponIdentifier wid;

	public Transform shootPoint;

	public GameObject muzzleFlash;

	[SerializeField]
	private Image timerMeter;

	[SerializeField]
	private RectTransform timerArm;

	[SerializeField]
	private Image[] variationColorables;

	private float[] colorablesTransparencies;

	private WeaponPos wpos;

	[Header("Freeze variation")]
	[SerializeField]
	private AudioSource timerFreezeSound;

	[SerializeField]
	private AudioSource timerUnfreezeSound;

	[SerializeField]
	private AudioSource timerTickSound;

	[HideInInspector]
	public AudioSource currentTimerTickSound;

	[SerializeField]
	private AudioSource timerWindupSound;

	private float lastKnownTimerAmount;

	[Header("Cannonball variation")]
	public Rigidbody cannonBall;

	[SerializeField]
	private AudioSource chargeSound;

	private float cbCharge;

	private bool firingCannonball;

	[Header("Napalm variation")]
	[SerializeField]
	private Rigidbody napalmProjectile;

	private float napalmProjectileCooldown;

	[SerializeField]
	private Transform napalmMuzzleFlashTransform;

	[SerializeField]
	private ParticleSystem napalmMuzzleFlashParticles;

	[SerializeField]
	private AudioSource[] napalmMuzzleFlashSounds;

	[SerializeField]
	private AudioSource napalmStopSound;

	[SerializeField]
	private AudioSource napalmNoAmmoSound;

	private bool firingNapalm;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	public void Shoot()
	{
	}

	public void ShootCannonball()
	{
	}

	public void ShootNapalm()
	{
	}

	public void FreezeRockets()
	{
	}

	public void UnfreezeRockets()
	{
	}

	public void Clunk(float pitch)
	{
	}
}
