using UnityEngine;
using Random = UnityEngine.Random;

public class BulkInstantiate : MonoBehaviour
{
    [SerializeField] private int count = 1;
    [SerializeField] private bool instantiateOnEnable = false;
    [SerializeField] private bool instantiateOnStart = true;
    [SerializeField] private GameObject source;
    [SerializeField] private InstantiateObjectMode mode = InstantiateObjectMode.Normal;

    private void OnEnable() { }    
    private void Start() { }
    private void OnDrawGizmos() { }
    public void Instantiate() { }}
