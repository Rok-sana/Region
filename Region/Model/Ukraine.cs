using System;
using Contur;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;

namespace Region.Model
{
//     public enum Oblast
//    {
//        Volynska = 0,  
//        Rivno,
//        Zhytomyr,
//        Kyiv,
//        Lviv,
//        Ternopil,
//        Ivano_Frankivsk,
//        Zakarpattya,
//        Cherovtsy,
//        Khmelnitsky,
//        Vinnytsia,
//        Poltava,
//        Odesa,
//        Chernigov,
//        Sumy,
//        Kirovograd,
//        Cherkasy,
//        Nikolaev,
//        Kharkiv,
//        Dnipropetrovsk,
//        Kherson,
//        Crimea,
//        Zaporozhia,
//        Luhansk,
//        Donetsk
//}
    public class Ukraine
    {     
        public const int FACTORS_NUMBER = 9;
        public const int REGIONS_COUNT = 25;

        public List< InvRegion> Regions;
        public List<Factor> Factors;
        public ConturList ConturList;


        public Ukraine()
        {
            ConturList = new ConturList("xconturs.txt");

            // Regions    

            Regions = new List< InvRegion>();
            using (StreamReader reader = new StreamReader("Regions.txt"))
            {
                for (int i = 0; i < REGIONS_COUNT; i++)
                {
                    int conturIndex = Convert.ToInt32(reader.ReadLine());
                    string name = reader.ReadLine();
                    string[] arr = reader.ReadLine().Split(',');
                    double[] factorValues = new double[arr.Length];

                    for (int j = 0; j < arr.Length; j++)
                    {
                        factorValues[j] = Convert.ToDouble(arr[j].Trim());
                    }
                    Regions.Add ( new InvRegion(conturIndex, name, factorValues));
                }
            }

            // Factors            
            Factors = new List<Factor>();
            using (StreamReader readers = new StreamReader("Coef.txt"))
            {
                for (int i = 0; i < FACTORS_NUMBER; i++)
                {
                   Factor fc = new Factor
                   {
                      Name = readers.ReadLine(),
                      Coef = Convert.ToDouble(readers.ReadLine())
                   };
                   Factors.Add(fc);
                }
            }
        }

       

        // пересчитать инвестиционную привлекательность регионов
        //
        public double [] ObInvestAppRegions()
        {
            double[,] matrix;
            matrix = new double[FACTORS_NUMBER, REGIONS_COUNT];
            for (int i = 0; i < FACTORS_NUMBER; i++)
                for (int j = 0; j < REGIONS_COUNT; j++)
                {
                   InvRegion region= Regions[j];
                   matrix[i, j] = region.FactorValues[i];
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
            double sumCoefs =Factors.Sum(f=>f.Coef);
            for (int j = 0; j < REGIONS_COUNT; j++)
                for (int i = 0; i < FACTORS_NUMBER; i++)
                    sums[j] =(sums[j]+ matrix[i, j] * Factors[i].Coef)/sumCoefs;
            return sums;
        }


    }
}
