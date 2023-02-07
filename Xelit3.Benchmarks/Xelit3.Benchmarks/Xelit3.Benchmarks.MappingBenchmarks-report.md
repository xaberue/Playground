``` ini

BenchmarkDotNet=v0.13.4, OS=Windows 11 (10.0.22621.1194)
Intel Core i7-5930K CPU 3.50GHz (Broadwell), 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2


```
|                                                Method |         Mean |      Error |     StdDev |       Median |
|------------------------------------------------------ |-------------:|-----------:|-----------:|-------------:|
|                   SingleElementManualMappingBenchmark |     13.85 ns |   0.310 ns |   0.535 ns |     13.88 ns |
|                MultipleElementsManualMappingBenchmark | 19,613.29 ns | 375.582 ns | 447.104 ns | 19,630.15 ns |
|                      SingleElementAutomapperBenchmark |     94.15 ns |   2.549 ns |   7.273 ns |     91.25 ns |
| MultipleElementAutomapperBenchmark_WithIEnumerableMap | 18,299.11 ns | 224.226 ns | 198.771 ns | 18,333.10 ns |
|         MultipleElementAutomapperBenchmark_WithSelect | 94,449.89 ns | 966.912 ns | 857.142 ns | 94,509.13 ns |
|           SingleElementMapsterBenchmark_WithoutConfig |     35.91 ns |   0.439 ns |   0.411 ns |     35.88 ns |
|              SingleElementMapsterBenchmark_WithConfig |     40.23 ns |   0.494 ns |   0.462 ns |     40.11 ns |
|                      MultipleElementsMapsterBenchmark | 19,079.99 ns | 369.013 ns | 345.175 ns | 19,070.28 ns |
|               SingleElementMapsterBenchmark_UsingType |     63.06 ns |   0.570 ns |   0.445 ns |     63.19 ns |
|            MultipleElementsMapsterBenchmark_UsingType | 19,541.24 ns | 380.335 ns | 467.085 ns | 19,383.79 ns |
