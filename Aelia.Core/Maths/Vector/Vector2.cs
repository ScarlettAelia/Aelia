using Aelia.Core.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aelia.Core.Maths.Vector;

/// <summary>
/// 2-dimensional vector
/// </summary>
public class Vector2
{
    #region Fields

    public double[] Elements { get; init; }

    #endregion Fields

    #region Accessors

    public int Dimensions => Elements.Length;

    #endregion Accessors

    #region Constructors

    public Vector2(double[] elements)
    {
        if (elements.IsNullOrEmpty()) throw new ArgumentException($"Cannot form a vector with null or empty elements");

        Elements = elements;
    }

    #endregion Constructors

    #region Functions

    #endregion Functions

    #region Operators

    #region Add

    #endregion Add

    #region Subtract

    #endregion Subtract

    #region Multiply

    #endregion Multiply

    #region Divide

    #endregion Divide

    #region Equals

    #endregion Equals

    #region Not Equals

    #endregion Not Equals

    #endregion Operators

    #region Overrides

    #endregion Overrides

    #region Conversions

    #endregion Conversions
}
