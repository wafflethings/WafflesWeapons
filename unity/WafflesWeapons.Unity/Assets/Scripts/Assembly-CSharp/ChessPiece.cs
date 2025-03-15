using Sandbox;
using Unity.Mathematics;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
	public ChessPieceData Data;

	public ChessPieceData.PieceType type;

	public bool isWhite;

	public bool queenSide;

	private bool positionDirty;

	private Quaternion startRot;

	private Rigidbody rb;

	private SandboxProp sbp;

	public AudioSource snapSound;

	[HideInInspector]
	public AudioSource dragSound;

	public GameObject breakEffect;

	public GameObject teleportEffect;

	public GameObject promotionEffect;

	public int timesMoved;

	public bool autoControl;

	public bool initialized;

	public GameObject promotionPanel;

	public float boardHeight;

	private ChessManager chessMan;

	private ChessManager.MoveData promotionMove;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void SetAutoControl(bool useAutoControl)
	{
	}

	private void Update()
	{
	}

	public void PieceCanMove(bool canMove)
	{
	}

	private void OnCollisionEnter(Collision collider)
	{
	}

	public void UpdatePosition(int2 position)
	{
	}

	public void ShowPromotionGUI(ChessManager.MoveData move)
	{
	}

	public void PlayerPromotePiece(int type)
	{
	}

	public void PromoteVisualPiece()
	{
	}

	public void Captured()
	{
	}
}
