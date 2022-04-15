using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slagalica_118_2018
{
    class KonekcijaDB
    {
        private static SqliteConnection instance = null;
        private static object padlock = new object();
        private static string filepath = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString();
        /*GetCurrentDirectory() vraca lokaciju projekta + "bin/Debug" 
         filepath = GetCurrentDirectory()-"bin/Debug" */
        private static string konekcioni_string = "Data Source="+ filepath + @"\baza\slagalica.db";

        public static SqliteConnection Instance { 
            get
            {
                lock (padlock)
                {
                    if (instance == null) 
                        instance = new SqliteConnection(konekcioni_string);
                }
                return instance;
            }
        }
    }
}
