using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class OutdoorLightMaster : MonoSingleton<OutdoorLightMaster>
{
    public bool inverse;
    public Light[] extraLights;
    public GameObject[] activateWhenOutside;
    public bool dontRotateSkybox;
    public bool waitForFirstDoorOpen;

    public void AddRequest()
{}
    public void RemoveRequest()
{}
    public void FirstDoorOpen()
{}
    public void UpdateSkyboxMaterial()
{}}
