using Api;

var server = new ServerService();

try
{
    server.StartServer(() =>
    {
        Console.WriteLine("The server is running.");
        Console.WriteLine();
    });

    await foreach (var message in server.ReadSreamAsync((byte)'\n'))
    {
        Console.WriteLine($"Message has been gotten: {message}");
    }
}
catch (Exception exception)
{
    Console.WriteLine(exception.Message);
}
finally
{
    server.StopServer(() =>
    {
        Console.WriteLine();
        Console.WriteLine("The server was stopped");
    });
}

Console.ReadKey();