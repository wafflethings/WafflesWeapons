using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    [SerializeField] private bool destroyOnEnable;
    [SerializeField] private bool dontDestroyOnTrigger;
    [SerializeField] private GameObject[] targets;
    
    private void OnEnable() { }
    public void Destroy() { }}