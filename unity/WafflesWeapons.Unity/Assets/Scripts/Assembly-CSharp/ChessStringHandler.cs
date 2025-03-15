using System.Collections.Generic;
using Unity.Mathematics;

public static class ChessStringHandler
{
	public static void LogMatchHistory(List<string> matchHistory)
	{
	}

	public static string GenerateFenString(ChessPieceData[] board, bool isWhiteTurn, string castlingAvailability, string enPassantTarget, int halfmoveClock, int fullmoveNumber)
	{
		return null;
	}

	private static char GetFenCharForPiece(ChessPieceData piece)
	{
		return '\0';
	}

	public static string CalculateCastlingAvailability(ChessPieceData[] board)
	{
		return null;
	}

	public static string ConvertToChessNotation(int2 position)
	{
		return null;
	}

	public static int2 ConvertFromChessNotation(string notation)
	{
		return default(int2);
	}

	public static (int2 start, int2 end, ChessPieceData.PieceType promotionType) ProcessFullMove(string move)
	{
		return default((int2, int2, ChessPieceData.PieceType));
	}

	public static string UCIMove(ChessManager.MoveData moveData)
	{
		return null;
	}

	public static string LogPerft(ChessManager.MoveData moveData, int subsequentMoves = 0)
	{
		return null;
	}

	public static void LogMoveData(ChessManager.MoveData moveData, int subsequentMoves = 0)
	{
	}
}
