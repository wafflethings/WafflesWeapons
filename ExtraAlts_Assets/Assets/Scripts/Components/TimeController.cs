using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class TimeController : MonoSingleton<TimeController>
{
	[SerializeField] GameObject parryLight;
	[SerializeField] GameObject parryFlash;
	public float timeScale;
	public float timeScaleModifier;

    void Start() { }
	void Update() { }
	private void FixedUpdate() { }
	public void ParryFlash() { }
	void HideFlash() { }
	public void SlowDown(float amount) { }
	public void HitStop(float length) { }
	public void TrueStop(float length) { }
	void ContinueTime(float length, bool trueStop) { }}
