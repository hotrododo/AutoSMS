namespace Auto_SMS
{
    partial class MainScreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dataList = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeSubmit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isDone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timePerJob = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.realTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hasDelay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxMessType = new System.Windows.Forms.TextBox();
            this.tbxBrandname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxIpAddr = new System.Windows.Forms.TextBox();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.tbxUser = new System.Windows.Forms.TextBox();
            this.tbxResultHasGone = new System.Windows.Forms.RichTextBox();
            this.tbxNoResult = new System.Windows.Forms.RichTextBox();
            this.cbxHasGone = new System.Windows.Forms.CheckBox();
            this.cbxNoResult = new System.Windows.Forms.CheckBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataList)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataList
            // 
            this.dataList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.name,
            this.phone,
            this.Email,
            this.timeSubmit,
            this.returnDate,
            this.isDone,
            this.timePerJob,
            this.realTime,
            this.hasDelay,
            this.state});
            this.tableLayoutPanel1.SetColumnSpan(this.dataList, 2);
            resources.ApplyResources(this.dataList, "dataList");
            this.dataList.Name = "dataList";
            this.dataList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.tableLayoutPanel1.SetRowSpan(this.dataList, 3);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            resources.ApplyResources(this.ID, "ID");
            this.ID.Name = "ID";
            // 
            // name
            // 
            this.name.DataPropertyName = "Tên người nộp";
            resources.ApplyResources(this.name, "name");
            this.name.Name = "name";
            // 
            // phone
            // 
            this.phone.DataPropertyName = "Số điện thoại";
            resources.ApplyResources(this.phone, "phone");
            this.phone.Name = "phone";
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            resources.ApplyResources(this.Email, "Email");
            this.Email.Name = "Email";
            // 
            // timeSubmit
            // 
            this.timeSubmit.DataPropertyName = "Ngày nộp";
            resources.ApplyResources(this.timeSubmit, "timeSubmit");
            this.timeSubmit.Name = "timeSubmit";
            // 
            // returnDate
            // 
            this.returnDate.DataPropertyName = "Ngày trả";
            resources.ApplyResources(this.returnDate, "returnDate");
            this.returnDate.Name = "returnDate";
            // 
            // isDone
            // 
            this.isDone.DataPropertyName = "Hoàn thành";
            resources.ApplyResources(this.isDone, "isDone");
            this.isDone.Name = "isDone";
            // 
            // timePerJob
            // 
            this.timePerJob.DataPropertyName = "Thời gian Khung/lĩnh vực";
            resources.ApplyResources(this.timePerJob, "timePerJob");
            this.timePerJob.Name = "timePerJob";
            this.timePerJob.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.timePerJob.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // realTime
            // 
            this.realTime.DataPropertyName = "Thời gian thực";
            resources.ApplyResources(this.realTime, "realTime");
            this.realTime.Name = "realTime";
            // 
            // hasDelay
            // 
            this.hasDelay.DataPropertyName = "Đúng/trễ";
            resources.ApplyResources(this.hasDelay, "hasDelay");
            this.hasDelay.Name = "hasDelay";
            // 
            // state
            // 
            this.state.DataPropertyName = "Trạng thái";
            resources.ApplyResources(this.state, "state");
            this.state.Name = "state";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Controls.Add(this.btnAdd);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            this.tableLayoutPanel1.SetRowSpan(this.panel2, 2);
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnEdit
            // 
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.tbxMessType);
            this.panel3.Controls.Add(this.tbxBrandname);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.tbxIpAddr);
            this.panel3.Controls.Add(this.tbxPassword);
            this.panel3.Controls.Add(this.tbxUser);
            this.panel3.Controls.Add(this.tbxResultHasGone);
            this.panel3.Controls.Add(this.tbxNoResult);
            this.panel3.Controls.Add(this.cbxHasGone);
            this.panel3.Controls.Add(this.cbxNoResult);
            this.panel3.Controls.Add(this.btnCheck);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // tbxMessType
            // 
            resources.ApplyResources(this.tbxMessType, "tbxMessType");
            this.tbxMessType.Name = "tbxMessType";
            // 
            // tbxBrandname
            // 
            resources.ApplyResources(this.tbxBrandname, "tbxBrandname");
            this.tbxBrandname.Name = "tbxBrandname";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tbxIpAddr
            // 
            resources.ApplyResources(this.tbxIpAddr, "tbxIpAddr");
            this.tbxIpAddr.Name = "tbxIpAddr";
            // 
            // tbxPassword
            // 
            resources.ApplyResources(this.tbxPassword, "tbxPassword");
            this.tbxPassword.Name = "tbxPassword";
            // 
            // tbxUser
            // 
            resources.ApplyResources(this.tbxUser, "tbxUser");
            this.tbxUser.Name = "tbxUser";
            // 
            // tbxResultHasGone
            // 
            resources.ApplyResources(this.tbxResultHasGone, "tbxResultHasGone");
            this.tbxResultHasGone.Name = "tbxResultHasGone";
            // 
            // tbxNoResult
            // 
            resources.ApplyResources(this.tbxNoResult, "tbxNoResult");
            this.tbxNoResult.Name = "tbxNoResult";
            // 
            // cbxHasGone
            // 
            resources.ApplyResources(this.cbxHasGone, "cbxHasGone");
            this.cbxHasGone.Name = "cbxHasGone";
            this.cbxHasGone.UseVisualStyleBackColor = true;
            this.cbxHasGone.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged);
            // 
            // cbxNoResult
            // 
            resources.ApplyResources(this.cbxNoResult, "cbxNoResult");
            this.cbxNoResult.Name = "cbxNoResult";
            this.cbxNoResult.UseVisualStyleBackColor = true;
            this.cbxNoResult.CheckedChanged += new System.EventHandler(this.CbxNoResult_CheckedChanged);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnCheck.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnCheck, "btnCheck");
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.BtnCheck_Click);
            // 
            // btnSearch
            // 
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.btnExport);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnExport.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnExport, "btnExport");
            this.btnExport.Name = "btnExport";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // tbxSearch
            // 
            resources.ApplyResources(this.tbxSearch, "tbxSearch");
            this.tbxSearch.Name = "tbxSearch";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnSearch, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbxSearch, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // cToolStripMenuItem
            // 
            this.cToolStripMenuItem.Name = "cToolStripMenuItem";
            resources.ApplyResources(this.cToolStripMenuItem, "cToolStripMenuItem");
            this.cToolStripMenuItem.Click += new System.EventHandler(this.CToolStripMenuItem_Click);
            // 
            // MainScreen
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.HelpButton = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainScreen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainScreen_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataList)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dataList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxMessType;
        private System.Windows.Forms.TextBox tbxBrandname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxIpAddr;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.TextBox tbxUser;
        private System.Windows.Forms.RichTextBox tbxResultHasGone;
        private System.Windows.Forms.RichTextBox tbxNoResult;
        private System.Windows.Forms.CheckBox cbxHasGone;
        private System.Windows.Forms.CheckBox cbxNoResult;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeSubmit;
        private System.Windows.Forms.DataGridViewTextBoxColumn returnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn isDone;
        private System.Windows.Forms.DataGridViewComboBoxColumn timePerJob;
        private System.Windows.Forms.DataGridViewTextBoxColumn realTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn hasDelay;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
    }
}

