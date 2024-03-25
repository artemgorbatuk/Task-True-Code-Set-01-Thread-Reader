using Api;

var client = new ClientService();

try
{
    await client.StartClientAsync(new IpAddressModel(), () =>
    {
        Console.WriteLine("The client is running.");
        Console.WriteLine();
    });

    var messages = Enumerable.Range(0, 10).Select(p => TextProcessor.GenerateText(5));

    var secret = "FLUGGAENKDECHIOEBOLSEN\n";

    await client.WriteStreamAsync(messages, (message) =>
    {
        Console.WriteLine($"Message has bent sent : {message.Substring(0, message.Length - 2)}");
    }, secret);
}
catch (Exception exception)
{
    Console.WriteLine(exception.Message);
}
finally
{
    client.CloseClient(() => 
    {
        Console.WriteLine();
        Console.WriteLine("Client was closed"); 
    });
}

Console.ReadKey();