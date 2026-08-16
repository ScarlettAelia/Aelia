using Aelia.Core.Drawing.Utils.Interface;
using Aelia.Core.Maths.Vector;

namespace Aelia.Core.Drawing.Utils.Abstract;

public abstract class AbstractShape : IDrawable
{
    #region Fields

    private Vector2Double _anchor;
    private Vector2Double _center;

    #endregion Fields

    #region Properties

    /// <summary>
    /// Placement of the anchor used in draw functions
    /// </summary>
    public Vector2Double Anchor
    {
        get => _anchor;
        set
        {
            if (_center != value)
            {
                _anchor = value;
                _center = SetCenter(value);
            }
        }
    }
    public double X
    {
        get => _anchor.X;
        set
        {
            if (value != _anchor.X)
            {
                _anchor = new(value, _anchor.Y);
            }
        }
    }
    public double Y
    {
        get => _anchor.Y;
        set
        {
            if (value != _anchor.Y)
            {
                Anchor = new(_anchor.X, value);
            }
        }
    }
    /// <summary>
    /// Center of the shape
    /// </summary>
    public Vector2Double Center
    {
        get => _center;
        set
        {
            if (_center != value)
            {
                _center = value;
                _anchor = SetAnchor(value);
            }
        }
    }
    public double CX
    {
        get => _center.X;
        set
        {
            if (value != _center.X)
            {
                Center = new(value, _center.Y);
            }
        }
    }
    public double CY
    {
        get => _center.Y;
        set
        {
            if (value != _center.Y)
            {
                Center = new(_center.X, value);
            }
        }
    }

    #endregion Properties

    #region Functions

    public abstract string DrawHtml();

    public abstract Vector2Double DrawVector();

    public abstract object DrawRaster();

    protected abstract Vector2Double SetAnchor(Vector2Double newCenter);
    protected abstract Vector2Double SetCenter(Vector2Double newAnchor);

    #endregion Functions
}
