using UnityEngine;
using UnityEngine.Events;

public class DifficultyDependantObject : MonoBehaviour
{
	public bool autoDeactivate;

	[Header("Active in difficulties:")]
	public bool veryEasy;

	public bool easy;

	public bool normal;

	public bool hard;

	public bool veryHard;

	public bool UKMD;

	[Header("Optional events: ")]
	public UnityEvent onRightDifficulty;

	public UnityEvent onWrongDifficulty;

	private void Awake()
	{
	}
}
