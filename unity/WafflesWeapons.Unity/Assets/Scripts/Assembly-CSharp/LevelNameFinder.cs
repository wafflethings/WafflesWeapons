using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelNameFinder : MonoBehaviour
{
	public string textBeforeName;

	public bool breakLine;

	private int thisLevelNumber;

	public int otherLevelNumber;

	private Text txt;

	private TMP_Text txt2;

	public bool lookForPreviousMission;

	public bool lookForLatestMission;

	private void OnEnable()
	{
	}
}
