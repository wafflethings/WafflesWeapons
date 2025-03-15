using TMPro;
using UnityEngine;
using UnityEngine.UI;
using plog;

public class EnemyInfoPage : ListComponent<EnemyInfoPage>
{
	private static readonly plog.Logger Log;

	[SerializeField]
	private TMP_Text enemyPageTitle;

	[SerializeField]
	private TMP_Text enemyEntryTitle;

	[SerializeField]
	private TMP_Text enemyPageContent;

	[SerializeField]
	private Transform enemyPreviewWrapper;

	[SerializeField]
	private GameObject wickedNoise;

	[Space]
	[SerializeField]
	private Transform enemyList;

	[SerializeField]
	private GameObject buttonTemplate;

	[SerializeField]
	private Image buttonTemplateBackground;

	[SerializeField]
	private Image buttonTemplateForeground;

	[SerializeField]
	private Image buttonTemplateWickedNoise;

	[SerializeField]
	private Sprite lockedSprite;

	[Space]
	[SerializeField]
	private SpawnableObjectsDatabase objects;

	private SpawnableObject currentSpawnable;

	private void Start()
	{
	}

	public void UpdateInfo()
	{
	}

	private void SwapLayers(Transform target, int layer)
	{
	}

	private void DisplayInfo(SpawnableObject source)
	{
	}

	public void DisplayInfo()
	{
	}

	public void UndisplayInfo()
	{
	}
}
