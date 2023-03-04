using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class SandboxNavmesh : MonoSingleton<SandboxNavmesh>
{
    [SerializeField] private NavMeshSurface surface;

    [NonSerialized] public bool isDirty;
    public UnityAction navmeshBuilt;

    public void MarkAsDirty()
    {
        
    }

    public void Rebake()
    {
        
    }
}
