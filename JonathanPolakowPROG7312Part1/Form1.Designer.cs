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
         this.pnlPlaceBooks = new System.Windows.Forms.Panel();
         this.pnlAwards = new System.Windows.Forms.Panel();
         this.pnlChooseDifficulty = new System.Windows.Forms.Panel();
         this.btnBack = new System.Windows.Forms.Button();
         this.lblHeading = new System.Windows.Forms.Label();
         this.btnHard = new System.Windows.Forms.Button();
         this.btnMedium = new System.Windows.Forms.Button();
         this.btnEasy = new System.Windows.Forms.Button();
         this.btnCasual = new System.Windows.Forms.Button();
         this.pnlMenu = new System.Windows.Forms.Panel();
         this.label1 = new System.Windows.Forms.Label();
         this.btnAwards = new System.Windows.Forms.Button();
         this.btn3 = new System.Windows.Forms.Button();
         this.btn2 = new System.Windows.Forms.Button();
         this.btnPlaceBooks = new System.Windows.Forms.Button();
         this.pnlChooseDifficulty.SuspendLayout();
         this.pnlMenu.SuspendLayout();
         this.SuspendLayout();
         // 
         // pnlPlaceBooks
         // 
         this.pnlPlaceBooks.BackColor = System.Drawing.Color.White;
         this.pnlPlaceBooks.BackgroundImage = global::JonathanPolakowPROG7312POE.Properties.Resources.BookShelfBackground;
         this.pnlPlaceBooks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
         this.pnlPlaceBooks.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlPlaceBooks.Location = new System.Drawing.Point(0, 0);
         this.pnlPlaceBooks.Name = "pnlPlaceBooks";
         this.pnlPlaceBooks.Size = new System.Drawing.Size(839, 596);
         this.pnlPlaceBooks.TabIndex = 1;
         this.pnlPlaceBooks.Visible = false;
         // 
         // pnlAwards
         // 
         this.pnlAwards.BackColor = System.Drawing.Color.White;
         this.pnlAwards.BackgroundImage = global::JonathanPolakowPROG7312POE.Properties.Resources.AwardsBackground;
         this.pnlAwards.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
         this.pnlAwards.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlAwards.Location = new System.Drawing.Point(0, 0);
         this.pnlAwards.Name = "pnlAwards";
         this.pnlAwards.Size = new System.Drawing.Size(839, 596);
         this.pnlAwards.TabIndex = 4;
         // 
         // pnlChooseDifficulty
         // 
         this.pnlChooseDifficulty.BackColor = System.Drawing.Color.White;
         this.pnlChooseDifficulty.BackgroundImage = global::JonathanPolakowPROG7312POE.Properties.Resources.BookShelfBackground;
         this.pnlChooseDifficulty.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
         this.pnlChooseDifficulty.Controls.Add(this.btnBack);
         this.pnlChooseDifficulty.Controls.Add(this.lblHeading);
         this.pnlChooseDifficulty.Controls.Add(this.btnHard);
         this.pnlChooseDifficulty.Controls.Add(this.btnMedium);
         this.pnlChooseDifficulty.Controls.Add(this.btnEasy);
         this.pnlChooseDifficulty.Controls.Add(this.btnCasual);
         this.pnlChooseDifficulty.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlChooseDifficulty.Location = new System.Drawing.Point(0, 0);
         this.pnlChooseDifficulty.Name = "pnlChooseDifficulty";
         this.pnlChooseDifficulty.Size = new System.Drawing.Size(839, 596);
         this.pnlChooseDifficulty.TabIndex = 4;
         // 
         // btnBack
         // 
         this.btnBack.Font = new System.Drawing.Font("MV Boli", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnBack.Location = new System.Drawing.Point(353, 367);
         this.btnBack.Name = "btnBack";
         this.btnBack.Size = new System.Drawing.Size(130, 28);
         this.btnBack.TabIndex = 5;
         this.btnBack.Text = "Back";
         this.btnBack.UseVisualStyleBackColor = true;
         this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
         // 
         // lblHeading
         // 
         this.lblHeading.AutoSize = true;
         this.lblHeading.BackColor = System.Drawing.Color.Transparent;
         this.lblHeading.Font = new System.Drawing.Font("MV Boli", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblHeading.ForeColor = System.Drawing.SystemColors.ButtonFace;
         this.lblHeading.Location = new System.Drawing.Point(309, 194);
         this.lblHeading.Name = "lblHeading";
         this.lblHeading.Size = new System.Drawing.Size(236, 34);
         this.lblHeading.TabIndex = 4;
         this.lblHeading.Text = "Select Difficulty";
         // 
         // btnHard
         // 
         this.btnHard.Font = new System.Drawing.Font("MV Boli", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnHard.Location = new System.Drawing.Point(353, 333);
         this.btnHard.Name = "btnHard";
         this.btnHard.Size = new System.Drawing.Size(130, 28);
         this.btnHard.TabIndex = 3;
         this.btnHard.Text = "15 Seconds";
         this.btnHard.UseVisualStyleBackColor = true;
         this.btnHard.Click += new System.EventHandler(this.BtnHard_Click);
         // 
         // btnMedium
         // 
         this.btnMedium.Font = new System.Drawing.Font("MV Boli", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnMedium.Location = new System.Drawing.Point(353, 299);
         this.btnMedium.Name = "btnMedium";
         this.btnMedium.Size = new System.Drawing.Size(130, 28);
         this.btnMedium.TabIndex = 2;
         this.btnMedium.Text = "45 Seconds";
         this.btnMedium.UseVisualStyleBackColor = true;
         this.btnMedium.Click += new System.EventHandler(this.BtnMedium_Click);
         // 
         // btnEasy
         // 
         this.btnEasy.Font = new System.Drawing.Font("MV Boli", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnEasy.Location = new System.Drawing.Point(353, 265);
         this.btnEasy.Name = "btnEasy";
         this.btnEasy.Size = new System.Drawing.Size(130, 28);
         this.btnEasy.TabIndex = 1;
         this.btnEasy.Text = "90 Seconds";
         this.btnEasy.UseVisualStyleBackColor = true;
         this.btnEasy.Click += new System.EventHandler(this.BtnEasy_Click);
         // 
         // btnCasual
         // 
         this.btnCasual.Font = new System.Drawing.Font("MV Boli", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnCasual.Location = new System.Drawing.Point(353, 231);
         this.btnCasual.Name = "btnCasual";
         this.btnCasual.Size = new System.Drawing.Size(130, 28);
         this.btnCasual.TabIndex = 0;
         this.btnCasual.Text = "No Time Limit";
         this.btnCasual.UseVisualStyleBackColor = true;
         this.btnCasual.Click += new System.EventHandler(this.BtnCasual_Click);
         // 
         // pnlMenu
         // 
         this.pnlMenu.BackColor = System.Drawing.Color.White;
         this.pnlMenu.BackgroundImage = global::JonathanPolakowPROG7312POE.Properties.Resources.LibraryBackground;
         this.pnlMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
         this.pnlMenu.Controls.Add(this.label1);
         this.pnlMenu.Controls.Add(this.btnAwards);
         this.pnlMenu.Controls.Add(this.btn3);
         this.pnlMenu.Controls.Add(this.btn2);
         this.pnlMenu.Controls.Add(this.btnPlaceBooks);
         this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlMenu.Location = new System.Drawing.Point(0, 0);
         this.pnlMenu.Name = "pnlMenu";
         this.pnlMenu.Size = new System.Drawing.Size(839, 596);
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
         // btn2
         // 
         this.btn2.Font = new System.Drawing.Font("MV Boli", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btn2.Location = new System.Drawing.Point(353, 248);
         this.btn2.Name = "btn2";
         this.btn2.Size = new System.Drawing.Size(130, 28);
         this.btn2.TabIndex = 1;
         this.btn2.Text = "Identify Areas";
         this.btn2.UseVisualStyleBackColor = true;
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
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(839, 596);
         this.Controls.Add(this.pnlMenu);
         this.Controls.Add(this.pnlChooseDifficulty);
         this.Controls.Add(this.pnlAwards);
         this.Controls.Add(this.pnlPlaceBooks);
         this.Margin = new System.Windows.Forms.Padding(1);
         this.MaximizeBox = false;
         this.MaximumSize = new System.Drawing.Size(855, 635);
         this.MinimumSize = new System.Drawing.Size(855, 635);
         this.Name = "Form1";
         this.Text = "Form1";
         this.pnlChooseDifficulty.ResumeLayout(false);
         this.pnlChooseDifficulty.PerformLayout();
         this.pnlMenu.ResumeLayout(false);
         this.pnlMenu.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion
      private System.Windows.Forms.Panel pnlPlaceBooks;
      private System.Windows.Forms.Panel pnlMenu;
      private System.Windows.Forms.Button btnAwards;
      private System.Windows.Forms.Button btn3;
      private System.Windows.Forms.Button btn2;
      private System.Windows.Forms.Button btnPlaceBooks;
      private System.Windows.Forms.Panel pnlAwards;
      private System.Windows.Forms.Panel pnlChooseDifficulty;
      private BookShelf bookShelf1;
      private Awards awards1;
      private System.Windows.Forms.Label lblHeading;
      private System.Windows.Forms.Button btnHard;
      private System.Windows.Forms.Button btnMedium;
      private System.Windows.Forms.Button btnEasy;
      private System.Windows.Forms.Button btnCasual;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button btnBack;
   }
}

