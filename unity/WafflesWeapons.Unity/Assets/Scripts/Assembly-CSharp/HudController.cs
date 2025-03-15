using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
	public static HudController Instance;

	public bool altHud;

	public bool colorless;

	private GameObject altHudObj;

	private HUDPos hudpos;

	public GameObject gunCanvas;

	public GameObject weaponIcon;

	public GameObject armIcon;

	public Sprite[] fistIcons;

	public Image fistFill;

	public Image fistBackground;

	public GameObject styleMeter;

	public GameObject styleInfo;

	public Speedometer speedometer;

	[Space]
	public Image[] hudBackgrounds;

	public TMP_Text[] textElements;

	[Space]
	public Material normalTextMaterial;

	public Material overlayTextMaterial;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void UpdateFistIcon(int current)
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnPrefChanged(string key, object value)
	{
	}

	private void SetWeaponIcons(bool showIcons)
	{
	}

	private void SetArmIcons(bool showIcons)
	{
	}

	public void SetStyleVisibleTemp(bool? meterVisible = null, bool? infoVisible = null)
	{
	}

	private void Update()
	{
	}

	private void Start()
	{
	}

	public void CheckSituation()
	{
	}

	public void SetOpacity(float amount)
	{
	}

	public void SetAlwaysOnTop(bool onTop)
	{
	}
}
