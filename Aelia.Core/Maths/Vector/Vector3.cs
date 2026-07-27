using Aelia.Core.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aelia.Core.Maths.Vector;

/// <summary>
/// 3-dimensional vector of doubles
/// </summary>
public class Vector3(double[] elements) : VectorN(elements, 3)
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
    public double Z
    {
        get => Elements[2];
        set => Elements[2] = value;
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
