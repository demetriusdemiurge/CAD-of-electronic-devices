using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CAD_Electronics_App
{
    public partial class EditManufacturerForm : Form
    {
        private DataRow _row;
        private bool _isEditMode;

        public EditManufacturerForm(DataRow row = null)
        {
            InitializeComponent();
            _row = row;
            _isEditMode = row != null;
            InitializeForm();
        }

        private void InitializeForm()
        {
            Text = _isEditMode ? "Редактирование производителя" : "Добавление производителя";
            txtId.ReadOnly = _isEditMode;

            if (_isEditMode)
            {
                txtId.Text = _row["ID"].ToString();
                txtName.Text = _row["Наименование"].ToString();
                txtOrigin.Text = _row["Страна_происхождения"].ToString();
                txtWebsite.Text = _row["Сайт"].ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    if (_isEditMode)
                    {
                        string query = @"UPDATE Производители SET 
                            Наименование = @name,
                            [Страна_происхождения] = @origin,
                            Сайт = @website
                        WHERE ID = @id";

                        using (var cmd = new SqlCommand(query, DatabaseHelper.GetConnection()))
                        {
                            cmd.Parameters.AddWithValue("@name", txtName.Text);
                            cmd.Parameters.AddWithValue("@origin", txtOrigin.Text);
                            cmd.Parameters.AddWithValue("@website", txtWebsite.Text);
                            cmd.Parameters.AddWithValue("@id", _row["ID"]);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string query = @"INSERT INTO Производители (
                            Наименование, [Страна_происхождения], Сайт
                        ) VALUES (
                            @name, @origin, @website
                        )";

                        using (var cmd = new SqlCommand(query, DatabaseHelper.GetConnection()))
                        {
                            cmd.Parameters.AddWithValue("@name", txtName.Text);
                            cmd.Parameters.AddWithValue("@origin", txtOrigin.Text);
                            cmd.Parameters.AddWithValue("@website", txtWebsite.Text);

                            cmd.ExecuteNonQuery();
                        }
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

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите наименование производителя", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}