using System;
using System.Collections.Generic;
using System.Text;

namespace Aelia.Test._TestUtils;

public sealed class AssertExtensions
{
    public static void DoesNotThrow<T>(Action action) where T: Exception
    {
        try { action(); }
        catch (T) { Assert.Fail($"Expected no {typeof(T).Name} to be thrown"); }
    }
}
