using Exam.classes;
using Exam.messageboxes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam.User_controll
{
    public partial class Fabricants_control : UserControl
    {
        Connexion connexion=new Connexion();
        MySqlDataAdapter dataadapter;
        DataTable datatable;
        int currRowIndex;

        public Fabricants_control()
        {
            InitializeComponent();
            afficher();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

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
           // string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            return Regex.IsMatch(input, pattern);
        }
        private void afficher()
        {
            // Connexion connexion = new Connexion();
            connexion.connexion();
            connexion.connexOpen();
            MySqlCommand Command = new MySqlCommand("select * from fournisseur", connexion.connMaster);
            Command.ExecuteNonQuery();
            datatable = new DataTable();
            dataadapter = new MySqlDataAdapter(Command);
            dataadapter.Fill(datatable);
            fournisseurtable.DataSource = datatable;
            connexion.connexClose();

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (nomtxt.Text == "" || phonetxt.Text == "" || emailtxt.Text == "" || villefournistxt.Text == "" || descriptiontxt.Text == "")
            {
                // DialogResult dialogClose = MessageBox.Show(" one of the fields is empty !!", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MsgBoxFieldEmpty msg = new MsgBoxFieldEmpty();
                msg.Show();
            }
            else if (!IsLettersAndNumbers(nomtxt.Text)) {
                DialogResult dialogClose = MessageBox.Show(" invalid name format", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!IsValidPhoneNumber(phonetxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid phone number ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!IsValidEmail(emailtxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid email format ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!IsOnlyLetters(villefournistxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid city name  ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!IsLettersAndNumbers(descriptiontxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid description format ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {

                    Fournisseur fourniseur = new Fournisseur(nomtxt.Text, emailtxt.Text, phonetxt.Text, villefournistxt.Text, descriptiontxt.Text);

                    nomtxt.Clear();
                    emailtxt.Clear();
                    phonetxt.Clear();
                    villefournistxt.Clear();
                    descriptiontxt.Clear();


                    connexion.connexion();
                    connexion.connexOpen();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO fournisseur(name,email,phone,city,description)" + "VALUES(@name,@email,@phone,@city,@description)", connexion.connMaster);
                    cmd.Parameters.AddWithValue("@name", fourniseur.Name);
                    cmd.Parameters.AddWithValue("@email", fourniseur.Email);
                    cmd.Parameters.AddWithValue("@phone", fourniseur.Phone);
                    cmd.Parameters.AddWithValue("@city", fourniseur.City);
                    cmd.Parameters.AddWithValue("@description", fourniseur.Description);
                    cmd.ExecuteNonQuery();
                    nomtxt.Clear();
                    emailtxt.Clear();
                    phonetxt.Clear();
                    villefournistxt.Clear();
                    descriptiontxt.Clear();
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
            if (nomtxt.Text == "" || phonetxt.Text == "" || emailtxt.Text == "" || villefournistxt.Text == "" || descriptiontxt.Text == "")
            {
                MsgBoxFieldEmpty msg = new MsgBoxFieldEmpty();
                msg.Show();
            }
            else if (!IsLettersAndNumbers(nomtxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid name format", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!IsValidPhoneNumber(phonetxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid phone number ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!IsValidEmail(emailtxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid email format ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!IsOnlyLetters(villefournistxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid city name  ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!IsLettersAndNumbers(descriptiontxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid description format ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    connexion.connexion();
                    connexion.connexOpen();
                    MySqlCommand cmd = new MySqlCommand("update fournisseur set name=@name,email=@email,phone=@phone,city=@city,description=@description where id=@id", connexion.connMaster);
                    cmd.Parameters.AddWithValue("@name", nomtxt.Text);
                    cmd.Parameters.AddWithValue("@email", emailtxt.Text);
                    cmd.Parameters.AddWithValue("@phone", phonetxt.Text);
                    cmd.Parameters.AddWithValue("@city", villefournistxt.Text);
                    cmd.Parameters.AddWithValue("@description", descriptiontxt.Text);
                    cmd.Parameters.AddWithValue("@id", currRowIndex);
                    cmd.ExecuteNonQuery();
                    afficher();
                    MsgBoxAddedsucc cmda = new MsgBoxAddedsucc();
                    cmda.Show();

                    nomtxt.Clear();
                    emailtxt.Clear();
                    phonetxt.Clear();
                    villefournistxt.Clear();
                    descriptiontxt.Clear();
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
                MySqlCommand cmd = new MySqlCommand("delete from fournisseur where id=" + currRowIndex, connexion.connMaster);
                cmd.ExecuteNonQuery();
                afficher();
                nomtxt.Clear();
                emailtxt.Clear();
                phonetxt.Clear();
                villefournistxt.Clear();
                descriptiontxt.Clear();
                connexion.connexClose();
            }
        }

        private void fournisseurtable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.fournisseurtable.Rows[e.RowIndex];
            currRowIndex = Convert.ToInt32(row.Cells[0].Value);
            nomtxt.Text = row.Cells[1].Value.ToString();
            emailtxt.Text = row.Cells[2].Value.ToString();
            phonetxt.Text = row.Cells[3].Value.ToString();
            villefournistxt.Text = row.Cells[4].Value.ToString();
            descriptiontxt.Text = row.Cells[5].Value.ToString();
        }
    }
}
