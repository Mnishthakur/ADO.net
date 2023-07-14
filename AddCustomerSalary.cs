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

            // Prompt user for the customer name and new salary
            Console.Write("Enter the customer name: ");
            string customerName = Console.ReadLine();
            
            Console.Write("Enter the new salary: ");
            decimal newSalary = Convert.ToDecimal(Console.ReadLine());

            // Create a new SqlCommand for updating the customer's salary
            using (SqlCommand command = connection.CreateCommand())
            {
                // Set the SQL query
                command.CommandText = "UPDATE Customer SET salary = @NewSalary WHERE name = @CustomerName";

                // Set the parameter values for the query
                command.Parameters.AddWithValue("@NewSalary", newSalary);
                command.Parameters.AddWithValue("@CustomerName", customerName);

                // Execute the SQL query
                int rowsAffected = command.ExecuteNonQuery();

                // Check if any rows were affected
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Customer salary updated successfully.");
                }
                else
                {
                    Console.WriteLine("No customer found with the specified name.");
                }
            }
        }
    }
}

