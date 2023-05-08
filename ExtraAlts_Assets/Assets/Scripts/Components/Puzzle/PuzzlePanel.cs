using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum TileType
{
    None,
    White,
    WhiteEnd,
    WhiteFill,
    WhitePit
}

public enum TileColor
{
    None,
    Red,
    Green,
    Blue
}

public class PuzzlePanel : MonoBehaviour
{
    public GameObject pitSquare;

     
    void Start() { }
    public void Activate(TileColor color) { }
    public void DeActivate() { }}
