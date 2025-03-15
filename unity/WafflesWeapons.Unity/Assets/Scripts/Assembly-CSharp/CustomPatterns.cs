using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomPatterns : MonoBehaviour
{
	private Dictionary<string, ArenaPattern> patternCache;

	private Dictionary<string, ArenaPattern> enabledPatterns;

	private Dictionary<string, ArenaPattern[]> enabledPatternPacks;

	private Dictionary<string, GameObject> patternActiveIndicators;

	private Dictionary<string, GameObject> patternPackActiveIndicators;

	private int currentPage;

	private int maxPages;

	private int maxItemsPerPage;

	[SerializeField]
	private AnimationCurve colorCurve;

	[SerializeField]
	private Texture2D parsingErrorTexture;

	[SerializeField]
	private GameObject buttonTemplate;

	[SerializeField]
	private GameObject packButtonTemplate;

	[SerializeField]
	private Transform grid;

	[SerializeField]
	private TMP_Text stateButtonText;

	[SerializeField]
	private TMP_Text pageText;

	public GameObject enableWhenCustom;

	public GameObject disableWhenCustom;

	private string PatternsPath => null;

	private ArenaPattern[] AllEnabledPatterns => null;

	private void Awake()
	{
	}

	public void Toggle()
	{
	}

	public void SaveEnabledPatterns()
	{
	}

	public void LoadEnabledPatterns()
	{
	}

	public void BuildButtons()
	{
	}

	private bool GeneratePatternPreview(ArenaPattern pattern, Vector2Int offset, ref Texture2D target)
	{
		return false;
	}

	private void TogglePattern(string key, bool isPack)
	{
	}

	private ArenaPattern LoadPattern(string relativePath)
	{
		return null;
	}

	public void NextPage()
	{
	}

	public void PreviousPage()
	{
	}

	public void OpenEditor()
	{
	}
}
