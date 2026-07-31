using Aelia.Core.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aelia.Core.Maths.Vector;

/// <summary>
/// 2-dimensional vector of doubles
/// </summary>
public class Vector2Double(double[] elements) : BaseVector<Vector2Double>(elements, 2)
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

    #region Constructors

    public Vector2Double(double x = 0, double y = 0) : this(elements: [x, y]) { }

    #endregion Constructors
}
