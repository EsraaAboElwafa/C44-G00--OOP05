using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary7
{
    internal class Point3D : IComparable, ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point3D() : this(0, 0, 0) { }

        public Point3D(int x) : this(x, 0, 0) { }

        public Point3D(int x, int y) : this(x, y, 0) { }

        public Point3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return $"Point Coordinates: ({X}, {Y}, {Z})";
        }

        public int CompareTo(object obj)
        {
            Point3D other = obj as Point3D;
            if (other == null) return 1;

            int result = this.X.CompareTo(other.X);
            if (result == 0)
            {
                result = this.Y.CompareTo(other.Y);
            }
            return result;
        }

        public object Clone()
        {
            return new Point3D(this.X, this.Y, this.Z);
        }
    }
}
