using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveCustomSetter : MonoBehaviour
{
	public enum ButtonState
	{
		Selected = 0,
		Unselected = 1
	}

	private int _wave;

	public int waveChangeAmount;

	private WaveMenu wm;

	private ButtonState _state;

	private ShopButton shopButton;

	private bool prepared;

	private Button button;

	[SerializeField]
	private Image buttonGraphic;

	[SerializeField]
	private TMP_Text buttonText;

	[SerializeField]
	private Button increaseButton;

	[SerializeField]
	private Button decreaseButton;

	[SerializeField]
	private Image increaseArrow;

	[SerializeField]
	private Image decreaseArrow;

	[Space]
	[SerializeField]
	private ShopButton increaseShopButton;

	[SerializeField]
	private ShopButton decreaseShopButton;

	public int wave
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

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

	public void IncreaseWave()
	{
	}

	public void DecreaseWave()
	{
	}

	private void UpdateChangeButtons()
	{
	}

	private void Select()
	{
	}
}
