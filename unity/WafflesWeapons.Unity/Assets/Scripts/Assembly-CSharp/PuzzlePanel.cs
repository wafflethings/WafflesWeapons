using UnityEngine;
using UnityEngine.UI;

public class PuzzlePanel : MonoBehaviour
{
	public GameObject[] tileTypePrefabs;

	public Color[] tileColors;

	public GameObject currentPanel;

	public TileType tileType;

	public TileColor tileColor;

	private Image img;

	private Sprite defaultSprite;

	[SerializeField]
	private Sprite activeSprite;

	private bool activated;

	private PuzzleController pc;

	[HideInInspector]
	public PuzzleLine pl;

	private ControllerPointer pointer;

	private void Start()
	{
	}

	public void Activate(TileColor color)
	{
	}

	public void DeActivate()
	{
	}
}
