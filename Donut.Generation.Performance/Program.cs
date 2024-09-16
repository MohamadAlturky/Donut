using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using Donut.Generation.Performance;


var result1 = BenchmarkRunner.Run<QueryBuilder>(
                    ManualConfig
                        .Create(DefaultConfig.Instance)
                        .WithOptions(ConfigOptions.DisableOptimizationsValidator));