using Aelia.Core.Maths.Numerics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aelia.Core.Drawing.Colors;

public class RgbaGradient
{
    #region Fields

    public (Probability Position, RgbaColor Color)[] ColorWaypoints { get; set; }

    #endregion Fields

    #region Properties

    #endregion Properties

    #region Accessors

    // Put accessors here

    #endregion Accessors

    #region Constructors

    public RgbaGradient(Probability[] positions, RgbaColor[] colors)
    {
        if (positions.Length != colors.Length)
            throw new ArgumentException();

        ColorWaypoints = new (Probability Position, RgbaColor Color)[positions.Length];

        for (int i = 0; i < positions.Length; i++)
        {
            ColorWaypoints[i] = (positions[i], colors[i]);
        }
    }
    public RgbaGradient((Probability Position, RgbaColor Color)[] colorWaypoints)
    {
        ColorWaypoints = colorWaypoints;
    }

    #endregion Constructors

    #region Functions

    // Put functions here

    #endregion Functions

    #region Operators

    #region Add

    // Addition

    #endregion Add

    #region Subtract

    // Subtraction

    #endregion Subtract

    #region Multiply

    // Multiplication

    #endregion Multiply

    #region Divide

    // Division

    #endregion Divide

    #region Equals

    // Equality

    #endregion Equals

    #region Not Equals

    // Non-equivelance

    #endregion Not Equals

    #endregion Operators

    #region Overrides

    // Put overrides here

    #endregion Overrides

    #region Conversions

    // Put conversions here

    #endregion Conversions
}
