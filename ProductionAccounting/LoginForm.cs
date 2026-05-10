using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProductionAccounting
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"SELECT u.user_id, u.full_name, u.password_salt, u.password_hash, r.role_name
                             FROM users u
                             JOIN roles r ON u.role_id = r.role_id
                             WHERE u.login = @login AND u.is_active = 1";

            DataTable dt = DatabaseConnection.ExecuteQuery(query,
                new MySqlParameter("@login", login));

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRow row = dt.Rows[0];
            string salt = row["password_salt"].ToString();
            string storedHash = row["password_hash"].ToString();

            if (PasswordHelper.VerifyPassword(password, salt, storedHash))
            {
                AppSession.CurrentUser = new UserSession
                {
                    UserId = Convert.ToInt32(row["user_id"]),
                    FullName = row["full_name"].ToString(),
                    Login = login,
                    Role = row["role_name"].ToString()
                };

                MessageBox.Show($"Добро пожаловать, {AppSession.CurrentUser.FullName}!",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }
    }
}