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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Exam.User_controll
{
    public partial class Users_control : UserControl
    {
        Connexion connexion=new Connexion();
        MySqlDataAdapter dataadapter;
        DataTable datatable;
        int currRowIndex;
        public Users_control()
        {
            InitializeComponent();
            afficher();
           
         
        }

        private void guna2HtmlLabel9_Click(object sender, EventArgs e)
        {

        }

       
        private void afficher()
        {
            // Connexion connexion = new Connexion();
            connexion.connexion();
            connexion.connexOpen();
            MySqlCommand Command = new MySqlCommand("select * from user", connexion.connMaster);
            Command.ExecuteNonQuery();
            datatable = new DataTable();
            dataadapter = new MySqlDataAdapter(Command);
            dataadapter.Fill(datatable);
            usertable.DataSource = datatable;
            connexion.connexClose();

        }
        bool IsValidEmail(string email)
        {
            // Regular expression pattern for a valid email address
            string pattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";
            return Regex.IsMatch(email, pattern);
        }
        bool IsValidPhoneNumber(string phoneNumber)
        {
            // Regular expression pattern for a valid phone number
            string pattern = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
            return Regex.IsMatch(phoneNumber, pattern);
        }
        bool IsValidFormat(string input)
        {
            // Regular expression pattern for a specific format
            string pattern = @"^[a-z]$";
            return Regex.IsMatch(input, pattern);
        }
        bool IsOnlyLetters(string input)
        {
            // Regular expression pattern for checking only letters
            string pattern = @"^[a-zA-Z]+$";
            return Regex.IsMatch(input, pattern);
        }
        bool IsLettersAndNumbers(string input)
        {
            // Regular expression pattern for checking only letters and numbers
            string pattern = @"^[a-zA-Z0-9]+$";
            return Regex.IsMatch(input, pattern);
        }
        bool IsValidPassword(string password)
        {
            // Regular expression pattern for a strong password
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            return Regex.IsMatch(password, pattern);
        }
        private void addbtn_Click(object sender, EventArgs e)
        {
            

            if (usernametxt.Text == "" || prenomtxt.Text == "" || nomtxt.Text == "" || emailtxt.Text == "" || phonetxt.Text == "" || passwordtxt.Text == "")
            {
                // DialogResult dialogClose = MessageBox.Show(" one of the fields is empty !!", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MsgBoxFieldEmpty msg = new MsgBoxFieldEmpty();
                msg.Show();

            }

            else if (!IsValidEmail(emailtxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid email ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (!IsValidPhoneNumber(phonetxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid phone number ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (!IsOnlyLetters(usernametxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid username format ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (!IsOnlyLetters(prenomtxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid first_name format ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (!IsOnlyLetters(nomtxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid last_name format ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (!IsValidPassword(passwordtxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" password must contain letters and numbers and >8 ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            else
            {
                try
                {

                    User user = new User(usernametxt.Text, prenomtxt.Text, nomtxt.Text, emailtxt.Text, phonetxt.Text, passwordtxt.Text);

                    nomtxt.Clear();
                    emailtxt.Clear();
                    phonetxt.Clear();
                    usernametxt.Clear();
                    prenomtxt.Clear();
                    nomtxt.Clear();
                    emailtxt.Clear();
                    phonetxt.Clear();
                    passwordtxt.Clear();
                    

                    connexion.connexion();
                    connexion.connexOpen();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO user(username,first_name,last_name,email,phone,password)" + "VALUES(@username,@first_name,@last_name,@email,@phone,@password)", connexion.connMaster);
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@first_name", user.First_name);
                    cmd.Parameters.AddWithValue("@last_name", user.Last_name);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@phone", user.Phone);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.ExecuteNonQuery();
                    nomtxt.Clear();
                    prenomtxt.Clear();
                    emailtxt.Clear();
                    phonetxt.Clear();
                    usernametxt.Clear();
                    prenomtxt.Clear();
                    passwordtxt.Clear();
                    confirmationtxt.Clear();
                    connexion.connexClose();
                    afficher();

                    MsgBoxAddedsucc msga = new MsgBoxAddedsucc();
                    msga.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            if (usernametxt.Text == "" || prenomtxt.Text == "" || nomtxt.Text == "" || emailtxt.Text == "" || phonetxt.Text == "" || passwordtxt.Text == "")
            {
                MsgBoxFieldEmpty msg = new MsgBoxFieldEmpty();
                msg.Show();
            }
           
            else if (!IsValidEmail(emailtxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid email ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (!IsValidPhoneNumber(phonetxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid phone number ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (!IsOnlyLetters(usernametxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid username format ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (!IsOnlyLetters(prenomtxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid first_name format ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (!IsOnlyLetters(nomtxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid last_name format ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (!IsValidPassword(passwordtxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" password must contain letters and numbers and >8 ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            else if (passwordtxt.Text != confirmationtxt.Text)
            {
                DialogResult dialogClose = MessageBox.Show(" confirm password you idiot!!", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                try
                {
                    connexion.connexion();
                    connexion.connexOpen();
                    MySqlCommand cmd = new MySqlCommand("update user set username=@username,first_name=@first_name,last_name=@last_name,email=@email,phone=@phone,password=@password where id=@id", connexion.connMaster);
                    cmd.Parameters.AddWithValue("@username", usernametxt.Text);
                    cmd.Parameters.AddWithValue("@first_name", prenomtxt.Text);
                    cmd.Parameters.AddWithValue("@last_name", nomtxt.Text);
                    cmd.Parameters.AddWithValue("@email", emailtxt.Text);
                    cmd.Parameters.AddWithValue("@phone", phonetxt.Text);
                    cmd.Parameters.AddWithValue("@password", passwordtxt.Text);
                    cmd.Parameters.AddWithValue("@id", currRowIndex);
                    cmd.ExecuteNonQuery();
                    afficher();
                    MsgBoxAddedsucc cmda = new MsgBoxAddedsucc();
                    cmda.Show();

                    nomtxt.Clear();
                    prenomtxt.Clear();
                    emailtxt.Clear();
                    phonetxt.Clear();
                    usernametxt.Clear();
                    prenomtxt.Clear();
                    passwordtxt.Clear();
                    confirmationtxt.Clear();
                    connexion.connexClose();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogDelete = MessageBox.Show("do you really want to delete this Item??", "delete item ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogDelete == DialogResult.OK)
            {
                connexion.connexion();
                connexion.connexOpen();
                MySqlCommand cmd = new MySqlCommand("delete from user where id=" + currRowIndex, connexion.connMaster);
                cmd.ExecuteNonQuery();
                afficher();
                nomtxt.Clear();
                prenomtxt.Clear();
                emailtxt.Clear();
                phonetxt.Clear();
                usernametxt.Clear();
                prenomtxt.Clear();
                passwordtxt.Clear();
                confirmationtxt.Clear();
                connexion.connexClose();
            }
        }

        private void usertable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.usertable.Rows[e.RowIndex];
            currRowIndex = Convert.ToInt32(row.Cells[0].Value);
            usernametxt.Text = row.Cells[1].Value.ToString();
            prenomtxt.Text = row.Cells[2].Value.ToString();
            nomtxt.Text = row.Cells[3].Value.ToString();
            emailtxt.Text = row.Cells[4].Value.ToString();  
            phonetxt.Text = row.Cells[5].Value.ToString();
            passwordtxt.Text = row.Cells[6].Value.ToString();
        }

        private void user_load(object sender, EventArgs e)
        {
            searchData("");
        }
        public void searchData(string valuToFind)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from user where CONCAT(first_name,phone,username) LIKE '%" + valuToFind + "%'", connexion.connMaster);
            datatable.Clear();
            adapter.Fill(datatable);
            usertable.DataSource = datatable;
        }
       

        private void cmdsearch_TextChanged(object sender, EventArgs e)
        {
            searchData(cmdsearch.Text);
        }
    }
}
