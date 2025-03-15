using System;
using UnityEngine;

[Serializable]
public struct AlterOption
{
	public string targetKey;

	[Space]
	public bool useInt;

	public int intValue;

	[Space]
	public bool useFloat;

	public float floatValue;

	[Space]
	public bool useBool;

	public bool boolValue;

	[Space]
	public bool useVector;

	public Vector3 vectorValue;
}
