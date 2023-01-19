using Exam.classes;
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

namespace Exam.User_controll
{
    public partial class Dashboard : UserControl
    {
        Connexion connexion = new Connexion();
        MySqlDataAdapter dataadapter;
        DataTable datatable;
        public Dashboard()
        {
            InitializeComponent();
            countproducts();
            countorders();
            countcategories();
            countuser();
            fillchart();
            fillchart1();
            
        }
        private void countproducts() {
            connexion.connexion();
            connexion.connexOpen();
            MySqlCommand Command = new MySqlCommand("select count(id) from produit", connexion.connMaster);
           // MySqlDataReader reader = Command.ExecuteReader();
           Int32 rows_c=Convert.ToInt32(Command.ExecuteScalar());
              // categoriecombo.Items.Add(reader.GetString("libelle"));
              
            
            connexion.connexClose();
            label1.Text = "" + rows_c.ToString();
        }

        private void countorders()
        {
            connexion.connexion();
            connexion.connexOpen();
            MySqlCommand Command = new MySqlCommand("select count(id) from commande", connexion.connMaster);
            // MySqlDataReader reader = Command.ExecuteReader();
            Int32 rows_c = Convert.ToInt32(Command.ExecuteScalar());
            // categoriecombo.Items.Add(reader.GetString("libelle"));


            connexion.connexClose();
            label4.Text = "" + rows_c.ToString();
        }

        private void countcategories()
        {
            connexion.connexion();
            connexion.connexOpen();
            MySqlCommand Command = new MySqlCommand("select count(id) from categorie", connexion.connMaster);
            // MySqlDataReader reader = Command.ExecuteReader();
            Int32 rows_c = Convert.ToInt32(Command.ExecuteScalar());
            // categoriecombo.Items.Add(reader.GetString("libelle"));


            connexion.connexClose();
            label6.Text = "" + rows_c.ToString();
        }

        private void countuser()
        {
            connexion.connexion();
            connexion.connexOpen();
            MySqlCommand Command = new MySqlCommand("select count(id) from user", connexion.connMaster);
            // MySqlDataReader reader = Command.ExecuteReader();
            Int32 rows_c = Convert.ToInt32(Command.ExecuteScalar());
            // categoriecombo.Items.Add(reader.GetString("libelle"));


            connexion.connexClose();
            label8.Text = "" + rows_c.ToString();
        }
        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fillchart() {
            connexion.connexion();
           // connexion.connexOpen();
            MySqlCommand cmd = new MySqlCommand("select * from produit",connexion.connMaster);
            MySqlDataReader myreader;
            try
            {
                connexion.connexOpen();
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    this.productschart.Series["Quantité"].Points.AddXY(myreader.GetString("name"), myreader.GetInt32("quantity"));

                }
            }
            catch (Exception ex) { 
            MessageBox.Show(ex.Message);
            }
        }
        private void fillchart1()
        {
            connexion.connexion();
            // connexion.connexOpen();
            MySqlCommand cmd = new MySqlCommand("select * from commande", connexion.connMaster);
            MySqlDataReader myreader;
            try
            {
                connexion.connexOpen();
                myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    // this.commandechart.Series["Commande"].Points.AddXY(myreader.GetString("date_commande"), myreader.GetInt32("qty_commande"));
                    DateTime date = DateTime.Parse(myreader.GetString("date_commande"));
                    int year = date.Year;
                    int month = date.Month;
                    int day = date.Day;

                    string year_month = day +"/" +month + "/" + year;
                    this.commandechart.Series["Commande"].Points.AddXY(year_month, myreader.GetInt32("qty_commande"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CustomGradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
