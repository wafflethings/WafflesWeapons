using UnityEngine;
using UnityEngine.UI;

public class PrefOptionToggle : MonoBehaviour
{
	public string prefName;

	public bool isLocal;

	public bool fallbackValue;

	public Toggle toggle;

	private void Awake()
	{
	}

	private bool GetPref()
	{
		return false;
	}

	private void OnToggle(bool value)
	{
	}
}
