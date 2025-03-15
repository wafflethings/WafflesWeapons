using System.Collections.Generic;
using UnityEngine;

public class WaveMenu : MonoBehaviour
{
	public List<WaveSetter> setters;

	public WaveCustomSetter customSetter;

	private int _highestWave;

	private int startWave;

	public int highestWave
	{
		get
		{
			return 0;
		}
		private set
		{
		}
	}

	private void Start()
	{
	}

	private void GetHighestWave()
	{
	}

	public void SetCurrentWave(int wave)
	{
	}
}
