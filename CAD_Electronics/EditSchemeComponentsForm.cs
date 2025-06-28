using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CAD_Electronics_App
{
    public partial class EditSchemeComponentsForm : Form
    {
        private DataRow _row;
        private bool _isEditMode;
        private int _schemeId;

        public EditSchemeComponentsForm(int schemeId, DataRow row = null)
        {
            InitializeComponent();
            _schemeId = schemeId;
            _row = row;
            _isEditMode = row != null;
            InitializeForm();
        }

        private void InitializeForm()
        {
            Text = _isEditMode ? "Редактирование компонента схемы" : "Добавление компонента в схему";

            var components = DatabaseHelper.GetData("SELECT Артикул, Наименование FROM Компоненты");
            cmbComponent.DataSource = components;
            cmbComponent.DisplayMember = "Наименование";
            cmbComponent.ValueMember = "Артикул";

            numQuantity.Minimum = 1;
            numQuantity.Maximum = 1000;

            if (_isEditMode)
            {
                cmbComponent.SelectedValue = _row["Компонент"];
                numQuantity.Value = Convert.ToInt32(_row["Количество"]);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    int componentId = Convert.ToInt32(cmbComponent.SelectedValue);
                    int quantity = (int)numQuantity.Value;

                    if (_isEditMode)
                    {
                        UpdateSchemeComponent(componentId, quantity);
                    }
                    else
                    {
                        AddSchemeComponent(componentId, quantity);
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

        private void AddSchemeComponent(int componentId, int quantity)
        {
            string query = @"INSERT INTO Состав_схемы (
                Схема, Компонент, Количество
            ) VALUES (
                @schemeId, @componentId, @quantity
            )";

            using (var cmd = new SqlCommand(query, DatabaseHelper.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@schemeId", _schemeId);
                cmd.Parameters.AddWithValue("@componentId", componentId);
                cmd.Parameters.AddWithValue("@quantity", quantity);

                cmd.ExecuteNonQuery();
            }
        }

        private void UpdateSchemeComponent(int componentId, int quantity)
        {
            string query = @"UPDATE Состав_схемы SET 
                Количество = @quantity
            WHERE Схема = @schemeId AND Компонент = @componentId";

            using (var cmd = new SqlCommand(query, DatabaseHelper.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@schemeId", _row["Схема"]);
                cmd.Parameters.AddWithValue("@componentId", _row["Компонент"]);

                cmd.ExecuteNonQuery();
            }
        }

        private bool ValidateInput()
        {
            if (cmbComponent.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка",
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