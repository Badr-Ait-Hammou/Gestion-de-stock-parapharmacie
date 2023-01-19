using DGVPrinterHelper;
using Exam.classes;
using Guna.UI2.WinForms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Font = System.Drawing.Font;

namespace Exam.User_controll
{
    public partial class List_Des_Commande : UserControl
    {
        Connexion connexion = new Connexion();
        MySqlDataAdapter dataadapter;
        DataTable datatable;
        byte[] img;
        int currRowIndex;
        public List_Des_Commande()
        {
            InitializeComponent();
            afficher();
        }


        public void searchData(string valuToFind)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter("select  id,name,price,reference,qty_commande,date_commande,montant from commande where CONCAT(name,price,categorie,date_commande,reference,montant) LIKE '%" + valuToFind + "%'", connexion.connMaster);
            datatable.Clear();
            adapter.Fill(datatable);
            listcommandetable.DataSource = datatable;
        }
        private void serach_load(object sender, EventArgs e)
        {
            searchData("");
        }

        private void cmdsearch_TextChanged(object sender, EventArgs e)
        {
            searchData(cmdsearch.Text);
        }


        private void afficher()
        {
            // Connexion connexion = new Connexion();
            connexion.connexion();
            connexion.connexOpen();
            MySqlCommand Command = new MySqlCommand("select id,name,price,reference,qty_commande,date_commande,montant from commande", connexion.connMaster);
           // MySqlCommand Command = new MySqlCommand("select * from commande", connexion.connMaster);
            Command.ExecuteNonQuery();
            datatable = new DataTable();
            dataadapter = new MySqlDataAdapter(Command);
            dataadapter.Fill(datatable);
            listcommandetable.DataSource = datatable;
         //   datatable = datatable.DefaultView.ToTable(true, "id", "name", "price", "reference", "qty_commande", "date_commande", "categorie","fournisseur");
            connexion.connexClose();
        }
            private void listcommandetable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.listcommandetable.Rows[e.RowIndex];
            currRowIndex = Convert.ToInt32(row.Cells[0].Value);
        }

        




        private void printbtn_Click(object sender, EventArgs e)
        {
             /* DGVPrinter printer = new DGVPrinter();

               printer.Title = "Liste Des Commandes";
               printer.SubTitle = String.Format(" Badr's parapharmacy ", DateTime.Now.Date, printer.SubTitleColor = Color.Black, printer);
               printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
               printer.PageNumbers = true;
               printer.PageNumberInHeader = false;
               //  printer.PrintMargins = null;

               printer.PorportionalColumns = true;
               printer.HeaderCellAlignment = StringAlignment.Near;
               printer.Footer = "Badr's parapharmacy";
               printer.FooterSpacing = 15;
               printer.PrintPreviewDataGridView(listcommandetable);
            */

            if (listcommandetable.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                //   sfd.FileName = "Output.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {


                            PdfPTable pdfTable = new PdfPTable(listcommandetable.Columns.Count);

                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            for (int i = 0; i < listcommandetable.ColumnCount; i++)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(listcommandetable.Columns[i].HeaderText));
                                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                                pdfTable.AddCell(cell);
                            }

                            //Add the rows of the DataGridView to the table
                            for (int i = 0; i < listcommandetable.Rows.Count; i++)
                            {
                                for (int j = 0; j < listcommandetable.Columns.Count; j++)
                                {
                                    if (listcommandetable.Rows[i].Cells[j].Value != null)
                                    {
                                        pdfTable.AddCell(listcommandetable.Rows[i].Cells[j].Value.ToString());
                                    }
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A3, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Data Exported Successfully !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }

            

        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogDelete = MessageBox.Show("do you really want to delete this Item??", "delete item ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogDelete == DialogResult.OK)
            {
                connexion.connexion();
                connexion.connexOpen();
                MySqlCommand cmd = new MySqlCommand("delete from commande where id=" + currRowIndex, connexion.connMaster);
                cmd.ExecuteNonQuery();
                afficher();
               
                connexion.connexClose();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           // e.Graphics.DrawString("FACTURE", new Font("Arial", 20, FontStyle.Bold) , Brushes.Black, new Point(400, 10));
            //e.Graphics.DrawString("Rapport du facteur", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(10, 40));
           
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
