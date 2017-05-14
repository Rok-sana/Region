using System;
using Contur;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;

namespace Region.Model
{
     public enum Oblast
    {
        Volynska=1,
        Rivno=2,
        Zhytomyr=3,
        Kyiv,
        Lviv,
        Ternopil,
        Ivano_Frankivsk,
        Zakarpattya,
        Cherovtsy,
        Khmelnitsky,
        Vinnytsia,
        Poltava,
        Odesa,
        Chernigov,
        Sumy,
        Kirovograd,
        Cherkasy,
        Nikolaev,
        Kharkiv,
        Dnipropetrovsk,
        Kherson,
        Crimea,
        Zaporozhia,
        Luhansk,
        Donetsk
}
    public class Ukraine
    {     
        public const int FACTORS_NUMBER = 8;
        public const int REGIONS_COUNT = 24;

        public Dictionary <Oblast, InvRegion> Regions;
        public List<Factor> Factors;
        public Conturs Conturs;

        public Ukraine()
        {
            Conturs = new Conturs();

            // Regions    
            
           Regions = new Dictionary<Oblast, InvRegion>();
            using (StreamReader reader = new StreamReader("Regions.txt"))
            {
                for( int i=0; i< REGIONS_COUNT; i++)
                {
                    Oblast id =(Oblast) Convert.ToInt32(reader.ReadLine());
                    string name = reader.ReadLine();
                    string [] arr = reader.ReadLine().Split(',');
                    double[] m = new double[arr.Length];

                    for ( int j =0; j< arr.Length; j++)
                    {
                        
                            m[j] = Convert.ToDouble(arr[j].Trim());
                        
                    }

                    Regions[id] = new InvRegion( id, name, m);
                    
                }
            }

            // Factors            
            Factors = new List<Factor>();

            double[] coefs = { 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9  };
            string[] names = { "Strength", "Valid", "Salary", "Incomes", " Retail", "Waste", "Balance", "Taxation", "OverhaulInvestments"};
            for (int i = 0; i < FACTORS_NUMBER; i++)
            {
                Factor f = new Factor
                {
                    Name = names[i],
                    Coef = coefs[i]
                };
                Factors.Add(f);
            }
        }

        // пересчитать инвестиционную привлекательность регионов

       

        public  double [] ObInvestAppRegions()
        {
            double[,] matrix;
            matrix = new double[FACTORS_NUMBER, REGIONS_COUNT];
            for (int i = 0; i < FACTORS_NUMBER; i++)
                for (int j = 0; j < REGIONS_COUNT; j++)
                {
                    Oblast e2 = (Oblast)j;
                    InvRegion value;
                    Regions.TryGetValue(e2, out value);
                    if (value != null)
                    {
                        // System.Diagnostics.Debug.WriteLine( value.Name);
                        matrix[i, j] = value.FactorValues[i];
                        //matrix[i, j] = Regions[(Oblast)j].FactorValues[i];

                    }
                    
                }
            // нормализация факторов
            for (int i = 0; i < FACTORS_NUMBER; i++)
            {
                double max = matrix[i, 0];
                for (int j = 0; j < REGIONS_COUNT; j++)
                    if (matrix[i, j] > max)
                        max=matrix[i,j];
                for (int j = 0; j < REGIONS_COUNT; j++)
                    matrix[i, j] /= max ;
            }
            // подсчет привлекательности
            double[] sums = new double[REGIONS_COUNT];
            for (int j = 0; j < REGIONS_COUNT; j++)
                for (int i = 0; i < FACTORS_NUMBER; i++)
                    sums[j] += matrix[i, j] * Factors[i].Coef;  

             return sums;

        }


    }
}
