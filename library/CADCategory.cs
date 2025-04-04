using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace library
{
    public class CADCategory
    {
        private readonly string _connectionString;

        public CADCategory()
        {
            _connectionString = System.Configuration.ConfigurationManager
                              .ConnectionStrings["DatabaseConnectionString"].ConnectionString;
        }

        public bool Read(ENCategory en)
        {
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    var cmd = new SqlCommand(
                        "SELECT [name] FROM [Categories] WHERE [id] = @id", con);

                    cmd.Parameters.AddWithValue("@id", en.Id);

                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            en.Name = dr["name"].ToString();
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error en CADCategory.Read: {ex.Message}");
                return false;
            }
        }

        public List<ENCategory> ReadAll()
        {
            var categories = new List<ENCategory>();
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    var cmd = new SqlCommand(
                        "SELECT [id], [name] FROM [Categories] ORDER BY [id]", con);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            categories.Add(new ENCategory(
                                Convert.ToInt32(dr["id"]),
                                dr["name"].ToString()
                            ));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error en CADCategory.ReadAll: {ex.Message}");
            }
            return categories;
        }
    }
}