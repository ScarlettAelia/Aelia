using Aelia.Core.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aelia.Core.Maths.Vector;

public static class VectorMaths
{
    public static double Magnitude(double[] vector)
    {
        double value = 0;

        for (int i = 0; i < vector.Length; i++)
        {
            value += vector[i] * vector[i];
        }

        return Math.Sqrt(value);
    }

    public static double MagnitudeBetween(double[] vector1, double[] vector2)
    {
        if (vector1.Length != vector2.Length)
            throw new ArgumentException();

        double[] difference = vector2.SubtractByElement(vector1);

        return Magnitude(difference);
    }
}