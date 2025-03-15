using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Punch : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CChainsawPunchRoutine_003Ed__68 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Punch _003C_003E4__this;

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
		public _003CChainsawPunchRoutine_003Ed__68(int _003C_003E1__state)
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

	private InputManager inman;

	public FistType type;

	private string hitter;

	private float damage;

	private float screenShakeMultiplier;

	private float force;

	private bool tryForExplode;

	private float cooldownCost;

	public bool ready;

	[HideInInspector]
	public Animator anim;

	private SkinnedMeshRenderer smr;

	private Revolver rev;

	[SerializeField]
	private AudioSource aud;

	private GameObject camObj;

	private CameraController cc;

	private RaycastHit hit;

	private LayerMask environmentMask;

	private NewMovement nmov;

	private TrailRenderer tr;

	private Light parryLight;

	private GameObject currentDustParticle;

	public GameObject dustParticle;

	public AudioSource normalHit;

	public AudioSource heavyHit;

	public AudioSource specialHit;

	private StyleHUD shud;

	private StatsManager sman;

	public bool holding;

	public Transform holder;

	public ItemIdentifier heldItem;

	private bool hasHeldItem;

	private FistControl fc;

	private bool shopping;

	private int shopRequests;

	public GameObject parriedProjectileHitObject;

	private ProjectileParryZone ppz;

	private bool returnToOrigRot;

	public GameObject blastWave;

	private bool holdingInput;

	public GameObject shell;

	public Transform shellEjector;

	private AudioSource ejectorAud;

	private bool alreadyBoostedProjectile;

	private bool ignoreDoublePunch;

	public bool hitSomething;

	public bool parriedSomething;

	public bool alreadyHitCoin;

	public int activeFrames;

	public InputAction heldAction;

	private List<Chainsaw> punchedChainsaws;

	private Coroutine punchChainsawsRoutine;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	public void ResetHeldState()
	{
	}

	public void ForceThrow()
	{
	}

	public void ForceDrop()
	{
	}

	public void PlaceHeldObject(ItemPlaceZone[] placeZones, Transform target)
	{
	}

	public void ResetHeldItemPosition()
	{
	}

	public void ForceHold(ItemIdentifier itid)
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	public void PunchStart()
	{
	}

	private void ActiveStart()
	{
	}

	private void FixedUpdate()
	{
	}

	private void ActiveFrame(bool firstFrame = false)
	{
	}

	private void HitSurface(RaycastHit hit)
	{
	}

	private bool TryParryProjectile(Transform target, bool canProjectileBoost = false)
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003CChainsawPunchRoutine_003Ed__68))]
	private IEnumerator ChainsawPunchRoutine()
	{
		return null;
	}

	public void CoinFlip()
	{
	}

	private void ActiveEnd()
	{
	}

	public void ResetFistRotation()
	{
	}

	private void PunchEnd()
	{
	}

	private void ReadyToPunch()
	{
	}

	private void PunchSuccess(Vector3 point, Transform target)
	{
	}

	public void Parry(bool hook = false, EnemyIdentifier eid = null, string customParryText = "")
	{
	}

	private void ParryProjectile(Projectile proj)
	{
	}

	public void BlastCheck()
	{
	}

	public void Eject()
	{
	}

	public void Hide()
	{
	}

	public void ShopMode()
	{
	}

	public void StopShop()
	{
	}

	public void EquipAnimation()
	{
	}

	private void AltHit(Transform target)
	{
	}

	public void CancelAttack()
	{
	}

	public static Vector3 GetParryLookTarget()
	{
		return default(Vector3);
	}
}
