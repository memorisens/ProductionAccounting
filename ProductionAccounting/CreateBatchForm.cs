using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProductionAccounting
{
    public partial class CreateBatchForm : Form
    {
        public CreateBatchForm()
        {
            InitializeComponent();
            LoadProducts();
            cmbShift.SelectedIndex = 0;
        }

        private void LoadProducts()
        {
            string query = "SELECT product_id, article, name FROM products ORDER BY name";
            DataTable dt = DatabaseConnection.ExecuteQuery(query);
            cmbProduct.DisplayMember = "name";
            cmbProduct.ValueMember = "product_id";
            cmbProduct.DataSource = dt;
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            string batchNumber = txtBatchNumber.Text.Trim();
            if (string.IsNullOrEmpty(batchNumber))
            {
                MessageBox.Show("Введите номер партии", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productId = (int)cmbProduct.SelectedValue;
            decimal quantity = numQuantity.Value;
            string shift = cmbShift.SelectedItem.ToString();

            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("sp_register_batch", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@p_batch_number", batchNumber);
                cmd.Parameters.AddWithValue("@p_product_id", productId);
                cmd.Parameters.AddWithValue("@p_quantity", quantity);
                cmd.Parameters.AddWithValue("@p_shift", shift);
                cmd.Parameters.AddWithValue("@p_created_by_user_id", AppSession.CurrentUser.UserId);

                MySqlParameter outParam = new MySqlParameter("@p_batch_id", MySqlDbType.Int32);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Партия {batchNumber} успешно создана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}