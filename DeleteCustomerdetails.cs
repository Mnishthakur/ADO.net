using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        // Connection string for your database
        string connectionString = "customer";

        // Create a new SqlConnection using the connection string
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Open the database connection
            connection.Open();

            // Prompt user for the customer ID to delete
            Console.Write("Enter the customer ID to delete: ");
            int customerIdToDelete = Convert.ToInt32(Console.ReadLine());

            // Create a new SqlCommand for deleting the customer
            using (SqlCommand command = connection.CreateCommand())
            {
                // Set the SQL query
                command.CommandText = "DELETE FROM Customer WHERE customer_id = @CustomerIdToDelete";

                // Set the parameter value for the customer ID
                command.Parameters.AddWithValue("@CustomerIdToDelete", customerIdToDelete);

                // Execute the SQL query
                int rowsAffected = command.ExecuteNonQuery();

                // Check if any rows were affected
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Customer deleted successfully.");
                }
                else
                {
                    Console.WriteLine("No customer found with the specified ID.");
                }
            }
        }
    }
}
