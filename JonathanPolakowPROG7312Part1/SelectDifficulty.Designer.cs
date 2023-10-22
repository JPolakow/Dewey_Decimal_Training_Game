namespace JonathanPolakowPROG7312POE
{
   partial class SelectDifficulty
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.btnBack = new System.Windows.Forms.Button();
         this.lblHeading = new System.Windows.Forms.Label();
         this.btnHard = new System.Windows.Forms.Button();
         this.btnMedium = new System.Windows.Forms.Button();
         this.btnEasy = new System.Windows.Forms.Button();
         this.btnCasual = new System.Windows.Forms.Button();
         this.SuspendLayout();
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
         // SelectDifficulty
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.Transparent;
         this.Controls.Add(this.btnBack);
         this.Controls.Add(this.lblHeading);
         this.Controls.Add(this.btnHard);
         this.Controls.Add(this.btnMedium);
         this.Controls.Add(this.btnEasy);
         this.Controls.Add(this.btnCasual);
         this.Name = "SelectDifficulty";
         this.Size = new System.Drawing.Size(821, 593);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion
      private System.Windows.Forms.Button btnBack;
      private System.Windows.Forms.Label lblHeading;
      private System.Windows.Forms.Button btnHard;
      private System.Windows.Forms.Button btnMedium;
      private System.Windows.Forms.Button btnEasy;
      private System.Windows.Forms.Button btnCasual;
   }
}
