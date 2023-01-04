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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Dashboard dh = new Dashboard();
            addusercontrol(dh);

        }

        private void button1_Click(object sender, EventArgs e)
        {
              this.Close();
           
        }


        private void addusercontrol(UserControl userControl) { 
            userControl.Dock= DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();


        
        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Dashboard dh = new Dashboard();
            addusercontrol(dh);
        }

        private void form1_load(object sender, EventArgs e)
        {
            int w= Screen.PrimaryScreen.Bounds.Width;
            int h= Screen.PrimaryScreen.Bounds.Height; 
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
            
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }


        private void chartbtn_Click(object sender, EventArgs e)
        {
            Chart ch = new Chart();
            addusercontrol(ch);
        }

        private void produitbtn_Click(object sender, EventArgs e)
        {
            Produit p = new Produit();
            addusercontrol(p);
        }
    }
}
