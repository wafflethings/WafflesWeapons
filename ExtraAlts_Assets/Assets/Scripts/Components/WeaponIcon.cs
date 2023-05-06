using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

// Token: 0x0200031E RID: 798
public class WeaponIcon : MonoBehaviour
{

	// Token: 0x04001BAD RID: 7085
	[FormerlySerializedAs("descriptor")]
	public WeaponDescriptor weaponDescriptor;

	// Token: 0x04001BAE RID: 7086
	[SerializeField]
	private Renderer[] variationColoredRenderers;

	// Token: 0x04001BAF RID: 7087
	[SerializeField]
	private Material[] variationColoredMaterials;

	// Token: 0x04001BB0 RID: 7088
	[SerializeField]
	private Image[] variationColoredImages;
}
