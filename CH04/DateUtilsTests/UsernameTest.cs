using NUnit.Framework;
using System;
using User;

namespace Tests;

internal class UsernameTest
{
    [Test]
    public void ctor_nullUsername_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(
          () => new Username(null!));
    }

    [TestCase("")]
    [TestCase("Upper")]
    [TestCase("toolongusername")]
    [TestCase("root!!")]
    [TestCase("a b")]
    public void ctor_invalidUsername_ThrowsArgumentException(string username)
    {
        Assert.Throws<ArgumentException>(
          () => new Username(username));
    }

    [TestCase("a")]
    [TestCase("1")]
    [TestCase("hunter2")]
    [TestCase("12345678")]
    [TestCase("abcdefgh")]
    public void ctor_validUsername_DoesNotThrow(string username)
    {
        Assert.DoesNotThrow(() => new Username(username));
    }
}