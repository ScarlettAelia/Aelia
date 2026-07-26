using Aelia.Core.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aelia.Core.Maths.Vector;

/// <summary>
/// 2-dimensional vector
/// </summary>
public struct Vector2
{
    #region Fields

    public double[] Elements { get; set; }

    #endregion Fields

    #region Properties

    readonly double X
    {
        get => Elements[0];
        set => Elements[0] = value;
    }
    readonly double Y
    {
        get => Elements[1];
        set => Elements[1] = value;
    }

    #endregion Properties

    #region Constructors

    public Vector2(double[] elements)
    {
        if (elements.Length > 2) throw new ArgumentException();

        Elements = new double[2];

        for (int i = 0; i < elements.Length; i++)
        {
            Elements[i] = elements[i];
        }
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
