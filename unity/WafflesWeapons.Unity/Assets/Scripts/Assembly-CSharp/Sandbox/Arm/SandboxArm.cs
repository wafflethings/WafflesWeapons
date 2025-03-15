using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using plog;

namespace Sandbox.Arm
{
	[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
	public class SandboxArm : MonoSingleton<SandboxArm>
	{
		private const bool DebugLogging = false;

		private static readonly plog.Logger Log;

		[FormerlySerializedAs("onEnableMode")]
		public SpawnableType onEnableType;

		[HideInInspector]
		public CameraController cameraCtrl;

		public LayerMask raycastLayers;

		public GameObject axisPoint;

		[SerializeField]
		private GameObject spawnEffect;

		public Material previewMaterial;

		public Transform holder;

		[FormerlySerializedAs("armAnimator")]
		public Animator animator;

		[Space]
		[SerializeField]
		private WeaponDescriptor genericDescriptor;

		[SerializeField]
		private WeaponDescriptor alterDescriptor;

		[SerializeField]
		private WeaponDescriptor destroyDescriptor;

		[SerializeField]
		private WeaponDescriptor buildOrPlaceDescriptor;

		[Space]
		public AudioSource tickSound;

		public AudioSource jabSound;

		public AudioSource selectSound;

		public AudioSource freezeSound;

		public AudioSource unfreezeSound;

		public AudioSource destroySound;

		public GameObject genericBreakParticles;

		public GameObject manipulateEffect;

		[Space]
		[SerializeField]
		private Image holoIcon;

		[SerializeField]
		private GameObject holoIconContainer;

		[NonSerialized]
		public SpawnMenu menu;

		private GoreZone goreZone;

		private bool debugStarted;

		private TimeSince timeSinceDebug;

		[NonSerialized]
		public bool hitSomething;

		[NonSerialized]
		public RaycastHit hit;

		private WeaponIcon localIcon;

		private bool firstBrushPositionSet;

		private Vector3 firstBlockPos;

		private Vector3 secondBlockPos;

		private Vector3 previousSecondBlockPos;

		public static GoreZone debugZone;

		private ISandboxArmMode currentMode;

		private static readonly int Holding;

		private static readonly int Punch;

		private static readonly int Manipulating;

		private static readonly int Pinched;

		private static readonly int Crush;

		private static readonly int PushZ;

		private static readonly int Point;

		private static readonly int Tap;

		protected override void Awake()
		{
		}

		public void SetArmMode(ISandboxArmMode mode)
		{
		}

		public void ReloadIcon()
		{
		}

		private void ReloadHudIconColor()
		{
		}

		public void ResetAnimator()
		{
		}

		public GoreZone GetGoreZone()
		{
			return null;
		}

		public void SelectObject(SpawnableObject obj)
		{
		}

		public ISandboxArmMode SetArmMode(SpawnableType type)
		{
			return null;
		}

		protected override void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void ResetMode()
		{
		}

		private void FixedUpdate()
		{
		}

		private void Update()
		{
		}

		public Vector2? GetHolderScreenPosition()
		{
			return null;
		}

		private void OnGUI()
		{
		}
	}
}
