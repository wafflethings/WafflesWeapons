using UnityEngine;

[CreateAssetMenu(menuName = "ULTRAKILL/Spawnable Object List")]
public class SpawnableObjectsDatabase : ScriptableObject
{
    public SpawnableObject[] enemies;
    public SpawnableObject[] objects;
    public SpawnableObject[] debug;
}