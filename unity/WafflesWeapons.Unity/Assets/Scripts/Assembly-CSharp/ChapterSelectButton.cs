using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChapterSelectButton : MonoBehaviour
{
	public LayerSelect[] layersInChapter;

	public TMP_Text rankText;

	private Image buttonBg;

	private Sprite originalSprite;

	[SerializeField]
	private Sprite buttonOnP;

	private Image rankButton;

	private Sprite originalRankSprite;

	[SerializeField]
	private Sprite rankOnP;

	public int totalScore;

	public bool notComplete;

	public int golds;

	public int allPerfects;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void CheckScore()
	{
	}
}
