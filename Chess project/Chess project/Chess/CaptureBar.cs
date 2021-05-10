using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Chess
{
	 
	/// Summary description for CaptureBar.
	 
	public class CaptureBar : System.Windows.Forms.UserControl
	{
		  
		/// Required designer variable.
		 
		private System.ComponentModel.Container components = null;
		private ArrayList Images;		// List of images to display
		private ArrayList Squars;	// Picture control array for storing the place holders
		public Images ChessImages;	// Contains reference of chess images

		public CaptureBar()
		{
			InitializeComponent();
			Squars = new ArrayList();
			Images = new ArrayList();
		}

		public void InitializeBar(Images ImagesList)
		{
			ChessImages = ImagesList;

			// TODO: Add any initialization after the InitializeComponent call
			for (int col=1; col<=12; col++)	// repeat for every column in the chess board row
			{
				Squar ChessSquar = new Squar(col, 1, null);
				//ChessSquar.SetBackgroundSquar(ChessImages);	// Set the chess squar background
				
				if ((col)%2==0) // White cell
					ChessSquar.BackgroundImage = ImagesList["White2"];
				else
					ChessSquar.BackgroundImage = ImagesList["Black2"];
				Squars.Add(ChessSquar);
				this.Controls.Add(ChessSquar);
			}

		}

		  
		/// Clean up any resources being used.
		 
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		  
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		 
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // CaptureBar
            // 
            this.Name = "CaptureBar";
            this.Size = new System.Drawing.Size(664, 55);
            this.Load += new System.EventHandler(this.CaptureBar_Load);
            this.ResumeLayout(false);

		}

		// Add the captured image to display list
		public void Add(Image CapturedImage)
		{
			Images.Add(CapturedImage);
			RefreshList();		// Redraw image list
		}

		// Remoe the last captured image from the display list
		public void RemoveLast()
		{
			if (Images.Count > 0)
				Images.RemoveAt(Images.Count-1);	// Remove last added image
			RefreshList();		// Redraw image list
		}

		// Clear the image list
		public void Clear()
		{
			Images.Clear();
			RefreshList();		// Redraw image list
		}

		// Redraw the image list
		public void RefreshList()
		{
			foreach (Squar sqr in Squars)
			{
				sqr.DrawPiece(null);
			}

			// Draw last added images in the available list
			int iStart=0, iIndex=0;

			if (Images.Count > Squars.Count)
				iStart= Images.Count-Squars.Count;

			for (;iStart<Images.Count; iStart++)
			{
				Squar sqr = (Squar)Squars[iIndex++];
				sqr.DrawPiece( (Image) Images[iStart]);
			}
		}

        #endregion

        private void CaptureBar_Load(object sender, EventArgs e)
        {

        }
    }
}
