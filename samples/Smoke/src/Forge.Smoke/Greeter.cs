// <copyright file="Greeter.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>

namespace Forge.Smoke;

/// <summary>Minimal API used to prove the Forge baseline builds and tests.</summary>
public static class Greeter
{
    public static string Hello(string name) => $"Hello, {name}!";
}
