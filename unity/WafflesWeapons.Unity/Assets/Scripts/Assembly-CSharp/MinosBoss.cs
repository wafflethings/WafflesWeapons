using UnityEngine;
using UnityEngine.Events;

public class MinosBoss : MonoBehaviour
{
	private Animator anim;

	private EnemyIdentifier eid;

	private Statue stat;

	public Transform head;

	private bool inAction;

	private bool inPhaseChange;

	private float cooldown;

	public int phase;

	public Transform rightArm;

	public Transform rightHand;

	private Transform[] rightHandBones;

	private SwingCheck2[] scRight;

	private bool attackingRight;

	public Transform leftArm;

	public Transform leftHand;

	private Transform[] leftHandBones;

	private SwingCheck2[] scLeft;

	private bool attackingLeft;

	public GameObject windupSound;

	public GameObject bigHurtSound;

	public GameObject punchExplosion;

	public bool onRight;

	public bool onMiddle;

	public bool onLeft;

	private float blackHoleCooldown;

	public GameObject blackHole;

	private BlackHoleProjectile currentBlackHole;

	public Transform blackHoleSpawnPos;

	private float lowMiddleChance;

	public GameObject[] eyes;

	public Material eyeless;

	public Parasite[] parasites;

	private float originalHealth;

	public UnityEvent onDeathImpact;

	public UnityEvent onDeathOver;

	private bool dead;

	private int difficulty;

	private bool beenParried;

	public bool parryChallenge;

	private int punchesSinceBreak;

	private void Start()
	{
	}

	private void UpdateBuff()
	{
	}

	private void SetSpeed()
	{
	}

	private void Update()
	{
	}

	private void SlamRight()
	{
	}

	private void SlamLeft()
	{
	}

	private void SlamMiddle()
	{
	}

	public void SwingStart()
	{
	}

	public void SpecialDeath()
	{
	}

	public void Impact()
	{
	}

	public void DeathOver()
	{
	}

	public void SwingEnd()
	{
	}

	private void BlackHole()
	{
	}

	public void SpawnBlackHole()
	{
	}

	public void LaunchBlackHole()
	{
	}

	public void GotParried()
	{
	}

	public void ResetColliders()
	{
	}

	public void StopAction()
	{
	}

	public void PlayerInZone(int zone)
	{
	}

	public void PlayerExitZone(int zone)
	{
	}

	private void PhaseChange(int targetPhase)
	{
	}

	public void ShutEye(int eye)
	{
	}

	public void SpawnParasites()
	{
	}

	public void TargetBeenHit(SwingCheck2 swing)
	{
	}
}
