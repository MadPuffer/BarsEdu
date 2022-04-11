using System;
using System.Collections.Generic;
using System.Threading;

Console.WriteLine("App is running");

string msg;
string argument;
List<string> arguments = new();

while (true)  // app loop
{
    Console.WriteLine("Enter the request text to send. Type /q to exit");
    
    msg = Console.ReadLine();
    if (msg == "/q") break;

    Console.WriteLine($"message will be sent: {msg}.\nEnter the message arguments. If no arguments are needed, type /end");
    
    while ((argument = Console.ReadLine()) != "/end")
    {
        arguments.Add(argument);
        Console.WriteLine("Enter the following message argument. If no arguments are needed, type /end");
    }
    
    string id = Guid.NewGuid().ToString("D");
    ThreadPool.QueueUserWorkItem(callback => MessageSender(msg, id, arguments.ToArray()));

    Console.WriteLine($"message was sent: {msg}. Assigned id - {id}");

}
Console.WriteLine("App is shutting down");


static void MessageSender(string msg, string id, string[] args)
{
    var requester = new DummyRequestHandler();
    try
    {
        Console.WriteLine($"Message with id - {id} received an answer - {requester.HandleRequest(msg, args)}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Message with id - {id} crashed with an error - {ex.Message}");
    }
}