using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DryZoneController : MonoSingleton<DryZoneController>
{
    public List<Water> waters = new List<Water>();
    public List<Collider> colliders = new List<Collider>();
    public List<int> colliderCalls = new List<int>();
    public List<DryZone> dryZones = new List<DryZone>();

    public void AddCollider(Collider other) { }
    public void RemoveCollider(Collider other) { }}
