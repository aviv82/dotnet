using System.Data;
using System.Data.SqlClient;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string connectionString = "Server=localhost; Database=RestaurantDb; User Id=sa; Password=MyPassword123#";


ReadRestaurantRecords();
Console.ReadLine();


void ReadRestaurantRecords()
{
    using SqlConnection connection = new SqlConnection(connectionString);
    try
    {
        connection.Open();
        var queryString = "SELECT * FROM Customers; SELECT * FROM Orders;";
        SqlCommand command = new SqlCommand(queryString, connection);
        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            for (int i =0; i< reader.FieldCount; i++)
            {
                Console.Write($"\t{reader[i]}");
            }
            Console.WriteLine();
        }
        reader.Close();
        Console.WriteLine("done and dusted");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        connection.Close();
    }
}