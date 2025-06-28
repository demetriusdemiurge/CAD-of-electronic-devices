using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CAD_Electronics_App
{
    public partial class EditDeviceComponentsForm : Form
    {
        private DataRow _row;
        private bool _isEditMode;
        private int _deviceId;

        public EditDeviceComponentsForm(int deviceId, DataRow row = null)
        {
            InitializeComponent();
            _deviceId = deviceId;
            _row = row;
            _isEditMode = row != null;
            InitializeForm();
        }

        private void InitializeForm()
        {
            Text = _isEditMode ? "Редактирование компонента устройства" : "Добавление платы в устройство";

            var boards = DatabaseHelper.GetData("SELECT ID, Наименование FROM Печатные_платы");
            cmbBoard.DataSource = boards;
            cmbBoard.DisplayMember = "Наименование";
            cmbBoard.ValueMember = "ID";

            numQuantity.Minimum = 1;
            numQuantity.Maximum = 1000;

            if (_isEditMode)
            {
                cmbBoard.SelectedValue = _row["Плата"];
                numQuantity.Value = Convert.ToInt32(_row["Количество"]);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    int boardId = Convert.ToInt32(cmbBoard.SelectedValue);
                    int quantity = (int)numQuantity.Value;

                    if (_isEditMode)
                    {
                        UpdateDeviceComponent(boardId, quantity);
                    }
                    else
                    {
                        AddDeviceComponent(boardId, quantity);
                    }

                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddDeviceComponent(int boardId, int quantity)
        {
            string query = @"INSERT INTO Состав_устройства (
                Устройство, Плата, Количество
            ) VALUES (
                @deviceId, @boardId, @quantity
            )";

            using (var cmd = new SqlCommand(query, DatabaseHelper.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@boardId", boardId);
                cmd.Parameters.AddWithValue("@deviceId", _deviceId);
                cmd.Parameters.AddWithValue("@quantity", quantity);

                cmd.ExecuteNonQuery();
            }
        }

        private void UpdateDeviceComponent(int boardId, int quantity)
        {
            string query = @"UPDATE Состав_устройства SET 
                Количество = @quantity
            WHERE Устройство = @deviceId AND Плата = @boardId";

            using (var cmd = new SqlCommand(query, DatabaseHelper.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@boardId", _row["Плата"]);
                cmd.Parameters.AddWithValue("@deviceId", _row["Устройство"]);

                cmd.ExecuteNonQuery();
            }
        }

        private bool ValidateInput()
        {
            if (cmbBoard.SelectedValue == null)
            {
                MessageBox.Show("Выберите плату", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numQuantity.Value <= 0)
            {
                MessageBox.Show("Количество должно быть больше 0", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}