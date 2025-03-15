using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shotgun : MonoBehaviour
{
	private InputManager inman;

	private WeaponIdentifier wid;

	private AudioSource gunAud;

	public AudioClip shootSound;

	public AudioClip shootSound2;

	public AudioClip clickSound;

	public AudioClip clickChargeSound;

	public AudioClip smackSound;

	public AudioClip pump1sound;

	public AudioClip pump2sound;

	public int variation;

	public GameObject bullet;

	public GameObject grenade;

	public float spread;

	private bool smallSpread;

	private Animator anim;

	private GameObject cam;

	private CameraController cc;

	private GunControl gc;

	private bool gunReady;

	public Transform[] shootPoints;

	public GameObject muzzleFlash;

	public SkinnedMeshRenderer heatSinkSMR;

	private Color tempColor;

	private bool releasingHeat;

	[SerializeField]
	private ParticleSystem[] heatReleaseParticles;

	private AudioSource heatSinkAud;

	private RaycastHit[] rhits;

	private bool charging;

	private float grenadeForce;

	private Vector3 grenadeVector;

	private Slider chargeSlider;

	public Image sliderFill;

	public GameObject grenadeSoundBubble;

	public GameObject chargeSoundBubble;

	private AudioSource tempChargeSound;

	[HideInInspector]
	public int primaryCharge;

	private bool cockedBack;

	public GameObject explosion;

	public GameObject pumpChargeSound;

	public GameObject warningBeep;

	private float timeToBeep;

	[SerializeField]
	private Chainsaw chainsaw;

	private List<Chainsaw> currentChainsaws;

	[SerializeField]
	private Transform chainsawAttachPoint;

	[SerializeField]
	private ScrollingTexture chainsawBladeScroll;

	private MeshRenderer chainsawBladeRenderer;

	private Material chainsawBladeMaterial;

	[SerializeField]
	private Material chainsawBladeMotionMaterial;

	[SerializeField]
	private HurtZone sawZone;

	[SerializeField]
	private ParticleSystem environmentalSawSpark;

	[SerializeField]
	private AudioSource environmentalSawSound;

	private WeaponPos wpos;

	private CameraFrustumTargeter targeter;

	private bool meterOverride;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	private void UpdateMeter()
	{
	}

	private void Shoot()
	{
	}

	private void ShootSinks()
	{
	}

	private void ShootSaw()
	{
	}

	private void Pump()
	{
	}

	public void ReleaseHeat()
	{
	}

	public void ClickSound()
	{
	}

	public void ReadyGun()
	{
	}

	public void Smack()
	{
	}

	public void SkipShoot()
	{
	}

	public void Pump1Sound()
	{
	}

	public void Pump2Sound()
	{
	}
}
