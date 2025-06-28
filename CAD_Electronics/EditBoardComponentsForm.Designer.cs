namespace CAD_Electronics_App
{
    partial class EditBoardComponentsForm
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
            this.txtBoard = new System.Windows.Forms.TextBox();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.cmbScheme = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBoard
            // 
            this.txtBoard.Enabled = false;
            this.txtBoard.Location = new System.Drawing.Point(261, 117);
            this.txtBoard.Name = "txtBoard";
            this.txtBoard.Size = new System.Drawing.Size(279, 22);
            this.txtBoard.TabIndex = 18;
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(261, 228);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(279, 22);
            this.numQuantity.TabIndex = 17;
            // 
            // cmbScheme
            // 
            this.cmbScheme.FormattingEnabled = true;
            this.cmbScheme.Location = new System.Drawing.Point(261, 172);
            this.cmbScheme.Name = "cmbScheme";
            this.cmbScheme.Size = new System.Drawing.Size(279, 24);
            this.cmbScheme.TabIndex = 16;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(324, 280);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(151, 54);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // EditBoardComponentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtBoard);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.cmbScheme);
            this.Controls.Add(this.btnSave);
            this.Name = "EditBoardComponentsForm";
            this.Text = "EditBoardComponentsForm";
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoard;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.ComboBox cmbScheme;
        private System.Windows.Forms.Button btnSave;
    }
}