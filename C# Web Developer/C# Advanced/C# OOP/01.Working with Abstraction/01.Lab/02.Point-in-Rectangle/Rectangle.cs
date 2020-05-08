using System;
using System.Collections.Generic;
using System.Text;

namespace _02.Point_in_Rectangle
{
    public class Rectangle
    {
        public Point TopLeft { get; set; }

        public Point BottomRight { get; set; }

        public bool Contains(Point point)
        {
            var xIsInside = this.TopLeft.X < point.X && point.X < this.BottomRight.X;
            var yIsInside = this.BottomRight.Y < point.Y && point.Y < this.TopLeft.Y;

            return xIsInside && yIsInside;

        }
    }
}
