using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProductionAccounting
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ConfigureUiByRole();
            LoadBatches();
            LoadStatistics();
            this.FormClosing += MainForm_FormClosing;
        }

        private void ConfigureUiByRole()
        {
            string role = AppSession.CurrentUser.Role;
            lblUserInfo.Text = $"Пользователь: {AppSession.CurrentUser.FullName} ({role})";

            switch (role)
            {
                case "director":
                    btnCreateBatch.Enabled = false;
                    btnAcceptBatch.Enabled = false;
                    btnShipBatch.Enabled = false;
                    btnDeleteBatch.Enabled = false;
                    btnRegister.Visible = false;
                    break;
                case "accountant":
                    btnCreateBatch.Enabled = false;
                    btnAcceptBatch.Enabled = false;
                    btnShipBatch.Enabled = false;
                    btnDeleteBatch.Enabled = false;
                    btnRegister.Visible = false;
                    break;
                case "master":
                    btnCreateBatch.Enabled = true;
                    btnDeleteBatch.Enabled = true;
                    btnAcceptBatch.Enabled = false;
                    btnShipBatch.Enabled = false;
                    btnRegister.Visible = false;
                    break;
                case "storekeeper":
                    btnAcceptBatch.Enabled = true;
                    btnShipBatch.Enabled = true;
                    btnCreateBatch.Enabled = false;
                    btnDeleteBatch.Enabled = false;
                    btnRegister.Visible = false;
                    break;
                case "admin":
                    btnCreateBatch.Enabled = true;
                    btnAcceptBatch.Enabled = true;
                    btnShipBatch.Enabled = true;
                    btnDeleteBatch.Enabled = true;
                    btnRegister.Visible = true;
                    break;
            }
        }

        private void LoadBatches()
        {
            string query = @"SELECT batch_id, batch_number, product_name, quantity, unit, 
                                    production_date, shift, current_status, warehouse_cell
                             FROM v_batches_full
                             ORDER BY production_date DESC";

            DataTable dt = DatabaseConnection.ExecuteQuery(query);
            dgvBatches.DataSource = dt;

            if (dgvBatches.Columns.Contains("batch_id"))
                dgvBatches.Columns["batch_id"].Visible = false;
            if (dgvBatches.Columns.Contains("batch_number"))
                dgvBatches.Columns["batch_number"].HeaderText = "Номер партии";
            if (dgvBatches.Columns.Contains("product_name"))
                dgvBatches.Columns["product_name"].HeaderText = "Продукция";
            if (dgvBatches.Columns.Contains("quantity"))
                dgvBatches.Columns["quantity"].HeaderText = "Кол-во";
            if (dgvBatches.Columns.Contains("production_date"))
                dgvBatches.Columns["production_date"].HeaderText = "Дата выпуска";
            if (dgvBatches.Columns.Contains("shift"))
                dgvBatches.Columns["shift"].HeaderText = "Смена";
            if (dgvBatches.Columns.Contains("current_status"))
                dgvBatches.Columns["current_status"].HeaderText = "Статус";
            if (dgvBatches.Columns.Contains("warehouse_cell"))
                dgvBatches.Columns["warehouse_cell"].HeaderText = "Ячейка склада";
        }

        private void LoadStatistics()
        {
            string query = @"SELECT * FROM v_production_stats";
            DataTable dt = DatabaseConnection.ExecuteQuery(query);
            dgvStats.DataSource = dt;
        }

        private void BtnCreateBatch_Click(object sender, EventArgs e)
        {
            CreateBatchForm form = new CreateBatchForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadBatches();
                LoadStatistics();
            }
        }

        private void BtnAcceptBatch_Click(object sender, EventArgs e)
        {
            if (dgvBatches.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите партию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int batchId = Convert.ToInt32(dgvBatches.SelectedRows[0].Cells["batch_id"].Value);
            string currentStatus = dgvBatches.SelectedRows[0].Cells["current_status"].Value.ToString();

            if (currentStatus != "произведена")
            {
                MessageBox.Show("Принять можно только партию в статусе 'произведена'", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AcceptBatchForm form = new AcceptBatchForm(batchId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadBatches();
                LoadStatistics();
            }
        }

        private void BtnShipBatch_Click(object sender, EventArgs e)
        {
            if (dgvBatches.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите партию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int batchId = Convert.ToInt32(dgvBatches.SelectedRows[0].Cells["batch_id"].Value);
            string currentStatus = dgvBatches.SelectedRows[0].Cells["current_status"].Value.ToString();

            if (currentStatus != "на складе" && currentStatus != "принята")
            {
                MessageBox.Show("Отгрузить можно только партию, которая находится на складе", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Отгрузить партию?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_ship_batch", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@p_batch_id", batchId);
                    cmd.Parameters.AddWithValue("@p_shipped_by_user_id", AppSession.CurrentUser.UserId);
                    cmd.Parameters.AddWithValue("@p_comment", "Отгрузка клиенту");

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Партия отгружена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBatches();
                        LoadStatistics();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnDeleteBatch_Click(object sender, EventArgs e)
        {
            if (dgvBatches.SelectedRows.Count == 0) return;

            int batchId = Convert.ToInt32(dgvBatches.SelectedRows[0].Cells["batch_id"].Value);
            string status = dgvBatches.SelectedRows[0].Cells["current_status"].Value.ToString();
            string batchNumber = dgvBatches.SelectedRows[0].Cells["batch_number"].Value.ToString();

            if (status != "произведена")
            {
                MessageBox.Show("Нельзя удалить партию, которая уже принята или отгружена", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Удалить партию {batchNumber}?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM batches WHERE batch_id = @batch_id";
                int rows = DatabaseConnection.ExecuteNonQuery(query, new MySqlParameter("@batch_id", batchId));

                if (rows > 0)
                {
                    MessageBox.Show("Партия удалена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBatches();
                    LoadStatistics();
                }
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm form = new RegisterForm();
            form.ShowDialog();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadBatches();
            LoadStatistics();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            AppSession.Logout();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                AppSession.Logout();
        }
    }
}