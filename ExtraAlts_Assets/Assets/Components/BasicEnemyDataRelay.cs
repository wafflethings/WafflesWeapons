using System;
using UnityEngine;

public class BasicEnemyDataRelay : MonoBehaviour
{
    [NonSerialized] public EnemyType enemyType;
    public float health = 1;

    public void WillReplace(GameObject oldObject, GameObject newObject, bool isSelfBeingReplaced) { }
}
