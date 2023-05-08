using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class LevelNamePopup : MonoSingleton<LevelNamePopup>
{
    public Text[] layerText;

    public Text[] nameText;

     
    void Start() { }
     
    void Update() { }
    public void NameAppear() { }}
