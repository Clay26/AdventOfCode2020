using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 2)]
    public class Day02 : BaseDay
    {
        public override string PartOne(string input)
        {
            double validPasswords = 0;
            foreach (string line in input.Split("\n"))
            {
                if (ParseLine(line).oldValid())
                {
                    validPasswords += 1;
                }
            }

            return Convert.ToString(validPasswords);
        }


        public override string PartTwo(string input)
        {
            double validPasswords = 0;
            foreach (string line in input.Split("\n"))
            {
                if (ParseLine(line).newValid())
                {
                    validPasswords += 1;
                }
            }

            return Convert.ToString(validPasswords);
        }

        public Password ParseLine(string line)
        {
            var input = line.Split(" ");

            var minMax = ParseMinMax(input[0]);

            string letter = Convert.ToString(input[1][0]);

            return new Password(letter, minMax.Item1, minMax.Item2, input[2]);
        }

        public Tuple<double,double> ParseMinMax(string range)
        {
            var input = range.Split("-");

            return new Tuple<double,double>(Convert.ToDouble(input[0]),Convert.ToDouble(input[1]));
            
        }
        public class Password
        {
            string policyLetter;

            double min;

            double max;

            string passwordContent;

            public Password(string letter, double min, double max, string password)
            {
                this.policyLetter = letter;
                this.min = min;
                this.max = max;
                this.passwordContent = password;
            }

            public bool oldValid()
            {
                double count = this.passwordContent.Split(this.policyLetter).Length - 1;

                if (count >= this.min && count <= this.max)
                {
                    return true;
                }

                return false;
            }

            public bool newValid()
            {
                int min = Convert.ToInt32(this.min);
                int max = Convert.ToInt32(this.max);

                string pos = this.passwordContent.Substring(min - 1, 1) + this.passwordContent.Substring(max - 1, 1);

                double count = pos.Split(this.policyLetter).Length - 1;

                if (count == 1)
                {
                    return true;
                }

                return false;
            }

        }
    }

}
