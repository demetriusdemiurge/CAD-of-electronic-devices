using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.ComponentModel;

namespace CAD_Electronics_App
{
    public partial class MainForm : Form
    {
        private SqlConnection connection;
        private const string ConnectionString = "Data Source=LAPTOP-H80F4HPF\\SQLEXPRESS;Initial Catalog=САПР электронных устройств;Integrated Security=True";

        public MainForm()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            ConfigureDataGridViews();
            LoadAllData();
            SetupContextMenus();
        }

        private void InitializeDatabaseConnection()
        {
            connection = new SqlConnection(ConnectionString);
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridViews()
        {
            var allGrids = new[] { componentsGrid, schemesGrid, schemesDetailsGrid,
                                 boardsGrid, boardsDetailsGrid, devicesGrid,
                                 devicesDetailsGrid, ordersGrid, engineersGrid,
                                 manufacturersGrid, reportsGrid };

            foreach (var grid in allGrids)
            {
                if (grid != null)
                {
                    grid.AllowUserToAddRows = false;
                    grid.AllowUserToDeleteRows = false;
                    grid.ReadOnly = true;
                    grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            }
            reportsComboBox.Items.Clear();
            reportsComboBox.Items.AddRange(new string[] {
        "Полная_Информация_По_Заказу",
        "Детальная_Спецификация_Устройства",
        "Библиотека_Компонентов"
    });
            reportsComboBox.SelectedIndex = 0;
            reportsComboBox.SelectedIndexChanged += reportsComboBox_SelectedIndexChanged;
        }

        private void LoadAllData()
        {
            LoadComponents();
            LoadSchemes();
            LoadSchemeDetails();
            LoadBoards();
            LoadBoardDetails();
            LoadDevices();
            LoadDeviceDetails();
            LoadOrders();
            LoadEngineers();
            LoadManufacturers();
            LoadReport();
            
        }

        private void SetupContextMenus()
        {
            SetupComponentsContextMenu();
        }

        #region Context Menu Setup Methods

        private void SetupComponentsContextMenu()
        {
            var menu = new ContextMenuStrip();
            menu.Items.Add("Добавить", null, (s, e) => AddComponent());
            menu.Items.Add("Редактировать", null, (s, e) => EditComponent());
            menu.Items.Add("Удалить", null, (s, e) => DeleteComponent());
            componentsGrid.ContextMenuStrip = menu;

            var smenu = new ContextMenuStrip();
            smenu.Items.Add("Добавить", null, (s, e) => AddScheme());
            smenu.Items.Add("Редактировать", null, (s, e) => EditScheme());
            smenu.Items.Add("Удалить", null, (s, e) => DeleteScheme());
            schemesGrid.ContextMenuStrip = smenu;

            var bmenu = new ContextMenuStrip();
            bmenu.Items.Add("Добавить", null, (s, e) => AddBoard());
            bmenu.Items.Add("Редактировать", null, (s, e) => EditBoard());
            bmenu.Items.Add("Удалить", null, (s, e) => DeleteBoard());
            boardsGrid.ContextMenuStrip = bmenu;

            var dmenu = new ContextMenuStrip();
            dmenu.Items.Add("Добавить", null, (s, e) => AddDevice());
            dmenu.Items.Add("Редактировать", null, (s, e) => EditDevice());
            dmenu.Items.Add("Удалить", null, (s, e) => DeleteDevice());
            devicesGrid.ContextMenuStrip = dmenu;

            var omenu = new ContextMenuStrip();
            omenu.Items.Add("Добавить", null, (s, e) => AddOrder());
            omenu.Items.Add("Редактировать", null, (s, e) => EditOrder());
            omenu.Items.Add("Удалить", null, (s, e) => DeleteOrder());
            ordersGrid.ContextMenuStrip = omenu;

            var emenu = new ContextMenuStrip();
            emenu.Items.Add("Добавить", null, (s, e) => AddEngineer());
            emenu.Items.Add("Редактировать", null, (s, e) => EditEngineer());
            emenu.Items.Add("Удалить", null, (s, e) => DeleteEngineer());
            engineersGrid.ContextMenuStrip = emenu;

            var mmenu = new ContextMenuStrip();
            mmenu.Items.Add("Добавить", null, (s, e) => AddManufacturer());
            mmenu.Items.Add("Редактировать", null, (s, e) => EditManufacturer());
            mmenu.Items.Add("Удалить", null, (s, e) => DeleteManufacturer());
            manufacturersGrid.ContextMenuStrip = mmenu;

            var scmenu = new ContextMenuStrip();
            scmenu.Items.Add("Добавить", null, (s, e) => AddSchemesDetails());
            scmenu.Items.Add("Редактировать", null, (s, e) => EditSchemesDetails());
            scmenu.Items.Add("Удалить", null, (s, e) => DeleteSchemesDetails());
            schemesDetailsGrid.ContextMenuStrip = scmenu;

            var bsmenu = new ContextMenuStrip();
            bsmenu.Items.Add("Добавить", null, (s, e) => AddBoardsDetails());
            bsmenu.Items.Add("Редактировать", null, (s, e) => EditBoardsDetails());
            bsmenu.Items.Add("Удалить", null, (s, e) => DeleteBoardsDetails());
            boardsDetailsGrid.ContextMenuStrip = bsmenu;

            var dbmenu = new ContextMenuStrip();
            dbmenu.Items.Add("Добавить", null, (s, e) => AddDevicesDetails());
            dbmenu.Items.Add("Редактировать", null, (s, e) => EditDevicesDetails());
            dbmenu.Items.Add("Удалить", null, (s, e) => DeleteDevicesDetails());
            devicesDetailsGrid.ContextMenuStrip = dbmenu;


        }

        #endregion

        #region Data Loading Methods

        private void LoadComponents()
        {
            try
            {
                using (var adapter = new SqlDataAdapter("SELECT * FROM Компоненты", connection))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    componentsGrid.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки компонентов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSchemes()
        {
            try
            {
                using (var adapter = new SqlDataAdapter("SELECT * FROM Схемы", connection))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    schemesGrid.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки схем: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBoards()
        {
            try
            {
                using (var adapter = new SqlDataAdapter("SELECT * FROM Печатные_платы", connection))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    boardsGrid.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки плат: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDevices()
        {
            try
            {
                using (var adapter = new SqlDataAdapter("SELECT * FROM Устройства", connection))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    devicesGrid.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки устройств: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrders()
        {
            try
            {
                using (var adapter = new SqlDataAdapter("SELECT * FROM Заказы", connection))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    ordersGrid.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки заказов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEngineers()
        {
            if (engineersGrid == null || connection == null || connection.State != ConnectionState.Open) return;
            try
            {
                using (var adapter = new SqlDataAdapter("SELECT * FROM Инженеры", connection))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    engineersGrid.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки инженеров: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadManufacturers()
        {
            try
            {
                using (var adapter = new SqlDataAdapter("SELECT * FROM Производители", connection))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    manufacturersGrid.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки производителей: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReport()
        {
            if (reportsComboBox.SelectedItem == null) return;

            try
            {
                string selectedReport = reportsComboBox.SelectedItem.ToString();
                string query = $"SELECT * FROM [{selectedReport}]";

                using (var adapter = new SqlDataAdapter(query, connection))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);

                    reportsGrid.DataSource = dt;

                    if (selectedReport == "Полная_Информация_По_Заказу")
                    {
                        reportsGrid.Columns["Номер_заказа"].HeaderText = "Номер заказа";
                        reportsGrid.Columns["Плановый_срок_начала"].HeaderText = "План. начало";
                        reportsGrid.Columns["Плановый_срок_окончания"].HeaderText = "План. окончание";
                        reportsGrid.Columns["Наименование_устройства"].HeaderText = "Устройство";
                        reportsGrid.Columns["Версия_устройства"].HeaderText = "Версия";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки отчета: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


        private void LoadSchemeDetails()
        {
            try
            {
                using (var adapter = new SqlDataAdapter("SELECT * FROM Состав_схемы", connection))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    schemesDetailsGrid.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки состава схем: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBoardDetails()
        {
            try
            {
                using (var adapter = new SqlDataAdapter("SELECT * FROM Состав_платы", connection))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    boardsDetailsGrid.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки состава плат: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDeviceDetails()
        {
            try
            {
                using (var adapter = new SqlDataAdapter("SELECT * FROM Состав_устройства", connection))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    devicesDetailsGrid.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки состава устройств: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reportsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadReport();

                if (reportsComboBox.SelectedItem.ToString() == "Полная_Информация_По_Заказу")
                {
                    reportsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else if (reportsComboBox.SelectedItem.ToString() == "Детальная_Спецификация_Устройства")
                {
                    reportsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при переключении отчета: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #region CRUD Operations

        #region Components CRUD
        private void AddComponent()
        {
            using (var form = new EditComponentForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadComponents();
                }
            }
        }

        private void EditComponent()
        {
            if (componentsGrid.CurrentRow != null)
            {
                var row = ((DataRowView)componentsGrid.CurrentRow.DataBoundItem).Row;
                using (var form = new EditComponentForm(row))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadComponents();
                    }
                }
            }
        }

        private void DeleteComponent()
        {
            if (componentsGrid.CurrentRow != null)
            {
                var row = ((DataRowView)componentsGrid.CurrentRow.DataBoundItem).Row;
                string article = row["Артикул"].ToString();

                if (MessageBox.Show($"Удалить компонент {article}?", "Подтверждение",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        using (var cmd = new SqlCommand($"DELETE FROM Компоненты WHERE Артикул = @article", connection))
                        {
                            cmd.Parameters.AddWithValue("@article", article);
                            cmd.ExecuteNonQuery();
                        }
                        LoadComponents();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region Schemes CRUD
        private void AddScheme()
        {
            using (var form = new EditSchemeForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadSchemes();
                }
            }
        }

        private void EditScheme()
        {
            if (schemesGrid.CurrentRow != null)
            {
                var row = ((DataRowView)schemesGrid.CurrentRow.DataBoundItem).Row;
                using (var form = new EditSchemeForm(row))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadSchemes();
                    }
                }
            }
        }

        private void DeleteScheme()
        {
            if (schemesGrid.CurrentRow != null)
            {
                var row = ((DataRowView)schemesGrid.CurrentRow.DataBoundItem).Row;
                int id = Convert.ToInt32(row["ID"]);

                if (MessageBox.Show($"Удалить схему {row["Наименование"]}?", "Подтверждение",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        using (var cmd = new SqlCommand("DELETE FROM Схемы WHERE ID = @id", connection))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                        LoadSchemes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region Boards CRUD
        private void AddBoard()
        {
            using (var form = new EditBoardForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadBoards();
                }
            }
        }

        private void EditBoard()
        {
            if (boardsGrid.CurrentRow != null)
            {
                var row = ((DataRowView)boardsGrid.CurrentRow.DataBoundItem).Row;
                using (var form = new EditBoardForm(row))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadBoards();
                    }
                }
            }
        }

        private void DeleteBoard()
        {
            if (boardsGrid.CurrentRow != null)
            {
                var row = ((DataRowView)boardsGrid.CurrentRow.DataBoundItem).Row;
                int id = Convert.ToInt32(row["ID"]);

                if (MessageBox.Show($"Удалить плату {row["Наименование"]}?", "Подтверждение",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        using (var cmd = new SqlCommand("DELETE FROM Печатные_платы WHERE ID = @id", connection))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                        LoadBoards();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region Devices CRUD
        private void AddDevice()
        {
            using (var form = new EditDeviceForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadDevices();
                }
            }
        }

        private void EditDevice()
        {
            if (devicesGrid.CurrentRow != null)
            {
                var row = ((DataRowView)devicesGrid.CurrentRow.DataBoundItem).Row;
                using (var form = new EditDeviceForm(row))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadDevices();
                    }
                }
            }
        }

        private void DeleteDevice()
        {
            if (devicesGrid.CurrentRow != null)
            {
                var row = ((DataRowView)devicesGrid.CurrentRow.DataBoundItem).Row;
                int id = Convert.ToInt32(row["ID"]);

                if (MessageBox.Show($"Удалить устройство {row["Наименование"]}?", "Подтверждение",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        using (var cmd = new SqlCommand("DELETE FROM Устройства WHERE ID = @id", connection))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                        LoadDevices();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region Orders CRUD
        private void AddOrder()
        {
            using (var form = new EditOrderForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadOrders();
                }
            }
        }

        private void EditOrder()
        {
            if (ordersGrid.CurrentRow != null)
            {
                var row = ((DataRowView)ordersGrid.CurrentRow.DataBoundItem).Row;
                using (var form = new EditOrderForm(row))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadOrders();
                    }
                }
            }
        }

        private void DeleteOrder()
        {
            if (ordersGrid.CurrentRow != null)
            {
                var row = ((DataRowView)ordersGrid.CurrentRow.DataBoundItem).Row;
                string orderNumber = row["Номер_заказа"].ToString();

                if (MessageBox.Show($"Удалить заказ {orderNumber}?", "Подтверждение",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        using (var cmd = new SqlCommand("DELETE FROM Заказы WHERE Номер_заказа = @orderNumber", connection))
                        {
                            cmd.Parameters.AddWithValue("@orderNumber", orderNumber);
                            cmd.ExecuteNonQuery();
                        }
                        LoadOrders();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region Engineers CRUD
        private void AddEngineer()
        {
            using (var form = new EditEngineerForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadEngineers();
                }
            }
        }

        private void EditEngineer()
        {
            if (engineersGrid.CurrentRow != null)
            {
                var row = ((DataRowView)engineersGrid.CurrentRow.DataBoundItem).Row;
                using (var form = new EditEngineerForm(row))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadEngineers();
                    }
                }
            }
        }

        private void DeleteEngineer()
        {
            if (engineersGrid.CurrentRow != null)
            {
                var row = ((DataRowView)engineersGrid.CurrentRow.DataBoundItem).Row;
                string personnelNumber = row["Табельный_номер"].ToString();

                if (MessageBox.Show($"Удалить инженера {row["ФИО"]}?", "Подтверждение",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        using (var cmd = new SqlCommand("DELETE FROM Инженеры WHERE Табельный_номер = @personnelNumber", connection))
                        {
                            cmd.Parameters.AddWithValue("@personnelNumber", personnelNumber);
                            cmd.ExecuteNonQuery();
                        }
                        LoadEngineers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region Manufacturers CRUD
        private void AddManufacturer()
        {
            using (var form = new EditManufacturerForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadManufacturers();
                }
            }
        }

        private void EditManufacturer()
        {
            if (manufacturersGrid.CurrentRow != null)
            {
                var row = ((DataRowView)manufacturersGrid.CurrentRow.DataBoundItem).Row;
                using (var form = new EditManufacturerForm(row))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadManufacturers();
                    }
                }
            }
        }

        private void DeleteManufacturer()
        {
            if (manufacturersGrid.CurrentRow != null)
            {
                var row = ((DataRowView)manufacturersGrid.CurrentRow.DataBoundItem).Row;
                int id = Convert.ToInt32(row["ID"]);

                if (MessageBox.Show($"Удалить производителя {row["Наименование"]}?", "Подтверждение",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        using (var cmd = new SqlCommand("DELETE FROM Производители WHERE ID = @id", connection))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                        LoadManufacturers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        private void AddSchemesDetails()
        {
            if (schemesGrid.CurrentRow == null) return;
            int schemeId = Convert.ToInt32(schemesGrid.CurrentRow.Cells["ID"].Value);

            using (var form = new EditSchemeComponentsForm(schemeId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadSchemeDetails();
                }
            }
        }

        private void EditSchemesDetails()
        {
            if (schemesDetailsGrid.CurrentRow != null && schemesGrid.CurrentRow != null)
            {
                var row = ((DataRowView)schemesDetailsGrid.CurrentRow.DataBoundItem).Row;
                int schemeId = Convert.ToInt32(schemesGrid.CurrentRow.Cells["ID"].Value);

                using (var form = new EditSchemeComponentsForm(schemeId, row))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadSchemeDetails();
                    }
                }
            }
        }

        private void DeleteSchemesDetails()
        {
            if (schemesDetailsGrid.CurrentRow != null && schemesGrid.CurrentRow != null)
            {
                var row = ((DataRowView)schemesDetailsGrid.CurrentRow.DataBoundItem).Row;
                int schemeId = Convert.ToInt32(schemesGrid.CurrentRow.Cells["ID"].Value);
                int componentId = Convert.ToInt32(row["Компонент"]);

                if (MessageBox.Show($"Удалить компонент из схемы?", "Подтверждение",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        using (var cmd = new SqlCommand(
                            "DELETE FROM Состав_схемы WHERE Схема = @schemeId AND Компонент = @componentId",
                            connection))
                        {
                            cmd.Parameters.AddWithValue("@schemeId", schemeId);
                            cmd.Parameters.AddWithValue("@componentId", componentId);
                            cmd.ExecuteNonQuery();
                        }
                        LoadSchemeDetails();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        private void AddBoardsDetails()
        {
            if (boardsGrid.CurrentRow == null) return;
            int boardId = Convert.ToInt32(boardsGrid.CurrentRow.Cells["ID"].Value);

            using (var form = new EditBoardComponentsForm(boardId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadBoardDetails();
                }
            }
        }

        private void EditBoardsDetails()
        {
            if (boardsDetailsGrid.CurrentRow != null && boardsGrid.CurrentRow != null)
            {
                var row = ((DataRowView)boardsDetailsGrid.CurrentRow.DataBoundItem).Row;
                int boardId = Convert.ToInt32(boardsGrid.CurrentRow.Cells["ID"].Value);

                using (var form = new EditBoardComponentsForm(boardId, row))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadBoardDetails();
                    }
                }
            }
        }

        private void DeleteBoardsDetails()
        {
            if (boardsDetailsGrid.CurrentRow != null && boardsGrid.CurrentRow != null)
            {
                var row = ((DataRowView)boardsDetailsGrid.CurrentRow.DataBoundItem).Row;
                int boardId = Convert.ToInt32(boardsGrid.CurrentRow.Cells["ID"].Value);
                int schemeId = Convert.ToInt32(row["Схема"]);

                if (MessageBox.Show($"Удалить схему из платы?", "Подтверждение",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        using (var cmd = new SqlCommand(
                            "DELETE FROM Состав_платы WHERE Плата = @boardId AND Схема = @schemeId",
                            connection))
                        {
                            cmd.Parameters.AddWithValue("@boardId", boardId);
                            cmd.Parameters.AddWithValue("@schemeId", schemeId);
                            cmd.ExecuteNonQuery();
                        }
                        LoadBoardDetails();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void AddDevicesDetails()
        {
            if (devicesGrid.CurrentRow == null) return;
            int deviceId = Convert.ToInt32(devicesGrid.CurrentRow.Cells["ID"].Value);

            using (var form = new EditDeviceComponentsForm(deviceId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadDeviceDetails();
                }
            }
        }

        private void EditDevicesDetails()
        {
            if (devicesDetailsGrid.CurrentRow != null && devicesGrid.CurrentRow != null)
            {
                var row = ((DataRowView)devicesDetailsGrid.CurrentRow.DataBoundItem).Row;
                int deviceId = Convert.ToInt32(devicesGrid.CurrentRow.Cells["ID"].Value);

                using (var form = new EditDeviceComponentsForm(deviceId, row))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadDeviceDetails();
                    }
                }
            }
        }

        private void DeleteDevicesDetails()
        {
            if (devicesDetailsGrid.CurrentRow != null && devicesGrid.CurrentRow != null)
            {
                var row = ((DataRowView)devicesDetailsGrid.CurrentRow.DataBoundItem).Row;
                int deviceId = Convert.ToInt32(devicesGrid.CurrentRow.Cells["ID"].Value);
                int boardId = Convert.ToInt32(row["Плата"]);

                if (MessageBox.Show($"Удалить плату из устройства?", "Подтверждение",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        using (var cmd = new SqlCommand(
                            "DELETE FROM Состав_устройства WHERE Устройство = @deviceId AND Плата = @boardId",
                            connection))
                        {
                            cmd.Parameters.AddWithValue("@boardId", boardId);
                            cmd.Parameters.AddWithValue("@deviceId", deviceId);
                            cmd.ExecuteNonQuery();
                        }
                        LoadDeviceDetails();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}