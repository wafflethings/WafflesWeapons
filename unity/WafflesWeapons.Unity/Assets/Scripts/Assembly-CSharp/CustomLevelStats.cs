using TMPro;
using UnityEngine;

public class CustomLevelStats : MonoBehaviour
{
	[SerializeField]
	private RankIcon mainRankIcon;

	[SerializeField]
	private TMP_Text secretsText;

	[SerializeField]
	private TMP_Text statsText;

	private const string AccentColor = "orange";

	public void LoadStats(string uuid)
	{
	}
}
