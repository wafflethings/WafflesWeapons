using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class StyleRank
{
    public Sprite sprite;
    public int maxMeter;
    public float drainSpeed;
}


public enum StyleFreshnessState
{
    Fresh,
    Used,
    Stale,
    Dull
}

[System.Serializable]
public class StyleFreshnessData{
    public StyleFreshnessState state;

    public string text;
    public float scoreMultiplier;

    public float min;
    public float max;
    public float span {get;set;}    public float justAboveMin {get;set;}
    public Slider slider;
}