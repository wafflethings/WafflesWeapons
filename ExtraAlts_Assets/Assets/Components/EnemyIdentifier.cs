using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum EnemyClass
{
    Husk,
    Machine,
    Demon,
    Divine,
    Other
};

public enum EnemyType
{
    //In alphabetical order, please (Current number: 19)

    Cerberus = 0,
    Drone = 1,
    Filth = 3,
    FleshPrison = 17,
    Gabriel = 16,
    HideousMass = 2,
    MaliciousFace = 4,
    Mindflayer = 5,
    Minos = 11,
    MinosPrime = 18,
    Schism = 14,
    Sisyphus = 19,
    Soldier = 15,
    Stalker = 12,
    Stray = 13,
    Streetcleaner = 6, 
    Swordsmachine = 7,
    V2 = 8,
    Virtue = 9,
    Wicked = 10,
}

public enum HitterAttribute
{
    None,
    Fire,
    Electricity,
    Antidivine,
    HeavyKnockback
}

public class EnemyIdentifier : MonoBehaviour
{

    public EnemyClass enemyClass;
    public EnemyType enemyType;
    public bool spawnIn;
    public GameObject spawnEffect;

    public string[] weaknesses;
    public float[] weaknessMultipliers;
    public float totalDamageMultiplier = 1;
    public GameObject weakPoint;
    public bool ignoredByEnemies;

    public GameObject ineffectiveSound;

    public bool useBrakes;
    public bool bigEnemy;
    public bool unbounceable;
    public bool poise;

    public bool sandified;
    public bool flying;

    public bool dontCountAsKills;
    public bool specialOob;
    public GameObject[] activateOnDeath;
    public UnityEvent onDeath;
    private BloodsplatterManager bsm;
    public int difficultyOverride = -1;

    public bool hooked;
    public bool hookIgnore;

    public void ForceGetHealth()
    {
        
    }
    

    private void Update()
    {
        
    }

    public void DeliverDamage(GameObject target, Vector3 force, Vector3 hitPoint, float multiplier, bool tryForExplode, float critMultiplier = 0)
    {
        
    }

    public void InstaKill()
    {
        
    }

    public void Explode()
    {
        
    }

    public void Splatter()
    {
        
    }

    public void StopSplatter()
    {
        
    }

    public void Sandify(bool ignorePrevious = false)
    {
        
    }

    public void Desandify(bool visualOnly = false)
    {
        
    }
}
