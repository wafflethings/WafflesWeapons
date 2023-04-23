using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Logic;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class StatsManager : MonoSingleton<StatsManager>
{
    public GameObject debugCheckPoint;

    public int levelNumber;

    public bool timer;

    public int[] timeRanks;
    public int[] killRanks;
    public int[] styleRanks;

    public GameObject[] secretObjects;

    public AudioClip[] rankSounds;

    public GameObject bonusGhost;
    public GameObject bonusGhostSupercharge;

    protected override void Awake() { }
    protected override void OnDestroy() { }
     
    void Start() { }
     
    void Update() { }
    public void GetCheckPoint(Vector3 position) { }
    public void Restart() { }
    public void StartTimer() { }
    public void StopTimer() { }
    public void HideShit() { }
    public void SendInfo() { }
    void GetFinalRank() { }
    public void MajorUsed() { }
    public void SecretFound(int i) { }}
