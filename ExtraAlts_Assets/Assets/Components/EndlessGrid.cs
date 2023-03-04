using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.UI;
using System.Text.RegularExpressions;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class EndlessGrid : MonoSingleton<EndlessGrid>
{
    public bool customPatternMode = false;
    public ArenaPattern[] customPatterns;
    public const int ArenaSize = 16;
    [SerializeField] ArenaPattern[] patterns;
    [SerializeField] private List<CyberPooledPrefab> jumpPadPool;
    [SerializeField] private PrefabDatabase prefabs;
    [SerializeField] private GameObject gridCube;
    [SerializeField] private LayerMask prefabSpawnLayerCheck;
    [SerializeField] private float offset = 5;
    public int enemyAmount = 999;
    public int currentWave;

    public Text waveNumberText;
    public Text enemiesLeftText;

    public bool crowdReactions;
    public Transform enemyToTrack;
    public float glowMultiplier = 1;
    
    private ArenaPattern[] CurrentPatternPool => customPatternMode ? customPatterns : patterns;

    public void UpdateGlow() //Use when the glowMultiplier is changed
{}
    public void OneDone()
{}
    public void OnePrefabDone()
{}}
