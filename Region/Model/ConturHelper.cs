using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Region.Model
{
    // export this[int], ctor(string fname),  ctor(List<Point[]> list),  SaveToFile(fname), ContursAroundPoint(Point)
    public class ConturHelper
    {
        public List<Point[]> List;

        // Ctor from file
        //
        public ConturHelper(string fname)
        {
            string[] lines = File.ReadAllLines(fname);
            List = new List<Point[]>();
            foreach (string line in lines)
            {
                var nums = line.Split(',').Select(s => Convert.ToInt32(s)).ToArray();
                var ps = new List<Point>();
                for(int i = 1; i < nums.Length; i += 2)
                {
                    ps.Add(new Point(nums[i - 1], nums[i]));
                }
                List.Add(ps.ToArray());
            }
        }


        public IEnumerable<Point[]> ContursAroundPoint(Point p)
        {
            return List.Where(c => IsInside(c, p)).OrderBy(c => c.Count());
        }


        public int ConturIndexAroundPoint(Point p)
        {
            return List.TakeWhile(c => !IsInside(c, p)).Count();
        }


        static bool IsInside(Point[] ps, Point p)
        {
            bool result = false;
            int j = ps.Count() - 1;
            for (int i = 0; i < ps.Count(); i++)
            {
                if (ps[i].Y < p.Y && ps[j].Y >= p.Y || ps[j].Y < p.Y && ps[i].Y >= p.Y)
                {
                    if (ps[i].X + (p.Y - ps[i].Y) / (ps[j].Y - ps[i].Y) * (ps[j].X - ps[i].X) < p.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }


    }
}

