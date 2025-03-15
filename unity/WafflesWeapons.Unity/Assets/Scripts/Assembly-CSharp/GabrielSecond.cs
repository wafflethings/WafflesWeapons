using UnityEngine;

public class GabrielSecond : MonoBehaviour, IHitTargetCallback
{
	private Animator anim;

	private Machine mach;

	private Rigidbody rb;

	private EnemyIdentifier eid;

	private SkinnedMeshRenderer smr;

	private GabrielVoice voice;

	private Collider col;

	public GameObject particles;

	public GameObject particlesEnraged;

	private Material origBody;

	private Material origWing;

	public Material enrageBody;

	public Material enrageWing;

	private int difficulty;

	private bool valuesSet;

	private bool active;

	private bool inAction;

	private bool goingLeft;

	private bool goForward;

	private float forwardSpeed;

	private float forwardSpeedMinimum;

	private float forwardSpeedMaximum;

	private float startCooldown;

	private float attackCooldown;

	public bool enraged;

	private GameObject currentEnrageEffect;

	public bool secondPhase;

	public float phaseChangeHealth;

	private float outOfSightTime;

	private int teleportAttempts;

	private int teleportInterval;

	public GameObject teleportSound;

	public GameObject decoy;

	private bool overrideRotation;

	private bool stopRotation;

	private Vector3 overrideTarget;

	private LayerMask environmentMask;

	[Header("Swords")]
	public Transform rightHand;

	public Transform leftHand;

	private TrailRenderer rightHandTrail;

	private TrailRenderer leftHandTrail;

	[SerializeField]
	private SwingCheck2 generalSwingCheck;

	private SwingCheck2 rightSwingCheck;

	private SwingCheck2 leftSwingCheck;

	private MeshRenderer rightHandGlow;

	private MeshRenderer leftHandGlow;

	[SerializeField]
	private AudioSource swingSound;

	[SerializeField]
	private AudioSource kickSwingSound;

	[SerializeField]
	private Renderer[] swordRenderers;

	[SerializeField]
	private GameObject fakeCombinedSwords;

	[SerializeField]
	private Projectile combinedSwordsThrown;

	private Projectile currentCombinedSwordsThrown;

	[HideInInspector]
	public bool swordsCombined;

	private float combinedSwordsCooldown;

	[HideInInspector]
	public bool lightSwords;

	[Space(20f)]
	public TrailRenderer kickTrail;

	public GameObject dashEffect;

	private bool dashing;

	private float forcedDashTime;

	private Vector3 dashTarget;

	private float[] moveChanceBonuses;

	private int previousMove;

	private int burstLength;

	private bool juggled;

	private float juggleHp;

	private float juggleEndHp;

	private float juggleLength;

	public GameObject juggleEffect;

	private bool juggleFalling;

	public GameObject summonedSwords;

	private GameObject currentSwords;

	public GameObject summonedSwordsWindup;

	private GameObject currentWindup;

	private float summonedSwordsCooldown;

	public Transform head;

	private bool readyTaunt;

	private float defaultAnimSpeed;

	private bool bossVersion;

	[SerializeField]
	private GameObject genericOutro;

	public bool ceilingHitChallenge;

	[SerializeField]
	private GameObject ceilingHitEffect;

	private float ceilingHitCooldown;

	[Header("Events")]
	public UltrakillEvent onFirstPhaseEnd;

	public UltrakillEvent onSecondPhaseStart;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void SetValues()
	{
	}

	private void UpdateBuff()
	{
	}

	private void UpdateSpeed()
	{
	}

	private void OnDisable()
	{
	}

	private void OnEnable()
	{
	}

	private void UpdateRigidbodySettings()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	private void BasicCombo()
	{
	}

	private void FastComboDash()
	{
	}

	private void FastCombo()
	{
	}

	private void ThrowCombo()
	{
	}

	private void CombineSwords()
	{
	}

	private void Gattai()
	{
	}

	private void CombinedSwordAttack()
	{
	}

	public void UnGattai(bool destroySwords = true)
	{
	}

	private void CheckIfSwordsCombined()
	{
	}

	private void CreateLightSwords()
	{
	}

	private void ThrowSwords()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	public void Teleport(bool closeRange = false, bool longrange = false, bool firstTime = true, bool horizontal = false, bool vertical = false)
	{
	}

	public GameObject CreateDecoy(Vector3 position, float transparencyOverride = 1f, Animator animatorOverride = null)
	{
		return null;
	}

	private void StartDash()
	{
	}

	private void Parryable()
	{
	}

	private void AttackFlash(int unparryable = 0)
	{
	}

	private void JuggleStart()
	{
	}

	private void JuggleStop(bool enrage = false)
	{
	}

	private void EnrageAnimation()
	{
	}

	public void EnrageNow()
	{
	}

	private void ForceUnEnrage()
	{
	}

	public void UnEnrage()
	{
	}

	private void RandomizeDirection()
	{
	}

	public void DamageStartLeft(int damage)
	{
	}

	public void DamageStopLeft(int keepMoving)
	{
	}

	public void DamageStartRight(int damage)
	{
	}

	public void DamageStopRight(int keepMoving)
	{
	}

	public void DamageStartKick(int damage)
	{
	}

	public void DamageStopKick(int keepMoving)
	{
	}

	public void DamageStartBoth(int damage)
	{
	}

	public void DamageStopBoth(int keepMoving)
	{
	}

	public void SetForwardSpeed(int newSpeed)
	{
	}

	public void EnrageTeleport(int teleportType = 0)
	{
	}

	private void ResetAnimSpeed()
	{
	}

	public void LookAtTarget(int instant = 0)
	{
	}

	public void FollowTarget()
	{
	}

	public void StopAction()
	{
	}

	public void ResetWingMat()
	{
	}

	public void Death()
	{
	}

	private void SetDamage(int damage)
	{
	}

	public void TargetBeenHit()
	{
	}

	private void DecideMovementSpeed(float normal, float longDistance)
	{
	}

	private void SpawnSummonedSwordsWindup()
	{
	}

	private void SpawnSummonedSwords()
	{
	}
}
