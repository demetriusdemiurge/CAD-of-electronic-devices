using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CAD_Electronics_App
{
    public partial class EditSchemeForm : Form
    {
        private DataRow _row;
        private bool _isEditMode;

        public EditSchemeForm(DataRow row = null)
        {
            InitializeComponent();
            _row = row;
            _isEditMode = row != null;
            InitializeForm();
        }

        private void InitializeForm()
        {
            Text = _isEditMode ? "Редактирование схемы" : "Добавление схемы";

            txtId.ReadOnly = _isEditMode;

            var engineers = DatabaseHelper.GetData("SELECT [Табельный_номер], ФИО FROM Инженеры");
            cmbEngineer.DataSource = engineers;
            cmbEngineer.DisplayMember = "ФИО";
            cmbEngineer.ValueMember = "Табельный_номер";

            if (_isEditMode)
            {
                txtId.Text = _row["ID"].ToString();
                txtName.Text = _row["Наименование"].ToString();
                cmbEngineer.SelectedValue = _row["Инженер"];
                dtpDate.Value = Convert.ToDateTime(_row["Дата_создания"]);
                txtStatus.Text = _row["Статус"].ToString();
                txtVersion.Text = _row["Версия"].ToString();
            }
            else
            {
                dtpDate.Value = DateTime.Now;
                txtStatus.Text = "Черновик";
                txtVersion.Text = "1.0";
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
                        string query = @"UPDATE Схемы SET 
                            Наименование = @name,
                            Инженер = @engineer,
                            [Дата_создания] = @date,
                            Статус = @status,
                            Версия = @version
                        WHERE ID = @id";

                        using (var cmd = new SqlCommand(query, DatabaseHelper.GetConnection()))
                        {
                            cmd.Parameters.AddWithValue("@name", txtName.Text);
                            cmd.Parameters.AddWithValue("@engineer", cmbEngineer.SelectedValue);
                            cmd.Parameters.AddWithValue("@date", dtpDate.Value);
                            cmd.Parameters.AddWithValue("@status", txtStatus.Text);
                            cmd.Parameters.AddWithValue("@version", txtVersion.Text);
                            cmd.Parameters.AddWithValue("@id", _row["ID"]);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string query = @"INSERT INTO Схемы (
                            Наименование, Инженер, [Дата_создания], Статус, Версия
                        ) VALUES (
                            @name, @engineer, @date, @status, @version
                        )";

                        using (var cmd = new SqlCommand(query, DatabaseHelper.GetConnection()))
                        {
                            cmd.Parameters.AddWithValue("@name", txtName.Text);
                            cmd.Parameters.AddWithValue("@engineer", cmbEngineer.SelectedValue);
                            cmd.Parameters.AddWithValue("@date", dtpDate.Value);
                            cmd.Parameters.AddWithValue("@status", txtStatus.Text);
                            cmd.Parameters.AddWithValue("@version", txtVersion.Text);

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
                MessageBox.Show("Введите наименование схемы", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbEngineer.SelectedValue == null)
            {
                MessageBox.Show("Выберите инженера", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}