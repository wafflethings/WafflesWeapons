using UnityEngine;

public class CombinedBossBar : MonoBehaviour, IEnemyHealthDetails
{
	public string fullName;

	public EnemyIdentifier[] enemies;

	public string FullName => null;

	public float Health => 0f;

	public bool Dead => false;

	public bool Blessed => false;

	private void OnEnable()
	{
	}

	public void ForceGetHealth()
	{
	}
}
