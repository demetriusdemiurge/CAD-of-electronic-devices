namespace CAD_Electronics_App
{
    partial class EditSchemeComponentsForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbComponent = new System.Windows.Forms.ComboBox();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.txtScheme = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(324, 249);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(151, 54);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbComponent
            // 
            this.cmbComponent.FormattingEnabled = true;
            this.cmbComponent.Location = new System.Drawing.Point(261, 141);
            this.cmbComponent.Name = "cmbComponent";
            this.cmbComponent.Size = new System.Drawing.Size(279, 24);
            this.cmbComponent.TabIndex = 11;
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(261, 197);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(279, 22);
            this.numQuantity.TabIndex = 13;
            // 
            // txtScheme
            // 
            this.txtScheme.Enabled = false;
            this.txtScheme.Location = new System.Drawing.Point(261, 86);
            this.txtScheme.Name = "txtScheme";
            this.txtScheme.Size = new System.Drawing.Size(279, 22);
            this.txtScheme.TabIndex = 14;
            // 
            // EditSchemeComponentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtScheme);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.cmbComponent);
            this.Controls.Add(this.btnSave);
            this.Name = "EditSchemeComponentsForm";
            this.Text = "EditSchemeComponentsForm";
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbComponent;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.TextBox txtScheme;
    }
}