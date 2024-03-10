using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class OrdersDAO : IRepository<Orders>
    {
        /// <summary>
        /// SQL delete command
        /// </summary>
        /// <param name="id"></param>
        void IRepository<Orders>.Delete(int id)
        {
            using (SqlConnection con = DatabaseSingleton.GetInstance())
            {
                string deleteSql = "DELETE FROM dbo.orders WHERE id = @id;";

                con.Open();
                using (SqlCommand command = new SqlCommand(deleteSql, con))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    command.ExecuteNonQuery();
                }
                con.Close();
            }
        }
        /// <summary>
        /// SQL GetAll command
        /// </summary>
        /// <returns></returns>
        IEnumerable<Orders> IRepository<Orders>.GetAll()
        {
            SqlConnection con = DatabaseSingleton.GetInstance();
            
                string getAllSql = "SELECT * FROM dbo.orders;";

                using (SqlCommand command = new SqlCommand(getAllSql, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Orders orders = new Orders
                            {
                                Id = reader.GetInt32(0),
                                Customer_id = reader.GetInt32(1),
                                Order_date = reader.GetDateTime(2),
                                Total_price = reader.GetDecimal(3),
                            };
                            yield return orders;
                        }
                        reader.Close();
                    }
                }
            
        }
        /// <summary>
        /// SQL GetByID command
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Orders IRepository<Orders>.GetByID(int id)
        {
            using (SqlConnection con = DatabaseSingleton.GetInstance())
            {
                string getByIdSql = "SELECT * FROM dbo.orders WHERE id = @id;";

                con.Open();
                using (SqlCommand command = new SqlCommand(getByIdSql, con))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();

                        Orders orders = new Orders
                        {
                            Id = reader.GetInt32(0),
                            Customer_id = reader.GetInt32(1),
                            Order_date = reader.GetDateTime(2),
                            Total_price = reader.GetInt32(3),
                        };

                        reader.Close();
                        con.Close();

                        return orders;
                    }
                }
            }
        }

        /// <summary>
        /// SQL Insert command
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        int IRepository<Orders>.Insert(Orders element)
        {
            SqlConnection con = DatabaseSingleton.GetInstance();
                string saveSql = "INSERT INTO dbo.orders (customer_id, order_date, total_price) VALUES (@customer_id, @order_date, @total_price); SELECT SCOPE_IDENTITY()";

                
                using (SqlCommand command = new SqlCommand(saveSql, con))
                {
                    command.Parameters.Add("@customer_id", SqlDbType.Int).Value = element.Customer_id;
                    command.Parameters.Add("@order_date", SqlDbType.DateTime).Value = element.Order_date;
                    command.Parameters.Add("@total_price", SqlDbType.Float).Value = element.Total_price;

                    command.CommandType = CommandType.Text;

                return Convert.ToInt32(command.ExecuteScalar());
            }
            
        }
        /// <summary>
        /// SQL Update command
        /// </summary>
        /// <param name="element"></param>
        void IRepository<Orders>.Update(Orders element)
        {
            using (SqlConnection con = DatabaseSingleton.GetInstance())
            {
                string saveSql = "UPDATE dbo.orders SET customer_id = @customer_id, order_date = @order_date, total_price = @total_price;";

                con.Open();
                using (SqlCommand command = new SqlCommand(saveSql, con))
                {
                    command.Parameters.Add("@customer_id", SqlDbType.Int).Value = element.Customer_id;
                    command.Parameters.Add("@order_date", SqlDbType.DateTime).Value = element.Order_date;
                    command.Parameters.Add("@total_price", SqlDbType.Float).Value = element.Total_price;

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }
}
