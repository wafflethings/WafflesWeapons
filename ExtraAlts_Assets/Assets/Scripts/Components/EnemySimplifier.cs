using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(200)]
public class EnemySimplifier : MonoBehaviour
{
	public bool enemyScriptHandlesEnrage = false;
	public Transform enemyRootTransform;
	public List<int> radiantSubmeshesToIgnore = new List<int>();
	public Material enragedMaterial;
	public Material simplifiedMaterial;
	public Material simplifiedMaterial2;
	public Material simplifiedMaterial3;
	public Material enragedSimplifiedMaterial;
	public bool ignoreCustomColor;
	public Material[] matList;
	public enum MaterialState
	{
		normal,
		simplified,
		enraged,
		enragedSimplified
	};

	 
	void Start() { }
	void TryRemoveSimplifier() { }
	private void OnEnable() { }
	 
	void Update() { }
	public void SetOutline(bool forceUpdate) { }
	public void UpdateColors() { }
	public void Begone() { }
	public void ChangeMaterialNew(MaterialState stateToTarget, Material newMaterial) { }
	 
	public void ChangeMaterial(Material oldMaterial, Material newMaterial) { }}
