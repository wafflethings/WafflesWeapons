using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleController : MonoBehaviour
{
	private bool backOnBlack;

	private Image img;

	private PuzzlePanel[] panels;

	public List<PuzzlePanel> activatedPanels;

	public List<TileColor> activatedColors;

	public bool puzzleInProgress;

	public bool solved;

	public GameObject[] toActivate;

	private TileColor currentColor;

	private int starts;

	private int ends;

	public GameObject puzzleCorrect;

	public GameObject puzzleWrong;

	public GameObject puzzleClick;

	private float checkForHold;

	private Punch punch;

	private void Start()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	public void Clicked(PuzzlePanel other)
	{
	}

	public void Unclicked()
	{
	}

	public void Hovered(PuzzlePanel other)
	{
	}

	public void Success()
	{
	}

	public void Failure()
	{
	}

	public void ResetPuzzle()
	{
	}

	private void CheckSolution()
	{
	}

	private void WhiteFlash()
	{
	}

	private void ActivateNow()
	{
	}
}
