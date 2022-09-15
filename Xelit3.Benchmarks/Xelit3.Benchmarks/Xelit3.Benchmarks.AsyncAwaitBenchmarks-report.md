``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22000.918/21H2)
Intel Core i7-5930K CPU 3.50GHz (Broadwell), 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.400
  [Host]     : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2  [AttachedDebugger]
  DefaultJob : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2


```
|                Method |     Mean |    Error |   StdDev | Allocated |
|---------------------- |---------:|---------:|---------:|----------:|
|  ReturnFromTaskMethod | 12.07 ns | 0.128 ns | 0.107 ns |         - |
| ReturnFromAwaitMethod | 24.37 ns | 0.508 ns | 0.543 ns |         - |
