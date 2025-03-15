using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Magnet : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CZap_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Magnet _003C_003E4__this;

		public List<GameObject> alreadyHitObjects;

		public float damage;

		public GameObject sourceWeapon;

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
		public _003CZap_003Ed__31(int _003C_003E1__state)
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

	private List<Rigidbody> affectedRbs;

	private List<Rigidbody> removeRbs;

	private List<EnemyIdentifier> eids;

	private List<Rigidbody> eidRbs;

	public List<EnemyIdentifier> ignoredEids;

	public EnemyIdentifier onEnemy;

	public List<Magnet> connectedMagnets;

	public List<Rigidbody> sawblades;

	public List<Rigidbody> rockets;

	public List<Rigidbody> chainsaws;

	private SphereCollider col;

	public float strength;

	private LayerMask lmask;

	private RaycastHit rhit;

	private bool beenZapped;

	[SerializeField]
	private float maxWeight;

	private TimeBomb tb;

	[HideInInspector]
	public float health;

	private float maxWeightFinal => 0f;

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

	public void Launch()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnTriggerExit(Collider other)
	{
	}

	public void ConnectMagnets(Magnet target)
	{
	}

	public void DisconnectMagnets(Magnet target)
	{
	}

	public void ExitEnemy(EnemyIdentifier eid)
	{
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CZap_003Ed__31))]
	public IEnumerator Zap(List<GameObject> alreadyHitObjects, float damage = 1f, GameObject sourceWeapon = null)
	{
		return null;
	}

	public void DamageMagnet(float damage)
	{
	}
}
