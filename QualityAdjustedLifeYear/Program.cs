using System;
using System.Collections.Generic;

namespace QualityAdjustedLifeYear
{
    class Program
    {
        static void Main(string[] args)
        {
            // Quality-Adjusted Life-Year 
            // https://open.kattis.com/problems/qaly
            // show 4 digits after point

            var periodsCount = EnterPeriodNum();

            var periodsResults = EnterAllPeriods(periodsCount);

            string str = String.Format("{0:0.000}", ListItemsSum(periodsResults));
            Console.WriteLine(str);
        }
        private static double ListItemsSum(List<double> list)
        {
            double sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                sum = sum + list[i];
            }
            return sum;
        }

        private static List<double> EnterAllPeriods(int yourcount)
        {
            var results = new List<double>();
            for (int i = 0; i < yourcount; i++)
            {
                results.Add(EnterOnePeriod());
            }
            return results;
        }

        private static double EnterOnePeriod()
        {
            var arr = new string[2] { "", "" };
            var ans = new double[2] { 0, 0 };
            try
            {
                arr = Console.ReadLine().Split(' ', 2);
                for (int i = 0; i < arr.Length; i++)
                {
                    ans[i] = double.Parse(arr[i]);
                }
                if (Conditions(ans) == false)
                    throw new ArgumentException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterOnePeriod();
            }
            return ans[0] * ans[1];
        }
        private static bool Conditions(double[] nums)
        {
            double q = nums[0];
            double y = nums[1];

            if (q <= 0 || q > 1)
                return false;
            else if (y <= 0 || y > 100)
                return false;
            else return true;
        }

        private static int EnterPeriodNum()
        {
            int a = 0;
            try
            {
                a = int.Parse(Console.ReadLine());
                if (a < 1 || a > 100)
                    throw new ArgumentException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterPeriodNum();
            }
            return a;
        }
    }
}
