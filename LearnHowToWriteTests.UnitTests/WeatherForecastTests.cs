namespace LearnHowToWriteTests.UnitTests
{
    public class WeatherForecastTests
    {
        [Fact]
        public void Test1()
        {
            var temp = new WeatherForecast { TemperatureC = 10 };

            //check if temperature in fahrenheit is correct
            Assert.Equal(49, temp.TemperatureF);
        }
    }
}