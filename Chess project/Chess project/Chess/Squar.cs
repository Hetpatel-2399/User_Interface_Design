using System;
using System.Windows.Forms;
using System.Drawing;

namespace Chess 
{
	 
	/// 
	 
	public class Squar : PictureBox
	{
		private GameUI s_ParentGame;
		private static Image s_DraggedImage;	// Image being dragged
		private static Image s_ImageBeforeDrag;	// Image stored in squar before dragging
		private static string s_DragSourceSquar;	// Squar from which the drag begin
		private static string s_DragDestSquar;		// Squar on which item is dropped

		public Squar(int row, int col, GameUI parentgame)
		{
			s_ParentGame = parentgame;

			// Initialize the squar UI component
			if (parentgame!=null)
				Location = new System.Drawing.Point((row-1)*55+33, (col-1)*55+33);	// move the piece place holder to it's proper location
			else
				Location = new System.Drawing.Point((row-1)*55, (col-1)*55);
			Name = ""+(char)(row+64)+col;	// Generate unique name for the place holder
			Size = new System.Drawing.Size(55, 55);
			Visible = true;	
			SizeMode = PictureBoxSizeMode.CenterImage;

			if (parentgame!=null)
				InitializeComponent();
			//BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		}

		// Set the chess piece image
		public void DrawPiece(System.Drawing.Image pieceImage)
		{
			Image = pieceImage;
		}

		// Set the chess background squar
		public void SetBackgroundSquar(Images ImageList)
		{
			int row=char.Parse(Name.Substring(0,1).ToUpper())-64; // Get row from first ascii char i.e. a=1, b=2 and so on
			int col=int.Parse(Name.Substring(1,1));				  // Get column value directly, as it's already numeric

			if (((row+col)%2==0)) // White cell
                BackgroundImage = ImageList["Black"];
			else
                BackgroundImage = ImageList["White"];
		}

		private void InitializeComponent()
		{
			// 
			// Squar
			// 
			this.AllowDrop = true;
			this.Click += new System.EventHandler(this.Squar_Click);
			this.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.Squar_GiveFeedback);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Squar_DragEnter);
			this.DragLeave += new System.EventHandler(this.Squar_DragLeave);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Squar_DragDrop);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Squar_MouseDown);

		}

		private void Squar_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
            bool moved = false;

            // Allow the pieces to move by single click
            if (s_ParentGame.IsRunning && e.Button == MouseButtons.Left && !s_ParentGame.ChessGame.ActivePlay.IsComputer())
            {
                if (!string.IsNullOrEmpty(s_ParentGame.LastSelectedSquar) && this.Name != s_ParentGame.LastSelectedSquar)
                {
                    if (s_ParentGame.UserMove(s_ParentGame.LastSelectedSquar, this.Name))
                    {
                        moved = true;
                        s_ParentGame.LastSelectedSquar = "";
                    }
                }
            }

			if (this.Image != null && e.Button == MouseButtons.Left && !s_ParentGame.ChessGame.ActivePlay.IsComputer())	// squar contains a piece
			{
				s_DraggedImage = this.Image;
				this.Image=null;
				s_DragSourceSquar=s_DragDestSquar=this.Name;	// get the source squar being dragged
				this.DoDragDrop(this.Name, DragDropEffects.Move);

                s_ParentGame.LastSelectedSquar = s_DragDestSquar;

				if (s_DragSourceSquar==s_DragDestSquar) // No d&d performed
				{
                    if (moved == false)
                    {
                        s_ParentGame.Sounds.PlayClick();
                        s_ParentGame.SelectedSquar = s_DragSourceSquar;
                    }
                    else
                        s_ParentGame.SelectedSquar = "";

					s_ParentGame.RedrawBoard();
				}
				else
					s_ParentGame.UserMove(s_DragSourceSquar, s_DragDestSquar);
			}
		}

		private void Squar_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			// Current that squar is not the squar from where drag started
			s_ImageBeforeDrag = this.Image;	// store image in temporary variable
			this.Image = s_DraggedImage;
			e.Effect = DragDropEffects.Move;
		}

		private void Squar_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			Cursor.Current = Cursors.Hand;
		}

		private void Squar_DragLeave(object sender, System.EventArgs e)
		{
			this.Image=s_ImageBeforeDrag;
		}

		// Called when click on any chess squar object
		private void Squar_Click(object sender, System.EventArgs e)
		{
			if (s_ParentGame.IsRunning && !s_ParentGame.ChessGame.ActivePlay.IsComputer())
			{
				Squar ChessSquar = (Squar)sender;

				s_ParentGame.Sounds.PlayClick();
				s_ParentGame.SelectedSquar = ChessSquar.Name;
				s_ParentGame.RedrawBoard();
			}
		}

		private void Squar_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			s_DragDestSquar = this.Name;
		}

	}
}
