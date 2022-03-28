using System;
using System.Collections.Generic;
using ExtensionMethods;

namespace Calculator
{
    public class TanFunction : EquationItem, IFunction
    {
        public TanFunction(FunctionType type)
        {
            Type = type;
        }
        public double Execute(List<object> EqItems)
        {
            double num = GetNum(EqItems, Index, 1);

            if (Settings.AngleUnits == AngleUnits.Deg)
            {
                num = num.DegToRad();
            }

            //pi*30/30 != pi
            if (num != 0)
            {
                var precision = 1.0 / Math.Pow(10, Settings.PrecisionPoints);
                var div = Math.Abs(num) / (Math.PI / 2);
                //pi/4 => 0,5 % 2 = 0,5
                //pi/2 => 1 % 2 = 1
                //pi => 2 % 2 = 0
                //3/2pi => 3 % 2 = 1
                //4/2pi => 4 % 2 = 0
                //5/2pi => 5 % 2 = 1

                if (Math.Abs(1 - (div % 2)) <= precision) 
                {
                    return double.NaN;
                }
            }

            return Math.Tan(num);
        }

        public override string GetStringRepresentation()
        {
            return "tan";
        }

        public IFunction NewInstance()
        {
            return new TanFunction(Type);
        }
    }
}
