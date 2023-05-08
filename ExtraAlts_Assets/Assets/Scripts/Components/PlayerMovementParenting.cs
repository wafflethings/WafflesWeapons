using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class PlayerMovementParenting : MonoSingleton<PlayerMovementParenting>
{
    public Vector3 currentDelta {get;set;}    public Transform deltaReceiver;
    public List<Transform> TrackedObjects {get;set;}
    void FixedUpdate() { }
    public void AttachPlayer(Transform other) { }
    public void DetachPlayer([CanBeNull] Transform other = null) { }}