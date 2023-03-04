using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeOfDayChanger : MonoBehaviour
{

    public Light[] oldLights;
    public Light[] newLights;

    public Material oldWalls;
    public Material oldSky;
    public Material newWalls;
    public Material newSky;

    public bool toBattleMusic;
    public bool toBossMusic;
    public bool musicWaitsUntilChange;

    public Material newSkybox;
    public Color fogColor;
    public SpriteRenderer sunSprite;
    public Color sunSpriteColor;

    public UnityEvent onMaterialChange;
}
