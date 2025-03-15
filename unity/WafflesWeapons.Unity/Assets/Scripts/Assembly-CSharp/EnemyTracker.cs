using System.Collections.Generic;

[ConfigureSingleton(SingletonFlags.None)]
public class EnemyTracker : MonoSingleton<EnemyTracker>
{
	public List<EnemyIdentifier> enemies;

	public List<int> enemyRanks;

	public List<Drone> drones;

	private void Update()
	{
	}

	private void OnGUI()
	{
	}

	public List<EnemyIdentifier> GetCurrentEnemies()
	{
		return null;
	}

	public void UpdateIdolsNow()
	{
	}

	public List<EnemyIdentifier> GetEnemiesOfType(EnemyType type)
	{
		return null;
	}

	public void AddEnemy(EnemyIdentifier eid)
	{
	}

	public int GetEnemyRank(EnemyIdentifier eid)
	{
		return 0;
	}
}
