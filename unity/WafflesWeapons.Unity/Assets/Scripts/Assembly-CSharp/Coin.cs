using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class Coin : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CPunchflection_003Ed__39 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public Coin _003C_003E4__this;

		private void MoveNext()
		{
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	public EnemyTarget customTarget;

	public GameObject sourceWeapon;

	private Rigidbody rb;

	private bool checkingSpeed;

	private float timeToDelete;

	public GameObject refBeam;

	public Vector3 hitPoint;

	private Collider[] cols;

	public bool shot;

	[HideInInspector]
	public bool shotByEnemy;

	private bool wasShotByEnemy;

	public GameObject coinBreak;

	public float power;

	private EnemyIdentifier eid;

	public bool quickDraw;

	public Material uselessMaterial;

	private GameObject altBeam;

	public GameObject coinHitSound;

	[HideInInspector]
	public int hitTimes;

	public bool doubled;

	public GameObject flash;

	public GameObject enemyFlash;

	public GameObject chargeEffect;

	private GameObject currentCharge;

	private StyleHUD shud;

	public CoinChainCache ccc;

	public int ricochets;

	[HideInInspector]
	public int difficulty;

	public bool dontDestroyOnPlayerRespawn;

	public bool ignoreBlessedEnemies;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnDestroy()
	{
	}

	private void TripleTime()
	{
	}

	private void TripleTimeEnd()
	{
	}

	private void DoubleTime()
	{
	}

	public void DelayedReflectRevolver(Vector3 hitp, GameObject beam = null)
	{
	}

	public void ReflectRevolver()
	{
	}

	public void DelayedPunchflection()
	{
	}

	[AsyncStateMachine(typeof(_003CPunchflection_003Ed__39))]
	public void Punchflection()
	{
	}

	public void Bounce()
	{
	}

	public void DelayedEnemyReflect()
	{
	}

	public void EnemyReflect()
	{
	}

	private void ShootAtPlayer()
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
	}

	public void GetDeleted()
	{
	}

	private void StartCheckingSpeed()
	{
	}

	private GameObject SpawnBeam()
	{
		return null;
	}

	public void RicoshotPointsCheck()
	{
	}
}
