using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace library
{
    public class CADCategory
    {
        private string connectionString;

        public CADCategory()
        {
            // revisar 
            connectionString = System.Configuration.ConfigurationManager
                            .ConnectionStrings["DatabaseConnectionString"].ConnectionString;
        }

        public bool Read(ENCategory en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        "SELECT name FROM Categories WHERE id = @id", connection);

                    command.Parameters.AddWithValue("@id", en.Id);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        en.Name = reader["name"].ToString();
                        return true;
                    }
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Category operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }

        public List<ENCategory> ReadAll()
        {
            List<ENCategory> categories = new List<ENCategory>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        "SELECT id, name FROM Categories ORDER BY id", connection);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ENCategory category = new ENCategory(
                            Convert.ToInt32(reader["id"]),
                            reader["name"].ToString());

                        categories.Add(category);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Category operation has failed. Error: {0}", ex.Message);
            }

            return categories;
        }
    }
}