using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class OrderDetailsDAO : IRepository<OrderDetails>
    {
        /// <summary>
        /// SQL delete command
        /// </summary>
        /// <param name="id"></param>
        void IRepository<OrderDetails>.Delete(int id)
        {
            using (SqlConnection con = DatabaseSingleton.GetInstance())
            {
                string deleteSql = "DELETE FROM dbo.order_details WHERE id = @id;";

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
        IEnumerable<OrderDetails> IRepository<OrderDetails>.GetAll()
        {
            using (SqlConnection con = DatabaseSingleton.GetInstance())
            {
                string getAllSql = "SELECT * FROM dbo.order_details;";

                con.Open();
                using (SqlCommand command = new SqlCommand(getAllSql, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            OrderDetails order_details = new OrderDetails
                            {
                                Id = reader.GetInt32(0),
                                Order_id = reader.GetInt32(1),
                                Product_id = reader.GetInt32(2),
                                Amount = reader.GetInt32(3),
                            };
                            yield return order_details;
                        }
                        reader.Close();
                    }
                    con.Close();
                }
            }
        }
        /// <summary>
        /// SQL GetByID command
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        OrderDetails IRepository<OrderDetails>.GetByID(int id)
        {
            using (SqlConnection con = DatabaseSingleton.GetInstance())
            {
                string getByIdSql = "SELECT * FROM dbo.order_details WHERE id = @id;";

                con.Open();
                using (SqlCommand command = new SqlCommand(getByIdSql, con))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();

                        OrderDetails order_details = new OrderDetails
                        {
                            Id = reader.GetInt32(0),
                            Order_id = reader.GetInt32(1),
                            Product_id = reader.GetInt32(2),
                            Amount = reader.GetInt32(3),
                        };

                        reader.Close();
                        con.Close();

                        return order_details;
                    }
                }
            }
        }
        /// <summary>
        /// SQL Update command
        /// </summary>
        /// <param name="element"></param>
        public static IEnumerable<OrderDetails> getByOrderID(int id)
        {
            SqlConnection con = DatabaseSingleton.GetInstance();
            
                string getByIdSql = "SELECT * FROM dbo.order_details WHERE order_id = @id;";

                using (SqlCommand command = new SqlCommand(getByIdSql, con))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                    while (reader.Read())
                    {
                        OrderDetails order_details = new OrderDetails
                        {
                            Id = reader.GetInt32(0),
                            Order_id = reader.GetInt32(1),
                            Product_id = reader.GetInt32(2),
                            Amount = reader.GetInt32(3),
                        };
                        yield return order_details;
                    }

                    reader.Close();
                    }
                }
            
        }

        /// <summary>
        /// SQL Insert command
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        int IRepository<OrderDetails>.Insert(OrderDetails element)
        {
            SqlConnection con = DatabaseSingleton.GetInstance();
            
                string saveSql = "INSERT INTO dbo.order_details (order_id, product_id, amount) VALUES (@order_id, @product_id, @amount); SELECT SCOPE_IDENTITY()";

                
                using (SqlCommand command = new SqlCommand(saveSql, con))
                {
                    command.Parameters.Add("@order_id", SqlDbType.Int).Value = element.Order_id;
                    command.Parameters.Add("@product_id", SqlDbType.Int).Value = element.Product_id;
                    command.Parameters.Add("@amount", SqlDbType.Float).Value = element.Amount;

                    command.CommandType = CommandType.Text;

                return Convert.ToInt32(command.ExecuteScalar());
            }
                
            
        }
        /// <summary>
        /// SQL Update command
        /// </summary>
        /// <param name="element"></param>
        void IRepository<OrderDetails>.Update(OrderDetails element)
        {
            using (SqlConnection con = DatabaseSingleton.GetInstance())
            {
                string saveSql = "UPDATE dbo.order_details SET order_id = @order_id, product_id = @product_id, amount = @amount;";

                con.Open();
                using (SqlCommand command = new SqlCommand(saveSql, con))
                {
                    command.Parameters.Add("@order_id", SqlDbType.Int).Value = element.Order_id;
                    command.Parameters.Add("@product_id", SqlDbType.DateTime).Value = element.Product_id;
                    command.Parameters.Add("@amount", SqlDbType.Float).Value = element.Amount;

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
                con.Close();
            }
        }
        /// <summary>
        /// SQL Update by product_id and customer_id, specific method used for updating values
        /// </summary>
        /// <param name="element"></param>
        public static void updateByProductIdAndCustomerId(int productId, int amount, int orderId)
        {
            SqlConnection con = DatabaseSingleton.GetInstance();

                string saveSql = "UPDATE dbo.order_details SET amount = @amount WHERE product_id = @product_id AND order_id = @order_id;";

                using (SqlCommand command = new SqlCommand(saveSql, con))
                {
                    command.Parameters.Add("@order_id", SqlDbType.Int).Value = orderId;
                    command.Parameters.Add("@product_id", SqlDbType.Int).Value = productId;
                    command.Parameters.Add("@amount", SqlDbType.Int).Value = amount;

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }

            
        }


    }
}
