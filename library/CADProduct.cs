using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;


namespace library
{
    public class CADProduct
    {
        private string constring;

        public CADProduct()
        {
            constring = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ToString();
        }

        public bool Create(ENProduct en)
        {
            try
            {
                SqlConnection c = new SqlConnection(constring);
                c.Open();
                SqlCommand com = new SqlCommand("INSERT INTO Products (name, code, amount, price, category, creationDate) VALUES (@name, @code, @amount, @price, @category, @creationDate)", c);
                com.Parameters.AddWithValue("@name", en.Name);
                com.Parameters.AddWithValue("@code", en.Code);
                com.Parameters.AddWithValue("@amount", en.Amount);
                com.Parameters.AddWithValue("@price", en.Price);
                com.Parameters.AddWithValue("@category", en.Category);
                com.Parameters.AddWithValue("@creationDate", en.CreationDate);
                com.ExecuteNonQuery();
                c.Close();
                return true;
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
                SqlConnection c = new SqlConnection(constring);
                c.Open();
                SqlCommand com = new SqlCommand("UPDATE Products SET name=@name, amount=@amount, price=@price, category=@category, creationDate=@creationDate WHERE code=@code", c);
                com.Parameters.AddWithValue("@name", en.Name);
                com.Parameters.AddWithValue("@amount", en.Amount);
                com.Parameters.AddWithValue("@price", en.Price);
                com.Parameters.AddWithValue("@category", en.Category);
                com.Parameters.AddWithValue("@creationDate", en.CreationDate);
                com.Parameters.AddWithValue("@code", en.Code);
                com.ExecuteNonQuery();
                c.Close();
                return true;
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
                SqlConnection c = new SqlConnection(constring);
                c.Open();
                SqlCommand com = new SqlCommand("DELETE FROM Products WHERE code=@code", c);
                com.Parameters.AddWithValue("@code", en.Code);
                com.ExecuteNonQuery();
                c.Close();
                return true;
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
                SqlConnection c = new SqlConnection(constring);
                c.Open();
                SqlCommand com = new SqlCommand("SELECT * FROM Products WHERE code=@code", c);
                com.Parameters.AddWithValue("@code", en.Code);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    en.Name = dr["name"].ToString();
                    en.Amount = Convert.ToInt32(dr["amount"]);
                    en.Price = Convert.ToSingle(dr["price"]);
                    en.Category = Convert.ToInt32(dr["category"]);
                    en.CreationDate = Convert.ToDateTime(dr["creationDate"]);
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
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }

        public bool ReadFirst(ENProduct en)
        {
            try
            {
                SqlConnection c = new SqlConnection(constring);
                c.Open();
                SqlCommand com = new SqlCommand("SELECT TOP 1 * FROM Products ORDER BY id ASC", c);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    en.Code = dr["code"].ToString();
                    en.Name = dr["name"].ToString();
                    en.Amount = Convert.ToInt32(dr["amount"]);
                    en.Price = Convert.ToSingle(dr["price"]);
                    en.Category = Convert.ToInt32(dr["category"]);
                    en.CreationDate = Convert.ToDateTime(dr["creationDate"]);
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
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }

        public bool ReadNext(ENProduct en)
        {
            try
            {
                SqlConnection c = new SqlConnection(constring);
                c.Open();
                SqlCommand com = new SqlCommand("SELECT TOP 1 * FROM Products WHERE code > @code ORDER BY code ASC", c);
                com.Parameters.AddWithValue("@code", en.Code);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    en.Code = dr["code"].ToString();
                    en.Name = dr["name"].ToString();
                    en.Amount = Convert.ToInt32(dr["amount"]);
                    en.Price = Convert.ToSingle(dr["price"]);
                    en.Category = Convert.ToInt32(dr["category"]);
                    en.CreationDate = Convert.ToDateTime(dr["creationDate"]);
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
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }

        public bool ReadPrev(ENProduct en)
        {
            try
            {
                SqlConnection c = new SqlConnection(constring);
                c.Open();
                SqlCommand com = new SqlCommand("SELECT TOP 1 * FROM Products WHERE code < @code ORDER BY code DESC", c);
                com.Parameters.AddWithValue("@code", en.Code);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    en.Code = dr["code"].ToString();
                    en.Name = dr["name"].ToString();
                    en.Amount = Convert.ToInt32(dr["amount"]);
                    en.Price = Convert.ToSingle(dr["price"]);
                    en.Category = Convert.ToInt32(dr["category"]);
                    en.CreationDate = Convert.ToDateTime(dr["creationDate"]);
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
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }
    }
}