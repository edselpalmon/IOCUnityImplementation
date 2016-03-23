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
            this.buttongGrp = new System.Windows.Forms.GroupBox();
            this.btnDeactivate = new System.Windows.Forms.Button();
            this.btnCreateNew = new System.Windows.Forms.Button();
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
            this.personalInfoGrp.Location = new System.Drawing.Point(12, 12);
            this.personalInfoGrp.Name = "personalInfoGrp";
            this.personalInfoGrp.Size = new System.Drawing.Size(488, 254);
            this.personalInfoGrp.TabIndex = 2;
            this.personalInfoGrp.TabStop = false;
            this.personalInfoGrp.Text = "Personal Information";
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
    }
}

