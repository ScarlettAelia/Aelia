using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace Aelia.Test.TestUtils;

public abstract class MyTestClass(ITestOutputHelper outputter)
{
    public readonly ITestOutputHelper Outputter = outputter;

    public void OutputBasicEquals(object expected, object input, object check, string function = "f()")
    {
        bool result = expected == check;
        Outputter.WriteLine($"input: '{input} -> {function} -> {check} == {expected}? {result}");
    }
}
