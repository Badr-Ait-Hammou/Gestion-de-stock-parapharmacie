using Exam.classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam.User_controll
{
    public partial class Chart : UserControl
    {
        Connexion connexion = new Connexion();
        MySqlDataAdapter dataadapter;
        DataTable datatable;
        public Chart()
        {
            InitializeComponent();
            afficher();
        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {
            this.Show();
        }
        private void afficher()
        {
            // Connexion connexion = new Connexion();
            connexion.connexion();
            connexion.connexOpen();
            MySqlCommand Command = new MySqlCommand("SELECT * FROM produit WHERE DATE(date_exp) BETWEEN CURDATE() AND DATE_ADD(CURDATE(), INTERVAL 80 DAY)", connexion.connMaster);
            // MySqlCommand Command = new MySqlCommand("select * from commande", connexion.connMaster);
            Command.ExecuteNonQuery();
            datatable = new DataTable();
            dataadapter = new MySqlDataAdapter(Command);
            dataadapter.Fill(datatable);
            neartoexpirecmd.DataSource = datatable;
            //   datatable = datatable.DefaultView.ToTable(true, "id", "name", "price", "reference", "qty_commande", "date_commande", "categorie","fournisseur");
            connexion.connexClose();
        }
        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void neartoexpirecmd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
