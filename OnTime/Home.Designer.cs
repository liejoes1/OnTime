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
            this.lbl_logo = new System.Windows.Forms.Label();
            this.lbl_description = new System.Windows.Forms.Label();
            this.link_lbl_go = new System.Windows.Forms.LinkLabel();
            this.lbl_week = new System.Windows.Forms.Label();
            this.lbl_week_value = new System.Windows.Forms.Label();
            this.lbl_message = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_intake_code
            // 
            this.tb_intake_code.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tb_intake_code.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tb_intake_code.BackColor = System.Drawing.Color.White;
            this.tb_intake_code.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_intake_code.ForeColor = System.Drawing.Color.Black;
            this.tb_intake_code.Location = new System.Drawing.Point(101, 252);
            this.tb_intake_code.Name = "tb_intake_code";
            this.tb_intake_code.Size = new System.Drawing.Size(264, 39);
            this.tb_intake_code.TabIndex = 2;
            // 
            // lbl_logo
            // 
            this.lbl_logo.AutoSize = true;
            this.lbl_logo.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_logo.ForeColor = System.Drawing.Color.White;
            this.lbl_logo.Location = new System.Drawing.Point(91, 96);
            this.lbl_logo.Name = "lbl_logo";
            this.lbl_logo.Size = new System.Drawing.Size(194, 65);
            this.lbl_logo.TabIndex = 3;
            this.lbl_logo.Text = "OnTime";
            // 
            // lbl_description
            // 
            this.lbl_description.AutoSize = true;
            this.lbl_description.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_description.ForeColor = System.Drawing.Color.White;
            this.lbl_description.Location = new System.Drawing.Point(97, 213);
            this.lbl_description.Name = "lbl_description";
            this.lbl_description.Size = new System.Drawing.Size(212, 21);
            this.lbl_description.TabIndex = 4;
            this.lbl_description.Text = "Please enter intake code here";
            // 
            // link_lbl_go
            // 
            this.link_lbl_go.ActiveLinkColor = System.Drawing.Color.DeepSkyBlue;
            this.link_lbl_go.AutoSize = true;
            this.link_lbl_go.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_lbl_go.LinkColor = System.Drawing.Color.White;
            this.link_lbl_go.Location = new System.Drawing.Point(296, 304);
            this.link_lbl_go.Name = "link_lbl_go";
            this.link_lbl_go.Size = new System.Drawing.Size(69, 25);
            this.link_lbl_go.TabIndex = 5;
            this.link_lbl_go.TabStop = true;
            this.link_lbl_go.Text = "Search";
            this.link_lbl_go.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_lbl_go_LinkClicked);
            // 
            // lbl_week
            // 
            this.lbl_week.AutoSize = true;
            this.lbl_week.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_week.ForeColor = System.Drawing.Color.White;
            this.lbl_week.Location = new System.Drawing.Point(98, 176);
            this.lbl_week.Name = "lbl_week";
            this.lbl_week.Size = new System.Drawing.Size(55, 21);
            this.lbl_week.TabIndex = 7;
            this.lbl_week.Text = "Week: ";
            // 
            // lbl_week_value
            // 
            this.lbl_week_value.AutoSize = true;
            this.lbl_week_value.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_week_value.ForeColor = System.Drawing.Color.White;
            this.lbl_week_value.Location = new System.Drawing.Point(159, 176);
            this.lbl_week_value.Name = "lbl_week_value";
            this.lbl_week_value.Size = new System.Drawing.Size(87, 21);
            this.lbl_week_value.TabIndex = 8;
            this.lbl_week_value.Text = "Day Month";
            // 
            // lbl_message
            // 
            this.lbl_message.AutoSize = true;
            this.lbl_message.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_message.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lbl_message.Location = new System.Drawing.Point(97, 338);
            this.lbl_message.Name = "lbl_message";
            this.lbl_message.Size = new System.Drawing.Size(71, 21);
            this.lbl_message.TabIndex = 9;
            this.lbl_message.Text = "Message";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lbl_message);
            this.Controls.Add(this.lbl_week_value);
            this.Controls.Add(this.lbl_week);
            this.Controls.Add(this.link_lbl_go);
            this.Controls.Add(this.lbl_description);
            this.Controls.Add(this.lbl_logo);
            this.Controls.Add(this.tb_intake_code);
            this.ForeColor = System.Drawing.Color.White;
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
        private System.Windows.Forms.Label lbl_logo;
        private System.Windows.Forms.Label lbl_description;
        private System.Windows.Forms.LinkLabel link_lbl_go;
        private System.Windows.Forms.Label lbl_week;
        private System.Windows.Forms.Label lbl_week_value;
        private System.Windows.Forms.Label lbl_message;
    }
}