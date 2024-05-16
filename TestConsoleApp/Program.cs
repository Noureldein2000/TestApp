// See https://aka.ms/new-console-template for more information
using TestConsoleApp;

Console.WriteLine("Hello, World!");
var count = 0;
var anyObject = new DTO();

Console.WriteLine(MutliTask.UseThreads(count, anyObject));

Console.WriteLine($"will next call job!{nameof(MutliTask.UseTasks)}");

Console.WriteLine(MutliTask.UseTasks(count, anyObject));

Console.WriteLine($"will next call job!{nameof(MutliTask.UseParallelFor)}");

Console.WriteLine(MutliTask.UseParallelFor(count, anyObject));
