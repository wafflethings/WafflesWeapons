using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveSetter : MonoBehaviour
{
	public int wave;

	private WaveMenu wm;

	private ButtonState _state;

	private ShopButton shopButton;

	private bool prepared;

	private Button button;

	[SerializeField]
	private Image buttonGraphic;

	[SerializeField]
	private TMP_Text buttonText;

	public ButtonState state
	{
		get
		{
			return default(ButtonState);
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	private void Select()
	{
	}
}
