using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProductionAccounting
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            LoadRoles();
        }

        private void LoadRoles()
        {
            string query = "SELECT role_name FROM roles";
            DataTable dt = DatabaseConnection.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                cmbRole.Items.Add(row["role_name"].ToString());
            }
            if (cmbRole.Items.Count > 0)
                cmbRole.SelectedIndex = 0;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Выберите роль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var (salt, hash) = PasswordHelper.CreateHashedPassword(password);
            string roleName = cmbRole.SelectedItem.ToString();

            string getRoleIdQuery = "SELECT role_id FROM roles WHERE role_name = @role_name";
            DataTable dt = DatabaseConnection.ExecuteQuery(getRoleIdQuery, new MySqlParameter("@role_name", roleName));

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Роль не найдена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int roleId = Convert.ToInt32(dt.Rows[0]["role_id"]);

            string insertQuery = @"INSERT INTO users (login, full_name, password_salt, password_hash, role_id, is_active, created_at)
                                   VALUES (@login, @full_name, @salt, @hash, @role_id, 1, NOW())";

            int rowsAffected = DatabaseConnection.ExecuteNonQuery(insertQuery,
                new MySqlParameter("@login", login),
                new MySqlParameter("@full_name", fullName),
                new MySqlParameter("@salt", salt),
                new MySqlParameter("@hash", hash),
                new MySqlParameter("@role_id", roleId));

            if (rowsAffected > 0)
            {
                MessageBox.Show("Пользователь успешно зарегистрирован", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}