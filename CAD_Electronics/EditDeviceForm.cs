using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CAD_Electronics_App
{
    public partial class EditDeviceForm : Form
    {
        private DataRow _row;
        private bool _isEditMode;

        public EditDeviceForm(DataRow row = null)
        {
            InitializeComponent();
            _row = row;
            _isEditMode = row != null;
            InitializeForm();
        }

        private void InitializeForm()
        {
            Text = _isEditMode ? "Редактирование устройства" : "Добавление устройства";
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
                txtType.Text = _row["Тип"].ToString();
                txtVersion.Text = _row["Версия"].ToString();
                txtStatus.Text = _row["Статус"].ToString();
                txtDescription.Text = _row["Описание"].ToString();
            }
            else
            {
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
                        string query = @"UPDATE Устройства SET 
                            Наименование = @name,
                            Инженер = @engineer,
                            Тип = @type,
                            Версия = @version,
                            Статус = @status,
                            Описание = @description
                        WHERE ID = @id";

                        using (var cmd = new SqlCommand(query, DatabaseHelper.GetConnection()))
                        {
                            cmd.Parameters.AddWithValue("@name", txtName.Text);
                            cmd.Parameters.AddWithValue("@engineer", cmbEngineer.SelectedValue);
                            cmd.Parameters.AddWithValue("@type", txtType.Text);
                            cmd.Parameters.AddWithValue("@version", txtVersion.Text);
                            cmd.Parameters.AddWithValue("@status", txtStatus.Text);
                            cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                            cmd.Parameters.AddWithValue("@id", _row["ID"]);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string query = @"INSERT INTO Устройства (
                            Наименование, Инженер, Тип, Версия, Статус, Описание
                        ) VALUES (
                            @name, @engineer, @type, @version, @status, @description
                        )";

                        using (var cmd = new SqlCommand(query, DatabaseHelper.GetConnection()))
                        {
                            cmd.Parameters.AddWithValue("@name", txtName.Text);
                            cmd.Parameters.AddWithValue("@engineer", cmbEngineer.SelectedValue);
                            cmd.Parameters.AddWithValue("@type", txtType.Text);
                            cmd.Parameters.AddWithValue("@version", txtVersion.Text);
                            cmd.Parameters.AddWithValue("@status", txtStatus.Text);
                            cmd.Parameters.AddWithValue("@description", txtDescription.Text);

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
                MessageBox.Show("Введите наименование устройства", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}