using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VariationInfo : MonoBehaviour
{
	public GameObject varPage;

	private int money;

	public int cost;

	public TMP_Text costText;

	public ShopButton buyButton;

	private TMP_Text buttonText;

	public GameObject buySound;

	public Image icon;

	public TMP_Text equipText;

	public GameObject equipButtons;

	private int equipStatus;

	public Button equipStatusButton;

	public bool alreadyOwned;

	public string weaponName;

	private GunSetter gs;

	private FistControl fc;

	private GameObject player;

	public GameObject orderButtons;

	[SerializeField]
	private Animator drawer;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	public void UpdateMoney()
	{
	}

	public void WeaponBought()
	{
	}

	public void ChangeEquipment(int value)
	{
	}

	private void SetEquipStatusText(int equipStatus)
	{
	}
}
