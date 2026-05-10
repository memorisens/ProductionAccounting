namespace ProductionAccounting
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvBatches;
        private System.Windows.Forms.DataGridView dgvStats;
        private System.Windows.Forms.Button btnCreateBatch;
        private System.Windows.Forms.Button btnAcceptBatch;
        private System.Windows.Forms.Button btnShipBatch;
        private System.Windows.Forms.Button btnDeleteBatch;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabBatches;
        private System.Windows.Forms.TabPage tabStats;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvBatches = new System.Windows.Forms.DataGridView();
            this.dgvStats = new System.Windows.Forms.DataGridView();
            this.btnCreateBatch = new System.Windows.Forms.Button();
            this.btnAcceptBatch = new System.Windows.Forms.Button();
            this.btnShipBatch = new System.Windows.Forms.Button();
            this.btnDeleteBatch = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabBatches = new System.Windows.Forms.TabPage();
            this.tabStats = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStats)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabBatches.SuspendLayout();
            this.tabStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Location = new System.Drawing.Point(12, 12);
            this.lblUserInfo.Size = new System.Drawing.Size(400, 23);
            this.lblUserInfo.Text = "Пользователь: ";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.LightCoral;
            this.btnLogout.Location = new System.Drawing.Point(900, 10);
            this.btnLogout.Size = new System.Drawing.Size(80, 25);
            this.btnLogout.Text = "Выход";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(810, 10);
            this.btnRefresh.Size = new System.Drawing.Size(80, 25);
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // btnCreateBatch
            // 
            this.btnCreateBatch.BackColor = System.Drawing.Color.LightGreen;
            this.btnCreateBatch.Location = new System.Drawing.Point(12, 45);
            this.btnCreateBatch.Size = new System.Drawing.Size(120, 30);
            this.btnCreateBatch.Text = "Создать партию";
            this.btnCreateBatch.UseVisualStyleBackColor = false;
            this.btnCreateBatch.Click += new System.EventHandler(this.BtnCreateBatch_Click);
            // 
            // btnAcceptBatch
            // 
            this.btnAcceptBatch.BackColor = System.Drawing.Color.LightBlue;
            this.btnAcceptBatch.Location = new System.Drawing.Point(140, 45);
            this.btnAcceptBatch.Size = new System.Drawing.Size(120, 30);
            this.btnAcceptBatch.Text = "Принять на склад";
            this.btnAcceptBatch.UseVisualStyleBackColor = false;
            this.btnAcceptBatch.Click += new System.EventHandler(this.BtnAcceptBatch_Click);
            // 
            // btnShipBatch
            // 
            this.btnShipBatch.BackColor = System.Drawing.Color.LightYellow;
            this.btnShipBatch.Location = new System.Drawing.Point(270, 45);
            this.btnShipBatch.Size = new System.Drawing.Size(120, 30);
            this.btnShipBatch.Text = "Отгрузить";
            this.btnShipBatch.UseVisualStyleBackColor = false;
            this.btnShipBatch.Click += new System.EventHandler(this.BtnShipBatch_Click);
            // 
            // btnDeleteBatch
            // 
            this.btnDeleteBatch.BackColor = System.Drawing.Color.LightCoral;
            this.btnDeleteBatch.Location = new System.Drawing.Point(400, 45);
            this.btnDeleteBatch.Size = new System.Drawing.Size(120, 30);
            this.btnDeleteBatch.Text = "Удалить партию";
            this.btnDeleteBatch.UseVisualStyleBackColor = false;
            this.btnDeleteBatch.Click += new System.EventHandler(this.BtnDeleteBatch_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(530, 45);
            this.btnRegister.Size = new System.Drawing.Size(120, 30);
            this.btnRegister.Text = "Регистрация";
            this.btnRegister.Visible = false;
            this.btnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabBatches);
            this.tabControl.Controls.Add(this.tabStats);
            this.tabControl.Location = new System.Drawing.Point(12, 85);
            this.tabControl.Size = new System.Drawing.Size(980, 560);
            this.tabControl.TabIndex = 0;
            // 
            // tabBatches
            // 
            this.tabBatches.Controls.Add(this.dgvBatches);
            this.tabBatches.Text = "Список партий";
            // 
            // dgvBatches
            // 
            this.dgvBatches.AllowUserToAddRows = false;
            this.dgvBatches.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBatches.Location = new System.Drawing.Point(0, 0);
            this.dgvBatches.ReadOnly = true;
            this.dgvBatches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBatches.Size = new System.Drawing.Size(972, 531);
            this.dgvBatches.TabIndex = 0;
            // 
            // tabStats
            // 
            this.tabStats.Controls.Add(this.dgvStats);
            this.tabStats.Text = "Статистика выпуска";
            // 
            // dgvStats
            // 
            this.dgvStats.AllowUserToAddRows = false;
            this.dgvStats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStats.Location = new System.Drawing.Point(0, 0);
            this.dgvStats.ReadOnly = true;
            this.dgvStats.Size = new System.Drawing.Size(972, 531);
            this.dgvStats.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 661);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnDeleteBatch);
            this.Controls.Add(this.btnShipBatch);
            this.Controls.Add(this.btnAcceptBatch);
            this.Controls.Add(this.btnCreateBatch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblUserInfo);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Учёт выпуска готовой продукции";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStats)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabBatches.ResumeLayout(false);
            this.tabStats.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}