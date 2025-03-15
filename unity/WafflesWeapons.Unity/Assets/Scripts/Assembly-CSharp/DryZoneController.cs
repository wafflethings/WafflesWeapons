using System.Collections.Generic;
using UnityEngine;

public class DryZoneController : MonoSingleton<DryZoneController>
{
	public HashSet<Water> waters;

	public Dictionary<Collider, int> colliderCalls;

	public HashSet<DryZone> dryZones;

	public void AddCollider(Collider other)
	{
	}

	public void RemoveCollider(Collider other)
	{
	}
}
