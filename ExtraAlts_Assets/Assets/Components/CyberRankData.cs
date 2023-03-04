using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]

public class CyberRankData
{
    public int wave;
    public int[] wavesByDifficulty; // Legacy
    public float[] preciseWavesByDifficulty;
    public int[] kills;
    public int[] style;
    public float[] time;
}
