using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class ScanningStuff : MonoSingleton<ScanningStuff>
{
	[SerializeField]
	private GameObject scanningPanel;

	[SerializeField]
	private GameObject readingPanel;

	[SerializeField]
	private TMP_Text readingText;

	[SerializeField]
	private ScrollRect scrollRect;

	public Image meter;

	private float loading;

	private bool scanning;

	private Dictionary<int, bool> scannedBooks;

	private Dictionary<int, float> bookScrollStates;

	private int currentBookId;

	public bool oldWeaponState;

	public bool IsReading => false;

	public void ReleaseScroll(int instanceId)
	{
	}

	public void ScanBook(string text, bool noScan, int instanceId)
	{
	}

	public void ResetState()
	{
	}

	private void Update()
	{
	}
}
