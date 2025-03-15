using System.Collections.Generic;
using UnityEngine;

public class LightningStrikeDecorative_Animated : MonoBehaviour
{
	[Header("Animations")]
	[SerializeField]
	private List<Texture2DArray> buildupAnim;

	[SerializeField]
	private float buildupTime;

	[SerializeField]
	private List<Texture2DArray> strikeAnim;

	[SerializeField]
	private float strikeTime;

	[SerializeField]
	private AnimatedTexture lightningAnim;

	[Header("Lightning Effects")]
	[SerializeField]
	private Light flash;

	[SerializeField]
	private AudioSource thunder;

	[HideInInspector]
	public float origPitch;

	[Header("Cooldown Settings")]
	[SerializeField]
	private float minInitialCooldown;

	[SerializeField]
	private float maxInitialCooldown;

	[SerializeField]
	private float minAfterCooldown;

	[SerializeField]
	private float maxAfterCooldown;

	[Header("Start Settings")]
	public bool flashOnStart;

	private float originalFlashIntensity;

	private float time;

	private float cooldown;

	private bool flashing;

	private bool inBuildup;

	private bool inStrike;

	private int atlasIndex;

	private float originalScale;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void FlashStart()
	{
	}
}
