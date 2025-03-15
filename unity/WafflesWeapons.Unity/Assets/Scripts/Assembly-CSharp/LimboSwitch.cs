using UnityEngine;
using UnityEngine.Events;

public class LimboSwitch : MonoBehaviour
{
	public SwitchLockType type;

	public bool beenPressed;

	public int switchNumber;

	private float fadeAmount;

	public bool dontSave;

	public UnityEvent onAlreadyPressed;

	public UnityEvent onDelayedEffect;

	private MaterialPropertyBlock block;

	private MeshRenderer mr;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void Pressed()
	{
	}

	private void DelayedEffect()
	{
	}
}
