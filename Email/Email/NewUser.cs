using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Email
{
    public partial class NewUser : Form{
        Login parent;

        public NewUser(Login parent){
            InitializeComponent();
            this.parent = parent;
        }
        public bool check_User(string table, string username){                  //false means name is taken
            if (username == null || username.Equals("") || username.Length == 0)
                return false;

            string query = "select * from " + Program.tables[Program.search_tables("User_Info")] +
                           " where User_Name = '" + username + "'";

            string tmp = Program.query_select(query, "User_ID");
            
            if (tmp.Equals(""))
                return true;
            return false;
        }
        private void check_Click(object sender, EventArgs e){
            string username = textBox1.Text;
            bool i = check_User("User_Info", username);

            if (i){
                label3.ForeColor = System.Drawing.Color.Green;
                label3.Text = "OK";
            }
            else{
                label3.ForeColor = System.Drawing.Color.Red;
                label3.Text = "Please Choose Another Name";
            }
        }
        private void rgsr_Click(object sender, EventArgs e){
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (!check_User("User_Info", username)){
                MessageBox.Show("Username is not available, please choose another");
                return;
            }
            if (password.Length == 0){
                MessageBox.Show("Must Specify a password");
                return;
            }
            int i;
            string q = "select max(User_ID) as USER_ID from " + Program.tables[Program.search_tables("User_Info")];

            string p = "User_ID";
            string tmp = Program.query_select(q, p);
            tmp = tmp.Replace("\t", ""); tmp = tmp.Replace("\r", ""); tmp = tmp.Replace("\n", "");
            if (tmp.Length == 0)
                i = 1;
            else
                i = Convert.ToInt32(tmp) + 1;

            string query = "insert into " + Program.tables[Program.search_tables("User_Info")] +
                               " values (" + i + ", '" + username + "', '" + password.GetHashCode() + "')";
            Program.query_execute(query);

            MessageBox.Show("congratulations, you have registered");
            back_btn.PerformClick();
            
        }
        private void back_Click(object sender, EventArgs e){
            this.Dispose();
            parent.Show();
            parent.Focus();
        }
    }
}
