using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;

namespace Region.Model
{
    public class Ukraine
    {     
        public const int FACTORS_NUMBER = 9;
        public const int REGIONS_COUNT = 25;

        public List< InvRegion> Regions;
        public List<Factor> Factors;


        public Ukraine()
        {

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
                       Comment = readers.ReadLine(),
                       Coef = Convert.ToDouble(readers.ReadLine())
                   };
                   Factors.Add(fc);
                }
            }
        }

       

        // пересчитать инвестиционную привлекательность регионов
        //
        public double [] InvestAppRegions()
        {
            // собираем все в матрицу, 1-й индекс - факторы, 2-й - регионы
            double[,] matrix = new double[FACTORS_NUMBER, REGIONS_COUNT];
            for (int f = 0; f < FACTORS_NUMBER; f++)
                for (int r = 0; r < REGIONS_COUNT; r++)
                {
                   InvRegion region = Regions[r];
                   matrix[f, r] = region.FactorValues[f];
                }

            // нормализация факторов
            for (int f = 0; f < FACTORS_NUMBER; f++)
            {
                double min = matrix[f, 0];
                double max = matrix[f, 0];
                for (int r = 0; r < REGIONS_COUNT; r++)
                {
                    if (matrix[f, r] < min)
                        min = matrix[f, r];
                    if (matrix[f, r] > max)
                        max = matrix[f, r];
                }
                for (int r = 0; r < REGIONS_COUNT; r++)
                    matrix[f, r] = (matrix[f, r] - min) / (max - min) ;
            }

            // подсчет привлекательности с учетом коэффициентов
            double[] sums = new double[REGIONS_COUNT];
            double sumCoefs = Factors.Sum(f => f.Coef);
            for (int r = 0; r < REGIONS_COUNT; r++)
            {
                for (int f = 0; f < FACTORS_NUMBER; f++)
                    sums[r] += matrix[f, r] * Factors[f].Coef;
                sums[r] /= sumCoefs;
            }
            return sums;
        }


    }
}
