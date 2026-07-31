using Aelia.Core.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aelia.Core.Maths.Vector;

/// <summary>
/// 3-dimensional vector of doubles
/// </summary>
public class Vector3Double(double[] elements) : BaseVector<Vector3Double>(elements, 3)
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

    #region Constructors

    public Vector3Double(double x = 0, double y = 0, double z = 0) : this(elements: [x, y, z]) { }

    #endregion Constructors
}
