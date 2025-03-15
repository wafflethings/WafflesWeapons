using System.Collections.Generic;
using UnityEngine;

public class BakeVertexLights : MonoBehaviour
{
	public List<Renderer> bakedRenderers;

	private MaterialPropertyBlock[] rendPropBlocks;

	[HideInInspector]
	public int UVTargetChannel;

	private float _strength;

	public float Strength
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void UpdateChannelStrength(int targetChannel, float strength)
	{
	}
}
