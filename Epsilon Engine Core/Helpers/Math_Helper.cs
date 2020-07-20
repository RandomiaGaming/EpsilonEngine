using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epsilon_Engine
{
    public static class Math_Helper
    {
        public static int Clamp(int Value, int Min, int Max)
        {
            if (Value > Max)
            {
                return Max;
            }
            else if (Value < Min)
            {
                return Min;
            }
            else
            {
                return Value;
            }
        }
        public static float Clamp(float Value, float Min, float Max)
        {
            if (Value > Max)
            {
                return Max;
            }
            else if (Value < Min)
            {
                return Min;
            }
            else
            {
                return Value;
            }
        }
        public static double Clamp(double Value, double Min, double Max)
        {
            if (Value > Max)
            {
                return Max;
            }
            else if (Value < Min)
            {
                return Min;
            }
            else
            {
                return Value;
            }
        }
    }
}
