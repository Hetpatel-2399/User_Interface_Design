using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Chess
{
	 
	/// Summary description for NewGame.
	 
	public class NewGame : System.Windows.Forms.Form
	{
        // Public variables

        public string ResourceFolderPath;      // folder path where all the external resources are stored
        public bool bStart;		        // True to start

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Button btnCancel;

		public System.Windows.Forms.PictureBox BlackPlayerImg;
		public System.Windows.Forms.RadioButton Play_CvC;
		public System.Windows.Forms.RadioButton Play_HvC;
		public System.Windows.Forms.RadioButton Play_HvH;
		public System.Windows.Forms.RadioButton PlayerLevel3;
		public System.Windows.Forms.RadioButton PlayerLevel2;
		public System.Windows.Forms.RadioButton PlayerLevel1;
		public System.Windows.Forms.TextBox BlackPlayerName;
		public System.Windows.Forms.TextBox WhitePlayerName;
		public System.Windows.Forms.PictureBox WhitePlayerImg;
		 
		 
		private System.ComponentModel.Container components = null;

		public NewGame()
		{
			InitializeComponent();
		}

		 		 
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

		#region Windows Form Designer generated code
		 
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		 
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewGame));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Play_CvC = new System.Windows.Forms.RadioButton();
            this.Play_HvC = new System.Windows.Forms.RadioButton();
            this.Play_HvH = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PlayerLevel3 = new System.Windows.Forms.RadioButton();
            this.PlayerLevel2 = new System.Windows.Forms.RadioButton();
            this.PlayerLevel1 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BlackPlayerName = new System.Windows.Forms.TextBox();
            this.BlackPlayerImg = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.WhitePlayerName = new System.Windows.Forms.TextBox();
            this.WhitePlayerImg = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlackPlayerImg)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WhitePlayerImg)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.Play_CvC);
            this.groupBox1.Controls.Add(this.Play_HvC);
            this.groupBox1.Controls.Add(this.Play_HvH);
            this.groupBox1.Location = new System.Drawing.Point(24, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 96);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player Options";
            // 
            // Play_CvC
            // 
            this.Play_CvC.Location = new System.Drawing.Point(14, 70);
            this.Play_CvC.Name = "Play_CvC";
            this.Play_CvC.Size = new System.Drawing.Size(146, 16);
            this.Play_CvC.TabIndex = 2;
            this.Play_CvC.Text = "Computer Vs. Computer";
            this.Play_CvC.CheckedChanged += new System.EventHandler(this.PlayesrType_CheckedChanged);
            // 
            // Play_HvC
            // 
            this.Play_HvC.Location = new System.Drawing.Point(14, 47);
            this.Play_HvC.Name = "Play_HvC";
            this.Play_HvC.Size = new System.Drawing.Size(136, 20);
            this.Play_HvC.TabIndex = 1;
            this.Play_HvC.Text = "Human Vs. Computer";
            this.Play_HvC.CheckedChanged += new System.EventHandler(this.PlayesrType_CheckedChanged);
            // 
            // Play_HvH
            // 
            this.Play_HvH.Checked = true;
            this.Play_HvH.Location = new System.Drawing.Point(14, 24);
            this.Play_HvH.Name = "Play_HvH";
            this.Play_HvH.Size = new System.Drawing.Size(136, 20);
            this.Play_HvH.TabIndex = 0;
            this.Play_HvH.TabStop = true;
            this.Play_HvH.Text = "Human Vs. Human";
            this.Play_HvH.CheckedChanged += new System.EventHandler(this.PlayesrType_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.PlayerLevel3);
            this.groupBox2.Controls.Add(this.PlayerLevel2);
            this.groupBox2.Controls.Add(this.PlayerLevel1);
            this.groupBox2.Location = new System.Drawing.Point(24, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(160, 91);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Player Level";
            // 
            // PlayerLevel3
            // 
            this.PlayerLevel3.Location = new System.Drawing.Point(13, 64);
            this.PlayerLevel3.Name = "PlayerLevel3";
            this.PlayerLevel3.Size = new System.Drawing.Size(139, 20);
            this.PlayerLevel3.TabIndex = 2;
            this.PlayerLevel3.Text = "Chess Master";
            // 
            // PlayerLevel2
            // 
            this.PlayerLevel2.Location = new System.Drawing.Point(13, 44);
            this.PlayerLevel2.Name = "PlayerLevel2";
            this.PlayerLevel2.Size = new System.Drawing.Size(139, 20);
            this.PlayerLevel2.TabIndex = 1;
            this.PlayerLevel2.Text = "Intermediate";
            // 
            // PlayerLevel1
            // 
            this.PlayerLevel1.Checked = true;
            this.PlayerLevel1.Location = new System.Drawing.Point(13, 24);
            this.PlayerLevel1.Name = "PlayerLevel1";
            this.PlayerLevel1.Size = new System.Drawing.Size(139, 20);
            this.PlayerLevel1.TabIndex = 0;
            this.PlayerLevel1.TabStop = true;
            this.PlayerLevel1.Text = "Beginner";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.BlackPlayerName);
            this.groupBox3.Controls.Add(this.BlackPlayerImg);
            this.groupBox3.Location = new System.Drawing.Point(192, 24);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(156, 95);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Black Player";
            // 
            // BlackPlayerName
            // 
            this.BlackPlayerName.Location = new System.Drawing.Point(67, 40);
            this.BlackPlayerName.Name = "BlackPlayerName";
            this.BlackPlayerName.Size = new System.Drawing.Size(80, 20);
            this.BlackPlayerName.TabIndex = 0;
            this.BlackPlayerName.Text = "Black Player";
            this.BlackPlayerName.Click += new System.EventHandler(this.PlayerName_Focus);
            this.BlackPlayerName.Enter += new System.EventHandler(this.PlayerName_Focus);
            // 
            // BlackPlayerImg
            // 
            this.BlackPlayerImg.BackColor = System.Drawing.Color.Transparent;
            this.BlackPlayerImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.BlackPlayerImg.Location = new System.Drawing.Point(14, 24);
            this.BlackPlayerImg.Name = "BlackPlayerImg";
            this.BlackPlayerImg.Size = new System.Drawing.Size(45, 50);
            this.BlackPlayerImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BlackPlayerImg.TabIndex = 1;
            this.BlackPlayerImg.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(277, 230);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(71, 24);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "&Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(197, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.WhitePlayerName);
            this.groupBox4.Controls.Add(this.WhitePlayerImg);
            this.groupBox4.Location = new System.Drawing.Point(192, 124);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(156, 92);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "White Player";
            // 
            // WhitePlayerName
            // 
            this.WhitePlayerName.Location = new System.Drawing.Point(67, 40);
            this.WhitePlayerName.Name = "WhitePlayerName";
            this.WhitePlayerName.Size = new System.Drawing.Size(80, 20);
            this.WhitePlayerName.TabIndex = 0;
            this.WhitePlayerName.Text = "White Player";
            this.WhitePlayerName.Click += new System.EventHandler(this.PlayerName_Focus);
            this.WhitePlayerName.Enter += new System.EventHandler(this.PlayerName_Focus);
            // 
            // WhitePlayerImg
            // 
            this.WhitePlayerImg.BackColor = System.Drawing.Color.Transparent;
            this.WhitePlayerImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.WhitePlayerImg.Location = new System.Drawing.Point(14, 24);
            this.WhitePlayerImg.Name = "WhitePlayerImg";
            this.WhitePlayerImg.Size = new System.Drawing.Size(45, 50);
            this.WhitePlayerImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.WhitePlayerImg.TabIndex = 1;
            this.WhitePlayerImg.TabStop = false;
            // 
            // NewGame
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(374, 284);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Game";
            this.Load += new System.EventHandler(this.NewGame_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlackPlayerImg)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WhitePlayerImg)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void btnStart_Click(object sender, System.EventArgs e)
		{
			bStart=true;
			this.Close();	// close the form
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			bStart=false;
			this.Close();	// close the form
		}

        private void PlayesrType_CheckedChanged(object sender, EventArgs e)
        {
            // Check the selected player types
            if (Play_HvH.Checked)
            {
                BlackPlayerImg.Image = System.Drawing.Image.FromFile(ResourceFolderPath + "User.jpg");
                WhitePlayerImg.Image = System.Drawing.Image.FromFile(ResourceFolderPath + "User_2.jpg");
                groupBox2.Enabled = false;
            }
            else if (Play_HvC.Checked)
            {
                BlackPlayerImg.Image = System.Drawing.Image.FromFile(ResourceFolderPath + "laptop.jpg");
                WhitePlayerImg.Image = System.Drawing.Image.FromFile(ResourceFolderPath + "User_2.jpg");
                groupBox2.Enabled = true;
            }
            else if (Play_CvC.Checked)
            {
                BlackPlayerImg.Image = System.Drawing.Image.FromFile(ResourceFolderPath + "laptop.jpg");
                WhitePlayerImg.Image = System.Drawing.Image.FromFile(ResourceFolderPath + "laptop_2.png");
                groupBox2.Enabled = true;
            }
        }

        private void NewGame_Load(object sender, EventArgs e)
        {
            //Player vs Player
            PlayesrType_CheckedChanged(null, null);
        }

        private void PlayerName_Focus(object sender, EventArgs e)
        {
            (sender as TextBox).Select(0, (sender as TextBox).Text.Length);
        }
	}
}
