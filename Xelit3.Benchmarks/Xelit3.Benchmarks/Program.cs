using BenchmarkDotNet.Running;
using Xelit3.Benchmarks;

var summary = BenchmarkRunner.Run<AsyncAwaitBenchmarks>();

Console.ReadKey();