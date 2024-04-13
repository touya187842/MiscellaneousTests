#if NET8_0_OR_GREATER
using Microsoft.Extensions.DependencyInjection;
using System;

namespace NUnitTests;

[TestFixture]
public class KeyedServiceTests
{
    [TestCase(false, false, false, false, InjectType.None, InjectType.None, InjectType.None, InjectType.None, InjectType.None)]
    [TestCase(false, false, false, true, InjectType.None, InjectType.None, InjectType.None, InjectType.None, InjectType.MyAnyKey)]
    [TestCase(false, false, true, false, InjectType.None, InjectType.None, InjectType.AnyKey, InjectType.AnyKey, InjectType.AnyKey)]
    [TestCase(false, false, true, true, InjectType.None, InjectType.None, InjectType.AnyKey, InjectType.AnyKey, InjectType.MyAnyKey)]
    [TestCase(false, true, false, false, InjectType.None, InjectType.None, InjectType.SpecificKey, InjectType.None, InjectType.None)]
    [TestCase(false, true, false, true, InjectType.None, InjectType.None, InjectType.SpecificKey, InjectType.None, InjectType.MyAnyKey)]
    [TestCase(false, true, true, false, InjectType.None, InjectType.None, InjectType.SpecificKey, InjectType.AnyKey, InjectType.AnyKey)]
    [TestCase(false, true, true, true, InjectType.None, InjectType.None, InjectType.SpecificKey, InjectType.AnyKey, InjectType.MyAnyKey)]
    [TestCase(true, false, false, false, InjectType.NullKey, InjectType.NullKey, InjectType.None, InjectType.None, InjectType.None)]
    [TestCase(true, false, false, true, InjectType.NullKey, InjectType.NullKey, InjectType.None, InjectType.None, InjectType.MyAnyKey)]
    [TestCase(true, false, true, false, InjectType.NullKey, InjectType.NullKey, InjectType.AnyKey, InjectType.AnyKey, InjectType.AnyKey)]
    [TestCase(true, false, true, true, InjectType.NullKey, InjectType.NullKey, InjectType.AnyKey, InjectType.AnyKey, InjectType.MyAnyKey)]
    [TestCase(true, true, false, false, InjectType.NullKey, InjectType.NullKey, InjectType.SpecificKey, InjectType.None, InjectType.None)]
    [TestCase(true, true, false, true, InjectType.NullKey, InjectType.NullKey, InjectType.SpecificKey, InjectType.None, InjectType.MyAnyKey)]
    [TestCase(true, true, true, false, InjectType.NullKey, InjectType.NullKey, InjectType.SpecificKey, InjectType.AnyKey, InjectType.AnyKey)]
    [TestCase(true, true, true, true, InjectType.NullKey, InjectType.NullKey, InjectType.SpecificKey, InjectType.AnyKey, InjectType.MyAnyKey)]
    public void Test(
        bool addNullKey, bool addSpecificKey, bool addAnyKey, bool addMyAnyKey,
        int expectedNotKeyed, int expectedNullKey, int expectedSpecific, int expectedAnyKey, int expectedMyAnyKey)
    {
        var myAnyKey = Activator.CreateInstance(KeyedService.AnyKey.GetType());
        Assume.That(ReferenceEquals(myAnyKey, KeyedService.AnyKey), Is.False);

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
        if (addMyAnyKey)
        {
            services.AddKeyedSingleton<IFoo>(myAnyKey, new Foo { Type = InjectType.MyAnyKey });
        }
        var provider = services.BuildServiceProvider();

        Assert.Multiple(() =>
        {
            Assert.That(provider.GetService<IFoo>()?.Type ?? InjectType.None, Is.EqualTo((InjectType)expectedNotKeyed));
            Assert.That(provider.GetKeyedService<IFoo>(null)?.Type ?? InjectType.None, Is.EqualTo((InjectType)expectedNullKey));
            Assert.That(provider.GetKeyedService<IFoo>("a")?.Type ?? InjectType.None, Is.EqualTo((InjectType)expectedSpecific));
            Assert.That(provider.GetKeyedService<IFoo>(KeyedService.AnyKey)?.Type ?? InjectType.None, Is.EqualTo((InjectType)expectedAnyKey));
            Assert.That(provider.GetKeyedService<IFoo>(myAnyKey)?.Type ?? InjectType.None, Is.EqualTo((InjectType)expectedMyAnyKey));
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
    MyAnyKey = 4,
}

#endif
