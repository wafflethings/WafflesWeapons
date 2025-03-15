using UnityEngine;
using UnityEngine.Events;

public class MinosArm : MonoBehaviour
{
	private bool introOver;

	private float attackCooldown;

	private bool inAction;

	private Animator anim;

	private int previousSlam;

	private int maxSlams;

	private int currentSlams;

	public Transform hand;

	public GameObject slamWave;

	public ObjectSpawner rubbleSpawner;

	private bool shaking;

	public GameObject shakeEffect;

	public GameObject impactSound;

	public GameObject hurtSound;

	public GameObject bigHurtSound;

	private Statue stat;

	private float originalHealth;

	private float speedState;

	public UnityEvent encounterStart;

	public UnityEvent encounterEnd;

	private int difficulty;

	private float originalAnimSpeed;

	private EnemyIdentifier eid;

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

	private void SlamLeft()
	{
	}

	private void SlamRight()
	{
	}

	private void SlamDown()
	{
	}

	public void Slam(int type)
	{
	}

	public void BigImpact(float shakeAmount = 2f)
	{
	}

	private void Flinch()
	{
	}

	public void Retreat()
	{
	}

	public void EndEncounter()
	{
	}

	public void IntroEnd()
	{
	}

	public void StopAction()
	{
	}

	public void StartShaking()
	{
	}

	public void StopShaking()
	{
	}

	public void StartEncounter()
	{
	}
}
