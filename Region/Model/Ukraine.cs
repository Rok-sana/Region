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
        Lutsk,
        Rivno,
        Zhytomyr,
        Kyiv,
        Lviv,
        Ternopil,
        Volynska,
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
        public const int FACTORS_NUMBER = 11;
        public const int REGIONS_COUNT = 5;

        public List <InvRegion> Regions;
        public List<Factor> Factors;
        public Conturs Conturs;

        public Ukraine()
        {
            Conturs = new Conturs();

            // Regions    
            Regions = new List<InvRegion>();
            using (StreamReader reader = new StreamReader("Regions.txt"))
            {
                for( int i=0; i< REGIONS_COUNT; i++)
                {
                    int id = Convert.ToInt32(reader.ReadLine());
                    string name = reader.ReadLine();
                    string [] arr = reader.ReadLine().Split(',');
                    double[] m = new double[arr.Length];

                    for ( int j =0; j< arr.Length; j++)
                    {
                        m[j] = Convert.ToDouble(arr[j].Trim());
                    }

                    Regions.Add(new InvRegion( (Oblast) id, name, m));
                    
                }
            }

            // Factors            
            Factors = new List<Factor>();

            double[] coefs = { 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1, 1 };
            string[] names = { "Strength", "Valid", "Salary", "Incomes", " Retail", "Waste", "Balance", "Taxation", "OverhaulInvestments", "Crime", "Corruption" };
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
            for ( int i=0; i< FACTORS_NUMBER; i++)
                for ( int j=0; j< REGIONS_COUNT; j++)
                    matrix[i, j] = Regions[j].FactorValues[i];

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
