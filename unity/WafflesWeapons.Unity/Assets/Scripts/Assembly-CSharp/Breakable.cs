using Sandbox;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Breakable : MonoBehaviour, IAlter, IAlterOptions<bool>
{
	public bool unbreakable;

	public bool weak;

	public bool precisionOnly;

	public bool interrupt;

	public bool breakOnThrown;

	public bool breakOnTouch;

	public bool breakOnEnvironment;

	[HideInInspector]
	public EnemyIdentifier interruptEnemy;

	public bool playerOnly;

	public bool specialCaseOnly;

	public bool accurateExplosionsOnly;

	public bool forceGroundSlammable;

	public bool forceSawbladeable;

	[Space(10f)]
	public GameObject breakParticle;

	public AssetReference breakParticleFallback;

	public bool particleAtBoundsCenter;

	public bool applyScaleToParticle;

	public Transform customPositionRotation;

	[Space(10f)]
	public bool crate;

	public int bounceHealth;

	[HideInInspector]
	public int originalBounceHealth;

	public GameObject crateCoin;

	public int coinAmount;

	private float defaultHeight;

	public bool protectorCrate;

	[Space(10f)]
	public GameObject[] activateOnBreak;

	public GameObject[] destroyOnBreak;

	public UltrakillEvent destroyEvent;

	private bool broken;

	private Collider col;

	private TimeSince? timeSinceBurn;

	private ItemIdentifier itid;

	private Rigidbody rb;

	public string alterKey => null;

	public string alterCategoryName => null;

	public AlterOption<bool>[] options => null;

	private void Start()
	{
	}

	public void Bounce()
	{
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
	}

	private void HitWith(GameObject target)
	{
	}

	public void Burn()
	{
	}

	public void ForceBreak()
	{
	}

	public void Break()
	{
	}
}
