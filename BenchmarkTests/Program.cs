using BenchmarkDotNet.Running;
using System.Linq;
using System.Reflection;

namespace BenchmarkTests;

public class Program
{
    public static void Main(string[] args)
    {
#if DOCKER
        var targetType = args[0];
        var benchmarkType = Assembly.GetExecutingAssembly().GetTypes().First(type => string.Equals(type.Name, targetType));
        BenchmarkRunner.Run(benchmarkType);
#else
        // BenchmarkRunner.Run<T>();
#endif
    }
}
