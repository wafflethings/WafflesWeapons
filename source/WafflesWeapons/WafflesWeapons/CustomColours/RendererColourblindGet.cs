using UnityEngine;

namespace WafflesWeapons.CustomColours;

public class RendererColourblindGet : MonoBehaviour
{
    [SerializeField] private int _variationNumber;
    
    private void Awake()
    {
        GetComponent<Renderer>().material.color = ColorBlindSettings.Instance.variationColors[_variationNumber];
    }
}
