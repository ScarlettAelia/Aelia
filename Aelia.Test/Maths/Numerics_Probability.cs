using Aelia.Test.TestUtils;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;
using Aelia.Core.Maths.Numerics;
using Aelia.Test._TestUtils;

namespace Aelia.Test.Maths;

public class Numerics_Probability(ITestOutputHelper outputter) : MyTestClass(outputter)
{
    [Theory]
    [InlineData(true, 0)]
    [InlineData(true, 0.000000000041)]
    [InlineData(true, 0.15)]
    [InlineData(true, 0.998)]
    [InlineData(true, 1)]
    [InlineData(false, -1)]
    [InlineData(false, -0.0000001)]
    [InlineData(false, 1.00000001)]
    public void Test_Constrution (bool pass, double input)
    {
        if (pass)
            AssertExtensions.DoesNotThrow<ArgumentOutOfRangeException>(() => new Probability(input));
        else
            Assert.Throws<ArgumentOutOfRangeException>(() => new Probability(input));
    }
}
