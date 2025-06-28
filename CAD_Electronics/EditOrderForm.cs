using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CAD_Electronics_App
{
    public partial class EditOrderForm : Form
    {
        private DataRow _row;
        private bool _isEditMode;

        public EditOrderForm(DataRow row = null)
        {
            InitializeComponent();
            _row = row;
            _isEditMode = row != null;
            InitializeForm();
        }

        private void InitializeForm()
        {
            Text = _isEditMode ? "Редактирование заказа" : "Добавление заказа";
            txtOrderNumber.ReadOnly = _isEditMode;

            var devices = DatabaseHelper.GetData("SELECT ID, Наименование FROM Устройства");
            cmbDevice.DataSource = devices;
            cmbDevice.DisplayMember = "Наименование";
            cmbDevice.ValueMember = "ID";

            var engineers = DatabaseHelper.GetData("SELECT [Табельный_номер], ФИО FROM Инженеры");
            cmbEngineer.DataSource = engineers;
            cmbEngineer.DisplayMember = "ФИО";
            cmbEngineer.ValueMember = "Табельный_номер";

            if (_isEditMode)
            {
                txtOrderNumber.Text = _row["Номер_заказа"].ToString();
                cmbDevice.SelectedValue = _row["Устройство"];
                cmbEngineer.SelectedValue = _row["Инженер"];
                txtDescription.Text = _row["Описание"].ToString();
                dtpPlanStart.Value = Convert.ToDateTime(_row["Плановый_срок_начала"]);
                dtpPlanEnd.Value = Convert.ToDateTime(_row["Плановый_срок_окончания"]);
                txtStatus.Text = _row["Статус"].ToString();
            }
            else
            {
                dtpPlanStart.Value = DateTime.Now;
                dtpPlanEnd.Value = DateTime.Now.AddDays(7);
                txtStatus.Text = "Новый";
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
                        string query = @"UPDATE Заказы SET 
                            Устройство = @device,
                            Инженер = @engineer,
                            Описание = @description,
                            [Плановый_срок_начала] = @planStart,
                            [Плановый_срок_окончания] = @planEnd,
                            Статус = @status
                        WHERE [Номер заказа] = @orderNumber";

                        using (var cmd = new SqlCommand(query, DatabaseHelper.GetConnection()))
                        {
                            cmd.Parameters.AddWithValue("@device", cmbDevice.SelectedValue);
                            cmd.Parameters.AddWithValue("@engineer", cmbEngineer.SelectedValue);
                            cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                            cmd.Parameters.AddWithValue("@planStart", dtpPlanStart.Value);
                            cmd.Parameters.AddWithValue("@planEnd", dtpPlanEnd.Value);
                            cmd.Parameters.AddWithValue("@status", txtStatus.Text);
                            cmd.Parameters.AddWithValue("@orderNumber", _row["Номер заказа"]);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string query = @"INSERT INTO Заказы (
                            Устройство, Инженер, Описание, 
                            [Плановый_срок_начала], [Плановый_срок_окончания], Статус
                        ) VALUES (
                            @device, @engineer, @description, 
                            @planStart, @planEnd, @status
                        )";

                        using (var cmd = new SqlCommand(query, DatabaseHelper.GetConnection()))
                        {
                            cmd.Parameters.AddWithValue("@device", cmbDevice.SelectedValue);
                            cmd.Parameters.AddWithValue("@engineer", cmbEngineer.SelectedValue);
                            cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                            cmd.Parameters.AddWithValue("@planStart", dtpPlanStart.Value);
                            cmd.Parameters.AddWithValue("@planEnd", dtpPlanEnd.Value);
                            cmd.Parameters.AddWithValue("@status", txtStatus.Text);

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
            if (cmbDevice.SelectedValue == null)
            {
                MessageBox.Show("Выберите устройство", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpPlanEnd.Value < dtpPlanStart.Value)
            {
                MessageBox.Show("Дата завершения не может быть раньше даты начала", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}