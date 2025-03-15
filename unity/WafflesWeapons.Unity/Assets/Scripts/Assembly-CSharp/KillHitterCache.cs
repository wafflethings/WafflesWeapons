using System.Collections.Generic;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class KillHitterCache : MonoSingleton<KillHitterCache>
{
	public int neededScore;

	public int currentScore;

	private List<int> eids;

	public bool ignoreRestarts;

	public void OneDone(int enemyId)
	{
	}

	public void RemoveId(int enemyId)
	{
	}
}
