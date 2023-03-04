using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200014A RID: 330
public class Grenade : MonoBehaviour
{
	// Token: 0x17000041 RID: 65
	// (get) Token: 0x060006C0 RID: 1728 RVA: 0x00044BB5 File Offset: 0x00042DB5
	public bool frozen
	{
		get
		{
			return false;
		}
	}

	// Token: 0x060006C1 RID: 1729 RVA: 0x00044BD0 File Offset: 0x00042DD0
	private void Awake()
	{

	}

	// Token: 0x060006C2 RID: 1730 RVA: 0x00044C17 File Offset: 0x00042E17
	private void Start()
	{
	}

	// Token: 0x060006C3 RID: 1731 RVA: 0x00044C2C File Offset: 0x00042E2C
	private void OnDestroy()
	{

	}

	// Token: 0x060006C4 RID: 1732 RVA: 0x00044CB4 File Offset: 0x00042EB4
	private void Update()
	{

	}

	// Token: 0x060006C5 RID: 1733 RVA: 0x00044D48 File Offset: 0x00042F48
	private void FixedUpdate()
	{

	}

	// Token: 0x060006C6 RID: 1734 RVA: 0x00045918 File Offset: 0x00043B18
	private void LateUpdate()
	{

	}

	// Token: 0x060006C7 RID: 1735 RVA: 0x00045B19 File Offset: 0x00043D19
	private void OnCollisionEnter(Collision collision)
	{
	}

	// Token: 0x060006C8 RID: 1736 RVA: 0x00045B2C File Offset: 0x00043D2C
	private void OnTriggerEnter(Collider other)
	{

	}

	// Token: 0x060006C9 RID: 1737 RVA: 0x00045B80 File Offset: 0x00043D80
	public void Collision(Collider other)
	{

	}

	// Token: 0x060006CA RID: 1738 RVA: 0x00046020 File Offset: 0x00044220
	public void Explode(bool big = false, bool harmless = false, bool super = false, float sizeMultiplier = 1f, bool ultrabooster = false, GameObject exploderWeapon = null)
	{

	}

	// Token: 0x060006CB RID: 1739 RVA: 0x00046208 File Offset: 0x00044408
	public void PlayerRideStart()
	{
		
	}

	// Token: 0x060006CC RID: 1740 RVA: 0x000462BF File Offset: 0x000444BF
	public void PlayerRideEnd()
	{

	}

	// Token: 0x060006CD RID: 1741 RVA: 0x000462F4 File Offset: 0x000444F4
	public void CanCollideWithPlayer(bool can = true)
	{

	}

	// Token: 0x04000AA0 RID: 2720
	public string hitterWeapon;

	// Token: 0x04000AA1 RID: 2721
	public GameObject sourceWeapon;

	// Token: 0x04000AA2 RID: 2722
	public GameObject explosion;

	// Token: 0x04000AA3 RID: 2723
	public GameObject harmlessExplosion;

	// Token: 0x04000AA4 RID: 2724
	public GameObject superExplosion;

	// Token: 0x04000AA5 RID: 2725
	private bool exploded;

	// Token: 0x04000AA6 RID: 2726
	public bool enemy;

	// Token: 0x04000AA7 RID: 2727
	public bool rocket;

	// Token: 0x04000AA8 RID: 2728
	[HideInInspector]
	public Rigidbody rb;

	// Token: 0x04000AA9 RID: 2729
	[HideInInspector]
	public List<Magnet> magnets = new List<Magnet>();

	// Token: 0x04000AAA RID: 2730
	[HideInInspector]
	public Magnet latestEnemyMagnet;

	// Token: 0x04000AAB RID: 2731
	public float rocketSpeed;

	// Token: 0x04000AAC RID: 2732
	[SerializeField]
	private GameObject freezeEffect;

	// Token: 0x04000AAD RID: 2733
	private CapsuleCollider col;

	// Token: 0x04000AAE RID: 2734
	public bool playerRiding;

	// Token: 0x04000AAF RID: 2735
	private bool playerInRidingRange = true;

	// Token: 0x04000AB0 RID: 2736
	private float downpull = -0.5f;

	// Token: 0x04000AB1 RID: 2737
	public GameObject playerRideSound;

	// Token: 0x04000AB2 RID: 2738
	[HideInInspector]
	public bool rideable;

	// Token: 0x04000AB3 RID: 2739
	private bool hasBeenRidden;
}
