namespace Auto_SMS
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.dataSet = new System.Windows.Forms.DataGridView();
            this.btnAddSet = new System.Windows.Forms.Button();
            this.btnEditSet = new System.Windows.Forms.Button();
            this.btnDeleteSet = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSet
            // 
            this.dataSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSet.Location = new System.Drawing.Point(12, 12);
            this.dataSet.Name = "dataSet";
            this.dataSet.Size = new System.Drawing.Size(255, 385);
            this.dataSet.TabIndex = 0;
            // 
            // btnAddSet
            // 
            this.btnAddSet.Location = new System.Drawing.Point(273, 12);
            this.btnAddSet.Name = "btnAddSet";
            this.btnAddSet.Size = new System.Drawing.Size(60, 30);
            this.btnAddSet.TabIndex = 1;
            this.btnAddSet.Text = "Thêm";
            this.btnAddSet.UseVisualStyleBackColor = true;
            this.btnAddSet.Click += new System.EventHandler(this.btnAddSet_Click);
            // 
            // btnEditSet
            // 
            this.btnEditSet.Location = new System.Drawing.Point(273, 48);
            this.btnEditSet.Name = "btnEditSet";
            this.btnEditSet.Size = new System.Drawing.Size(60, 30);
            this.btnEditSet.TabIndex = 2;
            this.btnEditSet.Text = "Sửa";
            this.btnEditSet.UseVisualStyleBackColor = true;
            this.btnEditSet.Click += new System.EventHandler(this.btnEditSet_Click);
            // 
            // btnDeleteSet
            // 
            this.btnDeleteSet.Location = new System.Drawing.Point(273, 84);
            this.btnDeleteSet.Name = "btnDeleteSet";
            this.btnDeleteSet.Size = new System.Drawing.Size(60, 30);
            this.btnDeleteSet.TabIndex = 3;
            this.btnDeleteSet.Text = "Xóa";
            this.btnDeleteSet.UseVisualStyleBackColor = true;
            this.btnDeleteSet.Click += new System.EventHandler(this.btnDeleteSet_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(273, 367);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(60, 30);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 409);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDeleteSet);
            this.Controls.Add(this.btnEditSet);
            this.Controls.Add(this.btnAddSet);
            this.Controls.Add(this.dataSet);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingForm";
            this.Text = "SettingForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataSet;
        private System.Windows.Forms.Button btnAddSet;
        private System.Windows.Forms.Button btnEditSet;
        private System.Windows.Forms.Button btnDeleteSet;
        private System.Windows.Forms.Button btnClose;
    }
}