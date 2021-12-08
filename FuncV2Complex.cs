using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Lab_3
{
    // Methods delegate
    public delegate Complex Fv2Complex(Vector2 v2);

    // Static class full of Methods
    static class FuncV2Complex
    {
        public static Complex FuncV2Complex_1(Vector2 v2)
        {
            double x = v2.X;
            double y = x * x * x + x * x;
            Complex res = new(y, y + 2);
            return res;
        }
    }
}
