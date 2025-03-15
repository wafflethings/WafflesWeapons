using System.Collections.Generic;
using UnityEngine;

public class ComponentsDatabase : MonoSingleton<ComponentsDatabase>
{
	public HashSet<Transform> scrollers;
}
