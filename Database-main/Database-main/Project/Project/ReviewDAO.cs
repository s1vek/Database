using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class ReviewDAO : IRepository<Review>
    {
        /// <summary>
        /// SQL delete command
        /// </summary>
        /// <param name="id"></param>
        void IRepository<Review>.Delete(int id)
        {
            using (SqlConnection con = DatabaseSingleton.GetInstance())
            {
                string deleteSql = "DELETE FROM dbo.review WHERE id = @id;";

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
        IEnumerable<Review> IRepository<Review>.GetAll()
        {
            using (SqlConnection con = DatabaseSingleton.GetInstance())
            {
                string getAllSql = "SELECT * FROM dbo.review;";

                con.Open();
                using (SqlCommand command = new SqlCommand(getAllSql, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Review review = new Review
                            {
                                Id = reader.GetInt32(0),
                                Customer_id = reader.GetInt32(1),
                                Reviewtext = reader.GetString(2),
                            };
                            yield return review;
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
        Review IRepository<Review>.GetByID(int id)
        {
            using (SqlConnection con = DatabaseSingleton.GetInstance())
            {
                string getByIdSql = "SELECT * FROM dbo.review WHERE id = @id;";

                con.Open();
                using (SqlCommand command = new SqlCommand(getByIdSql, con))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();

                        Review  review = new Review
                        {
                            Id = reader.GetInt32(0),
                            Customer_id = reader.GetInt32(1),
                            Reviewtext = reader.GetString(2),
                        };

                        reader.Close();
                        con.Close();

                        return review;
                    }
                }
            }
        }

        /// <summary>
        /// SQL Insert command
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        int IRepository<Review>.Insert(Review element)
        {
            SqlConnection con = DatabaseSingleton.GetInstance();
            
                string saveSql = "INSERT INTO dbo.review (customer_id, reviewtext) VALUES (@customer_id, @reviewtext);";
                
                using (SqlCommand command = new SqlCommand(saveSql, con))
                {
                    command.Parameters.Add("@customer_id", SqlDbType.Int).Value = element.Customer_id;
                    command.Parameters.Add("@reviewtext", SqlDbType.VarChar, 250).Value = element.Reviewtext;

                    command.CommandType = CommandType.Text;

                    return command.ExecuteNonQuery();
                }
                
            
        }
        /// <summary>
        /// SQL Update command
        /// </summary>
        /// <param name="element"></param>
        void IRepository<Review>.Update(Review element)
        {
            using (SqlConnection con = DatabaseSingleton.GetInstance())
            {
                string saveSql = "UPDATE dbo.review SET customer_id = @customer_id, reviewtext = @reviewtext;";

                con.Open();
                using (SqlCommand command = new SqlCommand(saveSql, con))
                {
                    command.Parameters.Add("@customer_id", SqlDbType.Int).Value = element.Customer_id;
                    command.Parameters.Add("@reviewtext", SqlDbType.VarChar, 250).Value = element.Reviewtext;

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
                con.Close();
            }
        }


    }
}
