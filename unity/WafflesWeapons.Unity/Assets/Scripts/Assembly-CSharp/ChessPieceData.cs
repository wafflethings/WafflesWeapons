public class ChessPieceData
{
	public enum PieceType
	{
		Pawn = 0,
		Rook = 1,
		Knight = 2,
		Bishop = 3,
		Queen = 4,
		King = 5
	}

	public bool isWhite;

	public int timesMoved;

	public bool queenSide;

	public bool autoControl;

	public PieceType type;

	public ChessPieceData(PieceType type, bool isWhite, bool queenSide)
	{
	}
}
