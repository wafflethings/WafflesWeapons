using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleController : MonoBehaviour
{    
    public List<PuzzlePanel> activatedPanels = new List<PuzzlePanel>();
    public List<TileColor> activatedColors = new List<TileColor>();
    public bool puzzleInProgress;

    public bool solved;

    public GameObject[] toActivate;
    public ObjectActivator activationZone;

    public GameObject puzzleCorrect;
    public GameObject puzzleWrong;
    public GameObject puzzleClick;

     
    void Start() { }
    private void OnDisable() { }
    private void Update() { }
    public void Clicked(PuzzlePanel other) { }
    public void Unclicked() { }
    public void Hovered(PuzzlePanel other) { }
    public void Success() { }
    public void Failure() { }
    public void ResetPuzzle() { }}
