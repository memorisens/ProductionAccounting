namespace ProductionAccounting
{
    partial class AcceptBatchForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtReceiptNumber;
        private System.Windows.Forms.TextBox txtWarehouseCell;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblReceiptNumber;
        private System.Windows.Forms.Label lblWarehouseCell;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtReceiptNumber = new System.Windows.Forms.TextBox();
            this.txtWarehouseCell = new System.Windows.Forms.TextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblReceiptNumber = new System.Windows.Forms.Label();
            this.lblWarehouseCell = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblReceiptNumber
            // 
            this.lblReceiptNumber.Location = new System.Drawing.Point(20, 20);
            this.lblReceiptNumber.Size = new System.Drawing.Size(100, 23);
            this.lblReceiptNumber.Text = "Номер ордера:";
            // 
            // txtReceiptNumber
            // 
            this.txtReceiptNumber.Location = new System.Drawing.Point(130, 20);
            this.txtReceiptNumber.Size = new System.Drawing.Size(200, 20);
            // 
            // lblWarehouseCell
            // 
            this.lblWarehouseCell.Location = new System.Drawing.Point(20, 60);
            this.lblWarehouseCell.Size = new System.Drawing.Size(100, 23);
            this.lblWarehouseCell.Text = "Ячейка склада:";
            // 
            // txtWarehouseCell
            // 
            this.txtWarehouseCell.Location = new System.Drawing.Point(130, 60);
            this.txtWarehouseCell.Size = new System.Drawing.Size(200, 20);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.LightBlue;
            this.btnAccept.Location = new System.Drawing.Point(80, 110);
            this.btnAccept.Size = new System.Drawing.Size(100, 35);
            this.btnAccept.Text = "Принять";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(200, 110);
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // AcceptBatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 170);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtWarehouseCell);
            this.Controls.Add(this.lblWarehouseCell);
            this.Controls.Add(this.txtReceiptNumber);
            this.Controls.Add(this.lblReceiptNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AcceptBatchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Приёмка партии на склад";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}