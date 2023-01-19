using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.classes
{
    internal class Fournisseur
    {
        private int id;
        private string name;
        private String email;
        private String phone;
        private String city;
        private String description;
        public static int count = 0;

        public Fournisseur( string name, string email, string phone, string city, string description)
        {
            this.id = ++count;
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.city = city;
            this.description = description;
        }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string City { get => city; set => city = value; }
        public string Description { get => description; set => description = value; }

        
    }
}
