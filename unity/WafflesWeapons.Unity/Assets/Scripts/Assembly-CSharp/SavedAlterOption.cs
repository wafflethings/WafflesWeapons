using System;
using Newtonsoft.Json;
using UnityEngine;

[Serializable]
public class SavedAlterOption
{
	public string Key;

	[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
	public float? FloatValue;

	[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
	public bool? BoolValue;

	[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
	public Vector3? VectorData;

	[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
	public int? IntValue;
}
