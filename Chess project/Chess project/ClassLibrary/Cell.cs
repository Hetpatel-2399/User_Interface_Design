using System;

namespace ChessLibrary
{
	 
	/// A class for the chess cell. It stores the type of chess cell and
	/// type of chess piece placed in this cell.
	 
    [Serializable]
	public class Cell
	{
		// chess cell attribute
		Piece s_piece;
		int s_row;
		int s_col;

		// Empty constructor to initalize the row and column for the cell
		public Cell()
		{
			s_row=0;
			s_col=0;
		}

		// Empty constructor to initalize the row and column for the cell
		public Cell(int irow, int icol)
		{
			s_row=irow;
			s_col=icol;
		}

		// Set the chess rows and columns from the given text string
		public Cell(string strLoc)
		{
			if(strLoc.Length==2)	// check if valid location string
			{
				s_col=char.Parse(strLoc.Substring(0,1).ToUpper())-64; // Get row from first ascii char i.e. a=1, b=2 and so on
				s_row=int.Parse(strLoc.Substring(1,1));				  // Get column value directly, as it's already numeric
			}
		}

		// This method returns true, if the current cell is the darker one
		public bool IsDark
		{
			get
			{
				return ((row+col)%2==0);	// every non-even column is the darker one
			}
		}

		// Return chess friendly location string from the internal row and column integers
		public override string ToString()
		{
			string strLoc="";
			strLoc=Convert.ToString(Convert.ToChar(col+64));	// Convert the row literal i.e. 1=a, 2=b and so on.
			strLoc+=row.ToString();								// convert and append column string
			return strLoc;	// return back the converted string
		}

		// Return chess friendly location for UI Interface
		public string ToString2()
		{
			string strLoc="";
			int BoardRow = Math.Abs(8-row)+1;		// On the chess board column start from bottom
			strLoc=Convert.ToString(Convert.ToChar(col+64));	// Convert the row literal i.e. 1=a, 2=b and so on.
			strLoc+=BoardRow.ToString();								// convert and append column string
			return strLoc;	// return back the converted string
		}

		// Override the default equals method for the chess cell class
		public override bool Equals(object obj)
		{
			if (obj is Cell)
			{
				Cell cellObj=(Cell)obj;
				
				return (cellObj.row==row && cellObj.col==col);			   
			}
			return false;
		}

		// Override the default GetHash function; required by Equalls method
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		#region Class attributes set and get methods
		// Get and set the cell row
		public int row
		{
			get
			{
				return s_row;
			}
			set
			{
				s_row=value;
			}
		}

		// returns true if the cell is empty
		public bool IsEmpty()
		{
			return s_piece == null || s_piece.Type == Piece.PieceType.Empty;
		}

		// returns true if the cell is owned by enemy of the given cell
		public bool IsOwnedByEnemy(Cell other)
		{
			if (IsEmpty())
				return false;
			else
                return s_piece.Side.type != other.piece.Side.type;
		}

		// returns true if the current cell is owned by source cell
		public bool IsOwned(Cell other)
		{
			if (IsEmpty())
				return false;
			else
				return s_piece.Side.type == other.piece.Side.type;
		}

		// Get and set the cell column
		public int col
		{
			get
			{
				return s_col;
			}
			set
			{
				s_col=value;
			}
		}

		// Get and set the chess piece
		public Piece piece
		{
			get
			{
				return s_piece;
			}
			set
			{
				s_piece=value;
			}
		}
		#endregion

		
	}
}
