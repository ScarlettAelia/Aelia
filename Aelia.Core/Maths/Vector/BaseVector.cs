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
public class BaseVector<T> : IVector,
                             IAdditionOperators<BaseVector<T>, BaseVector<T>, BaseVector<T>>,
                             IAdditionOperators<BaseVector<T>, double, BaseVector<T>>,
                             ISubtractionOperators<BaseVector<T>, BaseVector<T>, BaseVector<T>>,
                             ISubtractionOperators<BaseVector<T>, double, BaseVector<T>>,
                             IMultiplyOperators<BaseVector<T>, BaseVector<T>, BaseVector<T>>,
                             IMultiplyOperators<BaseVector<T>, double, BaseVector<T>>,
                             IDivisionOperators<BaseVector<T>, BaseVector<T>, BaseVector<T>>,
                             IDivisionOperators<BaseVector<T>, double, BaseVector<T>>,
                             IEqualityOperators<BaseVector<T>, BaseVector<T>, bool>,
                             IEqualityOperators<BaseVector<T>, double, bool>
                             where T : BaseVector<T>
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

    public static double Magnitude<V>(BaseVector<V> vector) where V : BaseVector<V>
        => VectorMaths.Magnitude(vector.Elements);
    public double Magnitude() => VectorMaths.Magnitude(Elements);

    public static double MagnitudeBetween<V1, V2>(BaseVector<V1> vector1, BaseVector<V2> vector2) where V1 : BaseVector<V1> where V2 : BaseVector<V2>
        => VectorMaths.MagnitudeBetween(vector1.Elements, vector2.Elements);
    public double MagnitudeBetween<V>(BaseVector<V> other) where V : BaseVector<V>
        => VectorMaths.MagnitudeBetween(this.Elements, other.Elements);

    #endregion Functions

    #region Operators

    #region Add

    public static BaseVector<V1> Add<V1, V2>(BaseVector<V1> left, BaseVector<V2> right) where V1 : BaseVector<V1> where V2 : BaseVector<V2>
        => left.Elements.AddByElement(right.Elements);
    public BaseVector<T> Add<V>(BaseVector<V> other) where V : BaseVector<V>
        => Add(this, other);
    public static BaseVector<V> Add<V>(BaseVector<V> left, double right) where V : BaseVector<V>
        => left.Elements.AddByElement(right);
    public BaseVector<T> Add(double other)
        => Add(this, other);

    public static BaseVector<T> operator +(BaseVector<T> left, BaseVector<T> right)
        => Add(left, right);
    public static BaseVector<T> operator +(BaseVector<T> left, double right)
        => Add(left, right);

    #endregion Add

    #region Subtract

    public static BaseVector<V1> Subtract<V1, V2>(BaseVector<V1> left, BaseVector<V2> right) where V1 : BaseVector<V1> where V2 : BaseVector<V2>
        => left.Elements.SubtractByElement(right.Elements);
    public BaseVector<T> Subtract<V>(BaseVector<V> other) where V : BaseVector<V>
        => Subtract(this, other);
    public static BaseVector<V> Subtract<V>(BaseVector<V> left, double right) where V : BaseVector<V>
        => left.Elements.SubtractByElement(right);
    public BaseVector<T> Subtract(double other)
        => Subtract(this, other);

    public static BaseVector<T> operator -(BaseVector<T> left, BaseVector<T> right)
        => Subtract(left, right);
    public static BaseVector<T> operator -(BaseVector<T> left, double right)
        => Subtract(left, right);

    #endregion Subtract

    #region Multiply

    public static BaseVector<V1> Multiply<V1, V2>(BaseVector<V1> left, BaseVector<V2> right) where V1 : BaseVector<V1> where V2 : BaseVector<V2>
        => left.Elements.MultiplyByElement(right.Elements);
    public BaseVector<T> Multiply<V>(BaseVector<V> other) where V : BaseVector<V>
        => Multiply(this, other);
    public static BaseVector<V> Multiply<V>(BaseVector<V> left, double right) where V : BaseVector<V>
        => left.Elements.MultiplyByElement(right);
    public BaseVector<T> Multiply(double other)
        => Multiply(this, other);

    public static BaseVector<T> operator *(BaseVector<T> left, BaseVector<T> right)
        => Multiply(left, right);
    public static BaseVector<T> operator *(BaseVector<T> left, double right)
        => Multiply(left, right);

    #endregion Multiply

    #region Divide

    public static BaseVector<V1> Divide<V1, V2>(BaseVector<V1> left, BaseVector<V2> right) where V1 : BaseVector<V1> where V2 : BaseVector<V2>
        => left.Elements.DivideByElement(right.Elements);
    public BaseVector<T> Divide<V>(BaseVector<V> other) where V : BaseVector<V>
        => Divide(this, other);
    public static BaseVector<V> Divide<V>(BaseVector<V> left, double right) where V : BaseVector<V>
        => left.Elements.DivideByElement(right);
    public BaseVector<T> Divide(double other)
        => Divide(this, other);

    public static BaseVector<T> operator /(BaseVector<T> left, BaseVector<T> right)
        => Divide(left, right);
    public static BaseVector<T> operator /(BaseVector<T> left, double right)
        => Divide(left, right);

    #endregion Divide

    #region Equals

    public static bool Equals<V1, V2>(BaseVector<V1> left, BaseVector<V2> right) where V1 : BaseVector<V1> where V2 : BaseVector<V2>
        => left.Elements == right.Elements;
    public bool Equals<V>(BaseVector<V> other) where V : BaseVector<V>
        => Equals(this, other);
    public static bool Equals<V>(BaseVector<V> left, double right) where V : BaseVector<V>
        => left.Elements.All(e => e == right);
    public bool Equals(double other)
        => Equals(this, other);

    public static bool operator ==(BaseVector<T>? left, BaseVector<T>? right)
        => left.Equals(right);
    public static bool operator ==(BaseVector<T>? left, double right)
        => left.Equals(right);

    #endregion Equals

    #region Not Equals

    public static bool NotEquals<V1, V2>(BaseVector<V1> left, BaseVector<V2> right) where V1 : BaseVector<V1> where V2 : BaseVector<V2>
        => left.Elements != right.Elements;
    public bool NotEquals<V>(BaseVector<V> other) where V : BaseVector<V>
        => NotEquals(this, other);
    public static bool NotEquals<V>(BaseVector<V> left, double right) where V : BaseVector<V>
        => left.Elements.Any(e => e != right);
    public bool NotEquals(double other)
        => Equals(this, other);

    public static bool operator !=(BaseVector<T>? left, BaseVector<T>? right)
        => left.NotEquals(right);
    public static bool operator !=(BaseVector<T>? left, double right)
        => left.NotEquals(right);

    #endregion Not Equals

    #endregion Operators

    #region Overrides

    #endregion Overrides

    #region Conversions

    public static implicit operator BaseVector<T>(double[] elements) => new(elements);

    #endregion Conversions
}
