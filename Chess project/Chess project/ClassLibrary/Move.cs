using System;

namespace ChessLibrary
{
	 
	/// This class stores info about a single chess game move.
	/// It contains source and target chess squars/cells and also the type
	/// of move and related info.
	 
    [Serializable]
	public class Move
	{
		public enum MoveType {NormalMove, CaputreMove, TowerMove, PromotionMove, EnPassant};	// Type of the move

		private Cell s_StartCell;	// start cell
		private Cell s_EndCell;		// end cell
		private Piece s_Piece;			// Piece being moved
		private Piece s_CapturedPiece;	// Piece captured by this mov
		private Piece s_PromoPiece;		// Piece selected after pawn promotion
		private Piece s_EnPassantPiece;	// Piece captured during enpassant move
		private MoveType s_Type;		// Type of the move
		private bool s_CauseCheck;		// if cause or leave the user under check
		private int	s_Score;			// Score of the move from the board analyze routine

        // Emptry internal constructor for XML Serialization support
        internal Move()
        {
            s_Score = 0;
        }

		public Move(Cell begin, Cell end)
		{
			s_StartCell=begin;
			s_EndCell=end;
			s_Piece=begin.piece;
			s_CapturedPiece=end.piece;
			s_Score=0;
		}

		// Returns the move start cell
		public Cell StartCell
		{
			get
			{
				return s_StartCell;
			}
            set
            {
                s_StartCell = value;
            }
		}

		// Returns the move end cell
		public Cell EndCell
		{
			get
			{
				return s_EndCell;
			}
            set
            {
                s_EndCell = value;
            }
		}

		// Returns the piece which was moved
		public Piece Piece
		{
			get
			{
				return s_Piece;
			}
            set
            {
                s_Piece = value;
            }
		}

		// Returns the captured piece 
		public Piece CapturedPiece
		{
			get
			{
				return s_CapturedPiece;
			}
            set
            {
                s_CapturedPiece = value;
            }
		}

		// Get and Set the move type property
		public MoveType Type
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

		// Return true if the move when executed, place or leave user under check
		public bool CauseCheck
		{
			get
			{
				return s_CauseCheck;
			}
			set
			{
				s_CauseCheck=value;
			}
		}

		// Set and get the promo piece
		public Piece PromoPiece
		{
			get
			{
				return s_PromoPiece;
			}
			set
			{
				s_PromoPiece=value;
			}
		}

		// Set and get the EnPassant piece
		public Piece EnPassantPiece
		{
			get
			{
				return s_EnPassantPiece;
			}
			set
			{
				s_EnPassantPiece=value;
			}
		}

		// Set and get the move Score
		public int Score
		{
			get
			{
				return s_Score;
			}
			set
			{
				s_Score=value;
			}
		}

		// Return true if the move was promo move
		public bool IsPromoMove()
		{
			return s_Type==MoveType.PromotionMove;
		}

		// Return true if the move was capture move
		public bool IsCaptureMove()
		{
			return s_Type==MoveType.CaputreMove;
		}

		//Return a descriptive move text
		public override string ToString()
		{
			if (s_Type == Move.MoveType.CaputreMove)	// It's a capture move
				return s_Piece + " " + s_StartCell.ToString2() + "x" + s_EndCell.ToString2();
			else
				return s_Piece + " " + s_StartCell.ToString2() + "-" + s_EndCell.ToString2();
		}
	}

	// This class is used to compare two Move type objects
	public class MoveCompare : System.Collections.IComparer
	{
		// Empty constructore
		public MoveCompare()
		{
		}

		public int Compare(Object firstObj, Object SecondObj)
		{
			Move firstMove = (Move)firstObj;
			Move secondMove = (Move)SecondObj;

			return -firstMove.Score.CompareTo(secondMove.Score);
		}
	}
}
