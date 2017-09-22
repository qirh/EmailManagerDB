using ActiveUp.Net.Mail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Email
{
    public partial class Main : Form
    {
        int user_id;
        Login parent;

        public Main(int x, Login parent){
            InitializeComponent();
            user_id = x;
            this.parent = parent;
            initCombo();
        }
        public void initCombo(){
            comboBox1.Items.Clear();    comboBox2.Items.Clear();

            string query = "select * from " + Program.tables[Program.search_tables("Email_Account")] + 
                           "where User_ID = " + user_id;
            string col = "Email_Address";

            string[] emails = Program.query_select(query, col).Split('\r');

            for (int i = 0; i < emails.Length - 1; i++)
                comboBox1.Items.Add(emails[i]);
            comboBox2.Items.Add("Inbox");   
            comboBox2.Items.Add("Sent Mail");
        }
        private void send_Click(object sender, EventArgs e){
            this.Hide();
            Send s = new Send(user_id, this);
            s.Show();
        }
        private void conf_Click(object sender, EventArgs e){
            this.Hide();    //needs more work
            Configure newuser = new Configure(user_id, this);
            newuser.Show();

        }
        private void log_Click(object sender, EventArgs e){ //too simple
            this.Dispose();
            parent.Show();
        }
        private void syn_Click(object sender, EventArgs e){
            string email = (string)comboBox1.SelectedItem;
            string box = (string)comboBox2.SelectedItem;
            if (email == null || email.Length == 0){
                MessageBox.Show("Please choose an email");
                return;
            }
            if (box == null || box.Length == 0){
                MessageBox.Show("Please choose a box");
                return;
            }
            dataGridView1.Rows.Clear();
            email = email.Trim();   box = box.Trim();
            string q = "select * from " + 
                        Program.tables[Program.search_tables("Email_Account")] +
                      " where User_ID = " + user_id + " and Email_Address = '" + email + "'";
            string p = "Email_POP3";
            string tmp = Program.query_select(q, p);

            string x;
            if (tmp.Equals("True\t\r\n"))
                x = "POP3";
            else
                x = "IMAP";
            q = "select * from " +
                           Program.tables[Program.search_tables("Service_Provider")] + " v, " +
                           Program.tables[Program.search_tables("Email_Account")] + " e, " +
                           Program.tables[Program.search_tables("Server_Info")] + " s " +
                           "where e.Email_Address = '" + email  +"' and e.SP_ID = v.SP_ID and v.SP_ID = s.SP_ID and " +
                           "e.User_ID = " + user_id +" and s.SV_Protocol = '" + x + "'";

            string[] col = {"SV_Name", "SV_Port", "SP_Name"};

            q = Program.query_select(q, col);

            if (q.Equals("")){
                MessageBox.Show("Sorry, only gmail is supported for retrieving mail");
                return;
            }
            string password;
            tmp = "select * from " + Program.tables[Program.search_tables("Email_Account")] + 
                  " where User_ID = " + user_id + " and Email_Address = '" + email + "'";
            p = "Email_Password";
            password = Program.query_select(tmp, p);
            password = password.Substring(0, password.Length - 3);
            string server_name; int port;
            dataGridView1.Rows.Clear();
            ThreeStrings[] messages;
            if (q.Substring(0, 3).Equals("pop")){
                server_name = q.Substring(0, 13);
                port = Convert.ToInt32(q.Substring(14, 3));
                messages = pop3(server_name, port, email, password, 10);       //do something about 10
            }
            else{
                server_name = q.Substring(0, 14);
                port = Convert.ToInt32(q.Substring(15, 3));
                messages = imap(server_name, port, email, password, "[Gmail]/Sent Mail", 10, checkBox1.Checked);   //also here
            }
            updategrid(messages);
            log(messages, email);
        }
        private void log(ThreeStrings[] messages, string email){
            int email_id = Convert.ToInt32(Program.get_Email_id(user_id, email));

            foreach (ThreeStrings message in messages){
                if (message != null){
                    int MS_ID;
                    string q = "select max(MS_ID) as MS_ID from " + Program.tables[Program.search_tables("Email_Message")];
                    string p = "MS_ID";
                    string maxMS_ID = Program.query_select(q, p).Trim();

                    if (maxMS_ID == null || maxMS_ID.Length == 0)
                        MS_ID = 1000000;
                    else
                        MS_ID = Convert.ToInt32(maxMS_ID) + 1;
                   // MessageBox.Show("BODY = " + message.body);
                    message.from = message.from.Replace("'", "\""); message.subject = message.subject.Replace("'", "\"");
                    message.body = message.body.Replace("'", "\"");
                    string query = "insert into " + Program.tables[Program.search_tables("Email_Message")] +
                                    " values (" + MS_ID + ", '" + message.from + "', '" +
                                    message.subject + "', '" + message.body + "', '" +
                                    DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "', " +
                                    0 + "," + email_id + ")";
                    
                    Program.query_execute(query);

                    query = "insert into " + Program.tables[Program.search_tables("Received_Email")] +
                            " values (" + MS_ID + ", " + 0 + ", " + 0 + ", " + 0 + ")";

                    Program.query_execute(query);
                }
            }
        }
        private void updategrid(ThreeStrings[] messages){
            foreach (ThreeStrings x in messages)
                if (x != null)
                    dataGridView1.Rows.Add(x.subject, x.from, x.body);
        }
        private ThreeStrings[] imap(string servername, int port, string email, string password, 
                                    string box, int numberofmessages, bool seen){
            Imap4Client imap = new Imap4Client();
            imap.ConnectSsl(servername, port);
            imap.Login(email, password);
            imap.Command("capability");

            Mailbox inbox = imap.SelectMailbox(box);
            int[] ids;
            if(seen)
                ids = inbox.Search("SEEN");
            else
                ids = inbox.Search("UNSEEN");
            ThreeStrings[] messages = new ThreeStrings[numberofmessages];

            if (ids.Length > 0){
                ActiveUp.Net.Mail.Message msg = null;
                AttachmentCollection atchColl = null;

                for(int i = 0; i < ids.Length && numberofmessages > 0; i++){
                    msg = inbox.Fetch.MessageObject(ids[i]);
                    atchColl = msg.Attachments;
                    if (atchColl != null && atchColl.Count > 0){
                        MimePart t = atchColl[0];
                    }
                    messages[i] = new ThreeStrings(msg.Subject, msg.From.ToString(), (string)msg.BodyText.Text);
                    if (numberofmessages <= 0)
                        break;
                    numberofmessages -= 1;
                }
            }
            return messages;
        }
        private ThreeStrings[] pop3(string servername, int port, string email, string password, int numberofmessages){
            Pop3Client pop3 = new Pop3Client();
            pop3.ConnectSsl(servername, port, email, password);
            ActiveUp.Net.Mail.Message msg = null;
            int x = pop3.MessageCount;
            ThreeStrings[] messages = new ThreeStrings[numberofmessages];
            while (x > 0 && numberofmessages > 0){
                msg = pop3.RetrieveMessageObject(x);
                messages[x] = new ThreeStrings(msg.Subject, msg.From.ToString(), (string)msg.BodyText.Text);
                x -=  1;
                numberofmessages -= 1;
            }
            return messages;
        }
    }
}
