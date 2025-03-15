using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class EndlessGrid : MonoSingleton<EndlessGrid>
{
	public bool customPatternMode;

	public ArenaPattern[] customPatterns;

	public const int ArenaSize = 16;

	[SerializeField]
	private ArenaPattern[] patterns;

	private int[] usedPatterns;

	[SerializeField]
	private List<CyberPooledPrefab> jumpPadPool;

	private int jumpPadSelector;

	[SerializeField]
	private CyberGrindNavHelper nvmhlpr;

	[SerializeField]
	private PrefabDatabase prefabs;

	[SerializeField]
	private GameObject gridCube;

	[SerializeField]
	private float offset;

	[HideInInspector]
	public EndlessCube[][] cubes;

	private int incompleteBlocks;

	private ArenaPattern currentPattern;

	public NavMeshSurface nms;

	private ActivateNextWave anw;

	public int enemyAmount;

	public int tempEnemyAmount;

	private int points;

	private int maxPoints;

	public int currentWave;

	private int currentPatternNum;

	private List<Vector2> meleePositions;

	private int usedMeleePositions;

	private List<Vector2> projectilePositions;

	private int usedProjectilePositions;

	private List<GameObject> spawnedEnemies;

	private List<GameObject> spawnedPrefabs;

	private List<EnemyTypeTracker> spawnedEnemyTypes;

	private int incompletePrefabs;

	private GoreZone gz;

	private int specialAntiBuffer;

	private int massAntiBuffer;

	private float uncommonAntiBuffer;

	public Text waveNumberText;

	public Text enemiesLeftText;

	public bool crowdReactions;

	private CrowdReactions crorea;

	private int hideousMasses;

	private NewMovement nmov;

	private WeaponCharges wc;

	private Material[] mats;

	private Color targetColor;

	private bool testMode;

	private bool lastEnemyMode;

	public Transform enemyToTrack;

	private float currentGlow;

	public float glowMultiplier;

	private GameObject combinedGridStaticObject;

	private MeshRenderer combinedGridStaticMeshRenderer;

	private MeshFilter combinedGridStaticMeshFilter;

	private Mesh combinedGridStaticMesh;

	private static readonly int WorldOffset;

	private static readonly int GradientSpeed;

	private static readonly int GradientFalloff;

	private static readonly int GradientScale;

	private static readonly int PcGamerMode;

	public int startWave;

	private ArenaPattern[] CurrentPatternPool => null;

	public void TrySetupStaticGridMesh()
	{
	}

	public void SetupStaticGridMesh()
	{
	}

	private void Start()
	{
	}

	private void LastEnemyMode()
	{
	}

	private void NormalMode()
	{
	}

	public void UpdateGlow()
	{
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void NextWave()
	{
	}

	private void DisplayNoPatternWarning()
	{
	}

	private void LoadPattern(ArenaPattern pattern)
	{
	}

	public void MakeGridDynamic()
	{
	}

	private GameObject SpawnOnGrid(GameObject obj, Vector2 position, bool prefab = false, bool enemy = false, CyberPooledType poolType = CyberPooledType.None, bool radiant = false)
	{
		return null;
	}

	public GameObject[] GetSpawnedEnemies()
	{
		return null;
	}

	public void OneDone()
	{
	}

	public void OnePrefabDone()
	{
	}

	private void GetEnemies()
	{
	}

	private int CapUncommonsAmount(int target, int amount)
	{
		return 0;
	}

	private int GetIndexOfEnemyType(EnemyType target)
	{
		return 0;
	}

	private bool SpawnRadiant(EndlessEnemy target, int indexOf)
	{
		return false;
	}

	private bool SpawnUncommons(int target, int amount)
	{
		return false;
	}

	private void GetNextEnemy()
	{
	}

	private void ShuffleDecks()
	{
	}

	private string SplitCamelCase(string str)
	{
		return null;
	}

	public void SetGlowColor(bool roundDown = false)
	{
	}
}
