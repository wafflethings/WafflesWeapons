using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
	public bool oneTime;

	public bool disableOnExit;

	public bool dontActivateOnEnable;

	public bool reactivateOnEnable;

	public bool activateOnDisable;

	public bool forEnemies;

	public bool notIfEnemiesDisabled;

	public bool onlyIfPlayerIsAlive;

	public bool dontUseEventsIfEnemiesDisabled;

	[HideInInspector]
	public bool activated;

	[HideInInspector]
	public bool activating;

	public float delay;

	private bool nonCollider;

	private int playerIn;

	[Space(20f)]
	public Collider[] ignoreColliders;

	[Space(20f)]
	public ObjectActivationCheck obac;

	public bool onlyCheckObacOnce;

	public bool disableIfObacOff;

	[Space(10f)]
	public UltrakillEvent events;

	private bool canUseEvents => false;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnTriggerExit(Collider other)
	{
	}

	public void ActivateDelayed(float delay)
	{
	}

	public void Activate()
	{
	}

	public void Activate(bool ignoreDisabled = false)
	{
	}

	public void Deactivate()
	{
	}

	public void Switch()
	{
	}

	private void OnDisable()
	{
	}

	private void OnEnable()
	{
	}
}
