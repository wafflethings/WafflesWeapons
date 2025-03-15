using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameConsole
{
	[Serializable]
	public class FilterButton
	{
		public TMP_Text text;

		public Image buttonBackground;

		public Image miniIndicator;

		public GameObject checkmark;

		public bool active;

		public void SetOpacity(float opacity)
		{
		}

		public void SetCheckmark(bool isChecked)
		{
		}
	}
}
