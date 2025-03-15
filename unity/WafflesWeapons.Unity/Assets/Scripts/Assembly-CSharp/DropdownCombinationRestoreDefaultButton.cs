using System;
using System.Collections.Generic;
using SettingsMenu.Models;
using TMPro;
using UnityEngine;

public class DropdownCombinationRestoreDefaultButton : MonoBehaviour
{
	[Serializable]
	public struct CombinationOption
	{
		public List<BooleanPrefOption> subOptions;
	}

	[Serializable]
	public struct BooleanPrefOption
	{
		public PreferenceKey preferenceKey;

		public bool expectedValue;
	}

	public GameObject buttonContainer;

	public int defaultCombination;

	public List<CombinationOption> combinations;

	public TMP_Dropdown dropdown;

	private bool isValueDirty;

	private void Start()
	{
	}

	public void RestoreDefault()
	{
	}

	private void UpdateSelf()
	{
	}

	private void LateUpdate()
	{
	}
}
