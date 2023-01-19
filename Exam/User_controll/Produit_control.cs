using Exam.classes;
using Exam.messageboxes;
using Google.Protobuf.WellKnownTypes;
using Guna.UI2.WinForms;
using Exam.classes;
using Exam.messageboxes;
using Google.Protobuf.WellKnownTypes;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Exam.User_controll
{
    public partial class Produit_control : UserControl
    {
        Connexion connexion = new Connexion();
        MySqlDataAdapter dataadapter;
        DataTable datatable;
        int currRowIndex;
        byte[] img;
        public Produit_control()
        {
            InitializeComponent();
            fillcategoriecombobox();
            fillfournisseurcombobox();
            afficher();

        }

        private void guna2DataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void fillcategoriecombobox() {
            categoriecombo.Items.Clear();
            connexion.connexion();
            connexion.connexOpen();
            MySqlCommand Command = new MySqlCommand("select libelle from categorie", connexion.connMaster);
            MySqlDataReader reader = Command.ExecuteReader();
            while (reader.Read()) {
                categoriecombo.Items.Add(reader.GetString("libelle"));
            }
            connexion.connexClose();

        }

        private void afficher()
        {
            // Connexion connexion = new Connexion();
            connexion.connexion();
            connexion.connexOpen();
            MySqlCommand Command = new MySqlCommand("select * from produit where quantity!=0", connexion.connMaster);
            Command.ExecuteNonQuery();
            datatable = new DataTable();
            dataadapter = new MySqlDataAdapter(Command);
            dataadapter.Fill(datatable);
            produittable.DataSource = datatable;
            connexion.connexClose();

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
        bool IsOnlyNumbers(string input)
        {
            // Regular expression pattern for checking only numbers
            string pattern = @"^\d+$";
            return Regex.IsMatch(input, pattern);
        }
        bool IsFutureDate(DateTime input)
        {
            return input > DateTime.Now;
        }
        private void fillfournisseurcombobox()
        {
            fournisseurcombo.Items.Clear();
            connexion.connexion();
            connexion.connexOpen();
            MySqlCommand Command = new MySqlCommand("select name from fournisseur", connexion.connMaster);
            MySqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                fournisseurcombo.Items.Add(reader.GetString("name"));
            }
            connexion.connexClose();

        }
        private void addbtn_Click(object sender, EventArgs e)
        {
            if (nomtxt.Text == "" || referencetxt.Text == "" || qttetxt.Text == "" || prixtxt.Text == "" || datepicker.Text == "" || produitimg.Image==null)
            {
                // DialogResult dialogClose = MessageBox.Show(" one of the fields is empty !!", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MsgBoxFieldEmpty msg = new MsgBoxFieldEmpty();
                msg.Show();
            }
            else if (!IsLettersAndNumbers(referencetxt.Text)) {
                DialogResult dialogClose = MessageBox.Show(" invalid reference format ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!IsFutureDate(datepicker.Value.Date))
            {
                DialogResult dialogClose = MessageBox.Show(" this product is expired ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!IsOnlyLetters(nomtxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid product name format ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!IsOnlyNumbers(qttetxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid quantity  format ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!IsOnlyNumbers(prixtxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid price  format ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {

                    byte[] image = img;

                    // Produit produit= new Produit(nomtxt.Text, double.Parse(prixtxt.ToString()), int.Parse(qttetxt.ToString()), referencetxt.Text,DateTime.Parse(datepicker.ToString()),categoriecombo.SelectedItem.ToString(),fournisseurcombo.SelectedItem.ToString(),image);
                    //  Produit produit = new Produit(nomtxt.Text, prixtxt.Text, qttetxt.Text, referencetxt.Text, DateTime.Parse(datepicker.ToString()), categoriecombo.Text.ToString(), fournisseurcombo.Text.ToString(), image);
                    Produit produit = new Produit(nomtxt.Text, Convert.ToInt32(prixtxt.Text), Convert.ToInt32(qttetxt.Text), referencetxt.Text, datepicker.Value.Date, categoriecombo.SelectedItem.ToString(), fournisseurcombo.SelectedItem.ToString(), image);
                    nomtxt.Clear();
                    prixtxt.Clear();
                    qttetxt.Clear();
                    referencetxt.Clear();
                    produitimg.Image = null;




                    connexion.connexion();
                    connexion.connexOpen();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO produit(name,price,quantity,reference,date_exp,categorie,fournisseur,image)" + "VALUES(@name,@price,@quantity,@reference,@date_exp,@categorie,@fournisseur,@image)", connexion.connMaster);
                    cmd.Parameters.AddWithValue("@name", produit.Name);
                    cmd.Parameters.AddWithValue("@price", produit.Price);
                    cmd.Parameters.AddWithValue("@quantity", produit.Qtte);
                    cmd.Parameters.AddWithValue("@reference", produit.Reference);
                    cmd.Parameters.AddWithValue("@date_exp", produit.Dateexp);
                    cmd.Parameters.AddWithValue("@categorie", produit.Categorie);
                    cmd.Parameters.AddWithValue("@fournisseur", produit.Fournisseur);
                    cmd.Parameters.AddWithValue("@image", produit.Image);

                    cmd.ExecuteNonQuery();
                    nomtxt.Clear();
                    prixtxt.Clear();
                    qttetxt.Clear();
                    referencetxt.Clear();
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

        private void categories(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Image image;
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                
                ofd.Filter = "All Files(*.jpg;*.png;*.gif;*.jpeg;*.pdf) | *.jpg;*.png;*.gif;*.jpeg;*.pdf";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    produitimg.Image = Image.FromFile(ofd.FileName);
                    produitimg.SizeMode = PictureBoxSizeMode.StretchImage;

                    image = Image.FromFile(ofd.FileName); ;
                    var ms = new MemoryStream();
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] i = ms.ToArray();
                    img = i;
                }
                else
                {

                }

            }
            catch (Exception ex)
            {

            }

        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            if (nomtxt.Text == "" || referencetxt.Text == "" || qttetxt.Text == "" || prixtxt.Text == "" || datepicker.Text == "" || produitimg.Image == null)
            {
                // DialogResult dialogClose = MessageBox.Show(" one of the fields is empty !!", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MsgBoxFieldEmpty msg = new MsgBoxFieldEmpty();
                msg.Show();
            }
            else if (!IsLettersAndNumbers(referencetxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid reference format ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!IsFutureDate(datepicker.Value.Date))
            {
                DialogResult dialogClose = MessageBox.Show(" this product is expired ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!IsOnlyLetters(nomtxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid product name format ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!IsOnlyNumbers(qttetxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid quantity  format ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!IsOnlyNumbers(prixtxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid price  format ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {

                    connexion.connexion();
                    connexion.connexOpen();
                    MySqlCommand cmd = new MySqlCommand("update produit set name=@name,price=@price,quantity=@quantity,reference=@reference,date_exp=@date_exp,categorie=@categorie,fournisseur=@fournisseur,image=@image where id=@id", connexion.connMaster);
                    cmd.Parameters.AddWithValue("@name", nomtxt.Text);

                    cmd.Parameters.AddWithValue("@price", prixtxt.Text);
                    cmd.Parameters.AddWithValue("@quantity", qttetxt.Text);
                    cmd.Parameters.AddWithValue("@reference", referencetxt.Text);
                    cmd.Parameters.AddWithValue("@date_exp", datepicker.Value.Date);
                    cmd.Parameters.AddWithValue("@categorie", categoriecombo.Text);
                    cmd.Parameters.AddWithValue("@fournisseur", fournisseurcombo.Text);
                    cmd.Parameters.AddWithValue("@image",saveimg() );
                    cmd.Parameters.AddWithValue("@id", currRowIndex);

                    cmd.ExecuteNonQuery();

                    afficher();
                    MsgBoxAddedsucc cmda = new MsgBoxAddedsucc();
                    cmda.Show();
                    nomtxt.Clear();
                    prixtxt.Clear();
                    qttetxt.Clear();
                    referencetxt.Clear();
                    produitimg.Image = null;
                    connexion.connexClose();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private Byte[] saveimg() { 
        MemoryStream ms = new MemoryStream();
            produitimg.Image.Save(ms, produitimg.Image.RawFormat);
            return ms.GetBuffer();
        }



        private void produittable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            DataGridViewRow row = this.produittable.Rows[e.RowIndex];
            currRowIndex = Convert.ToInt32(row.Cells[0].Value);
           nomtxt.Text = row.Cells[1].Value.ToString();
           prixtxt.Text = row.Cells[2].Value.ToString();
            qttetxt.Text = row.Cells[3].Value.ToString();
            referencetxt.Text = row.Cells[4].Value.ToString();
            datepicker.Text = row.Cells[5].Value.ToString();
            categoriecombo.SelectedItem = row.Cells[6].Value.ToString();
            fournisseurcombo.SelectedItem = row.Cells[7].Value.ToString();
            // produitimg.Image= row.Cells[8].Value.ToString();
            byte[] image = img = Encoding.ASCII.GetBytes(row.Cells[8].Value.ToString());
            if (image == null)
            {
               // produitimg = null;
                DialogResult dialogClose = MessageBox.Show("there is no image you idiot !!", "img error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                var data = (Byte[])(row.Cells[8].Value);
                var stream=new MemoryStream(data);
                produitimg.Image=Image.FromStream(stream);
               produitimg.SizeMode = PictureBoxSizeMode.Zoom;

            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogDelete = MessageBox.Show("do you really want to delete this Item??", "delete item ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogDelete == DialogResult.OK)
            {
                connexion.connexion();
                connexion.connexOpen();
                MySqlCommand cmd = new MySqlCommand("delete from produit where id=" + currRowIndex, connexion.connMaster);
                cmd.ExecuteNonQuery();
                afficher();
                nomtxt.Clear();
                prixtxt.Clear();
                qttetxt.Clear();
                referencetxt.Clear();
                produitimg.Image = null;
                connexion.connexClose();
            }

        }

        private void produit_load(object sender, EventArgs e)
        {
            searchData("");
        }
        public void searchData(string valuToFind)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from produit where CONCAT(name,price,categorie) LIKE '%" + valuToFind + "%' and quantity!=0", connexion.connMaster);
            datatable.Clear();
            adapter.Fill(datatable);
            produittable.DataSource = datatable;
        }

        private void searchproduit_TextChanged(object sender, EventArgs e)
        {
            searchData(searchproduit.Text);
        }


        private void printbtn_Click(object sender, EventArgs e)
        {

        }

       
        
    }
}
