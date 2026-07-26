using Aelia.Core.Drawing.Utils.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aelia.Core.Drawing.Utils.Abstract;

public abstract class Shape : IDrawable
{
    public abstract string DrawHtml();

    public abstract object DrawRaster();

    public abstract object DrawVector();
}
