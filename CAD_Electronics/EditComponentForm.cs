using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CAD_Electronics_App
{
    public partial class EditComponentForm : Form
    {
        private DataRow _row;
        private bool _isEditMode;
        private ComboBox cmbManufacturer;

        public EditComponentForm(DataRow row = null)
        {
            InitializeComponent();
            _row = row;
            _isEditMode = row != null;
            InitializeForm();
        }

        private void InitializeForm()
        {

            cmbManufacturer = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = txtManufacturer.Location,
                Size = txtManufacturer.Size
            };
            this.Controls.Add(cmbManufacturer);
            this.Controls.Remove(txtManufacturer);


            LoadManufacturers();

            Text = _isEditMode ? "Редактирование компонента" : "Добавление компонента";
            txtArticle.ReadOnly = _isEditMode;

            if (_isEditMode)
            {
                txtArticle.Text = _row["Артикул"].ToString();

                if (_row["Производитель"] != DBNull.Value)
                {
                    cmbManufacturer.SelectedValue = _row["Производитель"];
                }

                txtName.Text = _row["Наименование"].ToString();
                txtDescription.Text = _row["Описание"].ToString();
                txtType.Text = _row["Тип"].ToString();
                txtElectrical.Text = _row["Электрические_характеристики"].ToString();
                txtPackage.Text = _row["Тип_корпуса"].ToString();
            }
        }

        private void LoadManufacturers()
        {
            try
            {
                var manufacturers = DatabaseHelper.GetData("SELECT [ID], [Наименование] FROM Производители");
                cmbManufacturer.DataSource = manufacturers;
                cmbManufacturer.DisplayMember = "Наименование";
                cmbManufacturer.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки производителей: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        string query = $@"UPDATE Компоненты SET 
                            Производитель = @manufacturerId,
                            Наименование = @name,
                            Описание = @description,
                            Тип = @type,
                            [Электрические_характеристики] = @electrical,
                            [Тип_корпуса] = @package
                        WHERE Артикул = @article";

                        using (var cmd = new SqlCommand(query, DatabaseHelper.GetConnection()))
                        {
                            cmd.Parameters.AddWithValue("@manufacturerId", cmbManufacturer.SelectedValue);
                            cmd.Parameters.AddWithValue("@name", txtName.Text);
                            cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                            cmd.Parameters.AddWithValue("@type", txtType.Text);
                            cmd.Parameters.AddWithValue("@electrical", txtElectrical.Text);
                            cmd.Parameters.AddWithValue("@package", txtPackage.Text);
                            cmd.Parameters.AddWithValue("@article", _row["Артикул"]);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string query = $@"INSERT INTO Компоненты (
                            Производитель, Наименование, 
                            Описание, Тип, [Электрические_характеристики], [Тип_корпуса]
                        ) VALUES (
                            @manufacturerId, @name,
                            @description, @type, @electrical, @package
                        )";

                        using (var cmd = new SqlCommand(query, DatabaseHelper.GetConnection()))
                        {
                            cmd.Parameters.AddWithValue("@manufacturerId", cmbManufacturer.SelectedValue);
                            cmd.Parameters.AddWithValue("@name", txtName.Text);
                            cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                            cmd.Parameters.AddWithValue("@type", txtType.Text);
                            cmd.Parameters.AddWithValue("@electrical", txtElectrical.Text);
                            cmd.Parameters.AddWithValue("@package", txtPackage.Text);

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
            if (_isEditMode)
            {
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите наименование компонента", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtType.Text))
            {
                MessageBox.Show("Введите тип компонента", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}