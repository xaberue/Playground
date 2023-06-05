using BenchmarkDotNet.Attributes;


namespace Xelit3.Playground.Benchmarks;


[Config(typeof(AntivirusFriendlyConfig))]
[MemoryDiagnoser(false)]
public class SqlServerQueryBenchmarks
{

   

}
