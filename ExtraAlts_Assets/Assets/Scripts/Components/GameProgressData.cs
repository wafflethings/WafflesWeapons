using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]

public class GameProgressData
{
    public int levelNum;
    public int difficulty;
    public int[] primeLevels;

    public GameProgressData() { }}
