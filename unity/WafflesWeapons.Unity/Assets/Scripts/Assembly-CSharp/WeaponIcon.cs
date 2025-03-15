using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class WeaponIcon : MonoBehaviour
{
	[FormerlySerializedAs("descriptor")]
	public WeaponDescriptor weaponDescriptor;

	[SerializeField]
	private Renderer[] variationColoredRenderers;

	[SerializeField]
	private Image[] variationColoredImages;

	private int variationColor => 0;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	public void UpdateIcon()
	{
	}
}
