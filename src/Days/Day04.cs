using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 4)]
    public class Day04 : BaseDay
    {
        public override string PartOne(string input)
        {
            var passports = CreatePassports(input);
            double count = 0;
            foreach (var passport in passports)
            {
                if (ValidatePassport(passport))
                {
                    count++;
                }
            }

            return Convert.ToString(count);
        }

        public override string PartTwo(string input)
        {
            throw new NotImplementedException();
        }

        public bool ValidatePassport(Dictionary<string,string> passport)
        {
            string[] input = {"byr","iyr","eyr","hgt","hcl","ecl","pid"};
            List<string> neededKeys = new List<string>(input);

            foreach (string neededKey in neededKeys)
            {
                if (!passport.ContainsKey(neededKey))
                {
                    return false;
                }
                else
                {
                    if (neededKey == "byr")
                    {
                        if (!ValidateBirthYear(Convert.ToDouble(passport["byr"])))
                        {
                            return false;
                        }
                    }

                    if (neededKey == "iyr")
                    {
                        if (!ValidateIssueYear(Convert.ToDouble(passport["iyr"])))
                        {
                            return false;
                        }
                    }

                    if (neededKey == "eyr")
                    {
                        if (!ValidateExpYear(Convert.ToDouble(passport["eyr"])))
                        {
                            return false;
                        }
                    }

                    if (neededKey == "hgt")
                    {
                        if (!ValidateHeight(passport["hgt"]))
                        {
                            return false;
                        }
                    }

                    if (neededKey == "hcl")
                    {
                        if (!ValidateHairColor(passport["hcl"]))
                        {
                            return false;
                        }
                    }

                    if (neededKey == "ecl")
                    {
                        if (!ValidateEyeColor(passport["ecl"]))
                        {
                            return false;
                        }
                    }

                    if (neededKey == "pid")
                    {
                        if (!ValidatePassportId(passport["pid"]))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public bool ValidateBirthYear(double year)
        {
            return year >= 1920 && year <= 2020;
        }

        public bool ValidateIssueYear(double year)
        {
            return year >= 2010 && year <= 2020;
        }

        public bool ValidateExpYear(double year)
        {
            return year >= 2020 && year <= 2030;
        }

        public bool ValidateHeight(string height)
        {
            if (height.Contains("in"))
            {
                var inHeight = height.Split("i");
                return Convert.ToDouble(inHeight[0]) >= 59 && Convert.ToDouble(inHeight[0]) <= 76;
            }
            
            if (height.Contains("cm"))
            {
                var cmHeight = height.Split("c");
                return Convert.ToDouble(cmHeight[0]) >= 150 && Convert.ToDouble(cmHeight[0]) <= 193;
            }

            return false;
        }

        public bool ValidateHairColor(string color)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(color,@"#(\d*[a-f]*){6}");
        }

        public bool ValidateEyeColor(string color)
        {
            string[] input = {"amb","blu","brn","gry","grn","hzl","oth"};
            List<string> neededKeys = new List<string>(input);

            foreach (string neededKey in neededKeys)
            {
                if (color == neededKey)
                {
                    return true;
                }
            }

            return false;
        }

        public bool ValidatePassportId(string color)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(color, @"\d{9}");
        }

        public List<Dictionary<string,string>> CreatePassports(string input)
        {
            List<string> credLists = Passports(input);
            List<Dictionary<string,string>> passports = new List<Dictionary<string,string>>();

            foreach(string credList in credLists)
            {
                passports.Add(CreatePassport(credList));
            }

            return passports;
        }

        public Dictionary<string,string> CreatePassport(string input)
        {
            Dictionary<string,string> passport = new Dictionary<string,string>();

            foreach (string field in input.Split(" "))
            {
                if (field.Length > 1)
                {
                    var temp = field.Split(":");
                    passport.Add(temp[0],temp[1]);
                }
            }


            return passport;
        }

        public List<string> ParseFields(string input)
        {
            List<string> creds = new List<string>();

            foreach (string line in input.Split("\n"))
            {
                if (line.Length > 1)
                {
                    creds.Add(line.Split("\r")[0]); 
                }
                else
                {
                    creds.Add("NEW PASSPORT");
                }
            }

            return creds;
        }

        public List<string> Passports(string input)
        {
            var creds = ParseFields(input);
            List<string> passList = new List<string>();
            List<string> temp = new List<string>();

            foreach (string cred in creds)
            {
                if (cred != "NEW PASSPORT")
                {
                    temp.Add(cred);
                }
                else
                {
                    string passport = "";
                    foreach (string passLine in temp)
                    {
                        if (passport.Length > 0)
                        {
                            passport += " " + passLine;
                        }
                        else
                        {
                            passport += passLine;
                        }
                    }
                    passList.Add(passport);
                    temp.Clear();
                }
            }

            string passport2 = "";
            foreach (string passLine in temp)
            {
                if (passport2.Length > 0)
                {
                    passport2 += " " + passLine;
                }
            }
            passList.Add(passport2);
            temp.Clear();

            return passList;
        }
    }
}
