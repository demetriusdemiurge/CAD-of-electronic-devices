using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CAD_Electronics_App
{
    public partial class EditBoardForm : Form
    {
        private DataRow _row;
        private bool _isEditMode;

        public EditBoardForm(DataRow row = null)
        {
            InitializeComponent();
            _row = row;
            _isEditMode = row != null;
            InitializeForm();
        }

        private void InitializeForm()
        {
            Text = _isEditMode ? "Редактирование платы" : "Добавление платы";
            txtId.ReadOnly = _isEditMode;

            var engineers = DatabaseHelper.GetData(@"
        SELECT e.[Табельный_номер], e.ФИО 
        FROM Инженеры e
        WHERE e.Специализация IN (2, 4)
        ORDER BY (
            SELECT COUNT(*) 
            FROM Заказы z 
            WHERE z.Инженер = e.[Табельный_номер]
        )");

            cmbEngineer.DataSource = engineers;
            cmbEngineer.DisplayMember = "ФИО";
            cmbEngineer.ValueMember = "Табельный_номер";

            if (_isEditMode)
            {
                txtId.Text = _row["ID"].ToString();
                txtName.Text = _row["Наименование"].ToString();
                cmbEngineer.SelectedValue = _row["Инженер"];
                dtpDate.Value = Convert.ToDateTime(_row["Дата_создания"]);
                txtQuantity.Text = _row["Количество_слоев"].ToString();
                txtDimensions.Text = _row["Габариты"].ToString();
                txtVersion.Text = _row["Версия"].ToString();
                txtStatus.Text = _row["Статус"].ToString();
            }
            else
            {
                if (engineers.Rows.Count > 0)
                {
                    cmbEngineer.SelectedValue = engineers.Rows[0]["Табельный_номер"];
                }
                else
                {
                    MessageBox.Show("Нет доступных инженеров со специализацией 2 или 4", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                dtpDate.Value = DateTime.Now;
                txtQuantity.Text = "1";
                txtVersion.Text = "1.0";
                txtStatus.Text = "Черновик";
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
                        string query = @"UPDATE Печатные_платы SET 
                            Наименование = @name,
                            Инженер = @engineer,
                            [Дата_создания] = @date,
                            [Количество_слоев] = @quantity,
                            Габариты = @dimensions,
                            Версия = @version,
                            Статус = @status
                        WHERE ID = @id";

                        using (var cmd = new SqlCommand(query, DatabaseHelper.GetConnection()))
                        {
                            cmd.Parameters.AddWithValue("@name", txtName.Text);
                            cmd.Parameters.AddWithValue("@engineer", cmbEngineer.SelectedValue);
                            cmd.Parameters.AddWithValue("@date", dtpDate.Value);
                            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(txtQuantity.Text));
                            cmd.Parameters.AddWithValue("@dimensions", txtDimensions.Text);
                            cmd.Parameters.AddWithValue("@version", txtVersion.Text);
                            cmd.Parameters.AddWithValue("@status", txtStatus.Text);
                            cmd.Parameters.AddWithValue("@id", _row["ID"]);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string query = @"INSERT INTO Печатные_платы (
                            Наименование, Инженер, [Дата_создания], 
                            [Количество_слоев], Габариты, Версия, Статус
                        ) VALUES (
                            @name, @engineer, @date, 
                            @quantity, @dimensions, @version, @status
                        )";

                        using (var cmd = new SqlCommand(query, DatabaseHelper.GetConnection()))
                        {
                            cmd.Parameters.AddWithValue("@name", txtName.Text);
                            cmd.Parameters.AddWithValue("@engineer", cmbEngineer.SelectedValue);
                            cmd.Parameters.AddWithValue("@date", dtpDate.Value);
                            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(txtQuantity.Text));
                            cmd.Parameters.AddWithValue("@dimensions", txtDimensions.Text);
                            cmd.Parameters.AddWithValue("@version", txtVersion.Text);
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

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите наименование платы", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }


            if (cmbEngineer.SelectedValue == null || cmbEngineer.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите инженера из списка", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEngineer.Focus();
                return false;
            }


            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Введите корректное количество слоев (целое число больше 0)", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Focus();
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtDimensions.Text))
            {
                MessageBox.Show("Введите габариты платы", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDimensions.Focus();
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtVersion.Text))
            {
                MessageBox.Show("Введите версию платы", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVersion.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtStatus.Text))
            {
                MessageBox.Show("Введите статус платы", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStatus.Focus();
                return false;
            }

            if (dtpDate.Value > DateTime.Now)
            {
                MessageBox.Show("Дата создания не может быть в будущем", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDate.Focus();
                return false;
            }

            return true;
        }
    }
}