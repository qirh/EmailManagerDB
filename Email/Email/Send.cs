using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.IO;

namespace Email
{
    public partial class Send : Form
    {
        List<string> attach = new List<string>();
        int user_id;
        Main parent;

        public Send(int t, Main parent){
            InitializeComponent();
            user_id = t;
            this.parent = parent;
            initCombo();
        }
        private static void tmp() { }
        private void initCombo(){
            string query = "select * from " + Program.tables[Program.search_tables("Email_Account")] +
                           "where User_ID = " + user_id;
            string col = "Email_Address";

            string[] emails = Program.query_select(query, col).Split('\r');

            for (int i = 0; i < emails.Length - 1; i++)
                comboBox1.Items.Add(emails[i]);
        }
        private void send_Click(object sender, EventArgs e){
            string from = (string)comboBox1.SelectedItem;

            if (from == null || from.Length == 0 || !(from.Contains("@") && from.Contains("."))){
                MessageBox.Show("Please Choose an Email Address");
                return;
            }
            from = from.Trim();
            
            string subject = textBox4.Text;
            string body = textBox3.Text;
            
            string[] cols = {"SV_Name", "SV_Port", "SV_SSLFlag", "SV_STARTTLSFlag"};
            string[] smtpinfo = getSMTPInfo(cols, from).Split('\t');
            string smtpserver = smtpinfo[0];
            int smtpport = Convert.ToInt32(smtpinfo[1]);
            bool smtpssl = Convert.ToBoolean(smtpinfo[2]);
            bool smtpstarttls = Convert.ToBoolean(smtpinfo[3]);

            string[] to = textBox2.Text.Split(';');
            for (int x = 0; x < to.Length; x++)
                to[x] = to[x].Trim();
            string pass = getPass(user_id, from);

            string[] attachments = attach_txt.Text.Split('\r');
            
            for(int i = 0; i<attachments.Length; i++)
                attachments[i] = attachments[i].Replace("\n", "");


            if (send(from, to, subject.Trim(), body.Trim(), smtpserver.Trim(),
                    smtpport, pass.Trim(), smtpssl, smtpstarttls, attachments, checkBox1.Checked)){

                MessageBox.Show("Message successfully sent");
                Log(from, to, subject.Trim(), body.Trim(), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                    attachments, true, checkBox1.Checked);
            }
            else
                Log(from, to, subject.Trim(), body.Trim(), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                     attachments, false, checkBox1.Checked);
        }
        private static bool send(string from, string[] to, string subject, string body,
                            string smtpserver, int port, string pass, bool ssl, bool starttls, string[] attachments, bool pri){
            /*
            MessageBox.Show("Sending \r FROM: '" + from.Trim() + "'\r TO: '" + to + "'\r subj: '" + subject + "'\r bod: '" + body
                           + "'\r smtp: '" + smtpserver + "'\r port: '" + port
                           + "'\r pass: '" + pass.Trim() + "'\r ssl: '" + ssl + "'\r starttls: '" + starttls + "'");
             */
            try{                
                MailMessage mail = new MailMessage();
                mail.Subject = subject;
                mail.From = new MailAddress(from);
                mail.Body = body;
                mail.IsBodyHtml = true;
                if(pri)
                    mail.Priority = MailPriority.High;

                SmtpClient smtp = new SmtpClient();
                smtp.EnableSsl = ssl;
                smtp.Credentials = new NetworkCredential(from, pass);
                smtp.Host = smtpserver;
                smtp.Port = port;
                
                foreach(string x in to)
                    mail.To.Add(x);
                foreach (string x in attachments){
                    if (File.Exists(@x))
                        mail.Attachments.Add(new Attachment(@x));
                }

                smtp.Send(mail);    //what if sending fails?
                return true;
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private void Log(string from, string[] to, string subject, string body, string date, 
                         string[] attachments, bool success, bool pri){ 
            
            string rec = "";
            foreach (string x in to)
                rec = rec + x + " ; ";
            rec = rec.Substring(0, rec.Length - 2);
            
            int MS_ID;
            string q = "select max(MS_ID) as MS_ID from " + Program.tables[Program.search_tables("Email_Message")];
            string p = "MS_ID";
            string maxMS_ID = Program.query_select(q, p).Trim();

            if (maxMS_ID == null || maxMS_ID.Length == 0)
                MS_ID = 1000000;
            else
                MS_ID = Convert.ToInt32(maxMS_ID) + 1;
            
            string query = "insert into " + Program.tables[Program.search_tables("Email_Message")] +
                               " values (" + MS_ID + ", '" + rec + "', '" + subject + "', '" + body + "', '" + date + "', " +
                               +  1 + ", " + Convert.ToInt32(Program.get_Email_id(user_id, from)) +")";
            //MessageBox.Show(query);
            Program.query_execute(query);
            int y, z;
            if (pri)      y = 1;
            else          y = 0;
            if (success)  z = 1;
            else          z = 0;
            query = "insert into " + Program.tables[Program.search_tables("Sent_Email")] +
                               " values (" + MS_ID + ", " + y + ", " + z + ")";
            //MessageBox.Show(query);
            Program.query_execute(query);
            
            for (int i = 0; i < attachments.Length; i++){
                if (File.Exists(@attachments[i])){
                    query = "insert into " + Program.tables[Program.search_tables("Attachment")] +
                        " values (" + (i + 1) + ", '" + @attachments[i].Substring(@attachments[i].LastIndexOf("\\")+1) + "', '" +
                        @attachments[i].Substring(@attachments[i].LastIndexOf(".")+1) + "', '" + @attachments[i] + "', " + MS_ID + ")";
                    
                    //MessageBox.Show(query);
                    Program.query_execute(query);
                }
            }

        }
        private string getSMTPInfo(string[] col, string email){
            string first = "select * from ";
            string second = Program.tables[Program.search_tables("Email_Account")] + " e, "
                          + Program.tables[Program.search_tables("Service_Provider")] + " v, "
                          + Program.tables[Program.search_tables("Server_Info")] + " s ";
            string third = "where e.SP_ID = v.SP_ID and v.SP_ID = s.SP_ID and s.SV_Protocol = 'SMTP' and e.Email_Address = '" + email + "'";

            string query = first + second + third;

            string t =  Program.query_select(query, col);

            return t;
        }
        private string getPass(int user_id, string from){
            string first = "select * from ";
            string second = Program.tables[Program.search_tables("User_Info")] + " u, "
                          + Program.tables[Program.search_tables("Email_Account")] + " e ";
            string third = "where u.User_ID = e.User_ID and u.User_ID = " + user_id
                         + " and e.Email_Address = '" + from + "'";
            string query = first + second + third;

            return Program.query_select(query, "Email_Password");
        }
        private void back_btn_Click(object sender, EventArgs e){
            this.Hide();
            parent.Show();
            parent.Focus();
        }
        private void attach_btn_Click(object sender, EventArgs e){
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Please Select an Attachment";
            fDialog.InitialDirectory = @"C:\";
            fDialog.ReadOnlyChecked = true;
            fDialog.AddExtension = true;
            fDialog.CheckFileExists = true;
            fDialog.CheckPathExists = true;
            fDialog.ShowHelp = true;
            fDialog.Filter = "All files (*.*)|*.*";
            if (fDialog.ShowDialog() == DialogResult.OK){
                attach.Add(fDialog.FileName.ToString());
                fDialog.Dispose();
            }
            string tmp = "";

            foreach (string x in attach)
                tmp = tmp + x + "\r\n";
            attach_txt.Text = tmp;
        }
    }
}
