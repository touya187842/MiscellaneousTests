#if NET8_0_OR_GREATER
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace NUnitTests;

[TestFixture]
public class KeyedServiceTests
{
    [TestCase(false, false, false, InjectType.None, InjectType.None, InjectType.None, InjectType.None)]
    [TestCase(false, false, true, InjectType.None, InjectType.None, InjectType.AnyKey, InjectType.AnyKey)]
    [TestCase(false, true, false, InjectType.None, InjectType.None, InjectType.SpecificKey, InjectType.None)]
    [TestCase(false, true, true, InjectType.None, InjectType.None, InjectType.SpecificKey, InjectType.AnyKey)]
    [TestCase(true, false, false, InjectType.NullKey, InjectType.NullKey, InjectType.None, InjectType.None)]
    [TestCase(true, false, true, InjectType.NullKey, InjectType.NullKey, InjectType.AnyKey, InjectType.AnyKey)]
    [TestCase(true, true, false, InjectType.NullKey, InjectType.NullKey, InjectType.SpecificKey, InjectType.None)]
    [TestCase(true, true, true, InjectType.NullKey, InjectType.NullKey, InjectType.SpecificKey, InjectType.AnyKey)]
    public void Test(
        bool addNullKey, bool addSpecificKey, bool addAnyKey,
        int expectedNotKeyed, int expectedNullKey, int expectedSpecific, int expectedAnyKey)
    {
        var services = new ServiceCollection();
        if (addNullKey)
        {
            services.AddKeyedSingleton<IFoo>(null, new Foo { Type = InjectType.NullKey });
        }
        if (addSpecificKey)
        {
            services.AddKeyedSingleton<IFoo>("a", new Foo { Type = InjectType.SpecificKey });
        }
        if (addAnyKey)
        {
            services.AddKeyedSingleton<IFoo>(KeyedService.AnyKey, new Foo { Type = InjectType.AnyKey });
        }
        var provider = services.BuildServiceProvider();

        Assert.Multiple(() =>
        {
            Assert.That(provider.GetService<IFoo>()?.Type ?? InjectType.None, Is.EqualTo((InjectType)expectedNotKeyed));
            Assert.That(provider.GetKeyedService<IFoo>(null)?.Type ?? InjectType.None, Is.EqualTo((InjectType)expectedNullKey));
            Assert.That(provider.GetKeyedService<IFoo>("a")?.Type ?? InjectType.None, Is.EqualTo((InjectType)expectedSpecific));
            Assert.That(provider.GetKeyedService<IFoo>(KeyedService.AnyKey)?.Type ?? InjectType.None, Is.EqualTo((InjectType)expectedAnyKey));
        });
    }
}

file interface IFoo
{
    public InjectType Type { get; }
}

file class Foo : IFoo
{
    public InjectType Type { get; init; }
}

file enum InjectType
{
    None = 0,
    NullKey = 1,
    SpecificKey = 2,
    AnyKey = 3,
}

#endif
