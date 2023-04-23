using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class KillHitterCache : MonoSingleton<KillHitterCache>
{
    public int neededScore;
    public int currentScore;
    public bool ignoreRestarts;

    public void OneDone(int enemyId) { }
    public void RemoveId(int enemyId) { }}
