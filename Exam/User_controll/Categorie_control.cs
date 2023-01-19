using Exam.classes;
using Exam.messageboxes;
using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlX.XDevAPI;
using System.Text.RegularExpressions;

namespace Exam.User_controll
{
    public partial class Categorie_control : UserControl
    {
        
        Connexion connexion = new Connexion();
        MySqlDataAdapter dataadapter;
        DataTable datatable;
        int currRowIndex;

        public Categorie_control()
        {
            InitializeComponent();
            afficher();
        }

        private void Categorie_control_Load(object sender, EventArgs e)
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
           // string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            return Regex.IsMatch(input, pattern);
        }
        private void afficher() {
           // Connexion connexion = new Connexion();
            connexion.connexion();
            connexion.connexOpen();
            MySqlCommand Command = new MySqlCommand("select * from categorie",connexion.connMaster);
            Command.ExecuteNonQuery();
            datatable=new DataTable();
            dataadapter=new MySqlDataAdapter(Command);
            dataadapter.Fill(datatable);
            categorietable.DataSource = datatable;
            connexion.connexClose();

        }




        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (codetxt.Text == "" || libelletxt.Text == "")
            {
                // DialogResult dialogClose = MessageBox.Show(" one of the fields is empty !!", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MsgBoxFieldEmpty msg = new MsgBoxFieldEmpty();
                msg.Show();
            }
            else if (!IsLettersAndNumbers(codetxt.Text)) {
                DialogResult dialogClose = MessageBox.Show(" invalid code format ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!IsOnlyLetters(libelletxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid libelle format ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {

                    Categorie categorie = new Categorie(libelletxt.Text, codetxt.Text);

                    libelletxt.Clear();
                    codetxt.Clear();

                    connexion.connexion();
                    connexion.connexOpen();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO categorie(libelle,code)" + "VALUES(@libelle,@code)", connexion.connMaster);
                    cmd.Parameters.AddWithValue("@libelle", categorie.Libelle);
                    cmd.Parameters.AddWithValue("@code", categorie.Code);
                    cmd.ExecuteNonQuery();
                    libelletxt.Clear();
                    codetxt.Clear();
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
            if (libelletxt.Text == "" || codetxt.Text == "") {
                MsgBoxFieldEmpty msg = new MsgBoxFieldEmpty();
                msg.Show();
            }
            else if (!IsLettersAndNumbers(codetxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid code format ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!IsOnlyLetters(libelletxt.Text))
            {
                DialogResult dialogClose = MessageBox.Show(" invalid libelle format ", "add item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try {
                    connexion.connexion();
                    connexion.connexOpen();
                    MySqlCommand Command = new MySqlCommand("update categorie set libelle=@libelle,code=@code where id=@id", connexion.connMaster);
                    Command.Parameters.AddWithValue("@libelle", libelletxt.Text);
                    Command.Parameters.AddWithValue("@code",codetxt.Text);
                    Command.Parameters.AddWithValue("@id",currRowIndex);
                    Command.ExecuteNonQuery();
                    afficher();
                    MsgBoxAddedsucc cmda = new MsgBoxAddedsucc();
                    cmda.Show();

                    libelletxt.Clear();
                    codetxt.Clear();
                    connexion.connexClose();

                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



           
           
        }

        private void categorietable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row=this.categorietable.Rows[e.RowIndex];
            currRowIndex=Convert.ToInt32(row.Cells[0].Value);
            libelletxt.Text = row.Cells[1].Value.ToString();
            codetxt.Text = row.Cells[2].Value.ToString();
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogDelete = MessageBox.Show("do you really want to delete this Item??", "delete item ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogDelete == DialogResult.OK)
            {
                connexion.connexion();
                connexion.connexOpen();
                MySqlCommand cmd = new MySqlCommand("delete from categorie where id=" + currRowIndex, connexion.connMaster);
                cmd.ExecuteNonQuery();
                afficher();
                libelletxt.Clear();
                codetxt.Clear();
                connexion.connexClose();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
          /*  Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);
           PdfWriter.GetInstance(pdfDoc, new FileStream("DataGridView.pdf", FileMode.Create));
            pdfDoc.Open();
           
            //Add a table to the document
            PdfPTable pdfTable = new PdfPTable(categorietable.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 30;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            //Add the headers of the DataGridView to the table
            for (int i = 0; i < categorietable.ColumnCount; i++)
            {
                PdfPCell cell = new PdfPCell(new Phrase(categorietable.Columns[i].HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }

            //Add the rows of the DataGridView to the table
            for (int i = 0; i < categorietable.Rows.Count; i++)
            {
                for (int j = 0; j < categorietable.Columns.Count; j++)
                {
                    if (categorietable.Rows[i].Cells[j].Value != null)
                    {
                        pdfTable.AddCell(categorietable.Rows[i].Cells[j].Value.ToString());
                    }
                }
            }

            //Add the table to the document
            pdfDoc.Add(pdfTable);

            //Close the document
            pdfDoc.Close();

            */




            
            if (categorietable.Rows.Count > 0)
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
                           

                            PdfPTable pdfTable = new PdfPTable(categorietable.Columns.Count);
                            
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            for (int i = 0; i < categorietable.ColumnCount; i++)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(categorietable.Columns[i].HeaderText));
                                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                                pdfTable.AddCell(cell);
                            }

                            //Add the rows of the DataGridView to the table
                            for (int i = 0; i < categorietable.Rows.Count; i++)
                            {
                                for (int j = 0; j < categorietable.Columns.Count; j++)
                                {
                                    if (categorietable.Rows[i].Cells[j].Value != null)
                                    {
                                        pdfTable.AddCell(categorietable.Rows[i].Cells[j].Value.ToString());
                                    }
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
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
            
    }
}
