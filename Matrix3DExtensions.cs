using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Convert3DObject
{
    public static class Matrix3DExtensions
    {
        public static Vector3D ToEulerAngles(this Matrix3D m)
        {
            double x, y, z;
            if (Math.Abs(m.M12 + 1) < 0.0001)
            {
                x = 0;
                y = Math.PI / 2;
                z = Math.Atan2(m.M21, m.M31);
            }
            else if (Math.Abs(m.M12 - 1) < 0.0001)
            {
                x = 0;
                y = -Math.PI / 2;
                z = Math.Atan2(m.M21, m.M31);
            }
            else
            {
                y = Math.Asin(m.M13);
                x = Math.Atan2(-m.M23 / Math.Cos(y), m.M33 / Math.Cos(y));
                z = Math.Atan2(-m.M12 / Math.Cos(y), m.M11 / Math.Cos(y));
            }

            return new Vector3D(x, y, z);
        }
    }
}
