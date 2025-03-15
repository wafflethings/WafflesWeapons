using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ShotgunHammer : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CImpactRoutine_003Ed__81 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ShotgunHammer _003C_003E4__this;

		private Vector3 _003Cposition_003E5__2;

		private RaycastHit _003Crhit_003E5__3;

		private Collider[] _003Ccols_003E5__4;

		private int _003Ci_003E5__5;

		private RaycastHit[] _003Crhits_003E5__6;

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
		public _003CImpactRoutine_003Ed__81(int _003C_003E1__state)
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

	private WeaponIdentifier wid;

	public int variation;

	private GunControl gc;

	private bool gunReady;

	private WeaponPos wpos;

	private CameraFrustumTargeter targeter;

	private Animator anim;

	[HideInInspector]
	public int primaryCharge;

	public GameObject pumpChargeSound;

	public GameObject warningBeep;

	private float timeToBeep;

	private bool chargingSwing;

	private float swingCharge;

	[SerializeField]
	private Transform modelTransform;

	[HideInInspector]
	public Vector3 defaultModelPosition;

	[SerializeField]
	private Transform hammerPullable;

	[SerializeField]
	private AudioSource hammerPullSound;

	[HideInInspector]
	public Vector3 hammerDefaultPosition;

	private TimeSince pulledOut;

	private bool fireHeldOnPullOut;

	private float hammerCooldown;

	[SerializeField]
	private Transform rotatingMotor;

	private Quaternion motorPreviousRotation;

	[SerializeField]
	private SpriteRenderer motorSprite;

	[SerializeField]
	private AudioSource motorSound;

	private bool overheated;

	[SerializeField]
	private ParticleSystem overheatParticle;

	[SerializeField]
	private AudioSource overheatAud;

	private float currentSpeed;

	[SerializeField]
	private Renderer meter;

	[SerializeField]
	private Texture[] meterEmissives;

	private int tier;

	private MaterialPropertyBlock block;

	[SerializeField]
	private Transform meterHand;

	private TimeSince tierDownTimer;

	[SerializeField]
	private Image secondaryMeter;

	private float secondaryMeterFill;

	[SerializeField]
	private AudioSource hitSound;

	[SerializeField]
	private GameObject[] hitImpactParticle;

	private Coroutine impactRoutine;

	private float storedSpeed;

	private TimeSince speedStorageTimer;

	[Header("Core Eject")]
	[SerializeField]
	private GameObject grenade;

	[SerializeField]
	private AudioSource nadeSpawnSound;

	[SerializeField]
	private AudioSource nadeReadySound;

	private bool nadeCharging;

	[Header("Pump Charge")]
	[SerializeField]
	private AudioSource pump1Sound;

	[SerializeField]
	private AudioSource pump2Sound;

	[SerializeField]
	private GameObject pumpExplosion;

	[SerializeField]
	private GameObject overPumpExplosion;

	private bool aboutToSecondary;

	[Header("Chainsaw")]
	public GameObject chargeSoundBubble;

	private AudioSource tempChargeSound;

	private bool charging;

	private float chargeForce;

	[SerializeField]
	private Chainsaw chainsaw;

	private List<Chainsaw> currentChainsaws;

	[SerializeField]
	private Transform chainsawAttachPoint;

	[SerializeField]
	private ScrollingTexture chainsawBladeScroll;

	private MeshRenderer chainsawBladeRenderer;

	private Material chainsawBladeMaterial;

	[SerializeField]
	private Material chainsawBladeMotionMaterial;

	[SerializeField]
	private HurtZone sawZone;

	[SerializeField]
	private ParticleSystem environmentalSawSpark;

	[SerializeField]
	private AudioSource environmentalSawSound;

	private bool launchPlayer;

	private EnemyIdentifier hitEnemy;

	private Vector3 direction;

	private Transform target;

	private Vector3 hitPosition;

	private float damage;

	private bool forceWeakHit;

	private Grenade hitGrenade;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void UpdateMeter(bool forceUpdateTexture = false)
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	private void LateUpdate()
	{
	}

	private void Impact()
	{
	}

	[IteratorStateMachine(typeof(_003CImpactRoutine_003Ed__81))]
	private IEnumerator ImpactRoutine()
	{
		return null;
	}

	private void DeliverDamage()
	{
	}

	private void HitNade()
	{
	}

	private void ImpactEffects()
	{
	}

	private void ThrowNade()
	{
	}

	private void ShootSaw()
	{
	}

	private void Pump()
	{
	}

	private void Pump2Sound()
	{
	}
}
