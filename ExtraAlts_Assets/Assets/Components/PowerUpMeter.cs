using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class PowerUpMeter : MonoSingleton<PowerUpMeter>
{
    public float juice;
    public float latestMaxJuice;
    public Image vignette;
    public Color powerUpColor;
}
