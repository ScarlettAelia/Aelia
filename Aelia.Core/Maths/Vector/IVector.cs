using System;
using System.Collections.Generic;
using System.Text;

namespace Aelia.Core.Maths.Vector;

public interface IVector
{
    public double[] Elements { get; set; }
    public int Dimensions { get; }
}
