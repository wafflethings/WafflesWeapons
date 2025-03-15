using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Nailgun : MonoBehaviour
{
	private InputManager inman;

	private WeaponIdentifier wid;

	public int variation;

	public bool altVersion;

	public GameObject[] shootPoints;

	private Spin[] barrels;

	private float spinSpeed;

	private int barrelNum;

	private Light[] barrelLights;

	[SerializeField]
	private Renderer[] barrelHeats;

	private float heatUp;

	private bool burnOut;

	public GameObject muzzleFlash;

	public GameObject muzzleFlash2;

	public AudioSource snapSound;

	public float fireRate;

	private float currentFireRate;

	private float fireCooldown;

	private AudioSource aud;

	private AudioSource barrelAud;

	public GameObject nail;

	public GameObject heatedNail;

	public GameObject magnetNail;

	public AudioSource magnetShotSound;

	private CameraController cc;

	public float spread;

	private float currentSpread;

	private int burstAmount;

	private Animator anim;

	private bool canShoot;

	private NewMovement nm;

	[Header("Magnet")]
	public Text ammoText;

	public GameObject noAmmoSound;

	public GameObject lastShotSound;

	private float harpoonCharge;

	private bool shotSuccesfully;

	[Header("Overheat")]
	public Color emptyColor;

	public Color fullColor;

	private Slider heatSlider;

	private Image sliderBg;

	private float heatSinks;

	private float heatSinkFill;

	public Image[] heatSinkImages;

	private ParticleSystem heatSteam;

	private AudioSource heatSteamAud;

	private float heatCharge;

	[Header("Zapper")]
	public Zapper zapper;

	private Zapper currentZapper;

	public Transform zapperAttachTransform;

	[SerializeField]
	private TMP_Text statusText;

	[SerializeField]
	private Slider distanceMeter;

	[SerializeField]
	private Slider zapMeter;

	[SerializeField]
	private Image warningX;

	[SerializeField]
	private GameObject rechargingOverlay;

	[SerializeField]
	private Image rechargingMeter;

	private WeaponCharges wc;

	private WeaponPos wpos;

	private GunControl gc;

	private bool lookingForValue;

	private CameraFrustumTargeter targeter;

	private MaterialPropertyBlock heatProps;

	private Color heatColor;

	private string[] projectileVariationTypes;

	private void Awake()
	{
	}

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

	private void UpdateZapHud()
	{
	}

	private void FixedUpdate()
	{
	}

	private void UpdateAnimationWeight()
	{
	}

	private void SetHeat(float heat)
	{
	}

	private void Shoot()
	{
	}

	public void BurstFire()
	{
	}

	public void SuperSaw()
	{
	}

	public void ShootMagnet()
	{
	}

	public void ShootZapper()
	{
	}

	public void CanShoot()
	{
	}

	private void MaxCharge()
	{
	}

	private void RefreshHeatSinkFill(float charge, bool playSound = false)
	{
	}

	public void SnapSound()
	{
	}

	private int CorrectVariation()
	{
		return 0;
	}
}
