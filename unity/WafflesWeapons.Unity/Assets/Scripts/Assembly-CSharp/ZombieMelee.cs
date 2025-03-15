using UnityEngine;
using UnityEngine.AI;

public class ZombieMelee : MonoBehaviour, IHitTargetCallback
{
	public bool harmless;

	public bool damaging;

	public TrailRenderer biteTrail;

	public TrailRenderer diveTrail;

	public bool track;

	public float coolDown;

	public Zombie zmb;

	private NavMeshAgent nma;

	private Animator anim;

	private EnemyIdentifier eid;

	private bool customStart;

	private bool musicRequested;

	private int difficulty;

	private float defaultCoolDown;

	public GameObject swingSound;

	private Rigidbody rb;

	[HideInInspector]
	public SwingCheck2 swingCheck;

	[HideInInspector]
	public SwingCheck2 diveSwingCheck;

	[HideInInspector]
	public bool diving;

	private bool inAction;

	[SerializeField]
	private Transform modelTransform;

	private TimeSince randomJumpChanceCooldown;

	private bool aboutToDive;

	[SerializeField]
	private GameObject hitGroundParticle;

	[SerializeField]
	private GameObject pullOutParticle;

	private EnemySimplifier ensim;

	public Material originalMaterial;

	public Material biteMaterial;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void FixedUpdate()
	{
	}

	public void JumpAttack()
	{
	}

	public void JumpStart()
	{
	}

	private void CheckThatJumpStarted()
	{
	}

	public void JumpEnd()
	{
	}

	public void PullOut()
	{
	}

	public void JumpEndEnd()
	{
	}

	public void Swing()
	{
	}

	public void SwingEnd()
	{
	}

	public void DamageStart()
	{
	}

	public void TargetBeenHit()
	{
	}

	public void DamageEnd()
	{
	}

	public void StopTracking()
	{
	}

	public void CancelAttack()
	{
	}

	public void TrackTick()
	{
	}

	public void MouthClose()
	{
	}

	private void MouthOpen()
	{
	}
}
