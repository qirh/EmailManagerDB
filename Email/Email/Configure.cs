using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Email{

    public partial class Configure : Form{

        int user_id;
        Main parent;

        public Configure(int x, Main parent){
            InitializeComponent();
            user_id = x;
            this.parent = parent;
        }
        private void home_add_Click(object sender, EventArgs e){
            add1_pnl.Visible = true;
            home_pnl.Visible = false;
        }
        private void home_back_Click(object sender, EventArgs e){
            parent.initCombo();
            parent.Show();
            parent.Focus();
            this.Dispose();
        }
        private void home_drop_Click(object sender, EventArgs e){
            home_pnl.Visible = false;
            drop_pnl.Visible = true;

            string query = "select * from " + Program.tables[Program.search_tables("Email_Account")] +
                           "where User_ID = " + user_id;
            string col = "Email_Address";

            string[] emails = Program.query_select(query, col).Split('\r');
            drop_combo.Items.Clear();
            for (int i = 0; i < emails.Length - 1; i++)
                drop_combo.Items.Add(emails[i]);
        }
        private void add1_prev_Click(object sender, EventArgs e){
            home_pnl.Visible = true;
            add1_pnl.Visible = false;
        }
        private void add1_sbmt_Click(object sender, EventArgs e){
            if (add1_eml_txt.Text.Length == 0 || !add1_eml_txt.Text.Contains('@') ||
               !add1_eml_txt.Text.Contains('.') || add1_pass_txt.Text.Length == 0){
                MessageBox.Show("Incorrect Entries");
                return;
            }
            if (!add1_imap_radio.Checked && !add1_pop3_radio.Checked){
                MessageBox.Show("ERROR");
                return;
            }
            if (!CheckUserEmail())
                return;
            LogNewEmail();
            home_pnl.Visible = true;
            add1_pnl.Visible = false;
        }
        private void drop_drop_Click(object sender, EventArgs e){
            string email = (string)drop_combo.SelectedItem;
            if (email == null || email.Length < 4)
                return;
            
            string query = "delete from" + Program.tables[Program.search_tables("Email_Account")]
                         + " where User_ID = " + user_id + " and Email_Address = '" + email.Trim() + "'";

            Program.query_execute(query);
            MessageBox.Show("Email and messages successfully deleted");
            drop_back_btn.PerformClick();
        }
        private void drop_back_btn_Click(object sender, EventArgs e){
            drop_combo.Items.Clear();
            drop_pnl.Visible = false;
            home_pnl.Visible = true;
        }
        private int GetNthIndex(string s, char t, int n){
            int count = 0;
            for (int i = 0; i < s.Length; i++){
                if (s[i] == t){
                    count++;
                    if (count == n){
                        return i;
                    }
                }
            }
            return -1;
        }
        private void LogNewEmail(){

            int newID = GenerateEmailID();

            int j; //email_pop3
            if (add1_pop3_radio.Checked)
                j = 1;
            else
                j = 0;

            int newSP = GetSP();

            string q = "insert into " + Program.tables[Program.search_tables("Email_Account")] +
                               " values (" + newID + ", '" + add1_eml_txt.Text + "', '" + add1_pass_txt.Text
                               + "', null, " + j + ", " + user_id + ", " + newSP + ")";

            Program.query_execute(q);
        }
        private bool CheckUserEmail() {
            string q = "select * from " + Program.tables[Program.search_tables("User_Info")] + " u, "
                           + Program.tables[Program.search_tables("Email_Account")] + " e " +
                           " where e.Email_Address = '" + add1_eml_txt.Text + "' and u.User_ID = "
                           + user_id + " and u.User_ID = e.User_ID";

            string col = "User_ID";

            string tmp = Program.query_select(q, col);
            if(tmp.Length != 0){
                MessageBox.Show("Email already exists and cannot be added");
                return false;
            }
            return true;
        }
        private int GenerateEmailID(){
            int i;  //user_id
            string q = "select max(Email_ID) as Email_ID from "
                      + Program.tables[Program.search_tables("Email_Account")];
            string col = "Email_ID";
            string tmp = Program.query_select(q, col);
            if (tmp.Length == 0)
                i = 1;
            else
                i = Convert.ToInt32(tmp) + 1;
            return i;
        }
        private int GetSP(){
            string q = "select SP_Name from " + Program.tables[Program.search_tables("Service_Provider")];
            string col = "SP_Name";
            string[] tmp2 = Program.query_select(q, col).Split('\r');
            for (int f = 0; f < tmp2.Length; f++)
            {
                tmp2[f] = tmp2[f].Replace("\n", "");
                tmp2[f] = tmp2[f].Replace("\t", "");
            }

            string tmp = null;
            string z = add1_eml_txt.Text;
            z = z.Substring(z.IndexOf('@') + 1, GetNthIndex(z, '.', 1) - z.IndexOf('@') - 1);
            foreach (string x in tmp2){

                bool y = x.Equals(z, StringComparison.InvariantCultureIgnoreCase);
                if (y)
                    tmp = x;
            }
            if (tmp == null)
                return -1;
            q = "select SP_ID from " + Program.tables[Program.search_tables("Service_Provider")] +
                " where SP_Name = '" + tmp + "'";
            col = "SP_ID";
            int i = Convert.ToInt32(Program.query_select(q, col));
            return i;
        }
    }
}
