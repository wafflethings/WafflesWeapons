using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;

public class FinalCyberRank : MonoBehaviour
{
    public Text waveText;
    public Text killsText;
    public Text styleText;
    public Text timeText;

    public Text bestWaveText;
    public Text bestKillsText;
    public Text bestStyleText;
    public Text bestTimeText;

    public Text pointsText;
    public int totalPoints;

    public GameObject[] toAppear;
    public float savedTime;
    public float savedWaves;
    public int savedKills;
    public int savedStyle;   
    [SerializeField] private GameObject[] previousElements;
    [SerializeField] private GameObject highScoreElement;
    [SerializeField] private GameObject friendContainer;
    [SerializeField] private GameObject globalContainer;
    [SerializeField] private GameObject friendPlaceholder;
    [SerializeField] private GameObject globalPlaceholder;
    [SerializeField] private GameObject template;
    [SerializeField] private Text tRank;
    [SerializeField] private Text tUsername;
    [SerializeField] private Text tScore;
    [SerializeField] private Text tPercent;

     
    void Start() { }
    public void GameOver() { }
    void NewBest() { }
     
    void Update() { }
    public void Appear() { }
    public void FlashPanel(GameObject panel) { }
    void PointsShow() { }}
