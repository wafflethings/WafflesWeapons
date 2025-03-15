using System;

[Serializable]
public class RankData
{
	public int[] ranks;

	public int secretsAmount;

	public bool[] secretsFound;

	public bool challenge;

	public int levelNumber;

	public bool[] majorAssists;

	public RankScoreData[] stats;

	public RankData(StatsManager sman)
	{
	}
}
