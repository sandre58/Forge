// <copyright file="GreeterTests.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>

using FluentAssertions;
using Forge.Smoke;
using Xunit;

namespace Forge.Smoke.Tests;

public class GreeterTests
{
    [Fact]
    public void Hello_returns_greeting()
    {
        Greeter.Hello("Forge").Should().Be("Hello, Forge!");
    }
}
