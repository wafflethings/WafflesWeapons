using UnityEngine;

public class PulsateEmissiveMaterial : MonoBehaviour
{
	[HideInInspector]
	public bool valuesSet;

	[HideInInspector]
	public MeshRenderer rend;

	[HideInInspector]
	public Material[] sharedMaterials;

	[HideInInspector]
	public MaterialPropertyBlock block;

	[HideInInspector]
	public int emissiveID;

	[HideInInspector]
	public float defaultIntensity;

	[HideInInspector]
	public float targetIntensity;

	[HideInInspector]
	public float currentIntensity;

	public float intensityRange;

	public float pulseSpeed;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void SetValues()
	{
	}
}
