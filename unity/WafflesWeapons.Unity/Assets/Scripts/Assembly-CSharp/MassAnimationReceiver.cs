using UnityEngine;
using UnityEngine.Events;

public class MassAnimationReceiver : MonoBehaviour
{
	public GameObject groundBreakEffect;

	public GameObject smallGroundBreakEffect;

	public bool fakeMass;

	public bool otherBossIntro;

	public GameObject realMass;

	private Mass mass;

	public GameObject footstep;

	private Animator anim;

	private StatueIntroChecker sic;

	private bool turnTowards;

	private Transform player;

	private int breaks;

	public bool skipEntirelyOnReplay;

	public UnityEvent animationEvent1;

	public UnityEvent onSkip;

	public void Start()
	{
	}

	private void Update()
	{
	}

	public void GroundBreak()
	{
	}

	public void SmallGroundBreak()
	{
	}

	public void SpawnMass()
	{
	}

	public void Footstep()
	{
	}

	public void SkipOnReplay()
	{
	}

	public void AnimationEvent(int i)
	{
	}

	public void ShootSpear()
	{
	}

	public void StopAction()
	{
	}

	public void ShootHomingR()
	{
	}

	public void ShootHomingL()
	{
	}

	public void ShootExplosiveR()
	{
	}

	public void ShootExplosiveL()
	{
	}

	public void Slam()
	{
	}

	public void SwingStart()
	{
	}

	public void SwingEnd()
	{
	}

	public void CrazyReady()
	{
	}

	public void Enrage()
	{
	}
}
