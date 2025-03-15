using TMPro;
using UnityEngine;

public class CrateCounter : MonoSingleton<CrateCounter>
{
	public int crateAmount;

	private int currentCrates;

	private int unsavedCrates;

	[SerializeField]
	private TMP_Text display;

	private int currentCoins;

	private int savedCoins;

	private bool success;

	public UltrakillEvent onAllCratesGet;

	private void Start()
	{
	}

	public void AddCrate()
	{
	}

	public void AddCoin()
	{
	}

	public void SaveStuff()
	{
	}

	public void CoinsToPoints()
	{
	}

	public void ResetUnsavedStuff()
	{
	}

	private void UpdateDisplay()
	{
	}
}
