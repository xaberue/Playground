using BenchmarkDotNet.Attributes;

namespace Xelit3.Benchmarks;

[MemoryDiagnoser(false)]
public class AsyncAwaitBenchmarks
{
    [Benchmark]
    public async Task<bool> ReturnFromTaskMethod()
    {
        return await ReturnTaskMethod();
    }

    [Benchmark]
    public async Task<bool> ReturnFromAwaitMethod()
    {
        return await ReturnAwaitMethod();
    }

    public Task<bool> ReturnTaskMethod()
    {
        return Task.FromResult(true);
    }
    public async Task<bool> ReturnAwaitMethod()
    {
        return await Task.FromResult(true);
    }

}
