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
        private string username = "joe";
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

        // Get customer by id
        public Customer GetCustomer(int id)
        {
            Customer customer = null;

            string query = "Select Kunde.Kunde_ID, Kunde.Navn, Kunde.Adresse, Lokation.Lokation_ID, Lokation.postnummer AS Postnummer, Kunde.Email, Kunde.Password" +
                " from (Kunde INNER JOIN Lokation on Kunde.Lokation_ID = Lokation.Lokation_ID) WHERE Kunde.Kunde_ID = @val;";
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
                    customer = new Customer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), new (reader.GetInt32(3), reader.GetInt32(4)), reader.GetString(5), reader.GetString(6));
                    i++;
                }

                if (i != 1) return null;
            }

            return customer;
        }
        // Get all customers
        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            string query = "Select Kunde.Kunde_ID, Kunde.Navn, Kunde.Adresse, Lokation.Lokation_ID, Lokation.postnummer AS Postnummer, Kunde.Email, Kunde.Password" +
                " from Kunde INNER JOIN Lokation on Kunde.Lokation_ID = Lokation.Lokation_ID;";
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
                    customers.Add(new Customer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), new (reader.GetInt32(3), reader.GetInt32(4)), reader.GetString(5), reader.GetString(6)));
                    i++;
                }
            }

            return customers;
        }
        // Create customer
        public Customer CreateCustomer(Customer customer)
        {
            string query = "INSERT INTO Kunde (Navn, Adresse,Lokation_ID,Email, Password) VALUES (@val1, @val2, @val3, @val4, @val5); SELECT SCOPE_IDENTITY() AS id;";
            SqlCommand cmd = new SqlCommand(query, dbConn);
            cmd.Parameters.AddWithValue("@val1", customer.CustomerName);
            cmd.Parameters.AddWithValue("@val2", customer.CustomerAddress);
            cmd.Parameters.AddWithValue("@val3", customer.CustomerLocation);
            cmd.Parameters.AddWithValue("@val4", customer.CustomerEmail);
            cmd.Parameters.AddWithValue("@val5", customer.CustomerPassword);

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
        // Update customer
        public Customer UpdateCustomer(Customer customer)
        {
            string query = "UPDATE Kunde" +
                "SET Navn = val1, Adresse = val2, Lokation = val3, Email = val4, Password = val5" +
                "WHERE Kunde_ID = @val0";
            //string query = "UPDATE Kunde SET name=@NAME WHERE id=@ID;";
            SqlCommand cmd = new SqlCommand(query, dbConn);
            cmd.Parameters.AddWithValue("@val0", customer.CustomerId);
            cmd.Parameters.AddWithValue("@val1", customer.CustomerName);
            cmd.Parameters.AddWithValue("@val2", customer.CustomerAddress);
            cmd.Parameters.AddWithValue("@val3", customer.CustomerLocation);
            cmd.Parameters.AddWithValue("@val4", customer.CustomerEmail);
            cmd.Parameters.AddWithValue("@val5", customer.CustomerPassword);


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

            int row = cmd.ExecuteNonQuery();
            dbConn.Close();

            if (row == 1)
            {
                return customer;
            }
            else
            {
                return null;
            }

        }
        // Delete Customer by id
        public Customer DeleteCustomer(Customer customer)
        {

            string query = "DELETE FROM Kunde WHERE Kunde.Kunde_ID = @val;";
            SqlCommand cmd = new SqlCommand(query, dbConn);
            cmd.Parameters.AddWithValue("@val", customer.CustomerId);

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
            }
            int row = cmd.ExecuteNonQuery();
            dbConn.Close();

            if (row == 1)
            {
                return customer;
            }
            else
            {
                return null;
            }
        }



        // Get Manufacturer by id
        public Manufacturer GetManufacturer(int id)
        {
            Manufacturer manufacturer = null;

            string query = "Select Fabrikant.Fabrikant_ID, Fabrikant.Navn " +
                "from Fabrikant " +
                "WHERE Fabrikant.Fabrikant_ID = @val;";
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
                    manufacturer = new Manufacturer(reader.GetInt32(0), reader.GetString(1));
                    i++;
                }

                if (i != 1) return null;
            }

            return manufacturer;
        }
        // Get all Manufacturers
        public List<Manufacturer> GetManufacturers()
        {
            List<Manufacturer> manufacturer = new List<Manufacturer>();

            string query = "Select Fabrikant.Fabrikant_ID, Fabrikant.Navn from Fabrikant";
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
                    manufacturer.Add(new Manufacturer(reader.GetInt32(0), reader.GetString(1)));
                    i++;
                }
            }

            return manufacturer;
        }
        // Create Manufacturer
        public Manufacturer CreateManufacturer(Manufacturer manufacturer)
        {
            string query = "INSERT INTO Fabrikant (Navn) VALUES (@val1); SELECT SCOPE_IDENTITY() AS Fabrikant_ID;";
            SqlCommand cmd = new SqlCommand(query, dbConn);
            cmd.Parameters.AddWithValue("@val1", manufacturer.ManufacturerName);

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

            manufacturer.SetId(Convert.ToInt32(cmd.ExecuteScalar()));
            dbConn.Close();

            return manufacturer;
        }
        // Update Manufacturer
        public Manufacturer UpdateManufacturer(Manufacturer manufacturer)
        {
            string query = "UPDATE Fabrikant SET Navn = @val0 WHERE Fabrikant_ID = @val1";
            SqlCommand cmd = new SqlCommand(query, dbConn);
            cmd.Parameters.AddWithValue("@val0", manufacturer.ManufacturerName);
            cmd.Parameters.AddWithValue("@val1", manufacturer.ManufacturerId);


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

            int row = cmd.ExecuteNonQuery();
            dbConn.Close();

            if (row == 1)
            {
                return manufacturer;
            }
            else
            {
                return null;
            }

        }
        // Delete Manufacturer
        public Manufacturer DeleteManufacturer(Manufacturer manufacturer)
        {

            string query = "DELETE FROM Fabrikant WHERE Fabrikant.Fabrikant_ID = @val;";
            SqlCommand cmd = new SqlCommand(query, dbConn);
            cmd.Parameters.AddWithValue("@val", manufacturer.ManufacturerId);

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
            }
            int row = cmd.ExecuteNonQuery();
            dbConn.Close();

            if (row == 1)
            {
                return manufacturer;
            }
            else
            {
                return null;
            }
        }
    }
}
