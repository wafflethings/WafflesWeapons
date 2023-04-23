using UnityEngine;

public enum TextureType{
    Main,
    Emissive
}

public class AnimatedTexture : MonoBehaviour
{
    [SerializeField] private int materialIndex;
    [SerializeField] private float delay;
    [SerializeField] private Texture2D[] framePool;
    [SerializeField] private TextureType textureType;

    private void Update() { }}