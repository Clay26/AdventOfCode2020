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
            var numbers = CreateArray(input);

            var answer = FindTwoNumbersThatAddToTarget(numbers, magicNumber, true);

            if (answer.Item1 != 0)
            {
                return Convert.ToString(answer.Item1 * answer.Item2);
            }

            return "No answer found.";
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

        public Tuple<double,double> FindTwoNumbersThatAddToTarget(List<double> numbers, double target, bool optimize)
        {
            numbers.Sort();
            int startingPoint;
            if (optimize)
            {
                startingPoint = numbers.Count() / 2;
            }
            else
            {
                startingPoint = 0;
            }

            for (int i = startingPoint; i < numbers.Count(); i++)
            {
                double matchingNumber = target - numbers[i];
                if (numbers.IndexOf(matchingNumber) != -1)
                {
                    return new Tuple<double, double>(matchingNumber, numbers[i]);
                }
            }

            return new Tuple<double, double>(0, 0);
        }

        public Tuple<double,double,double> FindThreeNumbersThatAddToTarget(List<double> numbers, double target)
        {
            for (int i = 0; i < numbers.Count(); i++)
            {
                double magicNumber = target - numbers[i];
                var answer = FindTwoNumbersThatAddToTarget(numbers, magicNumber, false);

                if (answer.Item1 != 0)
                {
                    return new Tuple<double, double, double>(numbers[i], answer.Item1, answer.Item2);
                }
            }

            return new Tuple<double,double,double>(0,0,0);
        }

        public override string PartTwo(string input)
        {
            double magicNumber = 2020;
            var numbers = CreateArray(input);

            var answer = FindThreeNumbersThatAddToTarget(numbers, magicNumber);

            if (answer.Item1 != 0)
            {
                return Convert.ToString(answer.Item1 * answer.Item2 * answer.Item3);
            }

            return "No answer found.";
        }
    }
}
