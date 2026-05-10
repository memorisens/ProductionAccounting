namespace ProductionAccounting
{
    partial class CreateBatchForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtBatchNumber;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.ComboBox cmbShift;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblBatchNumber;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblShift;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtBatchNumber = new System.Windows.Forms.TextBox();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblBatchNumber = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblShift = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBatchNumber
            // 
            this.lblBatchNumber.Location = new System.Drawing.Point(20, 20);
            this.lblBatchNumber.Size = new System.Drawing.Size(100, 23);
            this.lblBatchNumber.Text = "Номер партии:";
            // 
            // txtBatchNumber
            // 
            this.txtBatchNumber.Location = new System.Drawing.Point(130, 20);
            this.txtBatchNumber.Size = new System.Drawing.Size(200, 20);
            // 
            // lblProduct
            // 
            this.lblProduct.Location = new System.Drawing.Point(20, 60);
            this.lblProduct.Size = new System.Drawing.Size(100, 23);
            this.lblProduct.Text = "Продукция:";
            // 
            // cmbProduct
            // 
            this.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduct.Location = new System.Drawing.Point(130, 60);
            this.cmbProduct.Size = new System.Drawing.Size(200, 21);
            // 
            // lblQuantity
            // 
            this.lblQuantity.Location = new System.Drawing.Point(20, 100);
            this.lblQuantity.Size = new System.Drawing.Size(100, 23);
            this.lblQuantity.Text = "Количество:";
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(130, 100);
            this.numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQuantity.Size = new System.Drawing.Size(100, 20);
            this.numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblShift
            // 
            this.lblShift.Location = new System.Drawing.Point(20, 140);
            this.lblShift.Size = new System.Drawing.Size(100, 23);
            this.lblShift.Text = "Смена:";
            // 
            // cmbShift
            // 
            this.cmbShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShift.Items.AddRange(new object[] { "утренняя", "вечерняя" });
            this.cmbShift.Location = new System.Drawing.Point(130, 140);
            this.cmbShift.Size = new System.Drawing.Size(100, 21);
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.LightGreen;
            this.btnCreate.Location = new System.Drawing.Point(80, 190);
            this.btnCreate.Size = new System.Drawing.Size(100, 35);
            this.btnCreate.Text = "Создать";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(200, 190);
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // CreateBatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 250);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.cmbShift);
            this.Controls.Add(this.lblShift);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.cmbProduct);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.txtBatchNumber);
            this.Controls.Add(this.lblBatchNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CreateBatchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Создание новой партии";
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}