using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class StyleHUD : MonoSingleton<StyleHUD>
{
	[CompilerGenerated]
	private sealed class _003CUpdateItems_003Ed__51 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public StyleHUD _003C_003E4__this;

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
		public _003CUpdateItems_003Ed__51(int _003C_003E1__state)
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

	public Image rankImage;

	public List<StyleRank> ranks;

	public bool showStyleMeter;

	public bool forceMeterOn;

	private int _rankIndex;

	public int maxReachedRank;

	private Queue<string> hudItemsQueue;

	private float currentMeter;

	private GameObject styleHud;

	private Slider styleSlider;

	private TMP_Text styleInfo;

	private float rankShaking;

	private Vector3 defaultPos;

	private float rankScale;

	private bool comboActive;

	private StatsManager sman;

	private GunControl gc;

	private float styleNameTime;

	private AudioSource aud;

	[Header("Multipliers")]
	public float bossStyleGainMultiplier;

	public float bossFreshnessDecayMultiplier;

	[Header("Freshness")]
	public bool dualWieldScale;

	public float freshnessDecayPerMove;

	public float freshnessDecayPerSec;

	[Space]
	public float freshnessRegenPerMove;

	public float freshnessRegenPerSec;

	[Space]
	public List<StyleFreshnessData> freshnessStateData;

	private Dictionary<StyleFreshnessState, StyleFreshnessData> freshnessStateDict;

	public TMP_Text freshnessSliderText;

	private float freshnessSliderValue;

	private Dictionary<GameObject, float> weaponFreshness;

	private float minFreshnessCache;

	private int weaponCountCache;

	private Dictionary<int, (float, float)> slotFreshnessLock;

	public Dictionary<string, float> freshnessDecayMultiplierDict;

	private Dictionary<string, string> idNameDict;

	private Coroutine updateItemsRoutine;

	private WaitForSeconds styleWait;

	public StyleRank currentRank => null;

	public int rankIndex
	{
		get
		{
			return 0;
		}
		private set
		{
		}
	}

	private bool freshnessEnabled => false;

	public string GetLocalizedName(string id)
	{
		return null;
	}

	private void Start()
	{
	}

	protected override void Awake()
	{
	}

	protected override void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CUpdateItems_003Ed__51))]
	private IEnumerator UpdateItems()
	{
		return null;
	}

	private void UpdateMeter()
	{
	}

	private void UpdateFreshness()
	{
	}

	private void UpdateHUD()
	{
	}

	public void RegisterStyleItem(string id, string name)
	{
	}

	public void ComboStart()
	{
	}

	public void ComboOver()
	{
	}

	private void AscendRank()
	{
	}

	private void UpdateFreshnessSlider()
	{
	}

	public void ResetFreshness()
	{
	}

	public void SnapFreshnessSlider()
	{
	}

	public StyleFreshnessState GetFreshnessState(GameObject sourceWeapon)
	{
		return default(StyleFreshnessState);
	}

	public void LockFreshness(int slot, float? min = null, float? max = null)
	{
	}

	public void LockFreshness(int slot, StyleFreshnessState? minState = null, StyleFreshnessState? maxState = null)
	{
	}

	public void UnlockFreshness(int slot)
	{
	}

	private void ClampFreshness(GameObject sourceWeapon, float amt)
	{
	}

	public void UpdateMinFreshnessCache(int count)
	{
	}

	public float GetFreshness(GameObject sourceWeapon)
	{
		return 0f;
	}

	public void SetFreshness(GameObject sourceWeapon, float amt)
	{
	}

	public void AddFreshness(GameObject sourceWeapon, float amt)
	{
	}

	public void DecayFreshness(GameObject sourceWeapon, string pointID, bool boss)
	{
	}

	public void DescendRank()
	{
	}

	public void AddPoints(int points, string pointID, GameObject sourceWeapon = null, EnemyIdentifier eid = null, int count = -1, string prefix = "", string postfix = "")
	{
	}

	public void RemovePoints(int points)
	{
	}

	public void ResetFreshness(GameObject weapon)
	{
	}

	public void ResetAllFreshness()
	{
	}

	private void RemoveText()
	{
	}
}
