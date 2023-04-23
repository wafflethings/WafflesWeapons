using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunColorSetter : MonoBehaviour
{
    public int colorNumber;

	public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;
	public Slider metalSlider;

	public Image colorExample;
	public Image metalExample;

	void OnEnable() { }
    public void SetRed(float amount) { }
    public void SetGreen(float amount) { }
	public void SetBlue(float amount) { }	public void SetMetal(float amount) { }
	public void UpdateColor() { }}
