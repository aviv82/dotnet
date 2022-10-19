using System.Data;
using System.Data.SqlClient;
using System.Linq;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string connectionString = "Server=localhost;Database=TestDb; User Id=sa; Password=MyPassword123#";

//ReadStudentRecords();
//InsertStudentRecords();
//ReadStudentRecords();
//DataAdapterGetStudent();
DataAdapterGetjustOne();
ReadStudentRecords();
Console.ReadLine();

void ReadStudentRecords()
{
    using SqlConnection connection = new SqlConnection(connectionString);

    try
    {
        connection.Open();
        var queryString = "SELECT Id, firstName, lastName, age FROM student";
        SqlCommand command = new SqlCommand(queryString, connection);
        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"\t{reader[0]}\t{reader[1]}\t{reader[2]}\t{reader[3]}");
        }
        reader.Close();
        Console.WriteLine("done and done");
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

void InsertStudentRecords()
{
    using SqlConnection connection = new SqlConnection(connectionString);


    try
    {
    var command = new SqlCommand("INSERT INTO student (firstName, lastName, age) VALUES('veronica', 'herbert', 67)", connection);
        connection.Open();
        command.ExecuteNonQuery();
        Console.WriteLine("insert successful");

    }

    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    finally
    {
        connection.Close();
    }
    Console.WriteLine("-----[][][]-----");
}

void DataAdapterGetStudent()
{
   using var connection = new SqlConnection(connectionString);

    try
    {
        var dataAdapter = new SqlDataAdapter("SELECT * FROM student; SELECT * FROM classes;", connection);
        var dataSet = new DataSet();
        dataAdapter.Fill(dataSet);
        connection.Open();

        dataSet.Tables[0].TableName = "student";
        dataSet.Tables[1].TableName = "classes";

        var firstNames = dataSet.Tables["student"].AsEnumerable()
        .Select(r => r["firstName"]);

        var studentClass = dataSet.Tables["student"].AsEnumerable()
            .Where(s => !string.IsNullOrEmpty(s["classId"].ToString())).Select(s => s["firstName"] + " " + s["lastName"]);

        foreach (var name in studentClass)
        {
            Console.WriteLine(name);
        }

        foreach (var name in firstNames)
    {
            Console.WriteLine(name);
    }

        
    }



    /*
    foreach (DataTable table in dataSet.Tables)
    {
        Console.WriteLine(table.TableName);
        foreach (DataRow row in table.Rows)
        {
            if (table.TableName == "student")
           {
                Console.WriteLine($"\t{row[0]}\t{row[1]}\t{row[2]}\t{row[3]}\t{row[4]}");
            } else {
                Console.WriteLine($"\t{row[0]}\t{row[1]}\t{row[2]}");
            }
        }
    }
}
    */
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void DataAdapterGetjustOne()
{
using var connection = new SqlConnection(connectionString);

try
{
    var dataAdapter = new SqlDataAdapter("SELECT * FROM student;", connection);
        dataAdapter.UpdateCommand = new SqlCommand("UPDATE student SET firstName = @firstName, lastName = @lastname " + "WHERE Id = @Id", connection);
        dataAdapter.UpdateCommand.Parameters.Add("@firstName", SqlDbType.NVarChar, 20, "firstname");
        dataAdapter.UpdateCommand.Parameters.Add("@lastName", SqlDbType.NVarChar, 20, "lastName");

        SqlParameter parameter = dataAdapter.UpdateCommand.Parameters.Add("@Id", SqlDbType.Int);

        parameter.SourceColumn = "Id";
        parameter.SourceVersion = DataRowVersion.Original;

        var dataSet = new DataSet();
        dataAdapter.Fill(dataSet);

        var rowToUpdate = dataSet.Tables[0].AsEnumerable().FirstOrDefault(s => s["firstname"].ToString() == "joren");

        if (rowToUpdate != null)
        {
            rowToUpdate["firstName"] = "general";
            rowToUpdate["lastname"] = "kenobi";
            dataAdapter.Update(dataSet);
        }

        /*
        connection.Open();

        var dataSet = new DataSet();
        dataAdapter.Fill(dataSet);

        dataSet.Tables[0].TableName = "student";

    var firstNames = dataSet.Tables["student"].AsEnumerable()
    .Select(r => r["firstName"]);

    var studentClass = dataSet.Tables["student"].AsEnumerable()
        .Where(s => !string.IsNullOrEmpty(s["classId"].ToString())).Select(s => s["firstName"] + " " + s["lastName"]);

    foreach (var name in studentClass)
    {
        Console.WriteLine(name);
    }

    foreach (var name in firstNames)
    {
        Console.WriteLine(name);
    }
        */

    }

    catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
}