using System.Collections.Generic;
using UnityEngine;

public class StalkerController : MonoSingleton<StalkerController>
{
	public List<Transform> targets;

	public bool CheckIfTargetTaken(Transform target)
	{
		return false;
	}
}
