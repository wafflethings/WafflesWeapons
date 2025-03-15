using UnityEngine;

public class WeaponStalenessLocker : MonoBehaviour
{
	public LockerType type;

	public int slot;

	public float minValue;

	public float maxValue;

	public StyleFreshnessState minState;

	public StyleFreshnessState maxState;

	public bool oneTime;

	private bool beenActivated;

	private bool colliderless;

	private void Start()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	public void Activate()
	{
	}
}
