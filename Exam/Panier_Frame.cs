using DGVPrinterHelper;
using Exam.classes;
using Exam.messageboxes;
using iTextSharp.text;
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
using Font = System.Drawing.Font;

namespace Exam
{
    public partial class Panier_Frame : Form
    {
        Connexion connexion = new Connexion();
        MySqlDataAdapter dataadapter;
        DataTable datatable;
        
        public Panier_Frame()
        {
            InitializeComponent();
            afficher();
            svgammount();
        }
        private void afficher()
        {
            
            // Connexion connexion = new Connexion();
            connexion.connexion();
            connexion.connexOpen();
            MySqlCommand Command = new MySqlCommand("select name,qty_commande,categorie,price from out_of_stock ", connexion.connMaster);
            Command.ExecuteNonQuery();
            datatable = new DataTable();
            dataadapter = new MySqlDataAdapter(Command);
            dataadapter.Fill(datatable);
            tablepanier.DataSource = datatable;
            connexion.connexClose();

        }

        private void svgammount()
        {
            connexion.connexion();
            connexion.connexOpen();
            MySqlCommand Command = new MySqlCommand("select sum(price*qty_commande) from out_of_stock", connexion.connMaster);
            // MySqlDataReader reader = Command.ExecuteReader();
            try
            {
                Int32 rows_c = Convert.ToInt32(Command.ExecuteScalar());
                // categoriecombo.Items.Add(reader.GetString("libelle"));


                connexion.connexClose();
                svglabel.Text = "" + rows_c.ToString();
            }
            catch (Exception ex) {
                MsgBasketempty msgb = new MsgBasketempty();
                msgb.Show();
            }
           
        }
        private void tablepanier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void submitorderbtn_Click(object sender, EventArgs e)
        {
            // DialogResult dialogDelete = MessageBox.Show("do you really want to delete this Item??", "delete item ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
           Msgordersubmitted msgq=new Msgordersubmitted();
            msgq.Show();
                connexion.connexion();
                connexion.connexOpen();
                MySqlCommand cmd = new MySqlCommand("delete from out_of_stock", connexion.connMaster);
                cmd.ExecuteNonQuery();
                afficher();
                svglabel.Text = "";
                connexion.connexClose();
            
        }

        private void guna2GradientButton9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panier_load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(450, 140);
        }

        private void printbtn_Click(object sender, EventArgs e)
        {
            /*   DGVPrinter printer = new DGVPrinter();
              connexion.connexion();
              connexion.connexOpen();
              MySqlCommand Command = new MySqlCommand("select sum(price*qty_commande) from out_of_stock", connexion.connMaster);
              Int32 rows_c = Convert.ToInt32(Command.ExecuteScalar());
              printer.Title = "Facture"+ rows_c.ToString(); 
                printer.SubTitle = String.Format(" Badr's para ", DateTime.Now.Date, printer.SubTitleColor = Color.Black, printer);
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
              e.Graphics.DrawString("Text to add", font, Brushes.Black, new PointF(100, tableBottomPosition + 50));

              printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = "merci pour votre visite";
                printer.FooterSpacing = 15;
                printer.PrintPreviewDataGridView(tablepanier);
             */
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();


        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("FACTURE", new Font("Arial", 20, FontStyle.Bold), Brushes.Blue, new Point(380, 10));
            e.Graphics.DrawString("Badr's para", new Font("Arial", 18, FontStyle.Bold), Brushes.Blue, new Point(10, 40));
          //  e.Graphics.DrawString("________________________________________________________________________________________", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(10, 90));
            e.Graphics.DrawString("nom".ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Gray, new Point(10, 150));
            e.Graphics.DrawString("| reference".ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Gray, new Point(100, 150));
            e.Graphics.DrawString("| prix".ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Gray, new Point(250, 150));
            e.Graphics.DrawString("| quantite".ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Gray, new Point(350, 150));
            e.Graphics.DrawString("| montant".ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Gray, new Point(500, 150));

            e.Graphics.DrawString("________________________________________________________________________________________", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(10, 180));
            connexion.connexion();
            connexion.connexOpen();
            MySqlCommand Command = new MySqlCommand("select name,reference,price,qty_commande,montant from out_of_stock", connexion.connMaster);
            MySqlCommand Commande = new MySqlCommand("select sum(price*qty_commande) from out_of_stock", connexion.connMaster);
            Int32 rows_c = Convert.ToInt32(Commande.ExecuteScalar());
            MySqlDataReader dr = Command.ExecuteReader();
            int i = 210;
            while (dr.Read())
            {

                e.Graphics.DrawString("_________________________________________________________________________________________________________", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(10, i));

                e.Graphics.DrawString(dr["name"].ToString(), new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(10, i + 3));
                e.Graphics.DrawString("|" + dr["reference"].ToString(), new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(100, i + 3));
                e.Graphics.DrawString("|" + dr["price"].ToString(), new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(250, i + 3));
                e.Graphics.DrawString("|" + dr["qty_commande"].ToString(), new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(350, i + 3));
                e.Graphics.DrawString("|" + dr["montant"].ToString(), new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(500, i + 3));
                i += 30;

            }
            svglabel.Text = "" + rows_c.ToString();
            e.Graphics.DrawString("total  " +" "+rows_c.ToString(), new Font("Arial", 20, FontStyle.Bold), Brushes.Red, new Point(450, i+10));
            e.Graphics.DrawString("Merci pour votre visite ", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, new Point(280, i+90));
            connexion.connexClose();
        }
    }
}
