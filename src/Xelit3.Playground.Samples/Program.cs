using Xelit3.Playground.Samples;
using Xelit3.Playground.SqlServer;

var exit = false;

while (!exit)
{
    Console.WriteLine("(1). Run EFCore Cartesian scenario ");
    Console.WriteLine("-----------------------------------------");
    Console.WriteLine("(e). EXIT ");
    Console.WriteLine("\nPlease write one option:");

    var option = Console.ReadLine();
    
    switch (option)
    {
        case "1":
            //Prepare
            var personsCount = GetPersonsSizeCount();
            EFTestDataContextHelper.Instance.Initialize(personsCount);
            
            //Run
            SqlServerEfCoreFetchingSamples.Run();

            //Clean
            EFTestDataContextHelper.Instance.Finish();
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