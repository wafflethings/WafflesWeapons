using System;
using UnityEngine;

public class RandomBase<T> : MonoBehaviour where T : RandomEntry, new()
{
    public bool randomizeOnEnable = true;
    public int toBeEnabledCount = 1;
    public T[] entries;
    
    bool firstDeserialization = true;
    private int arrayLength;
    
    public virtual void Randomize() { }
    public virtual void RandomizeWithCount(int count) { }
    public virtual void PerformTheAction(RandomEntry entry) { }
    
    // Stupid fucking hack for this stupid engine
    void OnValidate ()
    {
        if (firstDeserialization)
        {
            // This is the first time the editor properties have been deserialized in the object.
            // We take the actual array size.
            if (entries == null) entries = new T[0];
            arrayLength = entries.Length;
            firstDeserialization = false;
        }
        else
        {
            // Something have changed in the object's properties. Verify whether the array size
            // has changed. If it has been expanded, initialize the new elements.
            //
            // Without this, new elements would be initialized to zero / null (first new element)
            // or to the value of the last element.
 
            if (entries.Length != arrayLength)
            {
                if (entries.Length > arrayLength)
                {
                    for (int i = arrayLength; i < entries.Length; i++)
                        entries[i] = new T();
                }
 
                arrayLength = entries.Length;
            }
        }
    }
}

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