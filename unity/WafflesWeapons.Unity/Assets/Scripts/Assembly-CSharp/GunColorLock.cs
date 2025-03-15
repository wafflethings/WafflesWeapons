using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GunColorLock : MonoBehaviour
{
	private int weaponNumber;

	public bool alreadyUnlocked;

	public UltrakillEvent onUnlock;

	public GameObject buySound;

	public Button button;

	public TMP_Text buttonText;

	private void OnEnable()
	{
	}

	public void Unlock()
	{
	}
}
