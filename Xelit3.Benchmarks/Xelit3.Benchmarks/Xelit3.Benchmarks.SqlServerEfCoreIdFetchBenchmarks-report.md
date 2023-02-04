``` ini

BenchmarkDotNet=v0.13.4, OS=Windows 11 (10.0.22621.1194)
Intel Core i7-5930K CPU 3.50GHz (Broadwell), 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.102
  [Host] : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2

Job=MediumRun  Toolchain=InProcessNoEmitToolchain  IterationCount=15  
LaunchCount=2  WarmupCount=10  

```
|                              Method |         Mean |        Error |       StdDev | Allocated |
|------------------------------------ |-------------:|-------------:|-------------:|----------:|
|       RetrieveSingleElementFromGuid |     383.3 ns |     20.64 ns |     29.60 ns |     192 B |
|        RetrieveSingleElementFromInt |     329.4 ns |      3.76 ns |      5.39 ns |     184 B |
|       RetrieveSingleElementFromLong |     327.4 ns |      2.92 ns |      4.09 ns |     184 B |
|    RetrieveMultilpeRowsWithTracking | 305,907.2 ns | 12,885.50 ns | 18,480.00 ns |   11289 B |
| RetrieveMultilpeRowsWithoutTracking | 299,988.1 ns |  4,673.13 ns |  6,849.82 ns |   11857 B |
