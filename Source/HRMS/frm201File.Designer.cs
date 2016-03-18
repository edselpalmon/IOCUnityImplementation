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
            this.SuspendLayout();
            // 
            // btnEmployeeSearch
            // 
            this.btnEmployeeSearch.Location = new System.Drawing.Point(29, 161);
            this.btnEmployeeSearch.Name = "btnEmployeeSearch";
            this.btnEmployeeSearch.Size = new System.Drawing.Size(151, 23);
            this.btnEmployeeSearch.TabIndex = 0;
            this.btnEmployeeSearch.Text = "Employee Search";
            this.btnEmployeeSearch.UseVisualStyleBackColor = true;
            this.btnEmployeeSearch.Click += new System.EventHandler(this.btnEmployeeSearch_Click);
            // 
            // frm201File
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 524);
            this.Controls.Add(this.btnEmployeeSearch);
            this.Name = "frm201File";
            this.Text = "201 File";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEmployeeSearch;
    }
}

