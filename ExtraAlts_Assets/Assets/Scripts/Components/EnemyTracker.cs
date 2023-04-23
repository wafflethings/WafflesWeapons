using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.None)]
public class EnemyTracker : MonoSingleton<EnemyTracker>
{
    public List<EnemyIdentifier> enemies = new List<EnemyIdentifier>();
    public List<int> enemyRanks = new List<int>();

    void Update() { }
    public void AddEnemy(EnemyIdentifier eid) { }}
