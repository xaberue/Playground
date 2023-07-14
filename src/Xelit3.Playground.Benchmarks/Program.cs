using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using Xelit3.Playground.Benchmarks;
using Xelit3.Playground.SqlServer;

var exit = false;

while (!exit)
{
	Console.WriteLine("(1). Run Async/Await benchmarks ");
	Console.WriteLine("(2). Run mapping benchmarks ");
	Console.WriteLine("(3). Run SqlServer EFCore different PK's fetching benchmarks ");
	Console.WriteLine("(4). Run SqlServer different feching mechanisms benchmarks ");
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
            summary = BenchmarkRunner.Run<MappingBenchmarks>();
            break;

        case "3":
            var personsCount1 = GetPersonsSizeCount();
            SqlServerDbTestDataContextHelper.Instance.InitializeAllKeyTypes(personsCount1);
            summary = BenchmarkRunner.Run<SqlServerEfCoreFetchingDifferentPrimaryKeysBenchmarks>();
            SqlServerDbTestDataContextHelper.Instance.Finish();
            break;

        case "4":
            var personsCount2 = GetPersonsSizeCount();
            if(!(personsCount2 == 0))
                SqlServerDbTestDataContextHelper.Instance.InitializeDefault(personsCount2);
            else
                SqlServerDbTestDataContextHelper.Instance.InitializeDefault();
            summary = BenchmarkRunner.Run<SqlServerQueryBenchmarks>();
            if (!(personsCount2 == 0))
                SqlServerDbTestDataContextHelper.Instance.Finish();
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



static int GetPersonsSizeCount()
{
    var ok = false;
	var inputText = string.Empty;
    while (!ok)
    {
		try
		{
            Console.WriteLine($"Please entry how many users to add in the test database:");
            inputText = Console.ReadLine();
			ok = true;

            return int.Parse(inputText);
		}
		catch (Exception)
		{
			Console.WriteLine($"Invalid entry {inputText}. Please type a valid number");
		}		
    }
    return 0;
}