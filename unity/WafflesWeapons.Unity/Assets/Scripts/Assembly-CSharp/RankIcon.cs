using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RankIcon : MonoBehaviour
{
	[SerializeField]
	private bool useDefaultRank;

	[SerializeField]
	[Range(0f, 12f)]
	private int defaultRank;

	[SerializeField]
	private TMP_Text mainRankLetter;

	[SerializeField]
	private Image mainRankBackground;

	private void Start()
	{
	}

	public void SetRank(int rank)
	{
	}

	public void SetEmpty()
	{
	}
}
