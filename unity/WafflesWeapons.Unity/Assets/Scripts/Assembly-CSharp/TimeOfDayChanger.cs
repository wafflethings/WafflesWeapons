using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeOfDayChanger : MonoBehaviour
{
	public float speedMultiplier;

	private bool allOff;

	private bool allDone;

	public bool oneTime;

	public bool dontActivateOnEnable;

	private bool activated;

	private bool colliderless;

	public Light[] oldLights;

	public Light[] newLights;

	private List<float> orgOldIntensities;

	private List<float> origIntensities;

	public Material oldWalls;

	public Material oldSky;

	public Material newWalls;

	public Material newSky;

	public bool toBattleMusic;

	public bool toBossMusic;

	public bool musicWaitsUntilChange;

	public bool revertValuesOnFinish;

	public Material newSkybox;

	private Color skyboxColor;

	private Material oldSkyboxTemp;

	private Material newSkyboxTemp;

	public SpriteRenderer sunSprite;

	public Color sunSpriteColor;

	[Header("Fog")]
	public Color fogColor;

	public bool overrideFogSettings;

	public float fogStart;

	public float fogEnd;

	[Header("Lighting")]
	public Color ambientLightingColor;

	[Header("Events")]
	public UnityEvent onMaterialChange;

	private Color originalFogColor;

	private float originalFogStart;

	private float originalFogEnd;

	private Color originalSkyboxTint;

	private Color originalAmbientColor;

	private float transitionState;

	private static readonly int Tint;

	private void OnEnable()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	public void Activate()
	{
	}

	private void ChangeMaterials()
	{
	}

	private void Update()
	{
	}
}
