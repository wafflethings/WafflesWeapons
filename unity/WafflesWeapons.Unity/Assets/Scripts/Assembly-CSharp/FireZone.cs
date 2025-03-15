using UnityEngine;

public class FireZone : MonoBehaviour
{
	public HurtCooldownCollection HurtCooldownCollection;

	public FlameSource source;

	public bool canHurtPlayer;

	public int playerDamage;

	private Streetcleaner sc;

	private void Start()
	{
	}

	private void OnTriggerStay(Collider other)
	{
	}
}
