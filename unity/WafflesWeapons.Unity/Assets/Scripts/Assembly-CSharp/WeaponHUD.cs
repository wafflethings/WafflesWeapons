using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class WeaponHUD : MonoSingleton<WeaponHUD>
{
	private Image img;

	private Image glowImg;

	protected override void Awake()
	{
	}

	public void UpdateImage(Sprite icon, Sprite glowIcon, int variation)
	{
	}
}
