// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Characteristics;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

using CollectionSortingBenchmarks.Benchmarks;

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, ManualConfig
                .Create(DefaultConfig.Instance)
                .WithOption(ConfigOptions.JoinSummary, true)
                .WithOption(ConfigOptions.DisableLogFile, true));

//var cfg = DefaultConfig.Instance;
//cfg.AddJob(Job.Dry.WithWarmupCount(0).WithIterationCount(1));
//BenchmarkRunner.Run<SorterBenchmarkBase<int[]>>(cfg);
//BenchmarkRunner.Run<SorterBenchmarkBase<List<int>>>(cfg);


//var cfg = DefaultConfig.Instance;
//var jobs = cfg.GetJobs();
//foreach (var item in jobs)
//{
//    item.WithIterationCount(1).WithWarmupCount(0);
//}
//BenchmarkRunner.Run<SortingBenchmarks<List<int>>>(cfg);