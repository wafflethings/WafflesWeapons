using System;
using UnityEngine;

// Token: 0x0200028E RID: 654
public class SpriteGetVariationColor : MonoBehaviour
{
	// Token: 0x06000E45 RID: 3653 RVA: 0x0009C524 File Offset: 0x0009A724
	private void Update()
	{
		foreach (SpriteRenderer spriteRenderer in this.sprites)
		{
			//spriteRenderer.color = new Color(MonoSingleton<ColorBlindSettings>.Instance.variationColors[this.variation].r, MonoSingleton<ColorBlindSettings>.Instance.variationColors[this.variation].g, MonoSingleton<ColorBlindSettings>.Instance.variationColors[this.variation].b, spriteRenderer.color.a);
		}
	}

	// Token: 0x04001671 RID: 5745
	[SerializeField]
	private SpriteRenderer[] sprites;

	// Token: 0x04001672 RID: 5746
	[SerializeField]
	private int variation;
}
