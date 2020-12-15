using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day04
    {
        private static readonly string inputPath = @"C:\Projects\Advent of Code\AdventOfCode\AdventOfCode\2020\Inputs\Day04.txt";

        public static int Problem1()
        {
            var batchFile = File.ReadAllLines(inputPath);
            var passports = ExtractPassports(batchFile);

            int validPassports = 0;
            foreach (var passport in passports)
            {
                if (passport.IsValid)
                {
                    validPassports++;
                }
            }

            return validPassports;
        }

        public static int Problem2()
        {
            var batchFile = File.ReadAllLines(inputPath);
            var passports = ExtractPassports(batchFile);

            int validPassports = 0;
            foreach (var passport in passports)
            {
                if (passport.IsValidStrict)
                {
                    validPassports++;
                }
            }

            return validPassports;
        }

        public static List<Passport> ExtractPassports(string[] batchFile)
        {
            var passports = new List<Passport>();

            var passport = new Passport();
            foreach (var line in batchFile)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    passports.Add(passport);
                    passport = new Passport();
                    continue;
                }

                var fields = line.Split(' ');

                foreach (var field in fields)
                {
                    switch (field.Substring(0, 3))
                    {
                        case "byr":
                            passport.BirthYear = field[4..];
                            break;
                        case "iyr":
                            passport.IssueYear = field[4..];
                            break;
                        case "eyr":
                            passport.ExpirationYear = field[4..];
                            break;
                        case "hgt":
                            passport.Height = field[4..];
                            break;
                        case "hcl":
                            passport.HairColor = field[4..];
                            break;
                        case "ecl":
                            passport.EyeColor = field[4..];
                            break;
                        case "pid":
                            passport.PassportId = field[4..];
                            break;
                        case "cid":
                            passport.CountryId = field[4..];
                            break;
                    }
                }
            }

            if (passport != null)
            {
                passports.Add(passport);
            }

            return passports;
        }
    }

    public class Passport
    {
        public string BirthYear { get; set; }
        public string IssueYear { get; set; }
        public string ExpirationYear { get; set; }
        public string Height { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string PassportId { get; set; }
        public string CountryId { get; set; }

        public bool IsValid => !string.IsNullOrWhiteSpace(BirthYear)
                && !string.IsNullOrWhiteSpace(IssueYear)
                && !string.IsNullOrWhiteSpace(ExpirationYear)
                && !string.IsNullOrWhiteSpace(Height)
                && !string.IsNullOrWhiteSpace(HairColor)
                && !string.IsNullOrWhiteSpace(EyeColor)
                && !string.IsNullOrWhiteSpace(PassportId);

        public bool IsValidStrict => IsValidBirthYear()
                && IsValidIssueYear()
                && IsValidExpirationYear()
                && IsValidHeight()
                && IsValidHairColor()
                && IsValidEyeColor()
                && IsValidPassportId();

        public bool IsValidBirthYear()
        {
            if (string.IsNullOrWhiteSpace(BirthYear))
            {
                return false;
            }

            int year = int.Parse(BirthYear);

            return year >= 1920 && year <= 2002;
        }

        public bool IsValidIssueYear()
        {
            if (string.IsNullOrWhiteSpace(IssueYear))
            {
                return false;
            }

            int year = int.Parse(IssueYear);

            return year >= 2010 && year <= 2020;
        }

        public bool IsValidExpirationYear()
        {
            if (string.IsNullOrWhiteSpace(ExpirationYear))
            {
                return false;
            }

            int year = int.Parse(ExpirationYear);

            return year >= 2020 && year <= 2030;
        }

        public bool IsValidHeight()
        {
            if (string.IsNullOrWhiteSpace(Height))
            {
                return false;
            }

            var match = Regex.Match(Height, "(?<height>[0-9]{2,3})(?<unit>in|cm)");

            if (!match.Success)
            {
                return false;
            }

            var height = int.Parse(match.Groups["height"].Value);

            return match.Groups["unit"].Value switch
            {
                "cm" => height >= 150 && height <= 193,
                "in" => height >= 59 && height <= 76,
                _ => false,
            };
        }

        public bool IsValidHairColor()
        {
            return string.IsNullOrWhiteSpace(HairColor)
                ? false
                : Regex.IsMatch(HairColor, "^#[0-9a-f]{6}$");
        }

        public bool IsValidEyeColor()
        {
            return string.IsNullOrWhiteSpace(EyeColor)
                ? false
                : Regex.IsMatch(EyeColor, "^amb|blu|brn|gry|grn|hzl|oth$");
        }

        public bool IsValidPassportId()
        {
            return string.IsNullOrWhiteSpace(PassportId)
                ? false
                : Regex.IsMatch(PassportId, @"^\d{9}$");
        }
    }

}
