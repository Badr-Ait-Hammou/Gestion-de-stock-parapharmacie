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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam.User_controll
{
    public partial class Commandes_control : UserControl
    {
        Connexion connexion=new Connexion();
        MySqlDataAdapter dataadapter;
        DataTable datatable;
        int currRowIndex;
        byte[] img;
        public Commandes_control()
        {
            InitializeComponent();
           // fillcategoriecombobox();
           // fillfournisseurcombobox();
            afficher();
            
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
            commandetable.DataSource = datatable;
            connexion.connexClose();

        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            List_Des_Commande ls= new List_Des_Commande();
            ls.Show();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

       /* private void fillcategoriecombobox()
        {
            categoriecombo.Items.Clear();
            connexion.connexion();
            connexion.connexOpen();
            MySqlCommand Command = new MySqlCommand("select libelle from categorie", connexion.connMaster);
            MySqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                categoriecombo.Items.Add(reader.GetString("libelle"));
            }
            connexion.connexClose();

        }*/

       /* private void fillfournisseurcombobox()
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

        }*/

        private void addbtn_Click(object sender, EventArgs e)
        {

           

        }
        private void find_load(object sender, EventArgs e)
        {
            searchData("");
        }

        public void searchData(string valuToFind) {
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from produit where CONCAT(name,price,categorie) LIKE '%"+valuToFind+"%' and quantity!=0", connexion.connMaster);
            datatable.Clear();
            adapter.Fill(datatable);
            commandetable.DataSource=datatable;
        }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            searchData(guna2TextBox1.Text);
        }

        private void commandetable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.commandetable.Rows[e.RowIndex];
            currRowIndex = Convert.ToInt32(row.Cells[0].Value);
            nomtxt.Text = row.Cells[1].Value.ToString();
            prixtxt.Text = row.Cells[2].Value.ToString();
            qtytxt.Text = row.Cells[3].Value.ToString();
            referencetxt.Text = row.Cells[4].Value.ToString();
            dateexp.Text = row.Cells[5].Value.ToString();
           // dateexptextbox.Text = row.Cells[5].Value.ToString();
         //   categoriecombo.SelectedItem = row.Cells[6].Value.ToString();
            categorietextbox.Text= row.Cells[6].Value.ToString();
           // fournisseurcombo.SelectedItem = row.Cells[7].Value.ToString();
            fournisseurtextbox.Text = row.Cells[7].Value.ToString();
            // produitimg.Image= row.Cells[8].Value.ToString();
            byte[] image = img = Encoding.ASCII.GetBytes(row.Cells[8].Value.ToString());
            if (image == null)
            {
                produitimg = null;
            }
            else
            {
                var data = (Byte[])(row.Cells[8].Value);
                var stream = new MemoryStream(data);
                produitimg.Image = Image.FromStream(stream);
                produitimg.SizeMode = PictureBoxSizeMode.StretchImage;


            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

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
            return input > DateTime.Now ;
        }

        private void addbtn_Click_1(object sender, EventArgs e)
        {
            if (nomtxt.Text == "" || referencetxt.Text == "" || qtytxt.Text == "" || prixtxt.Text == "" || dateexp.Text == "" || qtycommandetxt.Text == "")
            {
                MsgBoxFieldEmpty msg = new MsgBoxFieldEmpty();
                msg.Show();
            } else if (!IsOnlyNumbers(qtycommandetxt.Text)) {
                DialogResult dialogClose = MessageBox.Show(" invalid quantity format ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (!IsFutureDate(datecommande.Value.Date))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid order date ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                try
                {

                    byte[] image = img;
                    int stock = 0;
                    int qtt_cmd = 0;
                    int new_stock = 0;
                    int price_cmd = 0;
                    int montant = 0;

                    stock = Convert.ToInt32(qtytxt.Text);
                    qtt_cmd = Convert.ToInt32(qtycommandetxt.Text);
                    price_cmd = Convert.ToInt32(prixtxt.Text);
                    montant = qtt_cmd * price_cmd;
                    Commande commande = new Commande(nomtxt.Text, Convert.ToInt32(prixtxt.Text), Convert.ToInt32(qtycommandetxt.Text), referencetxt.Text, dateexp.Value.Date, datecommande.Value.Date, categorietextbox.Text, fournisseurtextbox.Text, montant, image);
                    nomtxt.Clear();
                    prixtxt.Clear();
                    qtycommandetxt.Clear();
                    referencetxt.Clear();
                    fournisseurtextbox.Clear();
                    categorietextbox.Clear();
                    qtytxt.Clear();
                    connexion.connexion();
                    connexion.connexOpen();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO commande(name,price,qty_commande,reference,date_exp,date_commande,categorie,fournisseur,montant,image)" + "VALUES(@name,@price,@qty_commande,@reference,@date_exp,@date_commande,@categorie,@fournisseur,@montant,@image)", connexion.connMaster);
                    new_stock = stock - qtt_cmd;



                    if (new_stock < 0)
                    {
                        MsgBoxQtygreaterthanstock msgg = new MsgBoxQtygreaterthanstock();
                        msgg.Show();
                    }
                    else if (qtt_cmd == 0)
                    {
                        MsgBoxcannotbezeroq msgz = new MsgBoxcannotbezeroq();
                        msgz.Show();
                    }
                    else
                    {
                        MySqlCommand cmdu = new MySqlCommand("update produit set quantity ='" + new_stock + "' where id='" + currRowIndex + "'", connexion.connMaster);
                        cmd.Parameters.AddWithValue("@name", commande.Name);
                        cmd.Parameters.AddWithValue("@price", commande.Price);
                        cmd.Parameters.AddWithValue("@qty_commande", commande.Qtte);
                        cmd.Parameters.AddWithValue("@reference", commande.Reference);
                        cmd.Parameters.AddWithValue("@date_exp", commande.Dateexp);
                        cmd.Parameters.AddWithValue("@date_commande", commande.Datecmd);
                        cmd.Parameters.AddWithValue("@categorie", commande.Categorie);
                        cmd.Parameters.AddWithValue("@fournisseur", commande.Fournisseur);
                        cmd.Parameters.AddWithValue("@montant", commande.Total);
                        cmd.Parameters.AddWithValue("@image", commande.Image);
                        cmd.ExecuteNonQuery();
                        cmdu.ExecuteNonQuery();
                        nomtxt.Clear();
                        prixtxt.Clear();
                        qtycommandetxt.Clear();
                        referencetxt.Clear();
                        guna2TextBox1.Clear();
                        qtytxt.Clear();
                        produitimg.Image = null;

                        connexion.connexClose();
                        afficher();

                        Msgordersubmitted msgs = new Msgordersubmitted();
                        msgs.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        
        }

        private void addpanier_Click(object sender, EventArgs e)
        {

            if (nomtxt.Text == "" || referencetxt.Text == "" || qtytxt.Text == "" || prixtxt.Text == "" || dateexp.Text == "" || qtycommandetxt.Text == "")
            {
                // DialogResult dialogClose = MessageBox.Show(" one of the fields is empty !!", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MsgBoxFieldEmpty msg = new MsgBoxFieldEmpty();
                msg.Show();
            }
            else if (!IsOnlyNumbers(qtycommandetxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid quantity format ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (!IsFutureDate(datecommande.Value.Date))
            {
                DialogResult dialogClose = MessageBox.Show("  invalid order date ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                try
                {

                    byte[] image = img;
                    int stock = 0;
                    int qtt_cmd = 0;
                    int new_stock = 0;
                    int price_cmd = 0;
                    int montant = 0;

                    stock = Convert.ToInt32(qtytxt.Text);
                    qtt_cmd = Convert.ToInt32(qtycommandetxt.Text);
                    price_cmd = Convert.ToInt32(prixtxt.Text);
                    montant = qtt_cmd * price_cmd;

                    // Produit produit= new Produit(nomtxt.Text, double.Parse(prixtxt.ToString()), int.Parse(qttetxt.ToString()), referencetxt.Text,DateTime.Parse(datepicker.ToString()),categoriecombo.SelectedItem.ToString(),fournisseurcombo.SelectedItem.ToString(),image);
                    //  Produit produit = new Produit(nomtxt.Text, prixtxt.Text, qttetxt.Text, referencetxt.Text, DateTime.Parse(datepicker.ToString()), categoriecombo.Text.ToString(), fournisseurcombo.Text.ToString(), image);
                    // Commande commande = new Commande(nomtxt.Text, Convert.ToInt32(prixtxt.Text), Convert.ToInt32(qtycommandetxt.Text), referencetxt.Text, dateexp.Value.Date,datecommande.Value.Date, categoriecombo.SelectedItem.ToString(), fournisseurcombo.SelectedItem.ToString(), image);
                    // Commande commande = new Commande(nomtxt.Text, Convert.ToInt32(prixtxt.Text), Convert.ToInt32(qtycommandetxt.Text), referencetxt.Text, dateexp.Value.Date, datecommande.Value.Date, categorietextbox.Text, fournisseurtextbox.Text, image);
                    Basket basket = new Basket(nomtxt.Text, Convert.ToInt32(prixtxt.Text), Convert.ToInt32(qtycommandetxt.Text), referencetxt.Text, dateexp.Value.Date, datecommande.Value.Date, categorietextbox.Text, fournisseurtextbox.Text,montant, image);
                    Commande commande = new Commande(nomtxt.Text, Convert.ToInt32(prixtxt.Text), Convert.ToInt32(qtycommandetxt.Text), referencetxt.Text, dateexp.Value.Date, datecommande.Value.Date, categorietextbox.Text, fournisseurtextbox.Text, montant, image);

                    nomtxt.Clear();
                    prixtxt.Clear();
                    qtycommandetxt.Clear();
                    referencetxt.Clear();
                    fournisseurtextbox.Clear();
                    categorietextbox.Clear();
                    qtytxt.Clear();
                    connexion.connexion();
                    connexion.connexOpen();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO out_of_stock(name,price,qty_commande,reference,date_exp,date_commande,categorie,fournisseur,montant,image)" + "VALUES(@name,@price,@qty_commande,@reference,@date_exp,@date_commande,@categorie,@fournisseur,@montant,@image)", connexion.connMaster);
                    MySqlCommand cmdcmd = new MySqlCommand("INSERT INTO commande(name,price,qty_commande,reference,date_exp,date_commande,categorie,fournisseur,montant,image)" + "VALUES(@name,@price,@qty_commande,@reference,@date_exp,@date_commande,@categorie,@fournisseur,@montant,@image)", connexion.connMaster);

                    new_stock = stock - qtt_cmd;
                    if (new_stock < 0)
                    {
                        MsgBoxQtygreaterthanstock msgg = new MsgBoxQtygreaterthanstock();
                        msgg.Show();
                    }
                    else if (qtt_cmd == 0)
                    {
                        MsgBoxcannotbezeroq msgz = new MsgBoxcannotbezeroq();
                        msgz.Show();
                    }
                    else
                    {
                        MySqlCommand cmdu = new MySqlCommand("update produit set quantity ='" + new_stock + "' where id='" + currRowIndex + "'", connexion.connMaster);
                        //MySqlCommand cmdpanier = new MySqlCommand("INSERT INTO out_of_stock(name,price,qty_commande,reference,date_exp,date_commande,categorie,fournisseur,image)" + "VALUES(@name,@price,@qty_commande,@reference,@date_exp,@date_commande,@categorie,@fournisseur,@image)", connexion.connMaster);
                        cmd.Parameters.AddWithValue("@name", basket.Name);
                        cmd.Parameters.AddWithValue("@price", basket.Price);
                        cmd.Parameters.AddWithValue("@qty_commande", basket.Qtte);
                        cmd.Parameters.AddWithValue("@reference", basket.Reference);
                        cmd.Parameters.AddWithValue("@date_exp", basket.Dateexp);
                        cmd.Parameters.AddWithValue("@date_commande", basket.Datecmd);
                        cmd.Parameters.AddWithValue("@categorie", basket.Categorie);
                        cmd.Parameters.AddWithValue("@fournisseur", basket.Fournisseur);
                        cmd.Parameters.AddWithValue("@montant", basket.Ammount);
                        cmd.Parameters.AddWithValue("@image", basket.Image);

                        cmdcmd.Parameters.AddWithValue("@name", commande.Name);
                        cmdcmd.Parameters.AddWithValue("@price", commande.Price);
                        cmdcmd.Parameters.AddWithValue("@qty_commande", commande.Qtte);
                        cmdcmd.Parameters.AddWithValue("@reference", commande.Reference);
                        cmdcmd.Parameters.AddWithValue("@date_exp", commande.Dateexp);
                        cmdcmd.Parameters.AddWithValue("@date_commande", commande.Datecmd);
                        cmdcmd.Parameters.AddWithValue("@categorie", commande.Categorie);
                        cmdcmd.Parameters.AddWithValue("@fournisseur", commande.Fournisseur);
                        cmdcmd.Parameters.AddWithValue("@montant", commande.Total);
                        cmdcmd.Parameters.AddWithValue("@image", commande.Image);

                        cmd.ExecuteNonQuery();
                        // cmdpanier.ExecuteNonQuery();
                        cmdcmd.ExecuteNonQuery();
                        cmdu.ExecuteNonQuery();
                        nomtxt.Clear();
                        prixtxt.Clear();
                        qtycommandetxt.Clear();
                        referencetxt.Clear();
                        guna2TextBox1.Clear();
                        qtytxt.Clear();
                        produitimg.Image = null;

                        connexion.connexClose();
                        afficher();

                       Msgaddedtobasket msgs = new Msgaddedtobasket();
                        msgs.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void showpanier_Click(object sender, EventArgs e)
        {
            Panier_Frame pf = new Panier_Frame();
            pf.Show();
            
        }
    }
}
