# Logging samples

This folder contains sample implementations, best practices and tests realted to Logging on Asp Net Core.

_NOTE: This sample is a test project, may contain inconsistencies, potential improvements._

## Links

- [Logging in C# and .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/logging?tabs=command-line)
- [Serilog](https://serilog.net/)
- [Seq](https://datalust.co/)

### Default Console provider

- The default logging doesn't differentiate between serialization or not by default, you have to do it explicitly.
- It is possible to use scopes in console.
- It is possible to give format to certain properties, like dates.


### Serilog

- Serilog easily capture @ to differentiate logs Serialization from ToString
- Console gives colour formatting to certain properties, like dates.

```
[00:55:52 INF] Now listening on: https://localhost:7200
[00:55:52 INF] Now listening on: http://localhost:5066
[00:55:52 INF] No action descriptors found. This may indicate an incorrectly configured application or missing application parts. To learn more, visit https://aka.ms/aspnet/mvc/app-parts
[00:55:52 INF] Application started. Press Ctrl+C to shut down.
[00:55:52 INF] Hosting environment: Development
[00:55:52 INF] Content root path: F:\Workspace\Xelit3\Playground\dotnet\Xelit3.Playground.Logging\Xelit3.Playground.Logging.SerilogSample
[00:55:57 INF] Request starting HTTP/1.1 GET http://localhost:5066/weatherforecast/ - null null
[00:55:57 INF] Request finished HTTP/1.1 GET http://localhost:5066/weatherforecast/ - 307 0 null 70.4614ms
[00:55:57 INF] Request starting HTTP/1.1 GET https://localhost:7200/weatherforecast/ - null null
[00:55:57 INF] Executing endpoint 'HTTP: GET /weatherforecast'
[00:55:57 INF] Request finnished April 11, 2025
[00:55:57 INF] Weather forecast response [ToString()]: WeatherForecast { Date = 13/04/2025, TemperatureC = 45, Summary = Cool, TemperatureF = 112 }
[00:55:57 INF] Weather forecast response [Serialization]: {"Date": "13/04/2025", "TemperatureC": 45, "Summary": "Cool", "TemperatureF": 112, "$type": "WeatherForecast"}
[00:55:57 ERR] Weather forecast error This is a test exception
System.Exception: This is a test exception
   at Program.<>c__DisplayClass0_0.<<Main>$>b__1(ILoggerFactory loggerFactory) in F:\Workspace\Xelit3\Playground\dotnet\Xelit3.Playground.Logging\Xelit3.Playground.Logging.SerilogSample\Program.cs:line 49
[00:55:57 INF] Executed endpoint 'HTTP: GET /weatherforecast'
[00:55:57 INF] Request finished HTTP/1.1 GET https://localhost:7200/weatherforecast/ - 200 null application/json; charset=utf-8 180.2012ms
```