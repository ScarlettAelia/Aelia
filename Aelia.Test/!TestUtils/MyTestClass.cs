using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace Aelia.Test.TestUtils;

public abstract class MyTestClass
{
    private readonly ITestOutputHelper Outputter;

    public MyTestClass(ITestOutputHelper outputter)
    {
        Outputter = outputter;
    }
}
