using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
[DefaultExecutionOrder(600)]
public class MusicManager : MonoSingleton<MusicManager>
{
	public bool off;

	public bool dontMatch;

	public bool useBossTheme;

	public AudioSource battleTheme;

	public AudioSource cleanTheme;

	public AudioSource bossTheme;

	public AudioSource targetTheme;

	private AudioSource[] allThemes;

	public float volume;

	public float requestedThemes;

	private bool arenaMode;

	private float defaultVolume;

	public float fadeSpeed;

	public bool forcedOff;

	private bool filtering;

	private new void OnEnable()
	{
	}

	private void Update()
	{
	}

	public void ForceStartBattleMusic()
	{
	}

	public void ForceStartMusic()
	{
	}

	public void StartMusic()
	{
	}

	public void PlayBattleMusic()
	{
	}

	public void PlayCleanMusic()
	{
	}

	public void PlayBossMusic()
	{
	}

	public void ArenaMusicStart()
	{
	}

	public void ArenaMusicEnd()
	{
	}

	public void ForceStopMusic()
	{
	}

	public void StopMusic()
	{
	}

	public void FilterMusic()
	{
	}

	public void UnfilterMusic()
	{
	}

	private void RemoveHighPass()
	{
	}

	public bool IsInBattle()
	{
		return false;
	}
}
