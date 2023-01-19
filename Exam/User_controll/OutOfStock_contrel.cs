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


namespace Exam.User_controll
{
    public partial class OutOfStock_contrel : UserControl
    {
        Connexion connexion = new Connexion();
        MySqlDataAdapter dataadapter;
        DataTable datatable;
        int currRowIndex;

        public OutOfStock_contrel()
        {
            InitializeComponent();
            afficher();
           
        }
        private void afficher()
        {
            // Connexion connexion = new Connexion();
            connexion.connexion();
            connexion.connexOpen();
            MySqlCommand Command = new MySqlCommand("select id,name,price,quantity,reference,date_exp,categorie,fournisseur from produit where quantity=0 ", connexion.connMaster);
           //  MySqlCommand cmddel = new MySqlCommand("delete  from produit where quantity=0", connexion.connMaster);
            Command.ExecuteNonQuery();
           // cmddel.ExecuteNonQuery();
            datatable = new DataTable();
            dataadapter = new MySqlDataAdapter(Command);
            dataadapter.Fill(datatable);
            outstocktable.DataSource = datatable;
            //   datatable = datatable.DefaultView.ToTable(true, "id", "name", "price", "reference", "qty_commande", "date_commande", "categorie","fournisseur");
            connexion.connexClose();
        }
        private void find_out(object sender, EventArgs e)
        {
           
        }


        private void searchproduit_TextChanged(object sender, EventArgs e)
        {
        }

        private void outstocktable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.outstocktable.Rows[e.RowIndex];
            currRowIndex = Convert.ToInt32(row.Cells[0].Value);
           
            qttetxt.Text = row.Cells[3].Value.ToString();
          
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            if ( qttetxt.Text == "")
            {
                // DialogResult dialogClose = MessageBox.Show(" one of the fields is empty !!", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MsgBoxFieldEmpty msg = new MsgBoxFieldEmpty();
                msg.Show();
            }
            else
            {
                try
                {

                    connexion.connexion();
                    connexion.connexOpen();
                    MySqlCommand cmd = new MySqlCommand("update produit set quantity=@quantity where id=@id", connexion.connMaster);
              
                    cmd.Parameters.AddWithValue("@quantity", qttetxt.Text);
                    cmd.Parameters.AddWithValue("@id", currRowIndex);

                    cmd.ExecuteNonQuery();

                    afficher();
                    MsgBoxAddedsucc cmda = new MsgBoxAddedsucc();
                    cmda.Show();
                   
                    qttetxt.Clear();
              
                    connexion.connexClose();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

       
    }
}
