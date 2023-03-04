using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000203 RID: 515
public class Punch : MonoBehaviour
{
	// Token: 0x06000BB8 RID: 3000 RVA: 0x00080FB8 File Offset: 0x0007F1B8
	private void Start()
	{

	}

	// Token: 0x06000BB9 RID: 3001 RVA: 0x0008112C File Offset: 0x0007F32C
	private void OnEnable()
	{

	}

	// Token: 0x06000BBA RID: 3002 RVA: 0x00081240 File Offset: 0x0007F440
	public void ResetHeldState()
	{

	}

	// Token: 0x06000BBB RID: 3003 RVA: 0x00081270 File Offset: 0x0007F470
	public void ForceThrow()
	{

	}

	// Token: 0x06000BBC RID: 3004 RVA: 0x00081468 File Offset: 0x0007F668
	public void PlaceHeldObject(ItemPlaceZone[] placeZones, Transform target)
	{

	}

	// Token: 0x06000BBD RID: 3005 RVA: 0x000816B8 File Offset: 0x0007F8B8
	public void ResetHeldItemPosition()
	{

	}

	// Token: 0x06000BBE RID: 3006 RVA: 0x000817A8 File Offset: 0x0007F9A8
	public void ForceHold(ItemIdentifier itid)
	{

	}

	// Token: 0x06000BBF RID: 3007 RVA: 0x000819FE File Offset: 0x0007FBFE
	private void OnDisable()
	{

	}

	// Token: 0x06000BC0 RID: 3008 RVA: 0x00081A34 File Offset: 0x0007FC34
	private void Update()
	{

	}

	// Token: 0x06000BC1 RID: 3009 RVA: 0x00081D7C File Offset: 0x0007FF7C
	private void PunchStart()
	{

	}

	// Token: 0x06000BC2 RID: 3010 RVA: 0x00081E50 File Offset: 0x00080050
	private void ActiveStart()
	{

	}

	// Token: 0x06000BC3 RID: 3011 RVA: 0x00082BFC File Offset: 0x00080DFC
	private bool CheckForProjectile(Transform target)
	{
		return false;
	}

	// Token: 0x06000BC4 RID: 3012 RVA: 0x00082E5C File Offset: 0x0008105C
	public void CoinFlip()
	{

	}

	// Token: 0x06000BC5 RID: 3013 RVA: 0x00082E9C File Offset: 0x0008109C
	private void ActiveEnd()
	{

	}

	// Token: 0x06000BC6 RID: 3014 RVA: 0x00082ED6 File Offset: 0x000810D6
	public void ResetFistRotation()
	{

	}

	// Token: 0x06000BC7 RID: 3015 RVA: 0x00005EC5 File Offset: 0x000040C5
	private void PunchEnd()
	{
	}

	// Token: 0x06000BC8 RID: 3016 RVA: 0x00082EE0 File Offset: 0x000810E0
	private void ReadyToPunch()
	{

	}

	// Token: 0x06000BC9 RID: 3017 RVA: 0x00082F08 File Offset: 0x00081108
	private void PunchSuccess(Vector3 point, Transform target)
	{

	}

	// Token: 0x06000BCA RID: 3018 RVA: 0x000833AC File Offset: 0x000815AC
	public void Parry(bool hook = false, EnemyIdentifier eid = null)
	{

	}

	// Token: 0x06000BCB RID: 3019 RVA: 0x00083454 File Offset: 0x00081654
	private void ParryProjectile(Projectile proj)
	{

	}

	// Token: 0x06000BCC RID: 3020 RVA: 0x00083728 File Offset: 0x00081928
	public void BlastCheck()
	{

	}

	// Token: 0x06000BCD RID: 3021 RVA: 0x0008380C File Offset: 0x00081A0C
	public void Eject()
	{

	}

	// Token: 0x06000BCE RID: 3022 RVA: 0x00005EC5 File Offset: 0x000040C5
	public void Hide()
	{
	}

	// Token: 0x06000BCF RID: 3023 RVA: 0x00083950 File Offset: 0x00081B50
	public void ShopMode()
	{

	}

	// Token: 0x06000BD0 RID: 3024 RVA: 0x00083970 File Offset: 0x00081B70
	public void StopShop()
	{

	}

	// Token: 0x06000BD1 RID: 3025 RVA: 0x000839A4 File Offset: 0x00081BA4
	public void EquipAnimation()
	{

	}

	// Token: 0x06000BD2 RID: 3026 RVA: 0x000839E0 File Offset: 0x00081BE0
	private void AltHit(Transform target)
	{

	}

	// Token: 0x06000BD3 RID: 3027 RVA: 0x00083A95 File Offset: 0x00081C95
	public void CancelAttack()
	{

	}

	// Token: 0x06000BD4 RID: 3028 RVA: 0x00083AC4 File Offset: 0x00081CC4
	public static Vector3 GetParryLookTarget()
	{
		return default(Vector3);
	}

	// Token: 0x06000BD5 RID: 3029 RVA: 0x00083B90 File Offset: 0x00081D90
	public Punch()
	{
	}

	// Token: 0x04001236 RID: 4662
	private InputManager inman;

	// Token: 0x04001237 RID: 4663
	public FistType type;

// Token: 0x02000202 RID: 514
public enum FistType
{
	// Token: 0x04001233 RID: 4659
	Standard,
	// Token: 0x04001234 RID: 4660
	Heavy,
	// Token: 0x04001235 RID: 4661
	Spear
}


// Token: 0x04001238 RID: 4664
private string hitter;

	// Token: 0x04001239 RID: 4665
	private float damage;

	// Token: 0x0400123A RID: 4666
	private float screenShakeMultiplier;

	// Token: 0x0400123B RID: 4667
	private float force;

	// Token: 0x0400123C RID: 4668
	private bool tryForExplode;

	// Token: 0x0400123D RID: 4669
	private float cooldownCost;

	// Token: 0x0400123E RID: 4670
	public bool ready = true;

	// Token: 0x0400123F RID: 4671
	[HideInInspector]
	public Animator anim;

	// Token: 0x04001240 RID: 4672
	private SkinnedMeshRenderer smr;

	// Token: 0x04001241 RID: 4673
	private Revolver rev;

	// Token: 0x04001242 RID: 4674
	private AudioSource aud;

	// Token: 0x04001243 RID: 4675
	private GameObject camObj;

	// Token: 0x04001245 RID: 4677
	private RaycastHit hit;

	// Token: 0x04001246 RID: 4678
	public LayerMask deflectionLayerMask;

	// Token: 0x04001247 RID: 4679
	public LayerMask ignoreEnemyTrigger;

	// Token: 0x04001248 RID: 4680
	public LayerMask environmentMask;


	// Token: 0x0400124A RID: 4682
	private TrailRenderer tr;

	// Token: 0x0400124B RID: 4683
	private Light parryLight;

	// Token: 0x0400124C RID: 4684
	private GameObject currentDustParticle;

	// Token: 0x0400124D RID: 4685
	public GameObject dustParticle;

	// Token: 0x0400124E RID: 4686
	public AudioSource normalHit;

	// Token: 0x0400124F RID: 4687
	public AudioSource heavyHit;

	// Token: 0x04001250 RID: 4688
	public AudioSource specialHit;

	// Token: 0x04001252 RID: 4690
	private StatsManager sman;

	// Token: 0x04001253 RID: 4691
	public bool holding;

	// Token: 0x04001254 RID: 4692
	public Transform holder;

	// Token: 0x04001255 RID: 4693
	public ItemIdentifier heldItem;

	// Token: 0x04001257 RID: 4695
	private bool shopping;

	// Token: 0x04001258 RID: 4696
	private int shopRequests;

	// Token: 0x04001259 RID: 4697
	public GameObject parriedProjectileHitObject;

	// Token: 0x0400125B RID: 4699
	private bool returnToOrigRot;

	// Token: 0x0400125C RID: 4700
	public GameObject blastWave;

	// Token: 0x0400125D RID: 4701
	private bool holdingInput;

	// Token: 0x0400125E RID: 4702
	public GameObject shell;

	// Token: 0x0400125F RID: 4703
	public Transform shellEjector;

	// Token: 0x04001260 RID: 4704
	private AudioSource ejectorAud;

	// Token: 0x04001261 RID: 4705
	private bool alreadyBoostedProjectile;

	// Token: 0x04001262 RID: 4706
	private bool ignoreDoublePunch;

	// Token: 0x04001263 RID: 4707
	private bool hitSomething;
}
