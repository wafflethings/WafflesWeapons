using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;

public class GhostDrone : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAttack_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GhostDrone _003C_003E4__this;

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
		public _003CAttack_003Ed__35(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CFly_003Ed__36 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GhostDrone _003C_003E4__this;

		private Vector3 _003CstartPos_003E5__2;

		private bool _003CnoTarget_003E5__3;

		private Vector3 _003CtargetPos_003E5__4;

		private Quaternion _003CstartDir_003E5__5;

		private Quaternion _003ClookDir_003E5__6;

		private float _003Celapsed_003E5__7;

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
		public _003CFly_003Ed__36(int _003C_003E1__state)
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

	private LayerMask avoidanceMask;

	public float detectionAngle;

	public float detectionDistance;

	public float idleSpeed;

	public float attackSpeed;

	private float variableAttackSpeed;

	[HideInInspector]
	public Vector3 vacuumVelocity;

	private Vector3 originalPos;

	private Animator animator;

	private PlayerTracker pt;

	private Coroutine crt;

	private bool isAttacking;

	public bool alwaysAggro;

	[SerializeField]
	private GameObject killZone;

	private Light aggroLight;

	private Color startLightColor;

	private float startLightIntensity;

	private AudioSource aud;

	[SerializeField]
	private AudioClip spottedSound;

	[SerializeField]
	private AudioClip lostSound;

	[SerializeField]
	private AudioClip[] idleSounds;

	private TimeSince lastIdleSound;

	private Rigidbody rb;

	public AudioMixerGroup audioGroup;

	public GameObject deathExplosion;

	[SerializeField]
	private AudioClip ghostDeathSound;

	private bool isSucked;

	private bool wasSuckedLastFrame;

	private static readonly int IsScared;

	[SerializeField]
	private AudioSource scaredAudioSource;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void LateUpdate()
	{
	}

	private void TryFindPlayer()
	{
	}

	public void KillGhost()
	{
	}

	[IteratorStateMachine(typeof(_003CAttack_003Ed__35))]
	private IEnumerator Attack()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CFly_003Ed__36))]
	private IEnumerator Fly()
	{
		return null;
	}

	public Vector3 RandomNavmeshLocation(float radius)
	{
		return default(Vector3);
	}
}
