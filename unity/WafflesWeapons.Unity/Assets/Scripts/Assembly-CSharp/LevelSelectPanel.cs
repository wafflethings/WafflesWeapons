using UnityEngine;
using UnityEngine.UI;

public class LevelSelectPanel : MonoBehaviour
{
	public float collapsedHeight;

	public float expandedHeight;

	public GameObject leaderboardPanel;

	private RectTransform rectTransform;

	public int levelNumber;

	public int levelNumberInLayer;

	private bool allSecrets;

	public Sprite lockedSprite;

	public Sprite unlockedSprite;

	private Sprite origSprite;

	public Image[] secretIcons;

	public Image challengeIcon;

	private int tempInt;

	private string origName;

	public Sprite unfilledPanel;

	public Sprite filledPanel;

	private LayerSelect ls;

	private GameObject challengeChecker;

	public bool forceOff;

	private Color defaultColor;

	private void Setup()
	{
	}

	public void CheckScore()
	{
	}
}
