using UnityEngine;

public class EnviroMaterialGetter : MonoBehaviour
{
	public bool oneTime;

	[HideInInspector]
	public Vector3 previousActivationPosition;

	public Vector3 getRayDirection;

	public bool relative;

	[Space]
	public MeshRenderer[] targets;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void Activate()
	{
	}
}
