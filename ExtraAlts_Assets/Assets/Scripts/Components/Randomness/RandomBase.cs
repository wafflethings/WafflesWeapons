using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomBase<T> : MonoBehaviour where T : RandomEntry, new()
{
    public bool randomizeOnEnable = true;
    public int toBeEnabledCount = 1;
    public T[] entries;
    
    private void OnEnable() { }    
    public virtual void Randomize() { }
    public virtual void RandomizeWithCount(int count) { }
    public virtual void PerformTheAction(RandomEntry entry) { }    
     
    void OnValidate () { }}

[Serializable]
public class RandomEntry
{
    [Min(0)] [Tooltip("The bigger the weight, the bigger the chance.")] public int weight = 1;
}

[Serializable] 
public class RandomGameObjectEntry : RandomEntry
{
    public GameObject targetObject;
}