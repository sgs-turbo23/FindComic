using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindComic.DataAccess
{
    public class CollectionsDataAccess
    {
        public void GetScheme()
        {
            var path = @"C:\Users\masiw\AppData\Local\Microsoft\Edge\User Data\Default\Collections\collectionsSQLite";
            var sqlConnectionSb = new SQLiteConnectionStringBuilder { DataSource = path };
            using (var cn = new SQLiteConnection(sqlConnectionSb.ToString()))
            {
                cn.Open();
                var commandText = "select sqlite_version()";

                using (var cmd = new SQLiteCommand(commandText, cn))
                {
                    Console.WriteLine(cmd.ExecuteScalar());
                }
            }
        }

    }
}
