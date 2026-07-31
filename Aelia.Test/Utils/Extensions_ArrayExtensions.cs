using Aelia.Test.TestUtils;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;
using Aelia.Core.Maths.Numerics;
using Aelia.Test._TestUtils;
using Aelia.Core.Utils.Extensions;

namespace Aelia.Test.Utils;

public class Extensions_ArrayExtensions(ITestOutputHelper outputter) : MyTestClass(outputter)
{
    [Theory]
    [InlineData(true, new int[] { })]
    [InlineData(true, null )]
    [InlineData(true, new char[] { })]
    [InlineData(false, new char[] { 'f', 'a', 'l', 's', 'e' })]
    [InlineData(false, new int[] {1})]
    public void Test_IsNullOrEmpty<T>(bool expected, T[]? input)
    {
        bool check = input.IsNullOrEmpty();

        OutputBasicEquals(expected: expected, input: input, check: check, function: "IsNullOrEmpty()");

        Assert.Equal(expected, check);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { })]
    [InlineData(new int[] { 2, 3, 4, }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 0, 4 })]
    [InlineData(new int[] { 2, 3, 4, 5}, new int[] { 1, 2, 3, 4, 5 }, new int[] { 0 })]
    [InlineData(new int[] { 1, 2, 4, 5 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 5 })]
    [InlineData(new int[] { 1, 2, 4, 5 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 5, 8, 200 })]
    public void TestArray_RemoveItemsAt<T>(T[] expected, T[] initial, int[] indicies)
    {
        T[] check = initial.RemoveItemsAt(indicies);

        Assert.Equal(expected, check);
    }
    [Theory]

    [InlineData(new int[] { 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 }, 0)]
    [InlineData(new int[] { 1, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 }, 1)]
    [InlineData(new int[] { 1, 2, 4, 5 }, new int[] { 1, 2, 3, 4, 5 }, 2)]
    [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 5 }, 4)]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 }, 5)]
    public void TestSingle_RemoveItemsAt<T>(T[] expected, T[] initial, int index)
    {
        T[] check = initial.RemoveItemsAt(index);

        Assert.Equal(expected, check);
    }
}
