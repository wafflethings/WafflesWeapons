using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomContentButton : MonoBehaviour
{
	public Button button;

	public Image icon;

	public Image iconInset;

	public Image border;

	public TMP_Text text;

	public TMP_Text costText;

	public List<GameObject> objectsToActivateIfAvailable;
}
