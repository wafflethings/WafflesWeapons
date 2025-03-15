using UnityEngine;
using UnityEngine.UI;

public class Revolver : MonoBehaviour
{
	private InputManager inman;

	private WeaponIdentifier wid;

	public int gunVariation;

	public bool altVersion;

	private AudioSource gunAud;

	public AudioClip[] gunShots;

	private int currentGunShot;

	public GameObject gunBarrel;

	private bool gunReady;

	private bool shootReady;

	private bool pierceReady;

	public float shootCharge;

	public float pierceCharge;

	private bool chargingPierce;

	public float pierceShotCharge;

	public Vector3 shotHitPoint;

	public GameObject revolverBeam;

	public GameObject revolverBeamSuper;

	public AudioSource superGunSound;

	public RaycastHit hit;

	public RaycastHit[] allHits;

	private int currentHit;

	private int currentHitMultiplier;

	public float recoilFOV;

	public GameObject chargeEffect;

	private AudioSource ceaud;

	private Light celight;

	private GameObject camObj;

	private Camera cam;

	private CameraController cc;

	private Vector3 tempCamPos;

	public Vector3 beamReflectPos;

	private GameObject beamDirectionSetter;

	public MeshRenderer screenMR;

	private MaterialPropertyBlock screenProps;

	public Material batteryMat;

	public Texture2D batteryFull;

	public Texture2D batteryMid;

	public Texture2D batteryLow;

	public Texture2D[] batteryCharges;

	private AudioSource screenAud;

	public AudioClip chargedSound;

	public AudioClip chargingSound;

	public Transform twirlBone;

	private float latestTwirlRotation;

	private float twirlLevel;

	public bool twirlRecovery;

	public SpriteRenderer twirlSprite;

	public GameObject twirlShotSound;

	private GameObject currentDrip;

	public GameObject coin;

	public GameObject quickTwirlEffect;

	[HideInInspector]
	public RevolverCylinder cylinder;

	private SwitchMaterial rimLight;

	public GunControl gc;

	private Animator anim;

	private Punch punch;

	private NewMovement nmov;

	private WeaponPos wpos;

	public Image[] coinPanels;

	public bool[] coinPanelsCharged;

	private WeaponCharges wc;

	private CameraFrustumTargeter targeter;

	private float coinCharge;

	private void Start()
	{
	}

	private void OnDisable()
	{
	}

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	private void LateUpdate()
	{
	}

	private void Shoot(int shotType = 1)
	{
	}

	private void ThrowCoin()
	{
	}

	private void ReadyToShoot()
	{
	}

	public void Punch()
	{
	}

	public void ReadyGun()
	{
	}

	public void Click()
	{
	}

	public void InstaClick()
	{
	}

	public void MaxCharge()
	{
	}

	private void DelayedShoot()
	{
	}

	private void DelayedShoot2()
	{
	}

	private void CheckCoinCharges()
	{
	}
}
