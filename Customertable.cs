using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        // Connection string for your database
        string connectionString = "Your_Connection_String";

        // Create a new SqlConnection using the connection string
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Open the database connection
            connection.Open();

            // Create a new SqlCommand for inserting customer details
            using (SqlCommand command = connection.CreateCommand())
            {
                // Set the SQL query
                command.CommandText = "INSERT INTO Customer (customer_id, first_name, last_name, email, phone_number, address, city, state, zip_code) " +
                                      "VALUES (@CustomerId, @FirstName, @LastName, @Email, @PhoneNumber, @Address, @City, @State, @ZipCode)";

                // Set the parameter values for the query
                command.Parameters.AddWithValue("@CustomerId", 1); // Replace 1 with the actual customer ID
                command.Parameters.AddWithValue("@FirstName", "John");
                command.Parameters.AddWithValue("@LastName", "Doe");
                command.Parameters.AddWithValue("@Email", "johndoe@example.com");
                command.Parameters.AddWithValue("@PhoneNumber", "1234567890");
                command.Parameters.AddWithValue("@Address", "123 Main Street");
                command.Parameters.AddWithValue("@City", "City");
                command.Parameters.AddWithValue("@State", "State");
                command.Parameters.AddWithValue("@ZipCode", "12345");

                // Execute the SQL query
                int rowsAffected = command.ExecuteNonQuery();

                // Check if any rows were affected
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Customer details added successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to add customer details.");
                }
            }
        }
    }
