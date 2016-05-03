using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace Customer_bussiness
{
    class CustomerService
    {
        private String connectionString;
        private static CustomerService current;

        public static CustomerService Current
        {
            get
            {
                return current ?? (current = new CustomerService());
            }
        }
       
        private CustomerService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            // connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=NORTHWND;Integrated Security=True";
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                try
                {

                    String myQuery = "Select * from Customers";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {
                        myConnection.Open();
                        SqlDataReader myReader = myCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            Customer customer = FillCustomerFromReader(myReader);

                            customers.Add(customer);
                        }
                        myConnection.Close();
                    }

                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

            }

            return customers;
        }

        public Customer GetCustomerById(string id)
        {
            Customer customer = null;

            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                try
                {

                    String myQuery = "Select * from Customers where CustomerId = @customerID";


                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {
                        SqlParameter p = new SqlParameter("@customerID", System.Data.SqlDbType.NChar, 5);
                        p.Value = id;

                        myCommand.Parameters.Add(p);

                        myConnection.Open();
                        SqlDataReader myReader = myCommand.ExecuteReader();

                        if (myReader.Read())
                            customer = FillCustomerFromReader(myReader);

                        myConnection.Close();
                    }

                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

            }
            return customer;

        }

        public Customer FillCustomerFromReader(SqlDataReader reader)
        {
            Customer customer = new Customer();

           
            return customer;
        }

    }
}
