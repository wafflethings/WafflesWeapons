using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class ColorBlindSettings : MonoSingleton<ColorBlindSettings>
{
	public Color[] variationColors;

	[Header("HUD Colors")]
	public Color healthBarColor;

	public Color healthBarAfterImageColor;

	public Color antiHpColor;

	public Color overHealColor;

	public Color healthBarTextColor;

	public Color staminaColor;

	public Color staminaChargingColor;

	public Color staminaEmptyColor;

	public Color railcannonFullColor;

	public Color railcannonChargingColor;

	[Header("Enemy Colors")]
	public Color filthColor;

	public Color strayColor;

	public Color schismColor;

	public Color shotgunnerColor;

	public Color stalkerColor;

	public Color sisyphusColor;

	public Color ferrymanColor;

	public Color droneColor;

	public Color streetcleanerColor;

	public Color swordsmachineColor;

	public Color mindflayerColor;

	public Color v2Color;

	public Color turretColor;

	public Color guttermanColor;

	public Color guttertankColor;

	public Color maliciousColor;

	public Color cerberusColor;

	public Color idolColor;

	public Color mannequinColor;

	public Color virtueColor;

	public Color enrageColor;

	public void UpdateEnemyColors()
	{
	}

	public void UpdateHudColors()
	{
	}

	public void UpdateWeaponColors()
	{
	}

	public Color GetEnemyColor(EnemyType ect)
	{
		return default(Color);
	}

	public Color GetHudColor(HudColorType hct)
	{
		return default(Color);
	}

	public void SetEnemyColor(EnemyType ect, Color color)
	{
	}

	public void SetHudColor(HudColorType hct, Color color)
	{
	}
}
