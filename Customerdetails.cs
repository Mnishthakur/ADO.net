using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        // Connection string for your database
        string connectionString = "Customer";

        // Create a new SqlConnection using the connection string
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Open the database connection
            connection.Open();

            // Create a new SqlCommand for selecting all customer details
            using (SqlCommand command = new SqlCommand("SELECT * FROM Customer", connection))
            {
                // Create a SqlDataReader to read the data
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Check if any rows were returned
                    if (reader.HasRows)
                    {
                        // Iterate over the rows and retrieve the customer details
                        while (reader.Read())
                        {
                            int customerId = reader.GetInt32(reader.GetOrdinal("customer_id"));
                            string firstName = reader.GetString(reader.GetOrdinal("first_name"));
                            string lastName = reader.GetString(reader.GetOrdinal("last_name"));
                            string email = reader.GetString(reader.GetOrdinal("email"));
                            string phoneNumber = reader.GetString(reader.GetOrdinal("phone_number"));
                            string address = reader.GetString(reader.GetOrdinal("address"));
                            string city = reader.GetString(reader.GetOrdinal("city"));
                            string state = reader.GetString(reader.GetOrdinal("state"));
                            string zipCode = reader.GetString(reader.GetOrdinal("zip_code"));

                            // Display the customer details
                            Console.WriteLine("Customer ID: " + customerId);
                            Console.WriteLine("First Name: " + firstName);
                            Console.WriteLine("Last Name: " + lastName);
                            Console.WriteLine("Email: " + email);
                            Console.WriteLine("Phone Number: " + phoneNumber);
                            Console.WriteLine("Address: " + address);
                            Console.WriteLine("City: " + city);
                            Console.WriteLine("State: " + state);
                            Console.WriteLine("Zip Code: " + zipCode);
                            Console.WriteLine("-----------------------------------");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No customers found.");
                    }
                }
            }
        }
    }
}
