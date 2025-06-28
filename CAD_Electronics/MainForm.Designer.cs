namespace CAD_Electronics_App
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.componentsTab = new System.Windows.Forms.TabPage();
            this.componentsGrid = new System.Windows.Forms.DataGridView();
            this.schemesTab = new System.Windows.Forms.TabPage();
            this.schemesDetailsGrid = new System.Windows.Forms.DataGridView();
            this.schemesGrid = new System.Windows.Forms.DataGridView();
            this.boardsTab = new System.Windows.Forms.TabPage();
            this.boardsDetailsGrid = new System.Windows.Forms.DataGridView();
            this.boardsGrid = new System.Windows.Forms.DataGridView();
            this.devicesTab = new System.Windows.Forms.TabPage();
            this.devicesDetailsGrid = new System.Windows.Forms.DataGridView();
            this.devicesGrid = new System.Windows.Forms.DataGridView();
            this.ordersTab = new System.Windows.Forms.TabPage();
            this.ordersGrid = new System.Windows.Forms.DataGridView();
            this.engineersTab = new System.Windows.Forms.TabPage();
            this.engineersGrid = new System.Windows.Forms.DataGridView();
            this.manufacturersTab = new System.Windows.Forms.TabPage();
            this.manufacturersGrid = new System.Windows.Forms.DataGridView();
            this.reportsTab = new System.Windows.Forms.TabPage();
            this.reportsComboBox = new System.Windows.Forms.ComboBox();
            this.reportsGrid = new System.Windows.Forms.DataGridView();
            this.mainTabControl.SuspendLayout();
            this.componentsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.componentsGrid)).BeginInit();
            this.schemesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.schemesDetailsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schemesGrid)).BeginInit();
            this.boardsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boardsDetailsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardsGrid)).BeginInit();
            this.devicesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.devicesDetailsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.devicesGrid)).BeginInit();
            this.ordersTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ordersGrid)).BeginInit();
            this.engineersTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.engineersGrid)).BeginInit();
            this.manufacturersTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.manufacturersGrid)).BeginInit();
            this.reportsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.componentsTab);
            this.mainTabControl.Controls.Add(this.schemesTab);
            this.mainTabControl.Controls.Add(this.boardsTab);
            this.mainTabControl.Controls.Add(this.devicesTab);
            this.mainTabControl.Controls.Add(this.ordersTab);
            this.mainTabControl.Controls.Add(this.engineersTab);
            this.mainTabControl.Controls.Add(this.manufacturersTab);
            this.mainTabControl.Controls.Add(this.reportsTab);
            this.mainTabControl.Location = new System.Drawing.Point(12, 12);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(776, 426);
            this.mainTabControl.TabIndex = 0;
            // 
            // componentsTab
            // 
            this.componentsTab.Controls.Add(this.componentsGrid);
            this.componentsTab.Location = new System.Drawing.Point(4, 25);
            this.componentsTab.Name = "componentsTab";
            this.componentsTab.Padding = new System.Windows.Forms.Padding(3);
            this.componentsTab.Size = new System.Drawing.Size(768, 397);
            this.componentsTab.TabIndex = 0;
            this.componentsTab.Text = "Компоненты";
            this.componentsTab.UseVisualStyleBackColor = true;
            // 
            // componentsGrid
            // 
            this.componentsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.componentsGrid.Location = new System.Drawing.Point(6, 6);
            this.componentsGrid.Name = "componentsGrid";
            this.componentsGrid.RowHeadersWidth = 51;
            this.componentsGrid.RowTemplate.Height = 24;
            this.componentsGrid.Size = new System.Drawing.Size(756, 385);
            this.componentsGrid.TabIndex = 0;
            // 
            // schemesTab
            // 
            this.schemesTab.Controls.Add(this.schemesDetailsGrid);
            this.schemesTab.Controls.Add(this.schemesGrid);
            this.schemesTab.Location = new System.Drawing.Point(4, 25);
            this.schemesTab.Name = "schemesTab";
            this.schemesTab.Padding = new System.Windows.Forms.Padding(3);
            this.schemesTab.Size = new System.Drawing.Size(768, 397);
            this.schemesTab.TabIndex = 1;
            this.schemesTab.Text = "Схемы";
            this.schemesTab.UseVisualStyleBackColor = true;
            // 
            // schemesDetailsGrid
            // 
            this.schemesDetailsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.schemesDetailsGrid.Location = new System.Drawing.Point(6, 208);
            this.schemesDetailsGrid.Name = "schemesDetailsGrid";
            this.schemesDetailsGrid.RowHeadersWidth = 51;
            this.schemesDetailsGrid.RowTemplate.Height = 24;
            this.schemesDetailsGrid.Size = new System.Drawing.Size(756, 183);
            this.schemesDetailsGrid.TabIndex = 2;
            // 
            // schemesGrid
            // 
            this.schemesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.schemesGrid.Location = new System.Drawing.Point(6, 6);
            this.schemesGrid.Name = "schemesGrid";
            this.schemesGrid.RowHeadersWidth = 51;
            this.schemesGrid.RowTemplate.Height = 24;
            this.schemesGrid.Size = new System.Drawing.Size(756, 196);
            this.schemesGrid.TabIndex = 1;
            // 
            // boardsTab
            // 
            this.boardsTab.Controls.Add(this.boardsDetailsGrid);
            this.boardsTab.Controls.Add(this.boardsGrid);
            this.boardsTab.Location = new System.Drawing.Point(4, 25);
            this.boardsTab.Name = "boardsTab";
            this.boardsTab.Padding = new System.Windows.Forms.Padding(3);
            this.boardsTab.Size = new System.Drawing.Size(768, 397);
            this.boardsTab.TabIndex = 2;
            this.boardsTab.Text = "Платы";
            this.boardsTab.UseVisualStyleBackColor = true;
            // 
            // boardsDetailsGrid
            // 
            this.boardsDetailsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.boardsDetailsGrid.Location = new System.Drawing.Point(6, 208);
            this.boardsDetailsGrid.Name = "boardsDetailsGrid";
            this.boardsDetailsGrid.RowHeadersWidth = 51;
            this.boardsDetailsGrid.RowTemplate.Height = 24;
            this.boardsDetailsGrid.Size = new System.Drawing.Size(756, 183);
            this.boardsDetailsGrid.TabIndex = 2;
            // 
            // boardsGrid
            // 
            this.boardsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.boardsGrid.Location = new System.Drawing.Point(6, 6);
            this.boardsGrid.Name = "boardsGrid";
            this.boardsGrid.RowHeadersWidth = 51;
            this.boardsGrid.RowTemplate.Height = 24;
            this.boardsGrid.Size = new System.Drawing.Size(756, 196);
            this.boardsGrid.TabIndex = 1;
            // 
            // devicesTab
            // 
            this.devicesTab.Controls.Add(this.devicesDetailsGrid);
            this.devicesTab.Controls.Add(this.devicesGrid);
            this.devicesTab.Location = new System.Drawing.Point(4, 25);
            this.devicesTab.Name = "devicesTab";
            this.devicesTab.Padding = new System.Windows.Forms.Padding(3);
            this.devicesTab.Size = new System.Drawing.Size(768, 397);
            this.devicesTab.TabIndex = 3;
            this.devicesTab.Text = "Устройства";
            this.devicesTab.UseVisualStyleBackColor = true;
            // 
            // devicesDetailsGrid
            // 
            this.devicesDetailsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.devicesDetailsGrid.Location = new System.Drawing.Point(6, 208);
            this.devicesDetailsGrid.Name = "devicesDetailsGrid";
            this.devicesDetailsGrid.RowHeadersWidth = 51;
            this.devicesDetailsGrid.RowTemplate.Height = 24;
            this.devicesDetailsGrid.Size = new System.Drawing.Size(756, 183);
            this.devicesDetailsGrid.TabIndex = 2;
            // 
            // devicesGrid
            // 
            this.devicesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.devicesGrid.Location = new System.Drawing.Point(6, 6);
            this.devicesGrid.Name = "devicesGrid";
            this.devicesGrid.RowHeadersWidth = 51;
            this.devicesGrid.RowTemplate.Height = 24;
            this.devicesGrid.Size = new System.Drawing.Size(756, 196);
            this.devicesGrid.TabIndex = 1;
            // 
            // ordersTab
            // 
            this.ordersTab.Controls.Add(this.ordersGrid);
            this.ordersTab.Location = new System.Drawing.Point(4, 25);
            this.ordersTab.Name = "ordersTab";
            this.ordersTab.Padding = new System.Windows.Forms.Padding(3);
            this.ordersTab.Size = new System.Drawing.Size(768, 397);
            this.ordersTab.TabIndex = 4;
            this.ordersTab.Text = "Заказы";
            this.ordersTab.UseVisualStyleBackColor = true;
            // 
            // ordersGrid
            // 
            this.ordersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordersGrid.Location = new System.Drawing.Point(6, 6);
            this.ordersGrid.Name = "ordersGrid";
            this.ordersGrid.RowHeadersWidth = 51;
            this.ordersGrid.RowTemplate.Height = 24;
            this.ordersGrid.Size = new System.Drawing.Size(756, 385);
            this.ordersGrid.TabIndex = 1;
            // 
            // engineersTab
            // 
            this.engineersTab.Controls.Add(this.engineersGrid);
            this.engineersTab.Location = new System.Drawing.Point(4, 25);
            this.engineersTab.Name = "engineersTab";
            this.engineersTab.Padding = new System.Windows.Forms.Padding(3);
            this.engineersTab.Size = new System.Drawing.Size(768, 397);
            this.engineersTab.TabIndex = 5;
            this.engineersTab.Text = "Инженеры";
            this.engineersTab.UseVisualStyleBackColor = true;
            // 
            // engineersGrid
            // 
            this.engineersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.engineersGrid.Location = new System.Drawing.Point(6, 6);
            this.engineersGrid.Name = "engineersGrid";
            this.engineersGrid.RowHeadersWidth = 51;
            this.engineersGrid.RowTemplate.Height = 24;
            this.engineersGrid.Size = new System.Drawing.Size(756, 385);
            this.engineersGrid.TabIndex = 1;
            // 
            // manufacturersTab
            // 
            this.manufacturersTab.Controls.Add(this.manufacturersGrid);
            this.manufacturersTab.Location = new System.Drawing.Point(4, 25);
            this.manufacturersTab.Name = "manufacturersTab";
            this.manufacturersTab.Padding = new System.Windows.Forms.Padding(3);
            this.manufacturersTab.Size = new System.Drawing.Size(768, 397);
            this.manufacturersTab.TabIndex = 6;
            this.manufacturersTab.Text = "Производители";
            this.manufacturersTab.UseVisualStyleBackColor = true;
            // 
            // manufacturersGrid
            // 
            this.manufacturersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.manufacturersGrid.Location = new System.Drawing.Point(6, 6);
            this.manufacturersGrid.Name = "manufacturersGrid";
            this.manufacturersGrid.RowHeadersWidth = 51;
            this.manufacturersGrid.RowTemplate.Height = 24;
            this.manufacturersGrid.Size = new System.Drawing.Size(756, 385);
            this.manufacturersGrid.TabIndex = 0;
            // 
            // reportsTab
            // 
            this.reportsTab.Controls.Add(this.reportsGrid);
            this.reportsTab.Controls.Add(this.reportsComboBox);
            this.reportsTab.Location = new System.Drawing.Point(4, 25);
            this.reportsTab.Name = "reportsTab";
            this.reportsTab.Padding = new System.Windows.Forms.Padding(3);
            this.reportsTab.Size = new System.Drawing.Size(768, 397);
            this.reportsTab.TabIndex = 7;
            this.reportsTab.Text = "Отчёты";
            this.reportsTab.UseVisualStyleBackColor = true;
            // 
            // reportsComboBox
            // 
            this.reportsComboBox.FormattingEnabled = true;
            this.reportsComboBox.Location = new System.Drawing.Point(6, 6);
            this.reportsComboBox.Name = "reportsComboBox";
            this.reportsComboBox.Size = new System.Drawing.Size(265, 24);
            this.reportsComboBox.TabIndex = 0;
            // 
            // reportsGrid
            // 
            this.reportsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportsGrid.Location = new System.Drawing.Point(6, 36);
            this.reportsGrid.Name = "reportsGrid";
            this.reportsGrid.RowHeadersWidth = 51;
            this.reportsGrid.RowTemplate.Height = 24;
            this.reportsGrid.Size = new System.Drawing.Size(756, 355);
            this.reportsGrid.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainTabControl);
            this.Name = "MainForm";
            this.Text = "САПР электронных устройств";
            this.mainTabControl.ResumeLayout(false);
            this.componentsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.componentsGrid)).EndInit();
            this.schemesTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.schemesDetailsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schemesGrid)).EndInit();
            this.boardsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.boardsDetailsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardsGrid)).EndInit();
            this.devicesTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.devicesDetailsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.devicesGrid)).EndInit();
            this.ordersTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ordersGrid)).EndInit();
            this.engineersTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.engineersGrid)).EndInit();
            this.manufacturersTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.manufacturersGrid)).EndInit();
            this.reportsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reportsGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage componentsTab;
        private System.Windows.Forms.TabPage schemesTab;
        private System.Windows.Forms.TabPage boardsTab;
        private System.Windows.Forms.TabPage devicesTab;
        private System.Windows.Forms.TabPage ordersTab;
        private System.Windows.Forms.TabPage engineersTab;
        private System.Windows.Forms.TabPage manufacturersTab;
        private System.Windows.Forms.DataGridView componentsGrid;
        private System.Windows.Forms.DataGridView schemesGrid;
        private System.Windows.Forms.DataGridView boardsGrid;
        private System.Windows.Forms.DataGridView devicesGrid;
        private System.Windows.Forms.DataGridView ordersGrid;
        private System.Windows.Forms.DataGridView engineersGrid;
        private System.Windows.Forms.TabPage reportsTab;
        private System.Windows.Forms.DataGridView schemesDetailsGrid;
        private System.Windows.Forms.DataGridView boardsDetailsGrid;
        private System.Windows.Forms.DataGridView devicesDetailsGrid;
        private System.Windows.Forms.DataGridView manufacturersGrid;
        private System.Windows.Forms.ComboBox reportsComboBox;
        private System.Windows.Forms.DataGridView reportsGrid;
    }
}

