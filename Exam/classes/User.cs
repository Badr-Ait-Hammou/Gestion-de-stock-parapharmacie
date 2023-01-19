using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.classes
{
    internal class User
    {
        private int id;
        private String username;
        private String first_name;
        private String last_name;
        private String email;
        private String phone;
        private String password;
        public static int count = 0;

        public User( string username, string first_name, string last_name, string email, string phone, string password)
        {
            this.id = ++count;
            this.username = username;
            this.first_name = first_name;
            this.last_name = last_name;
            this.email = email;
            this.phone = phone;
            this.password = password;
        }

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string First_name { get => first_name; set => first_name = value; }
        public string Last_name { get => last_name; set => last_name = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Password { get => password; set => password = value; }
    }
}
