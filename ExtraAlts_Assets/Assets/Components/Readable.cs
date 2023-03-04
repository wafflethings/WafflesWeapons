using UnityEngine;

public class Readable : MonoBehaviour
{
    [SerializeField] [TextArea(3, 12)] public string content;
    [SerializeField] private bool instantScan;

    public void PickUp() { }

    public void PutDown() { }
}
