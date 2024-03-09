using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class ProductsDAO : IRepository<Products>
    {
        void IRepository<Products>.Delete(Products element)
        {
            using (SqlConnection con = DatabaseSingleton.GetInstance())
            {
                string deleteSql = "DELETE FROM dbo.products WHERE id = @id;";

                con.Open();
                using (SqlCommand command = new SqlCommand(deleteSql, con))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = element.Id;

                    command.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        IEnumerable<Products> IRepository<Products>.GetAll()
        {
            using (SqlConnection con = DatabaseSingleton.GetInstance())
            {
                string getAllSql = "SELECT * FROM dbo.products;";

                con.Open();
                using (SqlCommand command = new SqlCommand(getAllSql, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Products products = new Products
                            {
                                Id = reader.GetInt32(0),
                                Product_name = reader.GetString(1),
                                Price = reader.GetFloat(2),
                                Is_available = reader.GetBoolean(3),
                            };
                            yield return products;
                        }
                        reader.Close();
                    }
                    con.Close();
                }
            }
        }

        Products IRepository<Products>.GetByID(int id)
        {
            using (SqlConnection con = DatabaseSingleton.GetInstance())
            {
                string getByIdSql = "SELECT * FROM dbo.products WHERE id = @id;";

                con.Open();
                using (SqlCommand command = new SqlCommand(getByIdSql, con))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();

                        Products products = new Products
                        {
                            Id = reader.GetInt32(0),
                            Product_name = reader.GetString(1),
                            Price = reader.GetFloat(2),
                            Is_available = reader.GetBoolean(3),
                        };

                        reader.Close();
                        con.Close();

                        return products;
                    }
                }
            }
        }

        void IRepository<Products>.Insert(Products element)
        {
            using (SqlConnection con = DatabaseSingleton.GetInstance())
            {
                string saveSql = "INSERT INTO dbo.products (product_name, price, is_available) VALUES (@product_name, @price, @is_available);";

                con.Open();
                using (SqlCommand command = new SqlCommand(saveSql, con))
                {
                    command.Parameters.Add("@product_name", SqlDbType.VarChar, 50).Value = element.Product_name;
                    command.Parameters.Add("@price", SqlDbType.Float).Value = element.Price;
                    command.Parameters.Add("@is_available", SqlDbType.Bit).Value = element.Is_available;

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        void IRepository<Products>.Update(Products element)
        {
            using (SqlConnection con = DatabaseSingleton.GetInstance())
            {
                string saveSql = "UPDATE dbo.products SET product_name = @product_name, price = @price, is_available = @is_available;";

                con.Open();
                using (SqlCommand command = new SqlCommand(saveSql, con))
                {
                    command.Parameters.Add("@product_name", SqlDbType.VarChar, 50).Value = element.Product_name;
                    command.Parameters.Add("@price", SqlDbType.Float).Value = element.Price;
                    command.Parameters.Add("@is_available", SqlDbType.Bit).Value = element.Is_available;

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
                con.Close();
            }
        }

    }
}
