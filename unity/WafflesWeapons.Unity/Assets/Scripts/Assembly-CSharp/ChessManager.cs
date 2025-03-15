using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class ChessManager : MonoSingleton<ChessManager>
{
	public enum SpecialMove
	{
		None = 0,
		ShortCastle = 1,
		LongCastle = 2,
		PawnTwoStep = 3,
		PawnPromotion = 4,
		EnPassantCapture = 5
	}

	public struct MoveData
	{
		public int2 StartPosition;

		public ChessPieceData PieceToMove;

		public int2 EndPosition;

		public ChessPieceData CapturePiece;

		public SpecialMove SpecialMove;

		public int2 LastEnPassantPos;

		public ChessPieceData.PieceType PromotionType;

		public MoveData(ChessPieceData pieceToMove, int2 startPosition, ChessPieceData capturePiece, int2 endPosition, int2 lastEPPos, SpecialMove specialMove = SpecialMove.None, ChessPieceData.PieceType promotionType = ChessPieceData.PieceType.Pawn)
		{
			StartPosition = default(int2);
			PieceToMove = null;
			EndPosition = default(int2);
			CapturePiece = null;
			SpecialMove = default(SpecialMove);
			LastEnPassantPos = default(int2);
			PromotionType = default(ChessPieceData.PieceType);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass54_0
	{
		public string response;

		public bool isResponseReceived;

		internal bool _003CSendToBotCoroutine_003Eb__1()
		{
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003CLerpBotMove_003Ed__56 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ChessPiece piece;

		public ChessManager _003C_003E4__this;

		public int2 endIndex;

		public MoveData moveData;

		private Transform _003Ctrans_003E5__2;

		private Vector3 _003CstartPos_003E5__3;

		private Vector3 _003CendPos_003E5__4;

		private float _003Cduration_003E5__5;

		private float _003Celapsed_003E5__6;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CLerpBotMove_003Ed__56(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CSendToBotCoroutine_003Ed__54 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ChessManager _003C_003E4__this;

		public string newMoveData;

		private _003C_003Ec__DisplayClass54_0 _003C_003E8__1;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CSendToBotCoroutine_003Ed__54(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CStartEngine_003Ed__51 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public ChessManager _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CStopEngine_003Ed__52 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public ChessManager _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	public GameObject originalPieces;

	public GameObject originalExtras;

	public GameObject blackWinner;

	public GameObject whiteWinner;

	public GameObject blackOpponent;

	public GameObject whiteOpponent;

	public GameObject draw;

	public Transform helperTileGroup;

	private Renderer[] helperTiles;

	private MaterialPropertyBlock colorSetter;

	private Bounds colBounds;

	private GameObject clonedPieces;

	private ChessPieceData[] chessBoard;

	private Dictionary<ChessPieceData, ChessPiece> allPieces;

	private ChessPieceData whiteKing;

	private ChessPieceData blackKing;

	private int2 enPassantPos;

	private List<MoveData> legalMoves;

	private List<MoveData> pseudoLegalMoves;

	private List<MoveData> allLegalMoves;

	private UciChessEngine chessEngine;

	private List<string> UCIMoves;

	[HideInInspector]
	public bool isWhiteTurn;

	[HideInInspector]
	public bool whiteIsBot;

	[HideInInspector]
	public bool blackIsBot;

	[HideInInspector]
	public bool gameLocked;

	private bool tutorialMessageSent;

	private int numMoves;

	public int elo;

	private static readonly int2[] pawnMoves;

	private static readonly int2[] pawnCaptures;

	private static readonly int2[] rookDirections;

	private static readonly int2[] bishopDirections;

	private static readonly int2[] queenDirections;

	private static readonly int2[] knightOffsets;

	private static readonly int2[] kingDirections;

	private new void Awake()
	{
	}

	private void Start()
	{
	}

	public void SetupNewGame()
	{
	}

	public void ToggleWhiteBot(bool isBot)
	{
	}

	public void ToggleBlackBot(bool isBot)
	{
	}

	public void ResetBoard()
	{
	}

	public void UpdateGame(MoveData move)
	{
	}

	private bool IsGameOver()
	{
		return false;
	}

	public bool IsSufficientMaterial()
	{
		return false;
	}

	public void WinTrigger(bool? whiteWin)
	{
	}

	public void SetElo(float newElo)
	{
	}

	public void WhiteIsBot(bool isBot)
	{
	}

	public void BlackIsBot(bool isBot)
	{
	}

	[AsyncStateMachine(typeof(_003CStartEngine_003Ed__51))]
	private void StartEngine()
	{
	}

	[AsyncStateMachine(typeof(_003CStopEngine_003Ed__52))]
	public void StopEngine()
	{
	}

	public void BotStartGame()
	{
	}

	[IteratorStateMachine(typeof(_003CSendToBotCoroutine_003Ed__54))]
	private IEnumerator SendToBotCoroutine(string newMoveData)
	{
		return null;
	}

	private string ParseBotMove(string engineResponse)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CLerpBotMove_003Ed__56))]
	private IEnumerator LerpBotMove(ChessPiece piece, int2 endIndex, MoveData moveData)
	{
		return null;
	}

	private void MakeBotMove(string botMove)
	{
	}

	public int2 WorldPositionToIndex(Vector3 pos)
	{
		return default(int2);
	}

	public Vector3 IndexToWorldPosition(int2 index, float height)
	{
		return default(Vector3);
	}

	public void DisplayValidMoves()
	{
	}

	public void HideHelperTiles()
	{
	}

	public void FindMoveAtWorldPosition(ChessPiece chessPiece)
	{
	}

	public void InitializePiece(ChessPiece piece)
	{
	}

	public ChessPieceData GetPieceAt(int2 index)
	{
		return null;
	}

	public void SetPieceAt(int2 index, ChessPieceData piece)
	{
	}

	private int2 GetPiecePos(ChessPieceData piece)
	{
		return default(int2);
	}

	public void MakeMove(MoveData moveData, bool updateVisuals = false)
	{
	}

	public void StylishMove(MoveData move)
	{
	}

	public void UnmakeMove(MoveData moveData, bool updateVisuals = false)
	{
	}

	private bool IsValidPosition(int2 index)
	{
		return false;
	}

	public void GetLegalMoves(int2 index)
	{
	}

	private void GetPawnMoves(ChessPieceData pawn, int2 startPos, List<MoveData> validMoves)
	{
	}

	private void GetSlidingMoves(ChessPieceData slidingPiece, int2 startPos, List<MoveData> validMoves)
	{
	}

	private void GetKnightKingMoves(ChessPieceData piece, int2 startPos, List<MoveData> validMoves)
	{
	}

	private void TryCastle(ChessPieceData king, int2 startPos, bool isKingSide, List<MoveData> validMoves)
	{
	}

	public bool IsSquareAttacked(int2 position, bool isWhite)
	{
		return false;
	}

	private bool IsSlidingPieceAttacking(int2 position, bool isWhite, bool isRookMovement)
	{
		return false;
	}

	private bool IsPieceAtPositionOfType(int2 position, bool isWhite, ChessPieceData.PieceType type)
	{
		return false;
	}
}
