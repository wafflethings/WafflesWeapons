using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine.InputSystem;

public class JsonBinding
{
	public string path;

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
	public bool isComposite;

	[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
	public Dictionary<string, string> parts;

	private JsonBinding()
	{
	}

	public static List<JsonBinding> FromAction(InputAction action, string group)
	{
		return null;
	}
}
