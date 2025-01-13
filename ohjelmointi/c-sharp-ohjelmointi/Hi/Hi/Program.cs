using System.Data.Common;
using System.Linq.Expressions;
using Npgsql;

var connectionString = "Host=localhost;Database=suomioy";
await using var dataSource = NpgsqlDataSource.Create(connectionString);

/* Insert some data
await using (var cmd = new NpgsqlCommand("INSERT INTO data (some_field) VALUES (@p)", conn))
{
    cmd.Parameters.AddWithValue("p", "Hello world");
    await cmd.ExecuteNonQueryAsync();
}
*/
// Retrieve all rows
try
{
    var personID = "1";

    await using var cmd = dataSource.CreateCommand("SELECT last_name FROM person LIMIT 10");
    
    cmd.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = int.Parse(personID);

    await using (var reader = await cmd.ExecuteReaderAsync())
    
        while (await reader.ReadAsync())
        {
            Console.WriteLine(reader.GetString(0));
        }
    
}
catch(PostgresException)
{
    Console.WriteLine("ERROR 404");

    Console.WriteLine(e.ToString());
}
finally
{
    Console.WriteLine("Minut ajetaan vaikka mitä tapahtuisi");
}