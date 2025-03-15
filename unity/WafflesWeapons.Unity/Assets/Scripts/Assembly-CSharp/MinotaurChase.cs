using UnityEngine;

public class MinotaurChase : MonoBehaviour
{
	private Rigidbody rb;

	private EnemyIdentifier eid;

	private Animator anim;

	private bool gotValues;

	private bool trackTarget;

	public float movementRange;

	public Vector3 leashPosition;

	private float leashRandomizer;

	private float movementSpeed;

	private float currentAnimatorWeight;

	private float cooldown;

	private int previousAttack;

	private int currentAttacks;

	[SerializeField]
	private GameObject[] trams;

	private bool attacking;

	private bool backAttacking;

	[SerializeField]
	private SwingCheck2 hammerSwingCheck;

	[SerializeField]
	private TrailRenderer hammerTrail;

	[SerializeField]
	private Transform hammerPoint;

	[SerializeField]
	private GameObject hammerExplosion;

	[SerializeField]
	private GameObject meatInHand;

	[SerializeField]
	private GameObject handBlood;

	[SerializeField]
	private GameObject handSwingStuff;

	[SerializeField]
	private SwingCheck2 handSwingCheck;

	[SerializeField]
	private GameObject fallEffect;

	[SerializeField]
	private AudioSource roar;

	[SerializeField]
	private AudioClip roarClip;

	[SerializeField]
	private AudioClip longGruntClip;

	[SerializeField]
	private AudioClip shortRoarClip;

	[SerializeField]
	private AudioClip squealClip;

	[Header("Intro")]
	public bool intro;

	public UltrakillEvent onIntroEnd;

	private Transform tempTarget;

	private int difficulty;

	private bool dead;

	private bool dragging;

	public Material hurtMaterial;

	public Mesh hurtMesh;

	private void Start()
	{
	}

	private void GetValues()
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

	private void FixedUpdate()
	{
	}

	private void MeatThrow()
	{
	}

	private void HandBlood()
	{
	}

	private void MeatSpawn()
	{
	}

	private void MeatThrowPickTarget()
	{
	}

	private void MeatThrowThrow()
	{
	}

	private void HandSwing()
	{
	}

	private void HandSwingStart()
	{
	}

	private void HandSwinging()
	{
	}

	private void HandSwingStop()
	{
	}

	private void HammerSwing()
	{
	}

	private void QuickHammer()
	{
	}

	private void HammerSwingStart()
	{
	}

	private void HammerImpact()
	{
	}

	private void HammerSwingStop()
	{
	}

	public void Death()
	{
	}

	private void GetDragged()
	{
	}

	public void StopDragging()
	{
	}

	private void StartTracking()
	{
	}

	private void ResetTarget()
	{
	}

	private void StopAction()
	{
	}

	private void IntroEnd()
	{
	}

	public void DisableIntro()
	{
	}

	private GameObject GetClosestTram(Vector3 position, float shortestDistance = float.PositiveInfinity)
	{
		return null;
	}

	private void Roar()
	{
	}

	private void Roar(float pitch = 1f)
	{
	}

	private void Roar(AudioClip clip, float pitch = 1f)
	{
	}
}
