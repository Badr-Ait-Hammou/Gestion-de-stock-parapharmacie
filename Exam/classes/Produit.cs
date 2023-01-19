using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.classes
{
    internal class Produit
    {
        private int id;
        private string name;
        private int price;
        private int qtte;
        private String reference;
        private DateTime dateexp;
        private String categorie;
        private String fournisseur;
        byte[] image;

        public static int count = 0;

        public Produit( string name, int price, int qtte, string reference, DateTime dateexp, string categorie, string fournisseur, byte[] image)
        {
            this.id = ++count;
            this.name = name;
            this.price = price;
            this.qtte = qtte;
            this.reference = reference;
            this.dateexp = dateexp;
            this.categorie = categorie;
            this.fournisseur = fournisseur;
            this.image = image;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }
        public int Qtte { get => qtte; set => qtte = value; }
        public string Reference { get => reference; set => reference = value; }
        public DateTime Dateexp { get => dateexp; set => dateexp = value; }
        public string Categorie { get => categorie; set => categorie = value; }
        public string Fournisseur { get => fournisseur; set => fournisseur = value; }
        public byte[] Image { get => image; set => image = value; }
    }
}
