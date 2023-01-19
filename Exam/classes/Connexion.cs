using MySql.Data.MySqlClient;

namespace Exam.classes
{
    internal class Connexion
    {
        public MySqlConnection connMaster;

        public void connexion()
        {
            connMaster = new MySqlConnection($"datasource=localhost;port=3306;username=root;password=;database=gestion_parapharmacie");
        }
        public void connexClose() {
            connMaster.Close();

        }
        public void connexOpen() { 
        connMaster.Open();
        }
    }
}
