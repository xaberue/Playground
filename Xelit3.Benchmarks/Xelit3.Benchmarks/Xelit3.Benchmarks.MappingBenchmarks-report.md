``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22621.1344/22H2/2022Update/SunValley2)
Intel Core i7-5930K CPU 3.50GHz (Broadwell), 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 7.0.4 (7.0.423.11508), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.4 (7.0.423.11508), X64 RyuJIT AVX2


```
|                                                Method |         Mean |        Error |       StdDev |       Median |
|------------------------------------------------------ |-------------:|-------------:|-------------:|-------------:|
|                   SingleElementManualMappingBenchmark |     13.54 ns |     0.408 ns |     1.095 ns |     13.14 ns |
|                MultipleElementsManualMappingBenchmark | 18,026.42 ns |   327.315 ns |   683.228 ns | 17,848.09 ns |
|                      SingleElementAutomapperBenchmark |     94.43 ns |     1.508 ns |     1.337 ns |     94.47 ns |
| MultipleElementAutomapperBenchmark_WithIEnumerableMap | 25,101.95 ns | 2,280.189 ns | 6,723.190 ns | 21,305.36 ns |
|         MultipleElementAutomapperBenchmark_WithSelect | 98,832.20 ns | 1,715.378 ns | 1,604.566 ns | 98,101.34 ns |
|           SingleElementMapsterBenchmark_WithoutConfig |     38.16 ns |     0.763 ns |     1.643 ns |     37.56 ns |
|              SingleElementMapsterBenchmark_WithConfig |     40.84 ns |     1.263 ns |     3.684 ns |     39.67 ns |
|                      MultipleElementsMapsterBenchmark | 19,672.73 ns |   389.651 ns |   651.019 ns | 19,563.98 ns |
|               SingleElementMapsterBenchmark_UsingType |     65.46 ns |     1.091 ns |     1.456 ns |     65.20 ns |
|            MultipleElementsMapsterBenchmark_UsingType | 19,240.10 ns |   369.738 ns |   327.763 ns | 19,182.85 ns |
|      SingleElementMapsterBenchmark_UsingCodeGenerator |     20.19 ns |     0.425 ns |     0.472 ns |     20.21 ns |
|   MultipleElementsMapsterBenchmark_UsingCodeGenerator | 25,910.60 ns |   516.294 ns |   530.196 ns | 25,928.57 ns |
