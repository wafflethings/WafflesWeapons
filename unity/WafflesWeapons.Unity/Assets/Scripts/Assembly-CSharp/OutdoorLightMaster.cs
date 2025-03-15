using System.Collections.Generic;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class OutdoorLightMaster : MonoSingleton<OutdoorLightMaster>
{
	public SkyboxAnimation skyboxAnimation;

	private float skyboxRotation;

	private float skyboxWobbleSpeed;

	private float skyboxDefaultRotation;

	public bool inverse;

	private List<Light> outdoorLights;

	public Light[] extraLights;

	public GameObject[] activateWhenOutside;

	[HideInInspector]
	public LayerMask normalMask;

	[HideInInspector]
	public LayerMask playerMask;

	private int requests;

	private bool firstDoorOpened;

	public bool waitForFirstDoorOpen;

	private Material skyboxMaterial;

	private Material tempSkybox;

	public List<AudioLowPassFilter> muffleWhenIndoors;

	private List<float> muffleGoals;

	private bool muffleSounds;

	private float currentMuffle;

	public bool muffleWhenOutdoors;

	[HideInInspector]
	public List<Collider> outdoorsZonesCheckerable;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void AddRequest()
	{
	}

	public void RemoveRequest()
	{
	}

	public void FirstDoorOpen()
	{
	}

	public void UpdateSkyboxMaterial()
	{
	}

	public void ForceMuffle(float target)
	{
	}

	private void UpdateMuffle()
	{
	}
}
