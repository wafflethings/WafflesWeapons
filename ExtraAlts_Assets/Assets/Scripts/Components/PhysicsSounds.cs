using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class PhysicsSounds : MonoSingleton<PhysicsSounds>
{
    [SerializeField] private PhysSounds sounds;
    [SerializeField] private AudioSource template;
    
    public void ImpactAt(Vector3 point, float magnitude, PhysMaterial material) { }
    [System.Serializable]
    public struct PhysSounds
    {
        public AudioClip plastic;
        public AudioClip wood;
        public AudioClip stone;
        public AudioClip metal;
        public AudioClip fleshy;
        public AudioClip glass;
        public AudioClip grass;
    }
    
    public enum PhysMaterial { Plastic, Wood, Stone, Metal, Fleshy, Glass, Grass }
}
