using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayerSelect : MonoBehaviour
{
    public int layerNumber;
    public int levelAmount;

    public int golds;

    public Text rankText;

    public bool gold;
    public bool allPerfects;
    public int trueScore;
    public bool complete;
    public bool noSecretMission;

    private void OnDisable() { }
    public void CheckScore() { }
    public void AddScore(int score, bool perfect = false) { }
    public void Gold() { }
    public void SecretMissionDone() { }}
