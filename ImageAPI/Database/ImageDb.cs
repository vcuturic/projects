using System;
using System.Collections.Generic;
using virtouz_image_api.Models;
using System.Data.SQLite;

namespace virtouz_image_api.Database
{
    public class ImageDb
    {
        SQLiteConnection conn = Db.Instance;
        public int getNumOfPictures()
        {
            int numOfpcs=-1;
            string q = "select count(*) from Image";
            var command = conn.CreateCommand();
            command.CommandText = q;
            conn.Open();
            using(var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    numOfpcs = reader.GetInt32(0);
                }
            }
            conn.Close();
            return numOfpcs;
        }
        public int addPicture(String location, String name)
        {
            int pictureId = getNumOfPictures();
            string q = "insert into Image(id,location) values("+pictureId+",'"+location+pictureId+name+"')";
            var cmd = conn.CreateCommand();
            cmd.CommandText = q;
            conn.Open();
            try { cmd.ExecuteNonQuery(); }
            catch (Exception) { pictureId = -1; }
            conn.Close();
            return pictureId;        
        }
        public string getImageById(int id)
        {
            Image img = null;
            string location="";
            string q = "select * from Image where id = "+id;

            var command = conn.CreateCommand();
            command.CommandText = q;

            conn.Open();
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    location = reader["location"].ToString();
                    img = new Image(int.Parse(reader["id"].ToString()),
                                        reader["location"].ToString()
                                        );
                }
            }
            conn.Close();
            return location;
        }
        public List<Image> getAllImages()
        {
            List<Image> images = new List<Image>();
            string q = "select * from Image";

            var command = conn.CreateCommand();
            command.CommandText = q;

            conn.Open();
            using(var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    images.Add(new Image(int.Parse(reader["id"].ToString()),
                                        reader["location"].ToString()
                                        ));
                }
            }
            conn.Close();
            return images;
        } 
    }
}
