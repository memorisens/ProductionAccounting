using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProductionAccounting
{
    public partial class AcceptBatchForm : Form
    {
        private int _batchId;

        public AcceptBatchForm(int batchId)
        {
            InitializeComponent();
            _batchId = batchId;
            txtReceiptNumber.Text = $"ПРО-{DateTime.Now:yyyyMMdd}-{batchId:D3}";
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            string receiptNumber = txtReceiptNumber.Text.Trim();
            string warehouseCell = txtWarehouseCell.Text.Trim();

            if (string.IsNullOrEmpty(warehouseCell))
            {
                MessageBox.Show("Укажите ячейку склада", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("sp_accept_batch", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@p_batch_id", _batchId);
                cmd.Parameters.AddWithValue("@p_receipt_number", receiptNumber);
                cmd.Parameters.AddWithValue("@p_warehouse_cell", warehouseCell);
                cmd.Parameters.AddWithValue("@p_received_by_user_id", AppSession.CurrentUser.UserId);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Партия принята на склад", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
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