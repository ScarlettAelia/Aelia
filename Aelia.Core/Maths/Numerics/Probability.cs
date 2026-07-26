using System;
using System.Collections.Generic;
using System.Text;

namespace Aelia.Core.Maths.Numerics;

/// <summary>
/// Strictly bound double between [0, 1] (inclusive)
/// </summary>
public readonly record struct Probability
{
    double Value => field;

    public Probability(double probability)
    {
        if (probability < 0 || probability > 1)
            throw new ArgumentOutOfRangeException($"A probability is strictly bound between [0, 1]. '{probability}' is out of range.");

        Value = probability;
    }

    public static implicit operator Probability(double input)
    {
        return new Probability(input);
    }
}
