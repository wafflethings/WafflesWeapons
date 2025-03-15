using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Zapper : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CZapNextFrame_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Zapper _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CZapNextFrame_003Ed__30(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private LineRenderer lr;

	private Rigidbody rb;

	private AudioSource aud;

	[HideInInspector]
	public float damage;

	[HideInInspector]
	public GameObject sourceWeapon;

	public Transform lineStartTransform;

	public Rigidbody connectedRB;

	private ConfigurableJoint joint;

	[SerializeField]
	private GameObject openProngs;

	[SerializeField]
	private GameObject closedProngs;

	public float maxDistance;

	[HideInInspector]
	public float distance;

	[HideInInspector]
	public float charge;

	[HideInInspector]
	public float breakTimer;

	[HideInInspector]
	public bool raycastBlocked;

	private bool broken;

	public bool attached;

	public EnemyIdentifier attachedEnemy;

	public EnemyIdentifierIdentifier hitLimb;

	[SerializeField]
	private GameObject attachSound;

	[SerializeField]
	private Transform lightningPulseOrb;

	private LineRenderer pulseLine;

	[SerializeField]
	private GameObject zapParticle;

	[SerializeField]
	private AudioSource[] distanceWarningSounds;

	[SerializeField]
	private AudioSource cableSnap;

	[SerializeField]
	private AudioSource boostSound;

	[SerializeField]
	private GameObject breakParticle;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDisable()
	{
	}

	[IteratorStateMachine(typeof(_003CZapNextFrame_003Ed__30))]
	private IEnumerator ZapNextFrame()
	{
		return null;
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnCollisionEnter(Collision other)
	{
	}

	private void CheckAttach(Collider other, Vector3 position)
	{
	}

	private void Zap()
	{
	}

	public void Break(bool successful = false)
	{
	}

	public void ChargeBoost(float amount)
	{
	}
}
