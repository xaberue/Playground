using Xelit3.Playground.ResultPattern;

Console.WriteLine("Welcome to sample xaberue's app about Result pattern");

//Invoke service in Classes
var service = Helper.GetSampleService();
var info = new ExternalLoginInfo();

var result = service.ProvisionUser(info);

Console.WriteLine("End of the sample");
Console.ReadLine();
