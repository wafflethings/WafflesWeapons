using UnityEngine;

public class Railcannon : MonoBehaviour
{
	public int variation;

	public GameObject beam;

	public Transform shootPoint;

	public GameObject fullCharge;

	public GameObject fireSound;

	private AudioSource fullAud;

	private bool pitchRise;

	private InputManager inman;

	public WeaponIdentifier wid;

	private float gotWidDelay;

	private AudioSource aud;

	private CameraController cc;

	private Camera cam;

	private GunControl gc;

	private Animator anim;

	public SkinnedMeshRenderer body;

	public SkinnedMeshRenderer[] pips;

	private WeaponCharges wc;

	private WeaponPos wpos;

	private bool zooming;

	private bool gotStuff;

	private MaterialPropertyBlock propBlock;

	private static readonly int EmissiveIntensityID;

	private CameraFrustumTargeter targeter;

	private float altCharge;

	[SerializeField]
	private Light fullChargeLight;

	[SerializeField]
	private ParticleSystem fullChargeParticles;

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

	private void SetMaterialIntensity(float newIntensity, bool isRecharging)
	{
	}

	private void Shoot()
	{
	}

	private void GetStuff()
	{
	}
}
