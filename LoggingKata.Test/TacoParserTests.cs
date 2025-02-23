using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        private ILog logger = new TacoLogger(); // initializing logger
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("33.635282, -86.684056, Taco Bell Birmingham", -86.684056)]
        [InlineData("32.608278, -85.489219, Taco Bell Auburn", -85.489219)]   
        //Add additional inline data. Refer to your CSV file.
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete the test with Arrange, Act, Assert steps below.
            //       Note: "line" string represents input data we will Parse 
            //       to extract the Longitude.  
            //       Each "line" from your .csv file
            //       represents a TacoBell location

            //Arrange
            var tacoParser = new TacoParser();
            logger.LogInfo($"Starting test: ShouldParseLongitude with input '{line}'");

            //Act
            var actual = tacoParser.Parse(line);

            //Assert
            Assert.NotNull(actual); //ensuring parsing does not return null
            Assert.Equal(expected, actual.Location.Longitude, precision: 5);
            logger.LogInfo($"Test passed: Expected {expected}, but was {actual.Location.Longitude}");
        }


        //TODO: Create a test called ShouldParseLatitude
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("33.635282, -86.684056, Taco Bell Birmingham...", 33.635282)]
        [InlineData("32.543810, -85.508580, Taco Bell Auburn...", 32.543810)]
        public void ShouldParseLatitude(string line, double expected)
        {
            // Arrange
            var tacoParser = new TacoParser();
            logger.LogInfo($"Starting test: ShouldParseLatitude with input '{line}'");

            // Act
            var actual = tacoParser.Parse(line);

            // Assert //Latitude instead of Longitude
            Assert.Equal(expected, actual.Location.Latitude, precision: 5);
            logger.LogInfo($"Test passed: Expected {expected}, but was {actual.Location.Latitude}");
        }

    }
}
