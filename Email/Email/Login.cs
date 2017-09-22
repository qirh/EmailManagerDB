using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Email{
    public partial class Login : Form{

        public Login(){
            InitializeComponent();
        }
        private void sbmt_Click(object sender, EventArgs e){
            string q = "select * from " + Program.tables[Program.search_tables("User_Info")] +
                           " where User_Name = '" + usr_text.Text + "' and User_Password = '" + pass_text.Text.GetHashCode() + "'";

            string col = "User_ID";

            string tmp = Program.query_select(q, col);

            if(tmp.Length == 0){
                MessageBox.Show("Username-Password combination does not exist, please try again");
                return;
            }
            int i = Convert.ToInt32(tmp);
            if (i > 0){
                clear();
                this.Hide();
                Main main = new Main(i, this);
                main.Show();
            }
        }
        private void new_Click(object sender, EventArgs e){
            this.Hide();
            NewUser newuser = new NewUser(this);
            newuser.Show();
        }
        private void helpToolStripMenuItem1_Click(object sender, EventArgs e){
            MessageBox.Show("Email client designed for ICS324 Final project, for inquiries contact:\r\n\r\n almto3@homail.com");
        }
        private void clear(){
            usr_text.Text = ""; pass_text.Text = "";
        }
    }
}
