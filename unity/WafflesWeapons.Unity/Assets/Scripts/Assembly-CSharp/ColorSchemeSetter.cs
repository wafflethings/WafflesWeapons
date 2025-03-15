using UnityEngine;

public class ColorSchemeSetter : MonoBehaviour
{
	public bool replaceDitherUserSetting;

	public float ditheringAmount;

	public bool enforceMapColorPalette;

	public Texture mapDefinedPalette;

	public bool applyOnPlayerTriggerEnter;

	public bool applyOnPlayerTriggerExit;

	public bool oneTime;

	public void Apply()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnTriggerExit(Collider other)
	{
	}
}
