using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class UnderwaterController : MonoSingleton<UnderwaterController>
{
	public Image overlay;

	private Color defaultColor;

	private Color offColor;

	private HashSet<Water> touchingWaters;

	private AudioLowPassFilter lowPass;

	public bool inWater;

	private AudioSource aud;

	public AudioClip underWater;

	public AudioClip surfacing;

	private Collider col;

	private List<Water> toRemove;

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	public void EnterWater(Water enteredWater)
	{
	}

	public void OutWater(Water enteredWater)
	{
	}

	private void RemoveFromWater()
	{
	}

	public void UpdateColor(Color newColor)
	{
	}
}
