using UnityEngine;

public class SandificationZone : MonoBehaviour
{
	private int difficulty;

	[HideInInspector]
	public bool buffHealth;

	[HideInInspector]
	public float healthBuff;

	[HideInInspector]
	public bool buffDamage;

	[HideInInspector]
	public float damageBuff;

	public bool buffSpeed;

	public float speedBuff;

	private void Start()
	{
	}

	private void Enter(Collider other)
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
	}
}
