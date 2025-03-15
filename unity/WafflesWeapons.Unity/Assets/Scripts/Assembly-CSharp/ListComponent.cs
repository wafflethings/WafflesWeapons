using System.Collections.Generic;
using UnityEngine;

public abstract class ListComponent<T> : MonoBehaviour where T : MonoBehaviour
{
	public static List<T> InstanceList;

	protected virtual void Awake()
	{
	}

	protected virtual void OnDestroy()
	{
	}
}
