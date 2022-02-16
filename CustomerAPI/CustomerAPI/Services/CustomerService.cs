using System.Data;
using System.Data.SqlClient;
using CustomerAPI.Models;
using Newtonsoft.Json;

namespace CustomerAPI.Services
{
    public class CustomerService
    {
        public string Read()
        {
            string ConnectionString = @"server=DESKTOP-IMGD37M\SQLEXPRESS;database=OURCUSTOMERS;user=Hirushan;password=hirushan";
            SqlConnection connection =new SqlConnection(ConnectionString);
            connection.Open();
            using (connection)
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM CUSTOMER", connection))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if(dt.Rows.Count > 0)
                    {
                       return JsonConvert.SerializeObject(dt);
                    }
                    else
                    {
                        return "You don't have customers!";
                    }
                }
            }
        }

        public Customer Read(int id)
        {
            string ConnectionString = @"server=DESKTOP-IMGD37M\SQLEXPRESS;database=OURCUSTOMERS;user=Hirushan;password=hirushan";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            using (connection)
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM CUSTOMER WHERE id = "+id, connection))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        Customer customer = new Customer();
                        customer.Id = id;
                        customer.First_Name = Convert.ToString(dt.Rows[0][1]);
                        customer.Last_Name = Convert.ToString(dt.Rows[0][2]);
                        customer.DOB = Convert.ToDateTime(dt.Rows[0][3]);
                        customer.Gender = Convert.ToString(dt.Rows[0][4]);

                        return customer;
                    }
                    else
                    {
                        return null;
                    }
                }
            }


        }

        public void Create(Customer customer)
        {
            string ConnectionString = @"server=DESKTOP-IMGD37M\SQLEXPRESS;database=OURCUSTOMERS;user=Hirushan;password=hirushan";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            using (connection)
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.InsertCommand = new SqlCommand("INSERT INTO CUSTOMER(First_Name,Last_Name,DOB,Gender)VALUES('" + customer.First_Name + "', '" + customer.Last_Name + "','"+customer.DOB+"','"+customer.Gender+"')", connection);
                    adapter.InsertCommand.ExecuteNonQuery();
                }
            }


        }

        public void Update(Customer customer)
        {
            string ConnectionString = @"server=DESKTOP-IMGD37M\SQLEXPRESS;database=OURCUSTOMERS;user=Hirushan;password=hirushan";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            using (connection)
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.UpdateCommand = new SqlCommand("UPDATE CUSTOMER SET First_Name='" + customer.First_Name + "' , Last_Name='" + customer.Last_Name + "' , DOB='" + customer.DOB + "' , Gender='" + customer.Gender + "' WHERE id=" + customer.Id + "", connection);
                    adapter.UpdateCommand.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            string ConnectionString = @"server=DESKTOP-IMGD37M\SQLEXPRESS;database=OURCUSTOMERS;user=Hirushan;password=hirushan";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            using (connection)
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.DeleteCommand = new SqlCommand("DELETE FROM CUSTOMER WHERE id=" + id + "", connection);
                    adapter.DeleteCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
