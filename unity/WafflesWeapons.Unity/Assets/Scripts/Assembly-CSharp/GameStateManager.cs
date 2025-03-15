using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-500)]
public class GameStateManager : MonoBehaviour
{
	public bool introCheckComplete;

	public CustomGameDetails currentCustomGame;

	private readonly Dictionary<string, GameState> activeStates;

	private readonly List<string> stateOrder;

	public static GameStateManager Instance { get; private set; }

	public Vector3 defaultGravity { get; private set; }

	public bool CameraLocked { get; private set; }

	public bool PlayerInputLocked { get; private set; }

	public bool CursorLocked { get; private set; }

	public float TimerModifier { get; private set; }

	public static bool CanSubmitScores => false;

	public static bool ShowLeaderboards => false;

	private void Awake()
	{
	}

	private void IntroCheck()
	{
	}

	public bool IsStateActive(string stateKey)
	{
		return false;
	}

	public void RegisterState(GameState newState)
	{
	}

	public void PopState(string stateKey)
	{
	}

	public void SceneReset()
	{
	}

	public void ResetGravity()
	{
	}

	private void EvaluateState()
	{
	}

	private void Update()
	{
	}
}
