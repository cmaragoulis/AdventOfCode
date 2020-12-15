using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    public class Day04
    {
        public static int Problem1()
        {
            int answer = 0;
            var input = "172930-683082";

            var range = input.Split('-');
            int minValue = int.Parse(range[0]);
            int maxValue = int.Parse(range[1]);

            for (int i = minValue; i <= maxValue; i++)
            {
                answer += IsValidPassword(i) ? 1 : 0;
            }

            return answer;
        }

        public static int Problem2()
        {
            int answer = 0;
            var input = "172930-683082";

            var range = input.Split('-');
            int minValue = int.Parse(range[0]);
            int maxValue = int.Parse(range[1]);

            for (int i = minValue; i <= maxValue; i++)
            {
                answer += IsValidPassword2(i) ? 1 : 0;
            }

            return answer;
        }

        public static bool IsValidPassword(int password)
        {
            //check number of digits
            if (password < 100000 || password > 999999)
            {
                return false;
            }
            
            string passwordString = password.ToString();

            //digits never decrease
            for (int i = 0; i < passwordString.Length - 1; i++)
            {
                if (passwordString[i] > passwordString[i + 1])
                {
                    return false;
                }
            }

            //Contains duplicate adjacent digits
            var regex = new Regex(@"(\d)\1");
            if (!regex.IsMatch(passwordString))
            {
                return false;
            }

            return true;
        }

        public static bool IsValidPassword2(int password)
        {
            //check number of digits
            if (password < 100000 || password > 999999)
            {
                return false;
            }

            string passwordString = password.ToString();

            //digits never decrease
            for (int i = 0; i < passwordString.Length - 1; i++)
            {
                if (passwordString[i] > passwordString[i + 1])
                {
                    return false;
                }
            }

            //Contains 2 duplicate adjacent digits, but not 3 or more. Note: 111122 is valid

            //Find all occurences of duplicate consecutive digits
            var matches = Regex.Matches(passwordString, @"((\d)\2)");

            //Loop through them
            foreach (Match match in matches)
            {
                var digit = match.Value[0];

                //If there is one digit that is not repeated 3 times
                if (!Regex.IsMatch(passwordString, $@"({digit})\1\1"))
                {
                    //then the password meets the criteria
                    return true;
                }
            }

            return false;
        }
    }
}
