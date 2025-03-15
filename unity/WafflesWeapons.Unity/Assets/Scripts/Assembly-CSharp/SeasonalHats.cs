using System;
using UnityEngine;

public class SeasonalHats : MonoBehaviour
{
	private DateTime time;

	[SerializeField]
	private GameObject christmas;

	[SerializeField]
	private GameObject halloween;

	[SerializeField]
	private GameObject easter;

	private void Start()
	{
	}

	private DateTime GetEaster(int year)
	{
		return default(DateTime);
	}
}
