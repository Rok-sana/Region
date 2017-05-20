using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Region.Model
{
    public class InvRegion
    {
        public int ConturIndex;
        public string Name;
        public double [] FactorValues;

        public InvRegion(int conturIndex, string name, double[] factorValues)
        {
            ConturIndex = conturIndex;
            Name = name;
            FactorValues = factorValues;            
        }
    }
}
