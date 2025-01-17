﻿using System.Data;
using System.Data.SqlClient;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string connectionString = "Server=localhost; Database=RestaurantDb; User Id=sa; Password=MyPassword123#";

//ReadCustomerRecords();
//ReadRestaurantRecords();
Console.ReadLine();


void ReadCustomerRecords()
{
    using SqlConnection connection = new SqlConnection(connectionString);
    try
    {
        
        connection.Open();
        var queryString = "SELECT * FROM Customers; SELECT * FROM Orders;";
        SqlCommand command = new SqlCommand(queryString, connection);
        SqlDataReader reader = command.ExecuteReader();


        /*
        var dataRead = new SqlDataAdapter("SELECT * FROM Customers; SELECT * FROM Orders;", connection);
        var dataSet = new DataSet();
        dataRead.Fill(dataSet);

        dataSet.Tables[0].TableName = "customers";
        dataSet.Tables[1].TableName = "orders";

        var customers = dataSet.Tables["Customers"].AsEnumerable().Select(r => r["Name"]);
        var orders = dataSet.Tables["Orders"].AsEnumerable().Select(r => r["Description"]);

        Console.WriteLine("Customers:");
        Console.WriteLine();
        foreach (var customer in customers)
        {
            
            Console.WriteLine(customer);
        }
        Console.WriteLine();
        Console.WriteLine("Orders:");
        Console.WriteLine();
        foreach (var order in orders)
        {
           
            Console.WriteLine(order);
        }
        */

      
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"\t{reader[i]}");
                }
                Console.WriteLine();
            }
            //reader.NextResult();
        reader.Close();
        Console.WriteLine("done and dusted");

        // this is how to get both!
        /*
        while (reader.HasRows)
        {
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"\t{reader[i]}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        reader.NextResult();
        }
        reader.Close();
        Console.WriteLine("done and dusted");
        */
        
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

void InsertCustomer()
{
    using SqlConnection connection = new SqlConnection(connectionString);
    Console.WriteLine("please enter name");
    var toInsertName = Console.ReadLine();
    Console.WriteLine("please enter age");
    var toInsertAge = Console.ReadLine();
    try
    {
        var command = new SqlCommand($"INSERT INTO Customers (Name, Age) VALUES('{toInsertName}',{toInsertAge})", connection);
        connection.Open();
        command.ExecuteNonQuery();
        ReadCustomerRecords();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        connection.Close();
    }

};

void ReadOrderRecords()
{
    using SqlConnection connection = new SqlConnection(connectionString);
    try
    {

        connection.Open();
        var queryString = "SELECT * FROM Orders;";
        SqlCommand command = new SqlCommand(queryString, connection);
        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
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

void InsertOrder()
{
    using SqlConnection connection = new SqlConnection(connectionString);
    Console.WriteLine("please enter number");
    var toInsertNumber = Console.ReadLine();
    Console.WriteLine("please enter description");
    var toInsertDescription = Console.ReadLine();
    Console.WriteLine("please enter diner id");
    var toInsertId = Console.ReadLine();
    try
    {
        var command = new SqlCommand($"INSERT INTO Orders (OrderNumber, Description, CustomerId) VALUES({toInsertNumber},'{toInsertDescription}', {toInsertId})", connection);
        connection.Open();
        command.ExecuteNonQuery();
        ReadOrderRecords();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        connection.Close();
    }

};

void RemoveCustomer()
{
    using SqlConnection connection = new SqlConnection(connectionString);
    Console.WriteLine("please enter name to delete");
    var toDeleteName = Console.ReadLine();
    try
    {
        var command = new SqlCommand($"DELETE FROM Customers WHERE Name='{toDeleteName}';", connection);
        connection.Open();
        command.ExecuteNonQuery();
        ReadCustomerRecords();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        connection.Close();
    }

};

void RemoveOrder()
{
    using SqlConnection connection = new SqlConnection(connectionString);
    Console.WriteLine("please enter order number to delete");
    var toDeleteNumber = Console.ReadLine();
    try
    {
        var command = new SqlCommand($"DELETE FROM Orders WHERE OrderNumber={toDeleteNumber};", connection);
        connection.Open();
        command.ExecuteNonQuery();
        ReadOrderRecords();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        connection.Close();
    }

};

void ReadRestaurantRecords()
{
    using SqlConnection connection = new SqlConnection(connectionString);
    try
    {
        /*
        connection.Open();
        var queryString = "SELECT * FROM Customers; SELECT * FROM Orders;";
        SqlCommand command = new SqlCommand(queryString, connection);
        SqlDataReader reader = command.ExecuteReader();
        */

        var dataRead = new SqlDataAdapter("SELECT * FROM Customers; SELECT * FROM Orders;", connection);
        var dataSet = new DataSet("restaurant");
        dataRead.Fill(dataSet);

        dataSet.Tables[0].TableName = "customers";
        dataSet.Tables[1].TableName = "orders";

        Console.WriteLine();
        Console.WriteLine(dataSet.DataSetName);
        Console.WriteLine();

        foreach (DataTable t in dataSet.Tables)
        {
            Console.WriteLine($"{t.TableName}");
            Console.WriteLine();
            if (t.TableName == "customers")
            {
                t.Columns[0].ColumnName = "id";
                t.Columns[1].ColumnName = "name";
                t.Columns[2].ColumnName = "age";
            } else
            {
                t.Columns[0].ColumnName = "id";
                t.Columns[1].ColumnName = "number";
                t.Columns[2].ColumnName = "description";
                t.Columns[3].ColumnName = "customer id";
            }

            for(int i = 0; i < t.Columns.Count; i++)
            {
                Console.Write($"\t{t.Columns[i].ColumnName}");
            }
            Console.WriteLine();
            foreach (DataRow r in t.Rows)
            {
                for (int i = 0; i < t.Columns.Count; i++)
                {
                    Console.Write($"\t{r[i]}");
                }
                    Console.WriteLine();
            }
        }

        //dataSet.Tables[0].TableName = "customers";
        //dataSet.Tables[1].TableName = "orders";

        //var customers = dataSet.Tables["Customers"].AsEnumerable().Select(r => r["Name"]);
        //var orders = dataSet.Tables["Orders"].AsEnumerable().Select(r => r["Description"]);

        //Console.WriteLine(dataSet.Tables[0].AsDataView());

       /*
       Console.WriteLine("Customers:");
       Console.WriteLine();


       foreach (var customer in customers)
       {

           Console.WriteLine(customer);
       }
       Console.WriteLine();
       Console.WriteLine("Orders:");
       Console.WriteLine();
       foreach (var order in orders)
       {

           Console.WriteLine(order);
       }
       */


        /*
        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($"\t{reader[i]}");
            }
            Console.WriteLine();
        }
        reader.Close();
        Console.WriteLine("done and dusted");
        */

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

void UpdateCustomers()
{
    using SqlConnection connection = new SqlConnection(connectionString);

    Console.WriteLine("select customer name to update");
    var toUpdate = Console.ReadLine();

    Console.WriteLine("choose new name for customer");
    var newName = Console.ReadLine();

    try
    {
        SqlDataAdapter adapter = new SqlDataAdapter("", connectionString);

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