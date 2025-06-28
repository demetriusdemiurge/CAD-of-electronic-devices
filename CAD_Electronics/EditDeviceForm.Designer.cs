namespace CAD_Electronics_App
{
    partial class EditDeviceForm
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
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.cmbEngineer = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(261, 166);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(279, 22);
            this.txtType.TabIndex = 36;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(261, 299);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(279, 22);
            this.txtDescription.TabIndex = 35;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(261, 213);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(279, 22);
            this.txtStatus.TabIndex = 34;
            // 
            // cmbEngineer
            // 
            this.cmbEngineer.FormattingEnabled = true;
            this.cmbEngineer.Location = new System.Drawing.Point(261, 84);
            this.cmbEngineer.Name = "cmbEngineer";
            this.cmbEngineer.Size = new System.Drawing.Size(279, 24);
            this.cmbEngineer.TabIndex = 32;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(324, 359);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(151, 54);
            this.btnSave.TabIndex = 31;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(261, 253);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(279, 22);
            this.txtVersion.TabIndex = 30;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(261, 123);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(279, 22);
            this.txtName.TabIndex = 29;
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(261, 38);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(279, 22);
            this.txtId.TabIndex = 28;
            // 
            // EditDeviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.cmbEngineer);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtId);
            this.Name = "EditDeviceForm";
            this.Text = "Устройства";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.ComboBox cmbEngineer;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtId;
    }
}