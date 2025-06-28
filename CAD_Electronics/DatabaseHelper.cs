using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CAD_Electronics_App
{
    public static class DatabaseHelper
    {
        private static readonly string connectionString = "Data Source=LAPTOP-H80F4HPF\\SQLEXPRESS;Initial Catalog=САПР электронных устройств;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            var connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public static DataTable GetData(string query)
        {
            var dt = new DataTable();
            try
            {
                using (var connection = GetConnection())
                using (var command = new SqlCommand(query, connection))
                {
                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        public static int ExecuteQuery(string query)
        {
            try
            {
                using (var connection = GetConnection())
                using (var command = new SqlCommand(query, connection))
                {
                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка выполнения запроса: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
    }
}