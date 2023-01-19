using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.classes
{
    internal class Commande
    {
        private int id;
        private string name;
        private int price;
        private int qtte;
        private String reference;
        private DateTime dateexp;
        private DateTime datecmd;
        private String categorie;
        private String fournisseur;
        private int total;
        byte[] image;
        public static int count = 0;

        public Commande( string name, int price, int qtte, string reference, DateTime dateexp, DateTime datecmd, string categorie, string fournisseur, int total, byte[] image)
        {
            this.id = ++count;
            this.name = name;
            this.price = price;
            this.qtte = qtte;
            this.reference = reference;
            this.dateexp = dateexp;
            this.datecmd = datecmd;
            this.categorie = categorie;
            this.fournisseur = fournisseur;
            this.total = total;
            this.image = image;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }
        public int Qtte { get => qtte; set => qtte = value; }
        public string Reference { get => reference; set => reference = value; }
        public DateTime Dateexp { get => dateexp; set => dateexp = value; }
        public DateTime Datecmd { get => datecmd; set => datecmd = value; }
        public string Categorie { get => categorie; set => categorie = value; }
        public string Fournisseur { get => fournisseur; set => fournisseur = value; }
        public int Total { get => total; set => total = value; }
        public byte[] Image { get => image; set => image = value; }
    }
}
