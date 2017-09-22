//problems with multithreading
//lock all windows
//sending to kfupm's server
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Email{
    static class Program{
        private static string table_prefix = "[Email].[dbo].[";
        public static string[] tables = {"Attachment", "Email_Account", "Email_Message", "Received_Email", "Sent_Email", "Server_Info", 
                                         "Service_Provider", "User_Info"};

        public static SqlConnection sqlcn;
        [STAThread]
        static void Main(){
            string connection = @"Data Source=localhost;Initial Catalog=Email;Integrated Security=True";
            sqlcn = new SqlConnection(connection);

            for (int i = 0; i < tables.Length; i++)
                tables[i] = table_prefix + tables[i] + "]";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Login());
        }
        public static string query_select(string query, string col){
            return query_select(query, new List<string>() {col});
        }
        public static string query_select(string query, string[] col){
            return query_select(query, col.Cast<string>().ToList());
        }
        public static string query_select(string query, List<string> cols){
            string tmp = "";
            try{
                sqlcn.Open();
                
                SqlCommand sqlcd = new SqlCommand(query, sqlcn);
                SqlDataReader sqlrd = sqlcd.ExecuteReader();
                while (sqlrd.Read()){
                    foreach (string col in cols)
                        tmp = tmp + sqlrd[col].ToString() + "\t";
                    tmp = tmp + "\r\n";                       // why \r? this could cause problems
                }
                sqlrd.Close();
            }
            catch (Exception e){
                MessageBox.Show("EXC" + e.ToString());
            }
            finally{
                sqlcn.Close();
            }
            return tmp;
        }
        public static void query_execute(string query){
            try{
                sqlcn.Open();
                SqlCommand sqlcd = new SqlCommand(query, sqlcn);
                sqlcd.ExecuteNonQuery();
            }
            catch (Exception ex){
                MessageBox.Show("EXC" + ex.ToString());
            }
            finally{
                sqlcn.Close();
            }
        }
        public static int search_tables(string x){
            for (int j = 0; j < Program.tables.Length; j++)
                if (tables[j].Substring(15, tables[j].Length - 16).Trim().Equals(x.Trim()))
                    return j;
            return -1;
        }
        public static string get_Email_id(int user_id, string from){
            string first = "select Email_ID from ";
            string second = Program.tables[Program.search_tables("User_Info")] + " u, "
                          + Program.tables[Program.search_tables("Email_Account")] + " e ";
            string third = "where u.User_ID = e.User_ID and u.User_ID = " + user_id
                         + " and e.Email_Address = '" + from + "'";
            string query = first + second + third;

            return Program.query_select(query, "Email_ID");
        }
    }
}
