using Exam.classes;
using Exam.messageboxes;
using MySql.Data.MySqlClient;
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

namespace Exam
{
    public partial class Loginform : Form
    {
        Connexion connexion = new Connexion();
        MySqlDataAdapter dataadapter;
        DataTable datatable;
        public static string username;
        public Loginform()
        {
            InitializeComponent();
        }

        private void Loginform_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(450, 160);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {


            if (usernametxt.Text == "" || passwordtxt.Text == "")
            {
                MsgBoxFieldEmpty msg = new MsgBoxFieldEmpty();
                msg.Show();
            }
            else if (usernametxt.Text == "admin" && passwordtxt.Text == "admin")
            {
                 
                Form1 f = new Form1();
                f.Show();
                this.Hide();
               
            }
            else {
                 try
                  {
                      connexion.connexion();
                      connexion.connexOpen();
                      MySqlCommand cms = new MySqlCommand("select * from user where username = @username and password = @password", connexion.connMaster);
                      //cms.ExecuteNonQuery();
                      cms.Parameters.AddWithValue("@username", usernametxt.Text);
                      cms.Parameters.AddWithValue("@password", passwordtxt.Text);
                      MySqlDataAdapter da = new MySqlDataAdapter(cms);
                      DataTable datatable=new DataTable();
                      da.Fill(datatable);
                      if (datatable.Rows.Count > 0)
                      {
                        // MessageBox.Show("login successfull");
                        username = usernametxt.Text;
                        Loginform lg = new Loginform();
                       
                        FormUsers fus = new FormUsers();
                        
                        fus.Show();
                        lg.Close();
                       
                      }
                      else
                      {
                        Msguserorpassword userpas = new Msguserorpassword();
                        userpas.Show();
                         // MessageBox.Show("err");
                      }

                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show(ex.Message);
                  }
                

              
                
            }
            
        }
    }
}
