using System;

namespace ChessLibrary 
{
	 
	/// A class for the chess piece. It stores the type of chess piece properties
	/// like type, location, power etc. It also contains chess piece methods like
	/// get next move, move, etc
	 
    [Serializable]
	public class Piece
	{
		// chess piece class attributes
		int s_moves;			// total no. of moves by the piece
		Side s_Side;			// The ches side i.e. white/back to which this piece belongs
		PieceType s_Type;		// type of the chess piece i.e. king, queen etc.

		public enum PieceType {Empty, King, Queen, Rook, Bishop, Knight, Pawn};	// define the possible types for chess piece

		// define attributes for the chess item
		public Piece()
		{
			this.Type = PieceType.Empty;	// default piece is empty i.e. doesn't exists
		}

		// constructore with a given piece type
		public Piece(PieceType type)
		{
			this.s_Type = type;
		}

		// constructore with a given piece type and side
		public Piece(PieceType type, Side side)
		{
			this.s_Type = type;
			this.s_Side = side;
		}

		// Return true if the piece position is empty
		public bool IsEmpty()
		{
			return s_Type==PieceType.Empty;
		}

		// Return true if the piece is pawn
		public bool IsPawn()
		{
			return s_Type==PieceType.Pawn;
		}

		// Return true if the piece is knight
		public bool IsKnight()
		{
			return s_Type==PieceType.Knight;
		}

		// Return true if the piece is bishop
		public bool IsBishop()
		{
			return s_Type==PieceType.Bishop;
		}

		// Return true if the piece is rook
		public bool IsRook()
		{
			return s_Type==PieceType.Rook;
		}

		// Return true if the piece is queen
		public bool IsQueen()
		{
			return s_Type==PieceType.Queen;
		}

		// Return true if the piece is King
		public bool IsKing()
		{
			return s_Type==PieceType.King;
		}

		// returns the string for the piece
		public override string ToString()
		{
			switch (s_Type)
			{
				case PieceType.King:
					return "King";
				case PieceType.Queen:
					return "Queen";
				case PieceType.Bishop:
					return "Bishop";
				case PieceType.Rook:
					return "Rook";
				case PieceType.Knight:
					return "Knight";
				case PieceType.Pawn:
					return "Pawn";
				default:
					return "E";
			}
		}

		// Returns back weight of the chess peice
		public int GetWeight()
		{
			switch (s_Type)
			{
				case PieceType.King:
					return 0;
				case PieceType.Queen:
					return 900;
				case PieceType.Rook:
					return 500;
				case PieceType.Bishop:
					return 325;
				case PieceType.Knight:
					return 300;
				case PieceType.Pawn:
					return 100;
				default:
					return 0;
			}
		}

		#region Class attributes set and get methods
		// Get and set the cell row
		public PieceType Type
		{
			get
			{
				return s_Type;
			}
			set
			{
				s_Type=value;
			}
		}

		// Get and set the piece side
		public Side Side
		{
			get
			{
				return s_Side;
			}
			set
			{
				s_Side=value;
			}
		}

		// Get and set the piece moves
		public int Moves
		{
			get
			{
				return s_moves;
			}
			set
			{
				s_moves=value;
			}
		}
		#endregion
	}
}
