using UnityEngine;

[CreateAssetMenu(menuName = "ULTRAKILL/Spawnable Object")]
public class SpawnableObject : ScriptableObject
{
    public string objectName;
    public GameObject gameObject;
    public GameObject preview;
    public Sprite gridIcon;
    public Color backgroundColor;
}