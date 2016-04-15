namespace HRMS
{
    partial class frm201File
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
            this.btnEmployeeSearch = new System.Windows.Forms.Button();
            this.personalInfoGrp = new System.Windows.Forms.GroupBox();
            this.gvPersonalInfo = new System.Windows.Forms.DataGridView();
            this.buttongGrp = new System.Windows.Forms.GroupBox();
            this.btnDeactivate = new System.Windows.Forms.Button();
            this.btnCreateNew = new System.Windows.Forms.Button();
            this.EmployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MiddleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personalInfoGrp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPersonalInfo)).BeginInit();
            this.buttongGrp.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEmployeeSearch
            // 
            this.btnEmployeeSearch.Location = new System.Drawing.Point(6, 19);
            this.btnEmployeeSearch.Name = "btnEmployeeSearch";
            this.btnEmployeeSearch.Size = new System.Drawing.Size(151, 23);
            this.btnEmployeeSearch.TabIndex = 0;
            this.btnEmployeeSearch.Text = "Employee Search";
            this.btnEmployeeSearch.UseVisualStyleBackColor = true;
            this.btnEmployeeSearch.Click += new System.EventHandler(this.btnEmployeeSearch_Click);
            // 
            // personalInfoGrp
            // 
            this.personalInfoGrp.AutoSize = true;
            this.personalInfoGrp.Controls.Add(this.gvPersonalInfo);
            this.personalInfoGrp.Location = new System.Drawing.Point(12, 12);
            this.personalInfoGrp.Name = "personalInfoGrp";
            this.personalInfoGrp.Size = new System.Drawing.Size(488, 254);
            this.personalInfoGrp.TabIndex = 2;
            this.personalInfoGrp.TabStop = false;
            this.personalInfoGrp.Text = "Personal Information";
            // 
            // gvPersonalInfo
            // 
            this.gvPersonalInfo.AllowUserToAddRows = false;
            this.gvPersonalInfo.AllowUserToDeleteRows = false;
            this.gvPersonalInfo.AllowUserToOrderColumns = true;
            this.gvPersonalInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPersonalInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeId,
            this.EmployeeNumber,
            this.FirstName,
            this.MiddleName,
            this.LastName});
            this.gvPersonalInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvPersonalInfo.Location = new System.Drawing.Point(3, 16);
            this.gvPersonalInfo.Name = "gvPersonalInfo";
            this.gvPersonalInfo.ReadOnly = true;
            this.gvPersonalInfo.Size = new System.Drawing.Size(482, 235);
            this.gvPersonalInfo.TabIndex = 0;
            this.gvPersonalInfo.Click += new System.EventHandler(this.gvPersonalInfo_Click);
            // 
            // buttongGrp
            // 
            this.buttongGrp.AutoSize = true;
            this.buttongGrp.Controls.Add(this.btnDeactivate);
            this.buttongGrp.Controls.Add(this.btnCreateNew);
            this.buttongGrp.Controls.Add(this.btnEmployeeSearch);
            this.buttongGrp.Location = new System.Drawing.Point(12, 272);
            this.buttongGrp.Name = "buttongGrp";
            this.buttongGrp.Size = new System.Drawing.Size(488, 61);
            this.buttongGrp.TabIndex = 3;
            this.buttongGrp.TabStop = false;
            // 
            // btnDeactivate
            // 
            this.btnDeactivate.Location = new System.Drawing.Point(331, 19);
            this.btnDeactivate.Name = "btnDeactivate";
            this.btnDeactivate.Size = new System.Drawing.Size(151, 23);
            this.btnDeactivate.TabIndex = 2;
            this.btnDeactivate.Text = "De-Activate Employee";
            this.btnDeactivate.UseVisualStyleBackColor = true;
            // 
            // btnCreateNew
            // 
            this.btnCreateNew.Location = new System.Drawing.Point(169, 19);
            this.btnCreateNew.Name = "btnCreateNew";
            this.btnCreateNew.Size = new System.Drawing.Size(151, 23);
            this.btnCreateNew.TabIndex = 1;
            this.btnCreateNew.Text = "New Employee";
            this.btnCreateNew.UseVisualStyleBackColor = true;
            this.btnCreateNew.Click += new System.EventHandler(this.btnCreateNew_Click);
            // 
            // EmployeeId
            // 
            this.EmployeeId.DataPropertyName = "EmployeeId";
            this.EmployeeId.HeaderText = "EmployeeId";
            this.EmployeeId.Name = "EmployeeId";
            this.EmployeeId.ReadOnly = true;
            // 
            // EmployeeNumber
            // 
            this.EmployeeNumber.DataPropertyName = "EmployeeNumber";
            this.EmployeeNumber.HeaderText = "EmployeeNumber";
            this.EmployeeNumber.Name = "EmployeeNumber";
            this.EmployeeNumber.ReadOnly = true;
            // 
            // FirstName
            // 
            this.FirstName.DataPropertyName = "FirstName";
            this.FirstName.HeaderText = "FirstName";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            // 
            // MiddleName
            // 
            this.MiddleName.DataPropertyName = "MiddleName";
            this.MiddleName.HeaderText = "MiddleName";
            this.MiddleName.Name = "MiddleName";
            this.MiddleName.ReadOnly = true;
            // 
            // LastName
            // 
            this.LastName.DataPropertyName = "LastName";
            this.LastName.HeaderText = "LastName";
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            // 
            // frm201File
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(512, 349);
            this.Controls.Add(this.buttongGrp);
            this.Controls.Add(this.personalInfoGrp);
            this.Name = "frm201File";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "201 File";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm201File_FormClosed);
            this.personalInfoGrp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvPersonalInfo)).EndInit();
            this.buttongGrp.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEmployeeSearch;
        private System.Windows.Forms.GroupBox personalInfoGrp;
        private System.Windows.Forms.GroupBox buttongGrp;
        private System.Windows.Forms.Button btnDeactivate;
        private System.Windows.Forms.Button btnCreateNew;
        private System.Windows.Forms.DataGridView gvPersonalInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MiddleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
    }
}

