using System;
using UnityEngine;

public static class GameObjectExtensions
{
	public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
	{
		return null;
	}

	public static Component GetOrAddComponent(this GameObject gameObject, Type componentType)
	{
		return null;
	}
}
