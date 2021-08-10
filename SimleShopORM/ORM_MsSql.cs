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
        
        private string host = "10.142.69.56";
        private string username = "SimpleShop";
        private string password = "SimpleShop";
        private string database = "SimpleShop";

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

            string query = "SELECT id, navn FROM kunde WHERE id = @val";
            SqlCommand cmd = new SqlCommand(query, dbConn);
            cmd.Parameters.AddWithValue("@val", id);
            
            if (dbConn.State == System.Data.ConnectionState.Closed) 
            {
                try
                {
                    // open database connection
                    dbConn.Open();
                }
                catch (Exception ex) {
                    throw new Exception(ex.Message);
                }

                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                int i = 0;
                while (reader.Read()) 
                {
                    customer = new Customer(reader.GetInt32(0), reader.GetString(1));
                    i++;
                }

                if (i != 1) return null;
            }
            
            return customer;
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            string query = "SELECT id, navn FROM kunde";
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
                    customers.Add(new Customer(reader.GetInt32(0), reader.GetString(1)));
                    i++;
                }

                if (i <= 0) return null;
            }

            return customers;
        }

        public Product GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
