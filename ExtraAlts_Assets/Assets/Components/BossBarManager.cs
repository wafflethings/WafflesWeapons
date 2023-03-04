using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class BossBarManager : MonoSingleton<BossBarManager>
{
    [System.
    //Fucking.
    Serializable]
    public class SliderLayer
    {
        public Color color;
        public Color afterImageColor;
    }
    
    [System.
    //Fucking.
    Serializable]
    public class HealthLayer
    {
        public float health;
    }
}