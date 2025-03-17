using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoredProcdure
{
    //Calling a SP_AddNewPerson from C# Using ADO.NET

    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "YourConnectionStringHere";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SP_AddNewPerson", connection);
            command.CommandType = CommandType.StoredProcedure;


            // Add parameters
            command.Parameters.AddWithValue("@FirstName", "John");
            command.Parameters.AddWithValue("@LastName", "Doe");
            command.Parameters.AddWithValue("@Email", "john.doe@example.com");
            SqlParameter outputIdParam = new SqlParameter("@NewPersonID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(outputIdParam);


            // Execute
            connection.Open();
            command.ExecuteNonQuery();


            // Retrieve the ID of the new person
            int newPersonID = (int)command.Parameters["@NewPersonID"].Value;
            Console.WriteLine($"New Person ID: {newPersonID}");


            connection.Close();
        }
    }
}
