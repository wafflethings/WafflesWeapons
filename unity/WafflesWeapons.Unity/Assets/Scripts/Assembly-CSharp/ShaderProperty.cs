using System;
using UnityEngine;

[Serializable]
public class ShaderProperty
{
	public string name;

	public bool setFloat;

	public float floatValue;

	public bool setInt;

	public int intValue;

	public bool setVector;

	public Vector4 vectorValue;

	public bool setColor;

	public Color colorValue;

	public void Set(Material material)
	{
	}
}
