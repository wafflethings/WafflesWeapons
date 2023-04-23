using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum DecimalType
{
    NoLimit,
    Three,
    Two,
    One,
    NoDecimals
}

public class SliderValueToText : MonoBehaviour
{
    public DecimalType decimalType;
    public string suffix;
    public string ifMax;
    public string ifMin;
    public Color minColor;
    public Color maxColor;

     
    void Start() { }
     
    void Update() { }}
