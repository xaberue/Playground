using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.InProcess.NoEmit;

namespace Xelit3.Playground.Benchmarks
{
    public class AntivirusFriendlyConfig : ManualConfig
    {
        public AntivirusFriendlyConfig()
        {
            AddJob(Job.MediumRun.WithToolchain(InProcessNoEmitToolchain.Instance));
        }
    }
}
