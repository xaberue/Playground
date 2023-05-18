``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22621.1702/22H2/2022Update/SunValley2)
Intel Core i7-5930K CPU 3.50GHz (Broadwell), 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.203
  [Host] : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=MediumRun  Toolchain=InProcessNoEmitToolchain  IterationCount=15  
LaunchCount=2  WarmupCount=10  

```
|                                                                 Method |         Mean |      Error |     StdDev |       Median |    Allocated |
|----------------------------------------------------------------------- |-------------:|-----------:|-----------:|-------------:|-------------:|
|                                RetrieveMultipleLimitedRowsWithTracking |     1.915 ms |  0.0130 ms |  0.0186 ms |     1.915 ms |     37.45 KB |
|                             RetrieveMultipleLimitedRowsWithoutTracking |     1.944 ms |  0.0351 ms |  0.0515 ms |     1.932 ms |        38 KB |
|                                 RetrieveLimitedRowsUsingViewFromEFCore |     1.940 ms |  0.0299 ms |  0.0419 ms |     1.936 ms |     37.51 KB |
|                                   RetrieveAllRowsUsingLinqWithTracking |     2.321 ms |  0.0195 ms |  0.0279 ms |     2.320 ms |     57.43 KB |
|                                RetrieveAllRowsUsingLinqWithoutTracking |     2.414 ms |  0.0273 ms |  0.0399 ms |     2.407 ms |    234.82 KB |
|                                     RetrieveAllRowsUsingViewFromEFCore |     2.334 ms |  0.0203 ms |  0.0291 ms |     2.329 ms |      57.5 KB |
|             RetrieveLimitedRowsWithNestedEntitiesUsingLinqWithTracking |   995.204 ms |  7.2053 ms | 10.3336 ms | 1,000.760 ms | 204597.72 KB |
|          RetrieveLimitedRowsWithNestedEntitiesUsingLinqWithoutTracking | 1,018.787 ms |  7.3565 ms | 10.0697 ms | 1,015.330 ms | 218127.31 KB |
|            RetrieveLimitedRowsWithNestedEntitiesUsingLinqAndSplitQuery |    55.791 ms |  0.4978 ms |  0.7297 ms |    55.841 ms |  12607.76 KB |
|               RetrieveLimitedRowsWithNestedEntitiesUsingViewFromEFCore |     2.059 ms |  0.0155 ms |  0.0228 ms |     2.058 ms |     42.03 KB |
|                 RetrieveAllWithNestedEntitiesRowsUsingLinqWithTracking |   996.533 ms | 10.0491 ms | 14.4122 ms |   992.384 ms | 204597.72 KB |
|              RetrieveAllWithNestedEntitiesRowsUsingLinqWithoutTracking | 1,028.775 ms |  9.9971 ms | 14.9632 ms | 1,026.401 ms | 218127.25 KB |
|                RetrieveAllWithNestedEntitiesRowsUsingLinqAndSplitQuery |    55.194 ms |  1.1000 ms |  1.6124 ms |    54.577 ms |  12607.58 KB |
| RetrieveAllWithNestedEntitiesRowsUsingLinqAndSplitQueryWithoutTracking |    63.671 ms |  0.7511 ms |  1.1010 ms |    63.752 ms |  18659.75 KB |
|                   RetrieveAllWithNestedEntitiesRowsUsingViewFromEFCore | 1,221.162 ms | 13.5558 ms | 20.2896 ms | 1,221.709 ms | 314268.83 KB |
|                                              RetrieveFirstRowUsingLinq |    13.159 ms |  0.1074 ms |  0.1541 ms |    13.152 ms |   2123.22 KB |
|                               RetrieveFirstRowUsingLinqAndSplitQueries |     5.225 ms |  0.0223 ms |  0.0326 ms |     5.223 ms |    208.42 KB |
|                            RetrieveFirstRowUsingLinqAndExplicitLoading |     4.788 ms |  0.0653 ms |  0.0957 ms |     4.765 ms |   2812.78 KB |
