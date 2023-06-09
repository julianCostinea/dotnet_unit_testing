﻿using unit_tests_web_api.Fundamentals;
using Math = unit_tests_web_api.Fundamentals.Math;

namespace unit_tests_nunit;

[TestFixture]
public class MathTests
{
    private Math _math;
    [SetUp]
    public void Setup()
    {
        _math = new Math();
    }
    
    [Test]
    public void Add_WhenCalled_ReturnsSumOfArguments()
    {
        var result = _math.Add(1, 2);
        
        Assert.That(result, Is.EqualTo(3));
    }
    
    [Test]
    [TestCase(2, 1, 2)]
    [TestCase(1, 2, 2)]
    [TestCase(1, 1, 1)]
    public void Max_WhenCalled_ReturnsGreaterArgument(int a, int b, int expectedResult)
    {
        var result = _math.Max(a, b);
        
        Assert.That(result, Is.EqualTo(expectedResult));
    }
    
    [Test]
    public void GetOddNumbers_LimitIsGreaterThanZero_ReturnsOddNumbersUpToLimit()
    {
        var result = _math.GetOddNumbers(5);
        
        // Assert.That(result, Is.Not.Empty);
        //
        // Assert.That(result.Count(), Is.EqualTo(3));
        //
        // Assert.That(result, Does.Contain(1));
        // Assert.That(result, Does.Contain(3));
        // Assert.That(result, Does.Contain(5));
        
        Assert.That(result, Is.EquivalentTo(new [] {1, 3, 5}));
    }
}