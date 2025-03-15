using Train;
using UnityEngine;
using UnityEngine.UI;

public class TramControl : MonoBehaviour
{
    [SerializeField] private Tram targetTram;
    [Space]
    [SerializeField] private GameObject clickSound;
    [SerializeField] private GameObject clickFailSound;
    [Space]
    [SerializeField] private int maxSpeedStep;
    [SerializeField] private int minSpeedStep;
    [SerializeField] private float speedMultiplier;
    [SerializeField] private Image[] speedIndicators;
    public float maxPlayerDistance = 15;
    
    public int currentSpeedStep;

    public void SpeedUp() { }

    public void SpeedDown() { }
    
    public bool SpeedUp(int amount)
    {
        return false;
    }
        
    public bool SpeedDown(int amount)
    {
        return false;
    }

    private void LateUpdate() { }
    private void FixedUpdate() { }
}
