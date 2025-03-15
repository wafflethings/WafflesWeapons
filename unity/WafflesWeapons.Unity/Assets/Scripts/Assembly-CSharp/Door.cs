using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
	public DoorType doorType;

	private BigDoor[] bdoors;

	private SubDoor[] subdoors;

	public bool useRigidbody;

	private Rigidbody rb;

	public bool open;

	public bool gotValues;

	public bool gotPos;

	public Vector3 closedPos;

	public Vector3 openPos;

	[HideInInspector]
	public Vector3 openPosRelative;

	public bool startOpen;

	[HideInInspector]
	public Vector3 targetPos;

	public float speed;

	public bool easeIn;

	[HideInInspector]
	public bool inPos;

	public bool reverseDirection;

	public int requests;

	private AudioSource aud;

	public AudioClip openSound;

	public AudioClip closeSound;

	private AudioSource aud2;

	private MaterialPropertyBlock block;

	public bool locked;

	public GameObject noPass;

	private NavMeshObstacle nmo;

	public GameObject[] activatedRooms;

	public GameObject[] deactivatedRooms;

	public Light openLight;

	public UnityEvent onFullyOpened;

	public UnityEvent onFullyClosed;

	private Door[] allDoors;

	public bool screenShake;

	public bool dontCloseWhenAnotherDoorOpens;

	public bool dontCloseOtherDoorsWhenOpening;

	private CameraController cc;

	private DoorLock thisLock;

	private List<DoorLock> locks;

	[HideInInspector]
	public int openLocks;

	[HideInInspector]
	public DoorController[] docons;

	[HideInInspector]
	public List<bool> origDoconStates;

	private bool doconless;

	private Collider doconlessClosingCol;

	private MeshRenderer[] lightsMeshRenderers;

	public Color defaultLightsColor;

	public Color currentLightsColor;

	public bool turnEmissiveOffWhenLocked;

	private OcclusionPortal occpor;

	public bool ignoreHookCheck;

	public bool openOnUnlock;

	private void Awake()
	{
	}

	private void GetPos()
	{
	}

	public void AltarControlled()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	public void SimpleOpenOverride()
	{
	}

	public void Open(bool enemy = false, bool skull = false)
	{
	}

	public void Optimize()
	{
	}

	public void Close(bool force = false)
	{
	}

	public void Lock()
	{
	}

	public void Unlock()
	{
	}

	public void ChangeColor(Color targetColor)
	{
	}

	public void LockOpen()
	{
	}

	public void LockClose()
	{
	}

	public void BigDoorClosed()
	{
	}

	public void ForceStartOpen(bool force = true)
	{
	}
}
