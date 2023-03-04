using UnityEngine;

public class Cannonball : MonoBehaviour
{
    public bool launched;
    [SerializeField] private GameObject breakEffect;
    private bool checkingForBreak;
    public float damage;
    public float speed;

    private void FixedUpdate() { }
    
    public void Launch() { }
}
