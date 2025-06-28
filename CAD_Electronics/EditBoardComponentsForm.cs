using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CAD_Electronics_App
{
    public partial class EditBoardComponentsForm : Form
    {
        private DataRow _row;
        private bool _isEditMode;
        private int _boardId;

        public EditBoardComponentsForm(int schemeId, DataRow row = null)
        {
            InitializeComponent();
            _boardId = schemeId;
            _row = row;
            _isEditMode = row != null;
            InitializeForm();
        }

        private void InitializeForm()
        {
            Text = _isEditMode ? "Редактирование компонента платы" : "Добавление схемы на плату";

            var components = DatabaseHelper.GetData("SELECT ID, Наименование FROM Схемы");
            cmbScheme.DataSource = components;
            cmbScheme.DisplayMember = "Наименование";
            cmbScheme.ValueMember = "ID";

            numQuantity.Minimum = 1;
            numQuantity.Maximum = 1000;

            if (_isEditMode)
            {
                cmbScheme.SelectedValue = _row["Схема"];
                numQuantity.Value = Convert.ToInt32(_row["Количество"]);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    int schemeId = Convert.ToInt32(cmbScheme.SelectedValue);
                    int quantity = (int)numQuantity.Value;

                    if (_isEditMode)
                    {
                        UpdateBoardComponent(schemeId, quantity);
                    }
                    else
                    {
                        AddBoardComponent(schemeId, quantity);
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

        private void AddBoardComponent(int schemeId, int quantity)
        {
            string query = @"INSERT INTO Состав_платы (
                Плата, Схема, Количество
            ) VALUES (
                @boardId, @schemeId, @quantity
            )";

            using (var cmd = new SqlCommand(query, DatabaseHelper.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@boardId", _boardId);
                cmd.Parameters.AddWithValue("@schemeId", schemeId);
                cmd.Parameters.AddWithValue("@quantity", quantity);

                cmd.ExecuteNonQuery();
            }
        }

        private void UpdateBoardComponent(int schemeId, int quantity)
        {
            string query = @"UPDATE Состав_платы SET 
                Количество = @quantity
            WHERE Плата = @boardId AND Схема = @schemeId";

            using (var cmd = new SqlCommand(query, DatabaseHelper.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@boardId", _row["Плата"]);
                cmd.Parameters.AddWithValue("@schemeId", _row["Схема"]);

                cmd.ExecuteNonQuery();
            }
        }

        private bool ValidateInput()
        {
            if (cmbScheme.SelectedValue == null)
            {
                MessageBox.Show("Выберите схему", "Ошибка",
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