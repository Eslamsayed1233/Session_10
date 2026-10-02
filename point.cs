using System;
using System.Collections.Generic;
using System.Text;

namespace Session_10
{
    public class Point : IComparable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            Point upcomming = (Point)obj;

            if (upcomming.X == this.X && upcomming.Y == this.Y)
                return true;

            return false;
        }


        public override string ToString()
        {
            return $"(X = {X}, Y = {Y})";
        }

        public int CompareTo(Point? other)
        {
            if (other is null)
                return 1;

            //if (this.X == other.X)
            //{
            //    if (this.Y > other.Y)
            //        return 1;
            //    else if (this.Y < other.Y)
            //        return -1;
            //    else
            //        return 0;
            //}
            //else
            //{
            //    return -1;
            //}

            if (this.X == other.X)
                return this.Y.CompareTo(other.Y);
            else
                return this.X.CompareTo(other.X);
        }
    }
}
