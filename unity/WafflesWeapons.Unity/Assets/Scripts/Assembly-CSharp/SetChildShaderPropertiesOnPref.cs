using System.Collections.Generic;
using UnityEngine;

public class SetChildShaderPropertiesOnPref : MonoBehaviour
{
	private List<Renderer> renderers;

	public bool localPref;

	public string prefName;

	[Space]
	public ShaderProperty[] onTrue;

	public ShaderProperty[] onFalse;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}
}
