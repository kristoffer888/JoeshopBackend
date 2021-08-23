using SimpleShopModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimleShopORM
{
    public class ORM_MsSql : IORM
    {
        private SqlConnection dbConn;
        private string host = "localhost";
        private string username = "admin";
        private string password = "admin";
        private string database = "Butik";

        public ORM_MsSql()
        {
            SqlConnectionStringBuilder conString = new SqlConnectionStringBuilder()
            {
                InitialCatalog = database,
                UserID = username,
                Password = password,
                DataSource = host

            };

            // Instantier objekt af SqlConnection
            dbConn = new SqlConnection(conString.ToString());
        }

        public Customer GetCustomer(int id)
        {
            Customer customer = null;

            string query = "SELECT * FROM Kunde WHERE id = @val";
            SqlCommand cmd = new SqlCommand(query, dbConn);
            cmd.Parameters.AddWithValue("@val", id);

            if (dbConn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    // open database connection
                    dbConn.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                int i = 0;
                while (reader.Read())
                {
                    customer = new Customer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                    i++;
                }

                if (i != 1) return null;
            }

            return customer;
        }
        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            string query = "SELECT * FROM Kunde";
            SqlCommand cmd = new SqlCommand(query, dbConn);

            if (dbConn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    // open database connection
                    dbConn.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                int i = 0;
                while (reader.Read())
                {
                    customers.Add(new Customer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4)));
                    i++;
                }
            }

            return customers;
        }
        public Customer CreateCostumer(Customer customer)
        {
            string query = "INSERT INTO Kunde (Navn, Adresse,Lokation_ID,Email, Password) VALUES (@val1, @val2, @val3, @val4, @val5); SELECT SCOPE_IDENTITY() AS id;";
            SqlCommand cmd = new SqlCommand(query, dbConn);
            cmd.Parameters.AddWithValue("@val1", product.CustomerName);
            cmd.Parameters.AddWithValue("@val2", product.CustomerAddress);
            cmd.Parameters.AddWithValue("@val3", product.CustomerLocation);
            cmd.Parameters.AddWithValue("@val4", product.CustomerEmail);
            cmd.Parameters.AddWithValue("@val5", product.CustomerPassword);

            if (dbConn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    dbConn.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            customer.SetId(Convert.ToInt32(cmd.ExecuteScalar()));
            dbConn.Close();

            return customer;
        }
        public Product UpdateCustomer(Customer customer)
        {
        }
        public Product DeleteCustomer(Customer customer)
        {
        }
    }
}
