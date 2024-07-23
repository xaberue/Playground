``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22621.1485/22H2/2022Update/SunValley2)
Intel Core i7-5930K CPU 3.50GHz (Broadwell), 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.202
  [Host] : .NET 7.0.4 (7.0.423.11508), X64 RyuJIT AVX2

Job=MediumRun  Toolchain=InProcessNoEmitToolchain  IterationCount=15  
LaunchCount=2  WarmupCount=10  

```
|                                                     Method |           Mean |         Error |        StdDev |         Median | Allocated |
|----------------------------------------------------------- |---------------:|--------------:|--------------:|---------------:|----------:|
|                              RetrieveSingleElementFromGuid |       357.8 ns |      29.19 ns |      40.93 ns |       344.6 ns |     192 B |
|                               RetrieveSingleElementFromInt |       339.6 ns |       9.30 ns |      13.04 ns |       333.1 ns |     184 B |
|                              RetrieveSingleElementFromLong |       323.9 ns |       3.03 ns |       4.53 ns |       322.8 ns |     184 B |
|                           RetrieveMultilpeRowsWithTracking | 2,484,450.0 ns |  46,428.59 ns |  61,980.83 ns | 2,458,410.9 ns |   11295 B |
|                        RetrieveMultilpeRowsWithoutTracking | 2,492,198.4 ns |  34,792.06 ns |  47,623.77 ns | 2,486,146.5 ns |   11863 B |
|                    RetrieveMultilpeRowsWithCartesianValues | 2,566,912.0 ns |  95,621.20 ns | 134,047.57 ns | 2,531,425.0 ns |   62253 B |
|      RetrieveMultilpeRowsWithoutCartesianValues_SplitQuery | 4,182,674.6 ns | 405,358.23 ns | 606,721.11 ns | 4,490,212.8 ns |   40013 B |
| RetrieveMultilpeRowsWithoutCartesianValues_ExplicitLoading | 2,557,454.2 ns | 137,630.63 ns | 205,999.05 ns | 2,545,954.3 ns | 1012621 B |
