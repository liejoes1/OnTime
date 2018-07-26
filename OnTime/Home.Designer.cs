namespace OnTime
{
    partial class Home
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
            this.tb_intake_code = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tb_intake_code
            // 
            this.tb_intake_code.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tb_intake_code.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tb_intake_code.BackColor = System.Drawing.Color.White;
            this.tb_intake_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_intake_code.Location = new System.Drawing.Point(499, 275);
            this.tb_intake_code.Name = "tb_intake_code";
            this.tb_intake_code.Size = new System.Drawing.Size(429, 49);
            this.tb_intake_code.TabIndex = 2;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.tb_intake_code);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tb_intake_code;
    }
}