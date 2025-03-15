using System.Collections.Generic;
using UnityEngine;

public class FleshPrison : MonoBehaviour
{
	public Transform rotationBone;

	private Collider col;

	private Animator anim;

	public bool altVersion;

	private Texture currentIdleTexture;

	private Texture defaultTexture;

	public Texture[] idleTextures;

	private float idleTimer;

	public Texture hurtTexture;

	public Texture attackTexture;

	[SerializeField]
	private EnemySimplifier mainSimplifier;

	private AudioSource aud;

	private BossHealthBar bossHealth;

	private float secondaryBarValue;

	private bool started;

	private bool inAction;

	private float health;

	private EnemyIdentifier eid;

	private Statue stat;

	private bool hurting;

	private bool shakingCamera;

	private Vector3 origPos;

	public GameObject fleshDrone;

	public GameObject skullDrone;

	private float fleshDroneCooldown;

	private int droneAmount;

	private int currentDrone;

	private GameObject targeter;

	private bool healing;

	public List<DroneFlesh> currentDrones;

	public GameObject healingTargetEffect;

	public GameObject healingEffect;

	private float rotationSpeed;

	private float rotationSpeedTarget;

	private float attackCooldown;

	private int previousAttack;

	public GameObject insignia;

	private float maxHealth;

	public GameObject homingProjectile;

	private int projectileAmount;

	private int currentProjectile;

	private float homingProjectileCooldown;

	public GameObject attackWindUp;

	public GameObject blackHole;

	private BlackHoleProjectile currentBlackHole;

	private int difficulty;

	public UltrakillEvent onFirstHeal;

	private int timesHealed;

	private bool noDrones;

	private MaterialPropertyBlock texOverride;

	private float maxDroneCooldown => 0f;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void SpawnFleshDrones()
	{
	}

	private void StartHealing()
	{
	}

	private void HealFromDrone()
	{
	}

	private void HomingProjectileAttack()
	{
	}

	private void SpawnInsignia()
	{
	}

	private void SpawnBlackHole()
	{
	}

	public void ForceDronesOff()
	{
	}
}
