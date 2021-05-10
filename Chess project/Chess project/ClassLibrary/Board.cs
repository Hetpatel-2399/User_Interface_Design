using System;
using System.Collections;
using System.Xml;

namespace ChessLibrary
{
	 
	/// he main chess board. Board contain the chess cell
	/// which will contain the chess pieces. Board also contains the methods
	/// to get and set the user moves.
	 
    [Serializable]
	public class Board
	{
		private Side s_WhiteSide, s_BlackSide;	// Chess board site object 
		private Cells s_cells;	// collection of cells in the board

		public Board()
		{
            s_WhiteSide = new Side(Side.SideType.White);	// Makde white side
            s_BlackSide = new Side(Side.SideType.Black);	// Makde white side

			s_cells = new Cells();					// Initialize the chess cells collection
		}

		// Initialize the chess board and place piece on thier initial positions
		public void Init()
		{
			s_cells.Clear();		// Remove any existing chess cells

			// Build the 64 chess board cells
			for (int row=1; row<=8; row++)
				for (int col=1; col<=8; col++)
				{
					s_cells.Add(new Cell(row,col));	// Initialize and add the new chess cell
				}

			// Now setup the board for black side
			s_cells["a1"].piece = new Piece(Piece.PieceType.Rook,s_BlackSide);
			s_cells["h1"].piece = new Piece(Piece.PieceType.Rook,s_BlackSide);
			s_cells["b1"].piece = new Piece(Piece.PieceType.Knight,s_BlackSide);
			s_cells["g1"].piece = new Piece(Piece.PieceType.Knight,s_BlackSide);
			s_cells["c1"].piece = new Piece(Piece.PieceType.Bishop,s_BlackSide);
			s_cells["f1"].piece = new Piece(Piece.PieceType.Bishop,s_BlackSide);
			s_cells["e1"].piece = new Piece(Piece.PieceType.King,s_BlackSide);
			s_cells["d1"].piece = new Piece(Piece.PieceType.Queen,s_BlackSide);
			for (int col=1; col<=8; col++)
				s_cells[2, col].piece = new Piece(Piece.PieceType.Pawn,s_BlackSide);

			// Now setup the board for white side
			s_cells["a8"].piece = new Piece(Piece.PieceType.Rook,s_WhiteSide);
			s_cells["h8"].piece = new Piece(Piece.PieceType.Rook,s_WhiteSide);
			s_cells["b8"].piece = new Piece(Piece.PieceType.Knight,s_WhiteSide);
			s_cells["g8"].piece = new Piece(Piece.PieceType.Knight,s_WhiteSide);
			s_cells["c8"].piece = new Piece(Piece.PieceType.Bishop,s_WhiteSide);
			s_cells["f8"].piece = new Piece(Piece.PieceType.Bishop,s_WhiteSide);
			s_cells["e8"].piece = new Piece(Piece.PieceType.King,s_WhiteSide);
			s_cells["d8"].piece = new Piece(Piece.PieceType.Queen,s_WhiteSide);
			for (int col=1; col<=8; col++)
				s_cells[7, col].piece = new Piece(Piece.PieceType.Pawn,s_WhiteSide);
		}

		// get the new item by rew and column
		public Cell this[int row, int col]
		{
			get
			{
				return s_cells[row, col];
			}
		}

		// get the new item by string location
		public Cell this[string strloc]
		{
			get
			{
				return s_cells[strloc];	
			}
		}

		// get the chess cell by given cell
		public Cell this[Cell cellobj]
		{
			get
			{
				return s_cells[cellobj.ToString()];	
			}
		}

         
        /// Serialize the Game object as XML String
         
        /// <returns>XML containing the Game object state XML</returns>
        public XmlNode XmlSerialize(XmlDocument xmlDoc)
        {
            XmlElement xmlBoard = xmlDoc.CreateElement("Board");

            // Append game state attributes
            xmlBoard.AppendChild(s_WhiteSide.XmlSerialize(xmlDoc));
            xmlBoard.AppendChild(s_BlackSide.XmlSerialize(xmlDoc));

            xmlBoard.AppendChild(s_cells.XmlSerialize(xmlDoc));

            // Return this as String
            return xmlBoard;
        }

         
        /// DeSerialize the Board object from XML String
         
        /// <returns>XML containing the Board object state XML</returns>
        public void XmlDeserialize(XmlNode xmlBoard)
        {
            // Deserialize the Sides XML
            XmlNode side = XMLHelper.GetFirstNodeByName(xmlBoard, "Side");

            // Deserialize the XML nodes
            s_WhiteSide.XmlDeserialize(side);
            s_BlackSide.XmlDeserialize(side.NextSibling);

            // Deserialize the Cells
            XmlNode xmlCells = XMLHelper.GetFirstNodeByName(xmlBoard, "Cells");
            s_cells.XmlDeserialize(xmlCells);
        }

		// get all the cell locations on the chess board
		public ArrayList GetAllCells()
		{
			ArrayList CellNames = new ArrayList();

			// Loop all the squars and store them in Array List
			for (int row=1; row<=8; row++)
				for (int col=1; col<=8; col++)
				{
					CellNames.Add(this[row,col].ToString()); // append the cell name to list
				}

			return CellNames;
		}

		// get all the cell containg pieces of given side
        public ArrayList GetSideCell(Side.SideType PlayerSide)
		{
			ArrayList CellNames = new ArrayList();

			// Loop all the squars and store them in Array List
			for (int row=1; row<=8; row++)
				for (int col=1; col<=8; col++)
				{
					// check and add the current type cell
					if (this[row,col].piece!=null && !this[row,col].IsEmpty() && this[row,col].piece.Side.type == PlayerSide)
						CellNames.Add(this[row,col].ToString()); // append the cell name to list
				}

			return CellNames;
		}

		// Returns the cell on the top of the given cell
		public Cell TopCell(Cell cell)
		{
			return this[cell.row-1, cell.col];
		}

		// Returns the cell on the left of the given cell
		public Cell LeftCell(Cell cell)
		{
			return this[cell.row, cell.col-1];
		}

		// Returns the cell on the right of the given cell
		public Cell RightCell(Cell cell)
		{
			return this[cell.row, cell.col+1];
		}

		// Returns the cell on the bottom of the given cell
		public Cell BottomCell(Cell cell)
		{
			return this[cell.row+1, cell.col];
		}

		// Returns the cell on the top-left of the current cell
		public Cell TopLeftCell(Cell cell)
		{
			return this[cell.row-1, cell.col-1];
		}

		// Returns the cell on the top-right of the current cell
		public Cell TopRightCell(Cell cell)
		{
			return this[cell.row-1, cell.col+1];
		}

		// Returns the cell on the bottom-left of the current cell
		public Cell BottomLeftCell(Cell cell)
		{
			return this[cell.row+1, cell.col-1];
		}

		// Returns the cell on the bottom-right of the current cell
		public Cell BottomRightCell(Cell cell)
		{
			return this[cell.row+1, cell.col+1];
		}
	}
}
