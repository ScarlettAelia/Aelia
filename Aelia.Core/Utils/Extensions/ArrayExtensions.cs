using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Aelia.Core.Utils.Extensions;

public static class ArrayExtensions
{
    /// <summary>
    /// Checks if a <see cref="IEnumerable"/> is null or empty
    /// </summary>
    /// <typeparam name="T">Arbitrary type</typeparam>
    /// <param name="objects">Collection to test</param>
    /// <returns><b>true</b> if <paramref name="objects"/> is null or length is 0</returns>
    public static bool IsNullOrEmpty<T>([NotNullWhen(false)] this IEnumerable<T> objects)
    {
        return objects == null || objects.Any();
    }


}
