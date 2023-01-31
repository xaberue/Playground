using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using Xelit3.Benchmarks;

var exit = false;

while (!exit)
{
	Console.WriteLine("(1). Run Async/Await benchmarks ");
	Console.WriteLine("(2). Run DB benchmarks ");
	Console.WriteLine("-----------------------------------------");
	Console.WriteLine("(e). EXIT ");
	Console.WriteLine("\nPlease write one option:");

    var option = Console.ReadLine();
	Summary summary = null;

    switch (option)
	{
		case "1":
            summary = BenchmarkRunner.Run<AsyncAwaitBenchmarks>();
			break;

        case "2":
            summary = BenchmarkRunner.Run<SqlServerEfCoreIdFetchBenchmarks>();
            break;

		case "e":
            Console.WriteLine("Exiting from the application");
			exit = true;
            break;

        default:
			Console.WriteLine("Incorrect value, please type a valid character");
			break;
	}
}



Console.ReadKey();