namespace JonathanPolakowPROG7312POE
{
   partial class Form1
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.pnlIdentifyAreas = new System.Windows.Forms.Panel();
         this.pnlMenu = new System.Windows.Forms.Panel();
         this.label1 = new System.Windows.Forms.Label();
         this.btnAwards = new System.Windows.Forms.Button();
         this.btn3 = new System.Windows.Forms.Button();
         this.btnIdentifyAreas = new System.Windows.Forms.Button();
         this.btnPlaceBooks = new System.Windows.Forms.Button();
         this.pnlAwards = new System.Windows.Forms.Panel();
         this.pnlPlaceBooks = new System.Windows.Forms.Panel();
         this.pnlChooseDifficulty = new System.Windows.Forms.Panel();
         this.selectDifficulty1 = new JonathanPolakowPROG7312POE.SelectDifficulty();
         this.pnlMenu.SuspendLayout();
         this.pnlChooseDifficulty.SuspendLayout();
         this.SuspendLayout();
         // 
         // pnlIdentifyAreas
         // 
         this.pnlIdentifyAreas.BackColor = System.Drawing.Color.White;
         this.pnlIdentifyAreas.BackgroundImage = global::JonathanPolakowPROG7312POE.Properties.Resources.BookShelfBackground;
         this.pnlIdentifyAreas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
         this.pnlIdentifyAreas.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlIdentifyAreas.Location = new System.Drawing.Point(0, 0);
         this.pnlIdentifyAreas.Name = "pnlIdentifyAreas";
         this.pnlIdentifyAreas.Size = new System.Drawing.Size(829, 567);
         this.pnlIdentifyAreas.TabIndex = 2;
         this.pnlIdentifyAreas.Visible = false;
         // 
         // pnlMenu
         // 
         this.pnlMenu.BackColor = System.Drawing.Color.White;
         this.pnlMenu.BackgroundImage = global::JonathanPolakowPROG7312POE.Properties.Resources.LibraryBackground;
         this.pnlMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
         this.pnlMenu.Controls.Add(this.label1);
         this.pnlMenu.Controls.Add(this.btnAwards);
         this.pnlMenu.Controls.Add(this.btn3);
         this.pnlMenu.Controls.Add(this.btnIdentifyAreas);
         this.pnlMenu.Controls.Add(this.btnPlaceBooks);
         this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlMenu.Location = new System.Drawing.Point(0, 0);
         this.pnlMenu.Name = "pnlMenu";
         this.pnlMenu.Size = new System.Drawing.Size(829, 567);
         this.pnlMenu.TabIndex = 1;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.BackColor = System.Drawing.Color.Transparent;
         this.label1.Font = new System.Drawing.Font("MV Boli", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
         this.label1.Location = new System.Drawing.Point(309, 175);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(236, 34);
         this.label1.TabIndex = 5;
         this.label1.Text = "Select Difficulty";
         // 
         // btnAwards
         // 
         this.btnAwards.Font = new System.Drawing.Font("MV Boli", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnAwards.Location = new System.Drawing.Point(353, 316);
         this.btnAwards.Name = "btnAwards";
         this.btnAwards.Size = new System.Drawing.Size(130, 28);
         this.btnAwards.TabIndex = 3;
         this.btnAwards.Text = "View Awards";
         this.btnAwards.UseVisualStyleBackColor = true;
         this.btnAwards.Click += new System.EventHandler(this.BtnAwards_Click);
         // 
         // btn3
         // 
         this.btn3.Font = new System.Drawing.Font("MV Boli", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btn3.Location = new System.Drawing.Point(353, 282);
         this.btn3.Name = "btn3";
         this.btn3.Size = new System.Drawing.Size(130, 28);
         this.btn3.TabIndex = 2;
         this.btn3.Text = "Find Call Numbers";
         this.btn3.UseVisualStyleBackColor = true;
         // 
         // btnIdentifyAreas
         // 
         this.btnIdentifyAreas.Font = new System.Drawing.Font("MV Boli", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnIdentifyAreas.Location = new System.Drawing.Point(353, 248);
         this.btnIdentifyAreas.Name = "btnIdentifyAreas";
         this.btnIdentifyAreas.Size = new System.Drawing.Size(130, 28);
         this.btnIdentifyAreas.TabIndex = 1;
         this.btnIdentifyAreas.Text = "Identify Areas";
         this.btnIdentifyAreas.UseVisualStyleBackColor = true;
         this.btnIdentifyAreas.Click += new System.EventHandler(this.btnIdentifyAreas_Click);
         // 
         // btnPlaceBooks
         // 
         this.btnPlaceBooks.Font = new System.Drawing.Font("MV Boli", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnPlaceBooks.Location = new System.Drawing.Point(353, 214);
         this.btnPlaceBooks.Name = "btnPlaceBooks";
         this.btnPlaceBooks.Size = new System.Drawing.Size(130, 28);
         this.btnPlaceBooks.TabIndex = 0;
         this.btnPlaceBooks.Text = "Replace books";
         this.btnPlaceBooks.UseVisualStyleBackColor = true;
         this.btnPlaceBooks.Click += new System.EventHandler(this.BtnPlaceBooks_Click);
         // 
         // pnlAwards
         // 
         this.pnlAwards.BackColor = System.Drawing.Color.White;
         this.pnlAwards.BackgroundImage = global::JonathanPolakowPROG7312POE.Properties.Resources.AwardsBackground;
         this.pnlAwards.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
         this.pnlAwards.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlAwards.Location = new System.Drawing.Point(0, 0);
         this.pnlAwards.Name = "pnlAwards";
         this.pnlAwards.Size = new System.Drawing.Size(829, 567);
         this.pnlAwards.TabIndex = 4;
         // 
         // pnlPlaceBooks
         // 
         this.pnlPlaceBooks.BackColor = System.Drawing.Color.White;
         this.pnlPlaceBooks.BackgroundImage = global::JonathanPolakowPROG7312POE.Properties.Resources.BookShelfBackground;
         this.pnlPlaceBooks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
         this.pnlPlaceBooks.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlPlaceBooks.Location = new System.Drawing.Point(0, 0);
         this.pnlPlaceBooks.Name = "pnlPlaceBooks";
         this.pnlPlaceBooks.Size = new System.Drawing.Size(829, 567);
         this.pnlPlaceBooks.TabIndex = 1;
         this.pnlPlaceBooks.Visible = false;
         // 
         // pnlChooseDifficulty
         // 
         this.pnlChooseDifficulty.BackColor = System.Drawing.Color.White;
         this.pnlChooseDifficulty.BackgroundImage = global::JonathanPolakowPROG7312POE.Properties.Resources.BookShelfBackground;
         this.pnlChooseDifficulty.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
         this.pnlChooseDifficulty.Controls.Add(this.selectDifficulty1);
         this.pnlChooseDifficulty.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlChooseDifficulty.Location = new System.Drawing.Point(0, 0);
         this.pnlChooseDifficulty.Name = "pnlChooseDifficulty";
         this.pnlChooseDifficulty.Size = new System.Drawing.Size(829, 567);
         this.pnlChooseDifficulty.TabIndex = 4;
         // 
         // selectDifficulty1
         // 
         this.selectDifficulty1.BackColor = System.Drawing.Color.Transparent;
         this.selectDifficulty1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.selectDifficulty1.Location = new System.Drawing.Point(0, 0);
         this.selectDifficulty1.Name = "selectDifficulty1";
         this.selectDifficulty1.Size = new System.Drawing.Size(829, 567);
         this.selectDifficulty1.TabIndex = 0;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(829, 567);
         this.Controls.Add(this.pnlChooseDifficulty);
         this.Controls.Add(this.pnlIdentifyAreas);
         this.Controls.Add(this.pnlMenu);
         this.Controls.Add(this.pnlAwards);
         this.Controls.Add(this.pnlPlaceBooks);
         this.Margin = new System.Windows.Forms.Padding(1);
         this.MaximizeBox = false;
         this.MaximumSize = new System.Drawing.Size(845, 606);
         this.MinimumSize = new System.Drawing.Size(845, 606);
         this.Name = "Form1";
         this.Text = "Form1";
         this.pnlMenu.ResumeLayout(false);
         this.pnlMenu.PerformLayout();
         this.pnlChooseDifficulty.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion
      private System.Windows.Forms.Panel pnlPlaceBooks;
      private System.Windows.Forms.Panel pnlMenu;
      private System.Windows.Forms.Button btnAwards;
      private System.Windows.Forms.Button btn3;
      private System.Windows.Forms.Button btnIdentifyAreas;
      private System.Windows.Forms.Button btnPlaceBooks;
      private System.Windows.Forms.Panel pnlAwards;
      private BookShelf bookShelf1;
      private SelectDifficulty selectDifficulty1;
      private IdentifyAreas identifyAreas1;
      private Awards awards1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Panel pnlIdentifyAreas;
      private System.Windows.Forms.Panel pnlChooseDifficulty;
   }
}

