using System;
using UnityEngine;

public class FishConstraints : MonoBehaviour
{
    [SerializeField] private Collider[] restrictToColliderBounds;
    [NonSerialized] public Bounds area;
    
    private void OnDrawGizmos() { }}