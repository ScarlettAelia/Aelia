using Aelia.Core.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aelia.Core.Maths.Vector;

/// <summary>
/// 2-dimensional vector
/// </summary>
public class Vector2(double[] elements) : VectorN(elements, 2)
{
    #region Properties

    public double X
    {
        get => Elements[0];
        set => Elements[0] = value;
    }
    public double Y
    {
        get => Elements[1];
        set => Elements[1] = value;
    }

    #endregion Properties

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
