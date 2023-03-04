using System;
using UnityEngine;

// Token: 0x020002EF RID: 751
public class SoundPitch : MonoBehaviour
{
	// Token: 0x06000F6C RID: 3948 RVA: 0x000A41A4 File Offset: 0x000A23A4
	private void Start()
	{
		this.aud = base.GetComponent<AudioSource>();
		bool flag = !this.notOnEnable;
		if (flag)
		{
			this.activated = true;
		}
	}

	// Token: 0x06000F6D RID: 3949 RVA: 0x000A41D4 File Offset: 0x000A23D4
	private void Update()
	{
		bool flag = this.aud && this.activated;
		if (flag)
		{
			this.aud.pitch = Mathf.MoveTowards(this.aud.pitch, this.targetPitch, this.speed * Time.deltaTime);
		}
	}

	// Token: 0x06000F6E RID: 3950 RVA: 0x00008E82 File Offset: 0x00007082
	public void Activate()
	{
		this.activated = true;
	}

	// Token: 0x06000F6F RID: 3951 RVA: 0x00008E8C File Offset: 0x0000708C
	public void Deactivate()
	{
		this.activated = false;
	}

	// Token: 0x06000F70 RID: 3952 RVA: 0x00008E96 File Offset: 0x00007096
	public void ChangePitch(float newPitch)
	{
		this.targetPitch = newPitch;
	}

	// Token: 0x06000F71 RID: 3953 RVA: 0x00008EA0 File Offset: 0x000070A0
	public void ChangeSpeed(float newSpeed)
	{
		this.speed = newSpeed;
	}

	// Token: 0x04001844 RID: 6212
	private AudioSource aud;

	// Token: 0x04001845 RID: 6213
	public float targetPitch;

	// Token: 0x04001846 RID: 6214
	public float speed;

	// Token: 0x04001847 RID: 6215
	public bool notOnEnable;

	// Token: 0x04001848 RID: 6216
	private bool activated;
}
