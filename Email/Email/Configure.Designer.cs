namespace Email
{
    partial class Configure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configure));
            this.home_pnl = new System.Windows.Forms.Panel();
            this.home_drop_btn = new System.Windows.Forms.Button();
            this.home_back_btn = new System.Windows.Forms.Button();
            this.home_add_btn = new System.Windows.Forms.Button();
            this.add1_pnl = new System.Windows.Forms.Panel();
            this.add1_pop3_radio = new System.Windows.Forms.RadioButton();
            this.add1_imap_radio = new System.Windows.Forms.RadioButton();
            this.add1_prev_btn = new System.Windows.Forms.Button();
            this.add1_pass_txt = new System.Windows.Forms.TextBox();
            this.add1_next_btn = new System.Windows.Forms.Button();
            this.add1_eml_txt = new System.Windows.Forms.TextBox();
            this.add1_pass_lbl = new System.Windows.Forms.Label();
            this.add1_eml_lbl = new System.Windows.Forms.Label();
            this.drop_pnl = new System.Windows.Forms.Panel();
            this.drop_back_btn = new System.Windows.Forms.Button();
            this.drop_warn_lbl = new System.Windows.Forms.Label();
            this.drop_drop_btn = new System.Windows.Forms.Button();
            this.drop_email_lbl = new System.Windows.Forms.Label();
            this.drop_combo = new System.Windows.Forms.ComboBox();
            this.home_pnl.SuspendLayout();
            this.add1_pnl.SuspendLayout();
            this.drop_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // home_pnl
            // 
            this.home_pnl.Controls.Add(this.home_drop_btn);
            this.home_pnl.Controls.Add(this.home_back_btn);
            this.home_pnl.Controls.Add(this.home_add_btn);
            this.home_pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.home_pnl.Location = new System.Drawing.Point(0, 0);
            this.home_pnl.Name = "home_pnl";
            this.home_pnl.Size = new System.Drawing.Size(582, 363);
            this.home_pnl.TabIndex = 0;
            // 
            // home_drop_btn
            // 
            this.home_drop_btn.Location = new System.Drawing.Point(60, 195);
            this.home_drop_btn.Name = "home_drop_btn";
            this.home_drop_btn.Size = new System.Drawing.Size(156, 29);
            this.home_drop_btn.TabIndex = 3;
            this.home_drop_btn.Text = "Drop an email";
            this.home_drop_btn.UseVisualStyleBackColor = true;
            this.home_drop_btn.Click += new System.EventHandler(this.home_drop_Click);
            // 
            // home_back_btn
            // 
            this.home_back_btn.Location = new System.Drawing.Point(20, 23);
            this.home_back_btn.Name = "home_back_btn";
            this.home_back_btn.Size = new System.Drawing.Size(75, 23);
            this.home_back_btn.TabIndex = 2;
            this.home_back_btn.Text = "back";
            this.home_back_btn.UseVisualStyleBackColor = true;
            this.home_back_btn.Click += new System.EventHandler(this.home_back_Click);
            // 
            // home_add_btn
            // 
            this.home_add_btn.Location = new System.Drawing.Point(60, 97);
            this.home_add_btn.Name = "home_add_btn";
            this.home_add_btn.Size = new System.Drawing.Size(156, 29);
            this.home_add_btn.TabIndex = 0;
            this.home_add_btn.Text = "Add a New Email";
            this.home_add_btn.UseVisualStyleBackColor = true;
            this.home_add_btn.Click += new System.EventHandler(this.home_add_Click);
            // 
            // add1_pnl
            // 
            this.add1_pnl.BackColor = System.Drawing.SystemColors.Control;
            this.add1_pnl.Controls.Add(this.add1_pop3_radio);
            this.add1_pnl.Controls.Add(this.add1_imap_radio);
            this.add1_pnl.Controls.Add(this.add1_prev_btn);
            this.add1_pnl.Controls.Add(this.add1_pass_txt);
            this.add1_pnl.Controls.Add(this.add1_next_btn);
            this.add1_pnl.Controls.Add(this.add1_eml_txt);
            this.add1_pnl.Controls.Add(this.add1_pass_lbl);
            this.add1_pnl.Controls.Add(this.add1_eml_lbl);
            this.add1_pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.add1_pnl.Location = new System.Drawing.Point(0, 0);
            this.add1_pnl.Name = "add1_pnl";
            this.add1_pnl.Size = new System.Drawing.Size(582, 363);
            this.add1_pnl.TabIndex = 0;
            this.add1_pnl.Visible = false;
            // 
            // add1_pop3_radio
            // 
            this.add1_pop3_radio.AutoSize = true;
            this.add1_pop3_radio.Location = new System.Drawing.Point(117, 210);
            this.add1_pop3_radio.Name = "add1_pop3_radio";
            this.add1_pop3_radio.Size = new System.Drawing.Size(66, 21);
            this.add1_pop3_radio.TabIndex = 5;
            this.add1_pop3_radio.TabStop = true;
            this.add1_pop3_radio.Text = "POP3";
            this.add1_pop3_radio.UseVisualStyleBackColor = true;
            // 
            // add1_imap_radio
            // 
            this.add1_imap_radio.AutoSize = true;
            this.add1_imap_radio.Location = new System.Drawing.Point(310, 210);
            this.add1_imap_radio.Name = "add1_imap_radio";
            this.add1_imap_radio.Size = new System.Drawing.Size(61, 21);
            this.add1_imap_radio.TabIndex = 4;
            this.add1_imap_radio.TabStop = true;
            this.add1_imap_radio.Text = "IMAP";
            this.add1_imap_radio.UseVisualStyleBackColor = true;
            // 
            // add1_prev_btn
            // 
            this.add1_prev_btn.Location = new System.Drawing.Point(46, 272);
            this.add1_prev_btn.Name = "add1_prev_btn";
            this.add1_prev_btn.Size = new System.Drawing.Size(75, 23);
            this.add1_prev_btn.TabIndex = 2;
            this.add1_prev_btn.Text = "Previous";
            this.add1_prev_btn.UseVisualStyleBackColor = true;
            this.add1_prev_btn.Click += new System.EventHandler(this.add1_prev_Click);
            // 
            // add1_pass_txt
            // 
            this.add1_pass_txt.Location = new System.Drawing.Point(117, 146);
            this.add1_pass_txt.Name = "add1_pass_txt";
            this.add1_pass_txt.PasswordChar = '*';
            this.add1_pass_txt.Size = new System.Drawing.Size(324, 22);
            this.add1_pass_txt.TabIndex = 3;
            // 
            // add1_next_btn
            // 
            this.add1_next_btn.Location = new System.Drawing.Point(366, 272);
            this.add1_next_btn.Name = "add1_next_btn";
            this.add1_next_btn.Size = new System.Drawing.Size(75, 23);
            this.add1_next_btn.TabIndex = 1;
            this.add1_next_btn.Text = "Submit";
            this.add1_next_btn.UseVisualStyleBackColor = true;
            this.add1_next_btn.Click += new System.EventHandler(this.add1_sbmt_Click);
            // 
            // add1_eml_txt
            // 
            this.add1_eml_txt.Location = new System.Drawing.Point(117, 60);
            this.add1_eml_txt.Name = "add1_eml_txt";
            this.add1_eml_txt.Size = new System.Drawing.Size(324, 22);
            this.add1_eml_txt.TabIndex = 2;
            // 
            // add1_pass_lbl
            // 
            this.add1_pass_lbl.AutoSize = true;
            this.add1_pass_lbl.Location = new System.Drawing.Point(43, 126);
            this.add1_pass_lbl.Name = "add1_pass_lbl";
            this.add1_pass_lbl.Size = new System.Drawing.Size(69, 17);
            this.add1_pass_lbl.TabIndex = 1;
            this.add1_pass_lbl.Text = "Password";
            // 
            // add1_eml_lbl
            // 
            this.add1_eml_lbl.AutoSize = true;
            this.add1_eml_lbl.Location = new System.Drawing.Point(43, 49);
            this.add1_eml_lbl.Name = "add1_eml_lbl";
            this.add1_eml_lbl.Size = new System.Drawing.Size(42, 17);
            this.add1_eml_lbl.TabIndex = 0;
            this.add1_eml_lbl.Text = "Email";
            // 
            // drop_pnl
            // 
            this.drop_pnl.Controls.Add(this.drop_back_btn);
            this.drop_pnl.Controls.Add(this.drop_warn_lbl);
            this.drop_pnl.Controls.Add(this.drop_drop_btn);
            this.drop_pnl.Controls.Add(this.drop_email_lbl);
            this.drop_pnl.Controls.Add(this.drop_combo);
            this.drop_pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drop_pnl.Location = new System.Drawing.Point(0, 0);
            this.drop_pnl.Name = "drop_pnl";
            this.drop_pnl.Size = new System.Drawing.Size(582, 363);
            this.drop_pnl.TabIndex = 4;
            this.drop_pnl.Visible = false;
            // 
            // drop_back_btn
            // 
            this.drop_back_btn.Location = new System.Drawing.Point(20, 22);
            this.drop_back_btn.Name = "drop_back_btn";
            this.drop_back_btn.Size = new System.Drawing.Size(75, 23);
            this.drop_back_btn.TabIndex = 4;
            this.drop_back_btn.Text = "back";
            this.drop_back_btn.UseVisualStyleBackColor = true;
            this.drop_back_btn.Click += new System.EventHandler(this.drop_back_btn_Click);
            // 
            // drop_warn_lbl
            // 
            this.drop_warn_lbl.AutoSize = true;
            this.drop_warn_lbl.ForeColor = System.Drawing.Color.Red;
            this.drop_warn_lbl.Location = new System.Drawing.Point(199, 159);
            this.drop_warn_lbl.Name = "drop_warn_lbl";
            this.drop_warn_lbl.Size = new System.Drawing.Size(226, 17);
            this.drop_warn_lbl.TabIndex = 3;
            this.drop_warn_lbl.Text = "Warning, This action is irreversible";
            // 
            // drop_drop_btn
            // 
            this.drop_drop_btn.Location = new System.Drawing.Point(269, 190);
            this.drop_drop_btn.Name = "drop_drop_btn";
            this.drop_drop_btn.Size = new System.Drawing.Size(75, 29);
            this.drop_drop_btn.TabIndex = 2;
            this.drop_drop_btn.Text = "Drop";
            this.drop_drop_btn.UseVisualStyleBackColor = true;
            this.drop_drop_btn.Click += new System.EventHandler(this.drop_drop_Click);
            // 
            // drop_email_lbl
            // 
            this.drop_email_lbl.AutoSize = true;
            this.drop_email_lbl.Location = new System.Drawing.Point(102, 105);
            this.drop_email_lbl.Name = "drop_email_lbl";
            this.drop_email_lbl.Size = new System.Drawing.Size(114, 17);
            this.drop_email_lbl.TabIndex = 1;
            this.drop_email_lbl.Text = "Choose an Email";
            // 
            // drop_combo
            // 
            this.drop_combo.FormattingEnabled = true;
            this.drop_combo.Location = new System.Drawing.Point(235, 102);
            this.drop_combo.Name = "drop_combo";
            this.drop_combo.Size = new System.Drawing.Size(319, 24);
            this.drop_combo.TabIndex = 0;
            // 
            // Configure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 363);
            this.Controls.Add(this.home_pnl);
            this.Controls.Add(this.drop_pnl);
            this.Controls.Add(this.add1_pnl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Configure";
            this.Text = "Configure";
            this.home_pnl.ResumeLayout(false);
            this.add1_pnl.ResumeLayout(false);
            this.add1_pnl.PerformLayout();
            this.drop_pnl.ResumeLayout(false);
            this.drop_pnl.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel home_pnl;
        private System.Windows.Forms.Button home_add_btn;
        private System.Windows.Forms.Panel add1_pnl;
        private System.Windows.Forms.Button add1_prev_btn;
        private System.Windows.Forms.Button add1_next_btn;
        private System.Windows.Forms.TextBox add1_pass_txt;
        private System.Windows.Forms.TextBox add1_eml_txt;
        private System.Windows.Forms.Label add1_pass_lbl;
        private System.Windows.Forms.Label add1_eml_lbl;
        private System.Windows.Forms.Button home_back_btn;
        private System.Windows.Forms.Button home_drop_btn;
        private System.Windows.Forms.Panel drop_pnl;
        private System.Windows.Forms.ComboBox drop_combo;
        private System.Windows.Forms.Label drop_warn_lbl;
        private System.Windows.Forms.Button drop_drop_btn;
        private System.Windows.Forms.Label drop_email_lbl;
        private System.Windows.Forms.Button drop_back_btn;
        private System.Windows.Forms.RadioButton add1_pop3_radio;
        private System.Windows.Forms.RadioButton add1_imap_radio;

    }
}