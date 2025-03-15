using UnityEngine;

public class LightningStrikeDecorative : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer lightning;

	[SerializeField]
	private Light flash;

	[SerializeField]
	private AudioSource thunder;

	private float originalFlashIntensity;

	private Color originalColor;

	private float cooldown;

	private bool flashing;

	public bool flashOnStart;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void FlashStart()
	{
	}
}
