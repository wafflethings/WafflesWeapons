using System.Collections.Generic;
using UnityEngine;

public class CentaurDeath : MonoBehaviour
{
	public float forceStrength;

	public AnimationCurve timeCurve;

	public Texture burningTex;

	private MeshRenderer[] mRends;

	private List<Material> allMaterials;

	private MaterialPropertyBlock propBlock;

	private int burnID;

	private int burnFadeID;

	private float realTime;

	private float burnTime;

	private float burnTimeFade;

	private void Start()
	{
	}

	private void Update()
	{
	}
}
