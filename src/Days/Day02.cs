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
                if (ParseLine(line).valid())
                {
                    validPasswords += 1;
                }
            }

            return Convert.ToString(validPasswords);
        }


        public override string PartTwo(string input)
        {
            throw new NotImplementedException();
        }

        public Password ParseLine(string line)
        {
            var input = line.Split(" ");
            
            double min = Convert.ToDouble(Convert.ToString(input[0][0]));

            double max = Convert.ToDouble(Convert.ToString(input[0][2]));

            string letter = Convert.ToString(input[1][0]);

            return new Password(letter, min, max, input[2]);
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

            public bool valid()
            {
                double count = this.passwordContent.Split(this.policyLetter).Length - 1;

                if (count >= this.min && count <= this.max)
                {
                    return true;
                }

                return false;
            }

        }
    }

}
