using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FishEncyclopedia : MonoBehaviour
{
	[SerializeField]
	private GameObject fishPicker;

	[SerializeField]
	private GameObject fishInfoContainer;

	[SerializeField]
	private TMP_Text fishName;

	[SerializeField]
	private TMP_Text fishDescription;

	[Space]
	[SerializeField]
	private Transform fishGrid;

	[SerializeField]
	private FishMenuButton fishButtonTemplate;

	[SerializeField]
	private GameObject fish3dRenderContainer;

	[Space]
	[SerializeField]
	private FishDB[] fishDbs;

	private Dictionary<FishObject, FishMenuButton> fishButtons;

	private void Start()
	{
	}

	private void OnFishUnlocked(FishObject obj)
	{
	}

	private void DisplayFish(FishObject fish)
	{
	}

	public void SelectFish(FishObject fish)
	{
	}

	public void HideFishInfo()
	{
	}
}
