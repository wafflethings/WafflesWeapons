using UnityEngine;

public class SecondaryRevolver : MonoBehaviour
{
	private int bulletForce;

	private GameObject camObj;

	private Camera cam;

	public RaycastHit hit;

	private bool gunReady;

	public Vector3 shotHitPoint;

	private bool shootReady;

	private float shootCharge;

	private int currentGunShot;

	private AudioSource gunAud;

	public Revolver rev;

	public GameObject secBeamPoint;

	public GameObject secHitParticle;

	private GameObject gunBarrel;

	private Vector3 defaultGunPos;

	private Quaternion defaultGunRot;

	private MeshRenderer screenMR;

	private CameraFrustumTargeter targeter;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDisable()
	{
	}

	public void PickUp()
	{
	}

	private void Update()
	{
	}

	public void Shoot()
	{
	}

	private void ReadyToShoot()
	{
	}
}
