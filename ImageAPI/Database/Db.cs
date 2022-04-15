using System;
using System.Data.SQLite;
using System.IO;

namespace virtouz_image_api.Database
{
    public class Db
    {
        private static SQLiteConnection instance = null;
        private static readonly object padlock = new object();

        public static string filepath = Directory.GetCurrentDirectory();
        /*GetCurrentDirectory() vraca lokaciju projekta + "bin/Debug" 
         filepath = GetCurrentDirectory()-"bin/Debug" */
        private static string conns = "Data Source=" + filepath + @"/Database/virtuoz.db";

        public static SQLiteConnection Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                        instance = new SQLiteConnection(conns);
                }
                return instance;
            }
        }
    }
}
