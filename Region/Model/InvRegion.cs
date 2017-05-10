using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Region.Model
{
    public class InvRegion
    {
        public Oblast Id;
        public string Name;
        public double [] FactorValues;

        public InvRegion(Oblast id,string name, double[] values)
        {
            Id = id;
            Name = name;
            FactorValues = values;            
        }
    }
}
