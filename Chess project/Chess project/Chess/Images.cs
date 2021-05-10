using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using ChessLibrary;

namespace Chess
{
	 
	/// Summary description for Images.
	 
	public class Images
	{
		private ArrayList s_ImageList;		// store list of image list

		public Images()
		{
			s_ImageList = new ArrayList();
		}

		public void LoadImages(string SourceDir)
		{

			// Read and store the image black and white image paths
			s_ImageList.Add(System.Drawing.Image.FromFile(SourceDir+"Black.jpg"));
			s_ImageList.Add(System.Drawing.Image.FromFile(SourceDir+"White.jpg"));
			// Read and store the white pieces images
			s_ImageList.Add(System.Drawing.Image.FromFile(SourceDir+"king.gif"));
			s_ImageList.Add(System.Drawing.Image.FromFile(SourceDir+"queen.gif"));
			s_ImageList.Add(System.Drawing.Image.FromFile(SourceDir+"bishop.gif"));
			s_ImageList.Add(System.Drawing.Image.FromFile(SourceDir+"knight.gif"));
			s_ImageList.Add(System.Drawing.Image.FromFile(SourceDir+"rook.gif"));
			s_ImageList.Add(System.Drawing.Image.FromFile(SourceDir+"pawn.gif"));
			// Read and store the black pieces images
			s_ImageList.Add(System.Drawing.Image.FromFile(SourceDir+"king_2.gif"));
			s_ImageList.Add(System.Drawing.Image.FromFile(SourceDir+"queen_2.gif"));
			s_ImageList.Add(System.Drawing.Image.FromFile(SourceDir+"bishop_2.gif"));
			s_ImageList.Add(System.Drawing.Image.FromFile(SourceDir+"knight_2.gif"));
			s_ImageList.Add(System.Drawing.Image.FromFile(SourceDir+"rook_2.gif"));
			s_ImageList.Add(System.Drawing.Image.FromFile(SourceDir+"pawn_2.gif"));
			// Read and store the image black and white image paths
			s_ImageList.Add(System.Drawing.Image.FromFile(SourceDir+"Black_2.jpg"));
			s_ImageList.Add(System.Drawing.Image.FromFile(SourceDir+"White_2.jpg"));
		}

		// Get Image by name i.e. White or Black
		public Image this[string strName]
		{
			get 
			{
				switch (strName)	// check string type
				{
					case "White":
						return (Image)s_ImageList[0];
					case "Black":
						return (Image)s_ImageList[1];
					case "White2":
						return (Image)s_ImageList[14];
					case "Black2":
						return (Image)s_ImageList[15];
					default:
						return null;

				}
				
			}
		}

		// Return image for the given piece type
		public Image GetImageForPiece(Piece Piece)
		{
			// Not a valid chess piece
			if (Piece == null || Piece.Type == Piece.PieceType.Empty )
				return null;

			// check and return the white piece image
			if (Piece.Side.isWhite())
				switch(Piece.Type)
				{
					case Piece.PieceType.King:
						return (Image)s_ImageList[2];
					case Piece.PieceType.Queen:
						return (Image)s_ImageList[3];
					case Piece.PieceType.Bishop:
						return (Image)s_ImageList[4];
					case Piece.PieceType.Knight:
						return (Image)s_ImageList[5];
					case Piece.PieceType.Rook:
						return (Image)s_ImageList[6];
					case Piece.PieceType.Pawn:
						return (Image)s_ImageList[7];
					default:
						return null;
				}
			else
				switch(Piece.Type)
				{
					case Piece.PieceType.King:
						return (Image)s_ImageList[8];
					case Piece.PieceType.Queen:
						return (Image)s_ImageList[9];
					case Piece.PieceType.Bishop:
						return (Image)s_ImageList[10];
					case Piece.PieceType.Knight:
						return (Image)s_ImageList[11];
					case Piece.PieceType.Rook:
						return (Image)s_ImageList[12];
					case Piece.PieceType.Pawn:
						return (Image)s_ImageList[13];
					default:
						return null;
				}
		}
	}
}
