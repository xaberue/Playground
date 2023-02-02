``` ini

BenchmarkDotNet=v0.13.4, OS=Windows 11 (10.0.22621.1194)
Intel Core i7-5930K CPU 3.50GHz (Broadwell), 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.102
  [Host] : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2

Job=MediumRun  Toolchain=InProcessNoEmitToolchain  IterationCount=15  
LaunchCount=2  WarmupCount=10  

```
|                        Method |     Mean |   Error |   StdDev | Allocated |
|------------------------------ |---------:|--------:|---------:|----------:|
| RetrieveSingleElementFromGuid | 340.2 ns | 7.70 ns | 11.04 ns |     192 B |
|  RetrieveSingleElementFromInt | 328.8 ns | 5.10 ns |  7.15 ns |     184 B |
| RetrieveSingleElementFromLong | 339.8 ns | 4.46 ns |  6.39 ns |     184 B |
