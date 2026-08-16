using Aelia.Core.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;

namespace Aelia.Core.Maths.Vector;

/// <summary>
/// n-dimensional vector
/// </summary>
public class BaseVector : IVector,
                          IAdditionOperators<BaseVector, BaseVector, BaseVector>,
                          IAdditionOperators<BaseVector, double, BaseVector>,
                          ISubtractionOperators<BaseVector, BaseVector, BaseVector>,
                          ISubtractionOperators<BaseVector, double, BaseVector>,
                          IMultiplyOperators<BaseVector, BaseVector, BaseVector>,
                          IMultiplyOperators<BaseVector, double, BaseVector>,
                          IDivisionOperators<BaseVector, BaseVector, BaseVector>,
                          IDivisionOperators<BaseVector, double, BaseVector>,
                          IEqualityOperators<BaseVector, BaseVector, bool>,
                          IEqualityOperators<BaseVector, double, bool>
{
    #region Fields

    public double[] Elements { get; set; }

    #endregion Fields

    #region Accessors

    public int Dimensions => Elements.Length;

    #endregion Accessors

    #region Constructors

    public BaseVector(double[] elements)
    {
        if (elements.IsNullOrEmpty()) throw new ArgumentException($"Cannot form a vector with null or empty elements");

        Elements = elements;
    }

    internal BaseVector(double[] elements, int dimensions)
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

    public static double Magnitude(BaseVector vector)
        => VectorMaths.Magnitude(vector.Elements);
    public double Magnitude() => VectorMaths.Magnitude(Elements);

    public static double MagnitudeBetween(BaseVector vector1, BaseVector vector2)
        => VectorMaths.MagnitudeBetween(vector1.Elements, vector2.Elements);
    public double MagnitudeBetween(BaseVector other)
        => VectorMaths.MagnitudeBetween(this.Elements, other.Elements);

    #endregion Functions

    #region Operators

    #region Add

    public static BaseVector Add(BaseVector left, BaseVector right)
        => left.Elements.AddByElement(right.Elements);
    public BaseVector Add(BaseVector other)
        => Add(this, other);
    public static BaseVector Add(BaseVector left, double right)
        => left.Elements.AddByElement(right);
    public BaseVector Add(double other)
        => Add(this, other);

    public static BaseVector operator +(BaseVector left, BaseVector right)
        => Add(left, right);
    public static BaseVector operator +(BaseVector left, double right)
        => Add(left, right);

    #endregion Add

    #region Subtract

    public static BaseVector Subtract(BaseVector left, BaseVector right)
        => left.Elements.SubtractByElement(right.Elements);
    public BaseVector Subtract(BaseVector other) 
        => Subtract(this, other);
    public static BaseVector Subtract(BaseVector left, double right) 
        => left.Elements.SubtractByElement(right);
    public BaseVector Subtract(double other)
        => Subtract(this, other);

    public static BaseVector operator -(BaseVector left, BaseVector right)
        => Subtract(left, right);
    public static BaseVector operator -(BaseVector left, double right)
        => Subtract(left, right);

    #endregion Subtract

    #region Multiply

    public static BaseVector Multiply(BaseVector left, BaseVector right)
        => left.Elements.MultiplyByElement(right.Elements);
    public BaseVector Multiply(BaseVector other)
        => Multiply(this, other);
    public static BaseVector Multiply(BaseVector left, double right)
        => left.Elements.MultiplyByElement(right);
    public BaseVector Multiply(double other)
        => Multiply(this, other);

    public static BaseVector operator *(BaseVector left, BaseVector right)
        => Multiply(left, right);
    public static BaseVector operator *(BaseVector left, double right)
        => Multiply(left, right);

    #endregion Multiply

    #region Divide

    public static BaseVector Divide(BaseVector left, BaseVector right) 
        => left.Elements.DivideByElement(right.Elements);
    public BaseVector Divide(BaseVector other)
        => Divide(this, other);
    public static BaseVector Divide(BaseVector left, double right)
        => left.Elements.DivideByElement(right);
    public BaseVector Divide(double other)
        => Divide(this, other);

    public static BaseVector operator /(BaseVector left, BaseVector right)
        => Divide(left, right);
    public static BaseVector operator /(BaseVector left, double right)
        => Divide(left, right);

    #endregion Divide

    #region Equals

    public static bool Equals(BaseVector left, BaseVector right)
        => left.Elements == right.Elements;
    public bool Equals(BaseVector other)
        => Equals(this, other);
    public static bool Equals(BaseVector left, double right)
        => left.Elements.All(e => e == right);
    public bool Equals(double other)
        => Equals(this, other);

    public static bool operator ==(BaseVector? left, BaseVector? right)
        => left.Equals(right);
    public static bool operator ==(BaseVector? left, double right)
        => left.Equals(right);

    #endregion Equals

    #region Not Equals

    public static bool NotEquals(BaseVector left, BaseVector right) 
        => left.Elements != right.Elements;
    public bool NotEquals(BaseVector other)
        => NotEquals(this, other);
    public static bool NotEquals(BaseVector left, double right)
        => left.Elements.Any(e => e != right);
    public bool NotEquals(double other)
        => Equals(this, other);

    public static bool operator !=(BaseVector? left, BaseVector? right)
        => left.NotEquals(right);
    public static bool operator !=(BaseVector? left, double right)
        => left.NotEquals(right);

    #endregion Not Equals

    #endregion Operators

    #region Overrides

    #endregion Overrides

    #region Conversions

    public static BaseVector ToVector(double[] elements) => new(elements);
    public static implicit operator BaseVector(double[] elements) => new(elements);

    #endregion Conversions
}
