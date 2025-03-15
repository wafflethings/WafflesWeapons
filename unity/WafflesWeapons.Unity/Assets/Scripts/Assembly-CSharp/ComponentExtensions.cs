using System;
using UnityEngine;

public static class ComponentExtensions
{
	public static T GetOrAddComponent<T>(this Component component) where T : Component
	{
		return null;
	}

	public static Component GetOrAddComponent(this Component component, Type componentType)
	{
		return null;
	}
}
