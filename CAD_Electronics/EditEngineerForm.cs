using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CAD_Electronics_App
{
    public partial class EditEngineerForm : Form
    {
        private DataRow _row;
        private bool _isEditMode;

        public EditEngineerForm(DataRow row = null)
        {
            InitializeComponent();
            _row = row;
            _isEditMode = row != null;
            InitializeForm();
        }

        private void InitializeForm()
        {
            Text = _isEditMode ? "Редактирование инженера" : "Добавление инженера";
            txtId.ReadOnly = _isEditMode;

            var specializations = DatabaseHelper.GetData("SELECT Код, Название FROM Специализации");
            cmbSpecialization.DataSource = specializations;
            cmbSpecialization.DisplayMember = "Название";
            cmbSpecialization.ValueMember = "Код";

            if (_isEditMode)
            {
                txtId.Text = _row["Табельный_номер"].ToString();
                txtName.Text = _row["ФИО"].ToString();
                txtPhone.Text = _row["Телефон"].ToString();
                cmbSpecialization.SelectedValue = _row["Специализация"];
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    string phone = txtPhone.Text;

                    if (_isEditMode)
                    {
                        UpdateEngineer(phone);
                    }
                    else
                    {
                        AddEngineer(phone);
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

        private void UpdateEngineer(string phone)
        {
            string query = @"UPDATE Инженеры SET 
                ФИО = @name,
                Телефон = @phone,
                Специализация = @specialization
            WHERE [Табельный_номер] = @id";

            using (var cmd = new SqlCommand(query, DatabaseHelper.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@specialization", cmbSpecialization.SelectedValue);
                cmd.Parameters.AddWithValue("@id", _row["Табельный_номер"]);

                cmd.ExecuteNonQuery();
            }
        }

        private void AddEngineer(string phone)
        {
            string query = @"INSERT INTO Инженеры (
                ФИО, Телефон, Специализация
            ) VALUES (
                @name, @phone, @specialization
            )";

            using (var cmd = new SqlCommand(query, DatabaseHelper.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@specialization", cmbSpecialization.SelectedValue);

                cmd.ExecuteNonQuery();
            }
        }

        private bool ValidateInput()
        {

            if (string.IsNullOrWhiteSpace(txtName.Text) || txtName.Text == "ФИО")
            {
                MessageBox.Show("Введите ФИО инженера", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }


            string phone = txtPhone.Text;
            if (!IsValidPhoneNumber(phone))
            {
                MessageBox.Show("Введите корректный номер телефона (11 цифр)\nФорматы: +7XXXXXXXXXX или 8XXXXXXXXXX",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;
            return Regex.IsMatch(phone, @"^(\+7|8)\d{10}$");
        }

        private void EngineerForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                txtName.Text = "ФИО";
                txtName.ForeColor = Color.Gray;
            }

            if (string.IsNullOrEmpty(txtId.Text))
            {
                txtId.Text = "Табельный номер";
                txtId.ForeColor = Color.Gray;
            }

            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                txtPhone.Text = "Телефон";
                txtPhone.ForeColor = Color.Gray;
            }
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            if (txtName.Text == "ФИО")
            {
                txtName.Text = "";
                txtName.ForeColor = Color.Black;
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                txtName.Text = "ФИО";
                txtName.ForeColor = Color.Gray;
            }
        }

        private void txtId_Enter(object sender, EventArgs e)
        {
            if (txtId.Text == "Табельный номер")
            {
                txtId.Text = "";
                txtId.ForeColor = Color.Black;
            }
        }

        private void txtId_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                txtId.Text = "Табельный номер";
                txtId.ForeColor = Color.Gray;
            }
        }

        private void txtPhone_Enter(object sender, EventArgs e)
        {
            if (txtPhone.Text == "Телефон")
            {
                txtPhone.Text = "";
                txtPhone.ForeColor = Color.Black;
            }
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                txtPhone.Text = "Телефон";
                txtPhone.ForeColor = Color.Gray;
            }
        }
    }
}