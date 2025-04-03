using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace library
{
    public class CADProduct
    {
        private string constring;

        public CADProduct()
        {
            // Inicializa la cadena de conexión desde Web.config
            constring = System.Configuration.ConfigurationManager//revisar importante
                      .ConnectionStrings["DatabaseConnectionString"].ConnectionString;
        }

        public bool Create(ENProduct en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(constring))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        "INSERT INTO Products (code, name, amount, price, category, creationDate) " +
                        "VALUES (@code, @name, @amount, @price, @category, @creationDate)", connection);

                    command.Parameters.AddWithValue("@code", en.Code);
                    command.Parameters.AddWithValue("@name", en.Name);
                    command.Parameters.AddWithValue("@amount", en.Amount);
                    command.Parameters.AddWithValue("@price", en.Price);
                    command.Parameters.AddWithValue("@category", en.Category);
                    command.Parameters.AddWithValue("@creationDate", en.CreationDate);

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }

        public bool Update(ENProduct en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(constring))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        "UPDATE Products SET name = @name, amount = @amount, price = @price, " +
                        "category = @category, creationDate = @creationDate WHERE code = @code", connection);

                    command.Parameters.AddWithValue("@code", en.Code);
                    command.Parameters.AddWithValue("@name", en.Name);
                    command.Parameters.AddWithValue("@amount", en.Amount);
                    command.Parameters.AddWithValue("@price", en.Price);
                    command.Parameters.AddWithValue("@category", en.Category);
                    command.Parameters.AddWithValue("@creationDate", en.CreationDate);

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }

        public bool Delete(ENProduct en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(constring))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        "DELETE FROM Products WHERE code = @code", connection);

                    command.Parameters.AddWithValue("@code", en.Code);

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }

        public bool Read(ENProduct en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(constring))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        "SELECT name, amount, price, category, creationDate " +
                        "FROM Products WHERE code = @code", connection);

                    command.Parameters.AddWithValue("@code", en.Code);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        en.Name = reader["name"].ToString();
                        en.Amount = Convert.ToInt32(reader["amount"]);
                        en.Price = Convert.ToSingle(reader["price"]);
                        en.Category = Convert.ToInt32(reader["category"]);
                        en.CreationDate = Convert.ToDateTime(reader["creationDate"]);
                        return true;
                    }
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }

        public bool ReadFirst(ENProduct en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(constring))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        "SELECT TOP 1 code, name, amount, price, category, creationDate " +
                        "FROM Products ORDER BY code", connection);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        en.Code = reader["code"].ToString();
                        en.Name = reader["name"].ToString();
                        en.Amount = Convert.ToInt32(reader["amount"]);
                        en.Price = Convert.ToSingle(reader["price"]);
                        en.Category = Convert.ToInt32(reader["category"]);
                        en.CreationDate = Convert.ToDateTime(reader["creationDate"]);
                        return true;
                    }
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }

        public bool ReadNext(ENProduct en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(constring))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        "SELECT TOP 1 code, name, amount, price, category, creationDate " +
                        "FROM Products WHERE code > @code ORDER BY code", connection);

                    command.Parameters.AddWithValue("@code", en.Code);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        en.Code = reader["code"].ToString();
                        en.Name = reader["name"].ToString();
                        en.Amount = Convert.ToInt32(reader["amount"]);
                        en.Price = Convert.ToSingle(reader["price"]);
                        en.Category = Convert.ToInt32(reader["category"]);
                        en.CreationDate = Convert.ToDateTime(reader["creationDate"]);
                        return true;
                    }
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }

        public bool ReadPrev(ENProduct en)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(constring))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        "SELECT TOP 1 code, name, amount, price, category, creationDate " +
                        "FROM Products WHERE code < @code ORDER BY code DESC", connection);

                    command.Parameters.AddWithValue("@code", en.Code);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        en.Code = reader["code"].ToString();
                        en.Name = reader["name"].ToString();
                        en.Amount = Convert.ToInt32(reader["amount"]);
                        en.Price = Convert.ToSingle(reader["price"]);
                        en.Category = Convert.ToInt32(reader["category"]);
                        en.CreationDate = Convert.ToDateTime(reader["creationDate"]);
                        return true;
                    }
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }
    }
}