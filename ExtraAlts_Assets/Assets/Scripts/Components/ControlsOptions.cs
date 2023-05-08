using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsOptions : MonoBehaviour
{
    public OptionsManager opm;

    public Text wText;
    public Text sText;
    public Text aText;
    public Text dText;

    public Text jumpText;
    public Text dodgeText;
    public Text slideText;

    public Text fire1Text;
    public Text fire2Text;
    public Text punchText;
    public Text lastUsedWeaponText;
    public Text changeVariation;
    public Text changeFist;
    public Text hook;

    public Text slot1text;
    public Text slot2text;
    public Text slot3text;
    public Text slot4text;
    public Text slot5text;

    public Toggle scrollWheel;
     
    public Dropdown variationWheel;
    public Toggle reverseWheel;

    public Color normalColor;
    public Color pressedColor;

     
    void Start() { }
    private void OnDisable() { }
    private void LateUpdate() { }
    private void OnGUI() { }
    public void ChangeKey(GameObject stuff) { }
    public void ResetKeys() { }
    public void ScrollOn(bool stuff) { }
    public void ScrollVariations(int stuff) { }
    public void ScrollReverse(bool stuff) { }}
