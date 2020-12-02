using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 1)]
    public class Day01 : BaseDay
    {
        public override string PartOne(string input)
        {
            double magicNumber = 2020;

            List<double> numbers = CreateArray(input);
            numbers.Sort();

            for (int i = 0; i < numbers.Count(); i++)
            {
                double matchingNumber = magicNumber - numbers[i];
                if (numbers.IndexOf(matchingNumber) != -1)
                {
                    return Convert.ToString(matchingNumber * numbers[i]);
                }
            }

            return "null";
        }
        
        public List<double> CreateArray(string input)
        {
            List<double> num = new List<double>();

            foreach (string line in input.Split("\n"))
            {
                num.Add(Convert.ToDouble(line));

            }

            return num;
        }

        public override string PartTwo(string input)
        {
            throw new NotImplementedException();
        }
    }
}
