using UnityEngine;
using System.Collections.Generic;

public abstract class ListComponent<T> : MonoBehaviour where T : MonoBehaviour
{

	protected virtual void Awake() { }
	protected virtual void OnDestroy() { }
}
