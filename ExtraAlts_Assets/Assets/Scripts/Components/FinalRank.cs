using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class FinalRank : MonoSingleton<FinalRank>
{
    public bool casual;
    public bool dontSavePos;
    public bool reachedSecondPit;

    public Text time;
    public Text timeRank;

    public Text kills;
    public Text killsRank;

    public Text style;
    public Text styleRank;

    public Text extraInfo;
    public Text totalRank;

    public Text secrets;
    public Image[] secretsInfo;
    public GameObject[] levelSecrets;
    public List<int> prevSecrets;

    public Image[] challenges;

    public GameObject[] toAppear;

    public bool complete;
    public GameObject playerPosInfo;
    public Vector3 finalPitPos;

    public GameObject ppiObject;
    public string targetLevelName;
    public Text pointsText;
    public int totalPoints;
    public bool dependenciesLoaded;

    private void Start() { }
    private void Update() { }
    public void SetTime(float seconds, string rank) { }
    public void SetKills(int killAmount, string rank) { }
    public void SetStyle(int styleAmount, string rank) { }
    public void SetInfo(int restarts, bool damage, bool majorUsed, bool cheatsUsed) { }
    public void SetRank(string rank) { }
    public void SetSecrets(int secretsAmount, int maxSecrets) { }
    public void StartLoadingNextLevel() { }
    public void Appear() { }
    public void FlashPanel(GameObject panel) { }
    public void RanklessNextLevel(string lvlname) { }
    public void LevelChange(bool force = false) { }
    public void AddPoints(int points) { }
    void PointsShow() { }}
