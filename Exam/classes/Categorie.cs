using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.classes
{
    internal class Categorie
    {
        private int id;
        private String libelle;
        private String code;
        private static int count = 0;

        public Categorie( string libelle, string code)
        {
            this.id = ++count;
            this.libelle = libelle;
            this.code = code;
        }

        public int Id { get => id; set => id = value; }
        public string Libelle { get => libelle; set => libelle = value; }
        public string Code { get => code; set => code = value; }
        public static int Count { get => count; set => count = value; }
    }
}
