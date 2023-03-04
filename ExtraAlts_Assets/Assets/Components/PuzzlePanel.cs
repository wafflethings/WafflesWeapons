using UnityEngine;

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
    public TileType tileType;
    public TileColor tileColor;
    public GameObject currentPanel;
    public GameObject whiteSquare;
    public GameObject blackSquare;
    public GameObject fillSquare;
    public PuzzleLine pl;
    public GameObject pitSquare;

    public void Activate(TileColor color) { }

    public void DeActivate() { }
}