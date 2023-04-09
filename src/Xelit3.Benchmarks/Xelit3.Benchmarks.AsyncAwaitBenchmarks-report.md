``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22000.978/21H2)
Intel Core i7-5930K CPU 3.50GHz (Broadwell), 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.401
  [Host]     : .NET 6.0.9 (6.0.922.41905), X64 RyuJIT AVX2  [AttachedDebugger]
  DefaultJob : .NET 6.0.9 (6.0.922.41905), X64 RyuJIT AVX2


```

## Benchmark execution results 

|                         Method |          Mean |        Error |       StdDev | Allocated |
|------------------------------- |--------------:|-------------:|-------------:|----------:|
|           ReturnFromTaskMethod |      13.03 ns |     0.230 ns |     0.204 ns |         - |
|          ReturnFromAwaitMethod |      27.15 ns |     0.440 ns |     0.411 ns |         - |
| ReturnFromAwaitValueTaskMethod |      44.73 ns |     0.170 ns |     0.142 ns |         - |
|        ReturnFromDbTaskAwaited | 178,732.04 ns | 1,326.838 ns | 1,241.125 ns |    9554 B |
|   ReturnFromDbValueTaskAwaited | 179,767.72 ns | 1,616.742 ns | 1,433.199 ns |    9594 B |
|               ReturnFromDbTask | 175,149.57 ns | 1,164.576 ns | 1,032.367 ns |    9146 B |


## Compiler generated files

- _Both original code blocks [here](https://github.com/Xelit3/Playground/blob/main/Xelit3.Benchmarks/Xelit3.Benchmarks/AsyncAwaitBenchmarks.cs)_

### Async method awaiting task method

```csharp
using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;
using System.Threading.Tasks;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue | DebuggableAttribute.DebuggingModes.DisableOptimizations)]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
public class C
{
    [CompilerGenerated]
    private sealed class <ReturnFromTaskMethod>d__1 : IAsyncStateMachine
    {
        public int <>1__state;

        public AsyncTaskMethodBuilder<bool> <>t__builder;

        public C <>4__this;

        private bool <>s__1;

        private TaskAwaiter<bool> <>u__1;

        private void MoveNext()
        {
            int num = <>1__state;
            bool result;
            try
            {
                TaskAwaiter<bool> awaiter;
                if (num != 0)
                {
                    awaiter = <>4__this.ReturnTaskMethod().GetAwaiter();
                    if (!awaiter.IsCompleted)
                    {
                        num = (<>1__state = 0);
                        <>u__1 = awaiter;
                        <ReturnFromTaskMethod>d__1 stateMachine = this;
                        <>t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
                        return;
                    }
                }
                else
                {
                    awaiter = <>u__1;
                    <>u__1 = default(TaskAwaiter<bool>);
                    num = (<>1__state = -1);
                }
                <>s__1 = awaiter.GetResult();
                result = <>s__1;
            }
            catch (Exception exception)
            {
                <>1__state = -2;
                <>t__builder.SetException(exception);
                return;
            }
            <>1__state = -2;
            <>t__builder.SetResult(result);
        }

        void IAsyncStateMachine.MoveNext()
        {
            //ILSpy generated this explicit interface implementation from .override directive in MoveNext
            this.MoveNext();
        }

        [DebuggerHidden]
        private void SetStateMachine(IAsyncStateMachine stateMachine)
        {
        }

        void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
        {
            //ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
            this.SetStateMachine(stateMachine);
        }
    }

    public void M()
    {
    }

    [AsyncStateMachine(typeof(<ReturnFromTaskMethod>d__1))]
    [DebuggerStepThrough]
    public Task<bool> ReturnFromTaskMethod()
    {
        <ReturnFromTaskMethod>d__1 stateMachine = new <ReturnFromTaskMethod>d__1();
        stateMachine.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
        stateMachine.<>4__this = this;
        stateMachine.<>1__state = -1;
        stateMachine.<>t__builder.Start(ref stateMachine);
        return stateMachine.<>t__builder.Task;
    }

    private Task<bool> ReturnTaskMethod()
    {
        return Task.FromResult(true);
    }
}

```

### Async method awaiting already awaited method

```csharp
using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;
using System.Threading.Tasks;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue | DebuggableAttribute.DebuggingModes.DisableOptimizations)]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
public class C
{
    [CompilerGenerated]
    private sealed class <ReturnFromAwaitMethod>d__1 : IAsyncStateMachine
    {
        public int <>1__state;

        public AsyncTaskMethodBuilder<bool> <>t__builder;

        public C <>4__this;

        private bool <>s__1;

        private TaskAwaiter<bool> <>u__1;

        private void MoveNext()
        {
            int num = <>1__state;
            bool result;
            try
            {
                TaskAwaiter<bool> awaiter;
                if (num != 0)
                {
                    awaiter = <>4__this.ReturnAwaitMethod().GetAwaiter();
                    if (!awaiter.IsCompleted)
                    {
                        num = (<>1__state = 0);
                        <>u__1 = awaiter;
                        <ReturnFromAwaitMethod>d__1 stateMachine = this;
                        <>t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
                        return;
                    }
                }
                else
                {
                    awaiter = <>u__1;
                    <>u__1 = default(TaskAwaiter<bool>);
                    num = (<>1__state = -1);
                }
                <>s__1 = awaiter.GetResult();
                result = <>s__1;
            }
            catch (Exception exception)
            {
                <>1__state = -2;
                <>t__builder.SetException(exception);
                return;
            }
            <>1__state = -2;
            <>t__builder.SetResult(result);
        }

        void IAsyncStateMachine.MoveNext()
        {
            //ILSpy generated this explicit interface implementation from .override directive in MoveNext
            this.MoveNext();
        }

        [DebuggerHidden]
        private void SetStateMachine(IAsyncStateMachine stateMachine)
        {
        }

        void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
        {
            //ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
            this.SetStateMachine(stateMachine);
        }
    }

    [CompilerGenerated]
    private sealed class <ReturnAwaitMethod>d__2 : IAsyncStateMachine
    {
        public int <>1__state;

        public AsyncTaskMethodBuilder<bool> <>t__builder;

        public C <>4__this;

        private bool <>s__1;

        private TaskAwaiter<bool> <>u__1;

        private void MoveNext()
        {
            int num = <>1__state;
            bool result;
            try
            {
                TaskAwaiter<bool> awaiter;
                if (num != 0)
                {
                    awaiter = Task.FromResult(true).GetAwaiter();
                    if (!awaiter.IsCompleted)
                    {
                        num = (<>1__state = 0);
                        <>u__1 = awaiter;
                        <ReturnAwaitMethod>d__2 stateMachine = this;
                        <>t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
                        return;
                    }
                }
                else
                {
                    awaiter = <>u__1;
                    <>u__1 = default(TaskAwaiter<bool>);
                    num = (<>1__state = -1);
                }
                <>s__1 = awaiter.GetResult();
                result = <>s__1;
            }
            catch (Exception exception)
            {
                <>1__state = -2;
                <>t__builder.SetException(exception);
                return;
            }
            <>1__state = -2;
            <>t__builder.SetResult(result);
        }

        void IAsyncStateMachine.MoveNext()
        {
            //ILSpy generated this explicit interface implementation from .override directive in MoveNext
            this.MoveNext();
        }

        [DebuggerHidden]
        private void SetStateMachine(IAsyncStateMachine stateMachine)
        {
        }

        void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
        {
            //ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
            this.SetStateMachine(stateMachine);
        }
    }

    public void M()
    {
    }

    [AsyncStateMachine(typeof(<ReturnFromAwaitMethod>d__1))]
    [DebuggerStepThrough]
    public Task<bool> ReturnFromAwaitMethod()
    {
        <ReturnFromAwaitMethod>d__1 stateMachine = new <ReturnFromAwaitMethod>d__1();
        stateMachine.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
        stateMachine.<>4__this = this;
        stateMachine.<>1__state = -1;
        stateMachine.<>t__builder.Start(ref stateMachine);
        return stateMachine.<>t__builder.Task;
    }

    [AsyncStateMachine(typeof(<ReturnAwaitMethod>d__2))]
    [DebuggerStepThrough]
    private Task<bool> ReturnAwaitMethod()
    {
        <ReturnAwaitMethod>d__2 stateMachine = new <ReturnAwaitMethod>d__2();
        stateMachine.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
        stateMachine.<>4__this = this;
        stateMachine.<>1__state = -1;
        stateMachine.<>t__builder.Start(ref stateMachine);
        return stateMachine.<>t__builder.Task;
    }
}

```