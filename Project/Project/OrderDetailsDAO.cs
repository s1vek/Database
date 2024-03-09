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

        void IRepository<OrderDetails>.Delete(OrderDetails element)
        {
            using (SqlConnection con = DatabaseSingleton.GetInstance())
            {
                string deleteSql = "DELETE FROM dbo.order_details WHERE id = @id;";

                con.Open();
                using (SqlCommand command = new SqlCommand(deleteSql, con))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = element.Id;

                    command.ExecuteNonQuery();
                }
                con.Close();
            }
        }

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


    }
}
