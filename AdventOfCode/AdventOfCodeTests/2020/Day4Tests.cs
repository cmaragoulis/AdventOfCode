using AdventOfCode2020;
using Xunit;

namespace AdventOfCodeTests2020
{
    public class Day4Tests
    {
        [Fact]
        public void IsValidStrict_Correctly_ValidatesPassports()
        {
            //Arrange
            var invalidPassportsInput = new string[] { "eyr:1972 cid:100",
                            "hcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926",
                            "",
                            "iyr:2019",
                            "hcl:#602927 eyr:1967 hgt:170cm",
                            "ecl:grn pid:012533040 byr:1946",
                            "",
                            "hcl:dab227 iyr:2012",
                            "ecl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277",
                            "",
                            "hgt:59cm ecl:zzz",
                            "eyr:2038 hcl:74454a iyr:2023",
                            "pid:3556412378 byr:2007"};

            var validPassportsInput = new string[] { "pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980",
                            "hcl:#623a2f",
                            "",
                            "eyr:2029 ecl:blu cid:129 byr:1989",
                            "iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm",
                            "",
                            "hcl:#888785",
                            "hgt:164cm byr:2001 iyr:2015 cid:88",
                            "pid:545766238 ecl:hzl",
                            "eyr:2022",
                            "",
                            "iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719" };

            var invalidPassports = Day4.ExtractPassports(invalidPassportsInput);
            var validPassports = Day4.ExtractPassports(validPassportsInput);

            foreach (var invalidPassport in invalidPassports)
            {
                Assert.False(invalidPassport.IsValidStrict);
            }

            foreach (var validPassport in validPassports)
            {
                Assert.True(validPassport.IsValidStrict);
            }
        }

        [Theory]
        [InlineData("1920", true)]
        [InlineData("2002", true)]
        [InlineData("1919", false)]
        [InlineData("2003", false)]
        public void IsValidBirthYear(string birthYear, bool expectedValidity)
        {
            //Arrange
            var passport = new Passport
            {
                BirthYear = birthYear
            };

            //Act
            var actualValidity = passport.IsValidBirthYear();

            //Assert
            Assert.Equal(expectedValidity, actualValidity);
        }

        [Theory]
        [InlineData("2010", true)]
        [InlineData("2020", true)]
        [InlineData("2009", false)]
        [InlineData("2021", false)]
        public void IsValidIssueYear(string issueYear, bool expectedValidity)
        {
            //Arrange
            var passport = new Passport
            {
                IssueYear = issueYear
            };

            //Act
            var actualValidity = passport.IsValidIssueYear();

            //Assert
            Assert.Equal(expectedValidity, actualValidity);
        }

        [Theory]
        [InlineData("2020", true)]
        [InlineData("2030", true)]
        [InlineData("2019", false)]
        [InlineData("2031", false)]
        public void IsValidExpirationYear(string expirationYear, bool expectedValidity)
        {
            //Arrange
            var passport = new Passport
            {
                ExpirationYear = expirationYear
            };

            //Act
            var actualValidity = passport.IsValidExpirationYear();

            //Assert
            Assert.Equal(expectedValidity, actualValidity);
        }

        [Theory]
        [InlineData("60in", true)]
        [InlineData("190cm", true)]
        [InlineData("190in", false)]
        [InlineData("190", false)]
        [InlineData("150cm", true)]
        [InlineData("193cm", true)]
        [InlineData("149cm", false)]
        [InlineData("194cm", false)]
        [InlineData("59in", true)]
        [InlineData("76in", true)]
        [InlineData("58in", false)]
        [InlineData("77in", false)]
        public void IsValidHeight(string height, bool expectedValidity)
        {
            //Arrange
            var passport = new Passport
            {
                Height = height
            };

            //Act
            var actualValidity = passport.IsValidHeight();

            //Assert
            Assert.Equal(expectedValidity, actualValidity);
        }

        [Theory]
        [InlineData("#123abc", true)]
        [InlineData("#12f3bc", true)]
        [InlineData("#12f3bc3", false)]
        [InlineData("#123abz", false)]
        [InlineData("123abc", false)]
        public void IsValidHairColor(string hairColor, bool expectedValidity)
        {
            //Arrange
            var passport = new Passport
            {
                HairColor = hairColor
            };

            //Act
            var actualValidity = passport.IsValidHairColor();

            //Assert
            Assert.Equal(expectedValidity, actualValidity);
        }

        [Theory]
        [InlineData("amb", true)]
        [InlineData("blu", true)]
        [InlineData("brn", true)]
        [InlineData("gry", true)]
        [InlineData("grn", true)]
        [InlineData("hzl", true)]
        [InlineData("oth", true)]
        [InlineData("wat", false)]
        [InlineData("blk", false)]
        public void IsValidEyeColor(string eyeColor, bool expectedValidity)
        {
            //Arrange
            var passport = new Passport
            {
                EyeColor = eyeColor
            };

            //Act
            var actualValidity = passport.IsValidEyeColor();

            //Assert
            Assert.Equal(expectedValidity, actualValidity);
        }

        [Theory]
        [InlineData("000000001", true)]
        [InlineData("0123456789", false)]
        public void IsValidPassportId(string passportid, bool expectedValidity)
        {
            //Arrange
            var passport = new Passport
            {
                PassportId = passportid
            };

            //Act
            var actualValidity = passport.IsValidPassportId();

            //Assert
            Assert.Equal(expectedValidity, actualValidity);
        }
    }
}
