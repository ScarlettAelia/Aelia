using Aelia.Core.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Aelia.Core.Maths.Vector;

/// <summary>
/// n-dimensional vector
/// </summary>
public class VectorN : IVector, 
                       IAdditionOperators<VectorN, VectorN, VectorN>, 
                       ISubtractionOperators<VectorN, VectorN, VectorN>, 
                       IMultiplyOperators<VectorN, VectorN, VectorN>, 
                       IDivisionOperators<VectorN, VectorN, VectorN>,
                       IEqualityOperators<VectorN, VectorN, bool>
{
    #region Fields

    public double[] Elements { get; init; }

    #endregion Fields

    #region Accessors

    public int Dimensions => Elements.Length;

    #endregion Accessors

    #region Constructors

    public VectorN(double[] elements)
    {
        if (elements.IsNullOrEmpty()) throw new ArgumentException($"Cannot form a vector with null or empty elements");

        Elements = elements;
    }

    internal VectorN(double[] elements, int dimensions)
    {
        if (elements.Length > dimensions) throw new ArgumentException($"vector of length {elements.Length} is too long for a Vector{dimensions}");

        Elements = new double[dimensions];

        for (int i = 0; i < dimensions; i++)
        {
            Elements[i] = elements[i];
        }
    }

    #endregion Constructors

    #region Functions

    public static double Magnitude(VectorN vector) => VectorMaths.Magnitude(vector.Elements);
    public double Magnitude() => VectorMaths.Magnitude(Elements);

    public static double MagnitudeBetween(VectorN vector1, VectorN vector2) => VectorMaths.MagnitudeBetween(vector1.Elements, vector2.Elements);
    public double MagnitudeBetween(VectorN other) => VectorMaths.MagnitudeBetween(this.Elements, other.Elements);

    #endregion Functions

    #region Operators

    #region Add

    public static VectorN Add(VectorN left, VectorN right)
        => left.Elements.Add(right.Elements);
    public VectorN Add(VectorN other)
        => Add(this, other);

    public static VectorN operator +(VectorN left, VectorN right)
        => Add(left, right);

    #endregion Add

    #region Subtract

    public static VectorN Subtract(VectorN left, VectorN right)
        => left.Elements.Subtract(right.Elements);
    public VectorN Subtract(VectorN other)
        => Subtract(this, other);

    public static VectorN operator -(VectorN left, VectorN right)
        => Subtract(left, right);

    #endregion Subtract

    #region Multiply

    public static VectorN Multiply(VectorN left, VectorN right)
        => left.Elements.Multiply(right.Elements);
    public VectorN Multiply(VectorN other)
        => Multiply(this, other);

    public static VectorN operator *(VectorN left, VectorN right)
        => Multiply(left, right);

    #endregion Multiply

    #region Divide

    public static VectorN Divide(VectorN left, VectorN right)
        => left.Elements.Divide(right.Elements);
    public VectorN Divide(VectorN other)
        => Divide(this, other);

    public static VectorN operator /(VectorN left, VectorN right)
        => Divide(left, right);

    #endregion Divide

    #region Equals

    public static bool Equals(VectorN left, VectorN right)
        => left.Elements == right.Elements;
    public bool Equals(VectorN other)
        => this.Equals(other);

    public static bool operator ==(VectorN? left, VectorN? right)
        => left.Equals(right);



    #endregion Equals

    #region Not Equals

    public static bool NotEquals(VectorN left, VectorN right)
        => left.Elements != right.Elements;
    public bool NotEquals(VectorN other)
        => this.NotEquals(other);

    public static bool operator !=(VectorN? left, VectorN? right)
        => left.NotEquals(right);

    #endregion Not Equals

    #endregion Operators



    #region Overrides

    #endregion Overrides

    #region Conversions

    public static implicit operator VectorN(double[] elements) => new(elements);

    #endregion Conversions
}
