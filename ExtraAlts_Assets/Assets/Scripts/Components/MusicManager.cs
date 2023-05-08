using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
[DefaultExecutionOrder(600)]
public class MusicManager : MonoSingleton<MusicManager> {
    public bool off;
    public bool dontMatch;
    public AudioSource battleTheme;
    public AudioSource cleanTheme;
    public AudioSource bossTheme;
    public AudioSource targetTheme;
    public float volume = 1;
    public float requestedThemes;
    public float fadeSpeed;
    public bool forcedOff;

     
    void OnEnable () {}	
	 
	void Update () {}
    public void ForceStartMusic() { }
    public void StartMusic() { }
    public void PlayBattleMusic() { }
    public void PlayCleanMusic() { }
    public void PlayBossMusic() { }
    public void ArenaMusicStart() { }
    public void ArenaMusicEnd() { }
    public void ForceStopMusic() { }
    public void StopMusic() { }
    public void FilterMusic() { }
    public void UnfilterMusic() { }
    void RemoveHighPass() { }}
