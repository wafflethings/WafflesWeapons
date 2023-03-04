using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class ActivateNextWave : MonoBehaviour
{
    public bool lastWave;
    public int deadEnemies;
    public int enemyCount;

    public GameObject[] nextEnemies;

    public Door[] doors;

    public GameObject[] toActivate;

    public bool needNextRoomInfo;

    public Door doorForward;

    public AudioMixer allSounds;
    public bool forEnemies;

    public KillChallenge killChallenge;

    public void CountEnemies()
    {
        enemyCount = transform.childCount;
    }
    
}
