using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project
{

    public class CustomerDAO : IRepository<Customer>
    {
        /// <summary>
        /// SQL delete command
        /// </summary>
        /// <param name="id"></param>
          void IRepository<Customer>.Delete(int id)
        {
            using (SqlConnection con = DatabaseSingleton.GetInstance())
            {
                string deleteSql = "DELETE FROM dbo.customer WHERE id = @id;";

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
        IEnumerable<Customer> IRepository<Customer>.GetAll()
        {

            SqlConnection con = DatabaseSingleton.GetInstance();
                string getAllSql = "SELECT * FROM dbo.customer;";
                
                using (SqlCommand command = new SqlCommand(getAllSql, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer customer = new Customer
                            {
                                Id = reader.GetInt32(0),
                                First_name = reader.GetString(1),
                                Last_name = reader.GetString(2),
                                Email = reader.GetString(3),
                            };
                            yield return customer;
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
        Customer IRepository<Customer>.GetByID(int id)
        {
            using (SqlConnection con = DatabaseSingleton.GetInstance())
            {
                string getByIdSql = "SELECT * FROM dbo.customer WHERE id = @id;";

                con.Open();
                using (SqlCommand command = new SqlCommand(getByIdSql, con))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();

                        Customer customer = new Customer
                        {
                            Id = reader.GetInt32(0),
                            First_name = reader.GetString(1),
                            Last_name = reader.GetString(2),
                            Email = reader.GetString(3),
                        };

                        reader.Close();
                        con.Close();

                        return customer;
                    }
                }
            }
        }

        /// <summary>
        /// SQL Insert command
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        int IRepository<Customer>.Insert(Customer element)
        {
                SqlConnection con = DatabaseSingleton.GetInstance();
                string saveSql = "INSERT INTO dbo.customer (first_name, last_name, email) VALUES (@first_name, @last_name, @email); SELECT SCOPE_IDENTITY()";

                using (SqlCommand command = new SqlCommand(saveSql, con))
                {
                    command.Parameters.Add("@first_name", SqlDbType.VarChar, 50).Value = element.First_name;
                    command.Parameters.Add("@last_name", SqlDbType.VarChar, 50).Value = element.Last_name;
                    command.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = element.Email;

                    command.CommandType = CommandType.Text;

                return Convert.ToInt32(command.ExecuteScalar());
                }
        }

        /// <summary>
        /// SQL Update command
        /// </summary>
        /// <param name="element"></param>
        void IRepository<Customer>.Update(Customer element)
        {
            using (SqlConnection con = DatabaseSingleton.GetInstance())
            {
                string saveSql = "UPDATE dbo.customer SET first_name = @first_name, last_name = @last_name, email = @email;";

                con.Open();
                using (SqlCommand command = new SqlCommand(saveSql, con))
                {
                    command.Parameters.Add("@first_name", SqlDbType.VarChar, 50).Value = element.First_name;
                    command.Parameters.Add("@last_name", SqlDbType.VarChar, 50).Value = element.Last_name;
                    command.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = element.Email;

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }
}
