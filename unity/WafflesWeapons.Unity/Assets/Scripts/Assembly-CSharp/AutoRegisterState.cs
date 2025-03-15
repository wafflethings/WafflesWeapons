using UnityEngine;
using UnityEngine.Serialization;

public class AutoRegisterState : MonoBehaviour
{
	public string stateKey;

	[Space]
	public bool trackSelf;

	[Tooltip("If any of the tracked objects remain active, the state will be considered valid")]
	public GameObject[] additionalTrackedObjects;

	[FormerlySerializedAs("playerInputBlocking")]
	[Space]
	public LockMode playerInputLock;

	[FormerlySerializedAs("cameraInputBlocking")]
	public LockMode cameraInputLock;

	public LockMode cursorLock;

	[Space]
	public int priority;

	private GameState ownState;

	private void OnEnable()
	{
	}

	private void OnDestroy()
	{
	}
}
