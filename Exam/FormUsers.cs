using Exam.User_controll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam
{
    public partial class FormUsers : Form
    {
        public FormUsers()
        {
            InitializeComponent();
            Dashboard dh = new Dashboard();
            addusercontrol(dh);
            userslabel.Text=Loginform.username;
        }

        private void addusercontrol(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();



        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Dashboard dh = new Dashboard();
            addusercontrol(dh);
        }

        private void user_load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        private void chartbtn_Click(object sender, EventArgs e)
        {
            Chart ch = new Chart();
            addusercontrol(ch);
        }

        private void produitbtn_Click(object sender, EventArgs e)
        {
            Produit_control p = new Produit_control();
            addusercontrol(p);
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            Fabricants_control fabricants = new Fabricants_control();
            addusercontrol(fabricants);
        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            Commandes_control soldproduct = new Commandes_control();
            addusercontrol(soldproduct);
        }

        private void guna2GradientButton10_Click(object sender, EventArgs e)
        {
            List_Des_Commande ls = new List_Des_Commande();
            addusercontrol(ls);
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            Categorie_control categorie = new Categorie_control();
            addusercontrol(categorie);
        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            this.Close();
            Loginform logf=new Loginform();
            logf.Show();
        }

        private void guna2GradientButton9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2GradientButton8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void enrepturebtn_Click(object sender, EventArgs e)
        {
            OutOfStock_contrel ofs = new OutOfStock_contrel();
            addusercontrol(ofs);
        }

        private void chartbtn_Click_1(object sender, EventArgs e)
        {
            Chart ch = new Chart();
            addusercontrol(ch);
        }
    }
}
