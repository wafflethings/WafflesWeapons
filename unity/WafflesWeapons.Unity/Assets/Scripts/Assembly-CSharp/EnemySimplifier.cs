using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(200)]
public class EnemySimplifier : MonoBehaviour
{
	public enum MaterialState
	{
		normal = 0,
		simplified = 1,
		enraged = 2,
		enragedSimplified = 3
	}

	public bool neverOutlineAndRemoveSimplifier;

	public bool enemyScriptHandlesEnrage;

	public Transform enemyRootTransform;

	public List<int> radiantSubmeshesToIgnore;

	private Material currentMaterial;

	public Material enragedMaterial;

	[HideInInspector]
	public Material originalMaterial;

	[HideInInspector]
	public Material originalMaterial2;

	[HideInInspector]
	public Material originalMaterial3;

	public Material simplifiedMaterial;

	public Material simplifiedMaterial2;

	public Material simplifiedMaterial3;

	public Material enragedSimplifiedMaterial;

	private Renderer meshrenderer;

	[HideInInspector]
	public bool enraged;

	private OptionsManager oman;

	private GameObject player;

	private bool active;

	private bool simplify;

	private bool playerDistCheck;

	[HideInInspector]
	public EnemyType enemyColorType;

	public bool ignoreCustomColor;

	[HideInInspector]
	public EnemyIdentifier eid;

	[HideInInspector]
	public bool isHat;

	[HideInInspector]
	public DoubleRender radianceEffect;

	public Material[] matList;

	private bool hasSimplifiedMaterial;

	private int shouldBeOutlined;

	private int lastOutlineState;

	private MaterialState currentState;

	private MaterialState lastState;

	private Dictionary<MaterialState, Material> materialDict;

	private bool hasEnragedSimplified;

	private bool lastSandified;

	private bool lastBlessed;

	private MaterialPropertyBlock propBlock;

	private static readonly int HasSandBuff;

	private static readonly int NewSanded;

	private static readonly int Blessed;

	private static readonly int Outline;

	private static readonly int ForceOutline;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void TryRemoveSimplifier()
	{
	}

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	public void SetOutline(bool forceUpdate)
	{
	}

	public void UpdateColors()
	{
	}

	public void Begone()
	{
	}

	public void ChangeTexture(MaterialState stateToTarget, Texture newTexture)
	{
	}

	public void ChangeMaterialNew(MaterialState stateToTarget, Material newMaterial)
	{
	}

	public void ChangeMaterial(Material oldMaterial, Material newMaterial)
	{
	}
}
