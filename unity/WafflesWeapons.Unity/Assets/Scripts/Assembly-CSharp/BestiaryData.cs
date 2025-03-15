using System.Collections.Generic;

[ConfigureSingleton(SingletonFlags.PersistAutoInstance)]
public class BestiaryData : MonoSingleton<BestiaryData>
{
	private bool checkedSave;

	private Dictionary<EnemyType, int> foundEnemies;

	private void InitDictionary()
	{
	}

	protected override void Awake()
	{
	}

	private void Start()
	{
	}

	public int GetEnemy(EnemyType enemy)
	{
		return 0;
	}

	public void SetEnemy(EnemyType enemy, int newState = 2)
	{
	}

	public void CheckSave()
	{
	}
}
