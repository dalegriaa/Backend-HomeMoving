using System.Data;
using System.Data.SQLite;
using Transversal.common;

namespace Infrastructure.Data
{
    public class ConnectionFactory : IconectionFactory
    {


        public IDbConnection GetInstance
        {
            get {
                var db = new SQLiteConnection(
                     string.Format("Data Source={0};Version=3;", "D:/Learning/TechAndSolve/DataBase/database.db"));

                db.Open();

                return db;
            }
     
        }
    }
}
