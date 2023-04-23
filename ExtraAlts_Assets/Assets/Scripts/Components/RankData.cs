using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class RankData
{
    public int[] ranks;
    public int secretsAmount;
    public bool[] secretsFound;
    public bool challenge;
    public int levelNumber;
    public bool[] majorAssists;

    public RankData (StatsManager sman) { }}
