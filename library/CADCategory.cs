using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace library
{
    public class CADCategory
    {
        private string constring;

        public CADCategory()
        {
            constring = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ToString();
        }

        public bool Read(ENCategory en)
        {
            try
            {
                SqlConnection c = new SqlConnection(constring);
                c.Open();
                SqlCommand com = new SqlCommand("SELECT * FROM Categories WHERE id=@id", c);
                com.Parameters.AddWithValue("@id", en.Id);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    en.Name = dr["name"].ToString();
                    dr.Close();
                    c.Close();
                    return true;
                }
                dr.Close();
                c.Close();
                return false;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Category read failed. Error: {0}", ex.Message);
                return false;
            }
        }

        public List<ENCategory> ReadAll()
        {
            List<ENCategory> list = new List<ENCategory>();
            try
            {
                SqlConnection c = new SqlConnection(constring);
                c.Open();
                SqlCommand com = new SqlCommand("SELECT * FROM Categories", c);
                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    ENCategory en = new ENCategory();
                    en.Id = Convert.ToInt32(dr["id"]);
                    en.Name = dr["name"].ToString();
                    list.Add(en);
                }

                dr.Close();
                c.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Category list failed. Error: {0}", ex.Message);
            }

            return list;
        }
    }
}
