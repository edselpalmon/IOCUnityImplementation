namespace TestHibernate
{
    partial class Form1
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
            this.btnGetChannel = new System.Windows.Forms.Button();
            this.txtDisplayChannel = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetChannel
            // 
            this.btnGetChannel.Location = new System.Drawing.Point(43, 36);
            this.btnGetChannel.Name = "btnGetChannel";
            this.btnGetChannel.Size = new System.Drawing.Size(75, 23);
            this.btnGetChannel.TabIndex = 0;
            this.btnGetChannel.Text = "Get Channel";
            this.btnGetChannel.UseVisualStyleBackColor = true;
            this.btnGetChannel.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDisplayChannel
            // 
            this.txtDisplayChannel.Location = new System.Drawing.Point(33, 110);
            this.txtDisplayChannel.Name = "txtDisplayChannel";
            this.txtDisplayChannel.Size = new System.Drawing.Size(239, 20);
            this.txtDisplayChannel.TabIndex = 1;
            this.txtDisplayChannel.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(138, 35);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save Channel";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDisplayChannel);
            this.Controls.Add(this.btnGetChannel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetChannel;
        private System.Windows.Forms.TextBox txtDisplayChannel;
        private System.Windows.Forms.Button btnSave;
    }
}

