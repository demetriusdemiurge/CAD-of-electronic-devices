namespace CAD_Electronics_App
{
    partial class EditOrderForm
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
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cmbEngineer = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.cmbDevice = new System.Windows.Forms.ComboBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.dtpPlanStart = new System.Windows.Forms.DateTimePicker();
            this.dtpPlanEnd = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(261, 162);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(279, 22);
            this.txtDescription.TabIndex = 43;
            // 
            // cmbEngineer
            // 
            this.cmbEngineer.FormattingEnabled = true;
            this.cmbEngineer.Location = new System.Drawing.Point(261, 120);
            this.cmbEngineer.Name = "cmbEngineer";
            this.cmbEngineer.Size = new System.Drawing.Size(279, 24);
            this.cmbEngineer.TabIndex = 41;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(324, 359);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(151, 54);
            this.btnSave.TabIndex = 40;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Enabled = false;
            this.txtOrderNumber.Location = new System.Drawing.Point(261, 38);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(279, 22);
            this.txtOrderNumber.TabIndex = 37;
            // 
            // cmbDevice
            // 
            this.cmbDevice.FormattingEnabled = true;
            this.cmbDevice.Location = new System.Drawing.Point(261, 78);
            this.cmbDevice.Name = "cmbDevice";
            this.cmbDevice.Size = new System.Drawing.Size(279, 24);
            this.cmbDevice.TabIndex = 45;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(261, 288);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(279, 22);
            this.txtStatus.TabIndex = 42;
            // 
            // dtpPlanStart
            // 
            this.dtpPlanStart.Location = new System.Drawing.Point(261, 206);
            this.dtpPlanStart.Name = "dtpPlanStart";
            this.dtpPlanStart.Size = new System.Drawing.Size(279, 22);
            this.dtpPlanStart.TabIndex = 46;
            // 
            // dtpPlanEnd
            // 
            this.dtpPlanEnd.Location = new System.Drawing.Point(261, 248);
            this.dtpPlanEnd.Name = "dtpPlanEnd";
            this.dtpPlanEnd.Size = new System.Drawing.Size(279, 22);
            this.dtpPlanEnd.TabIndex = 47;
            // 
            // EditOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtpPlanEnd);
            this.Controls.Add(this.dtpPlanStart);
            this.Controls.Add(this.cmbDevice);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.cmbEngineer);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtOrderNumber);
            this.Name = "EditOrderForm";
            this.Text = "Заказы";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ComboBox cmbEngineer;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.ComboBox cmbDevice;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.DateTimePicker dtpPlanStart;
        private System.Windows.Forms.DateTimePicker dtpPlanEnd;
    }
}