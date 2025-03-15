using UnityEngine;

public class Gabriel : MonoBehaviour
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

	public Transform rightHand;

	public Transform leftHand;

	private GameObject rightHandWeapon;

	private GameObject leftHandWeapon;

	private WeaponTrail rightHandTrail;

	private WeaponTrail leftHandTrail;

	private SwingCheck2 rightSwingCheck;

	private SwingCheck2 leftSwingCheck;

	public GameObject sword;

	public GameObject zweiHander;

	public GameObject axe;

	public GameObject spear;

	public GameObject glaive;

	private bool spearing;

	private int spearAttacks;

	private bool dashing;

	private float forcedDashTime;

	private Vector3 dashTarget;

	public GameObject dashEffect;

	private int throws;

	private GameObject thrownObject;

	private bool threwAxes;

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

	private int dashAttempts;

	private EnemyTarget target => null;

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

	private void StingerCombo()
	{
	}

	private void SpearCombo()
	{
	}

	private void ZweiDash()
	{
	}

	private void StartDash()
	{
	}

	private void ZweiCombo()
	{
	}

	private void AxeThrow()
	{
	}

	private void SpearAttack()
	{
	}

	private void SpearFlash()
	{
	}

	private void SpearGoHorizontal()
	{
	}

	private void SpearGo()
	{
	}

	private void JuggleStart()
	{
	}

	private void JuggleStop(bool enrage = false)
	{
	}

	private void Enrage()
	{
	}

	public void EnrageNow()
	{
	}

	public void UnEnrage()
	{
	}

	private void SpearThrow()
	{
	}

	private void ThrowWeapon(GameObject projectile)
	{
	}

	private void CheckForThrown()
	{
	}

	public void EnableWeapon()
	{
	}

	public void DisableWeapon()
	{
	}

	private void RandomizeDirection()
	{
	}

	private void SpawnLeftHandWeapon(GabrielWeaponType weapon)
	{
	}

	private void SpawnRightHandWeapon(GabrielWeaponType weapon)
	{
	}

	private GameObject GetWeaponGameObject(GabrielWeaponType weapon)
	{
		return null;
	}

	private SwingCheck2 WeaponHitBox(GabrielWeaponType weapon)
	{
		return null;
	}

	private SwingCheck2 CreateHitBox(Vector3 position, Vector3 size, bool ignoreSlide = false)
	{
		return null;
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

	private void SpawnSummonedSwordsWindup()
	{
	}

	private void SpawnSummonedSwords()
	{
	}
}
