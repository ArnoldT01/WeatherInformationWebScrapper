using HtmlAgilityPack;

namespace WeatherInformationWebScrapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Send get request to weather.com
            string url = "https://weather.com/en-ZA/weather/today/l/2a4a3941719942132f9ed4f71b5feadec34a454fbf3b03789def2d719b4b2e92";
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result;
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            // Get the location
            var cityElement = htmlDocument.DocumentNode.SelectSingleNode("//h1[@class='CurrentConditions--location--1YWj_']");
            var city = cityElement.InnerText.Trim();
            Console.WriteLine(city);

            // Get the temperature
            var temperatureElement = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='CurrentConditions--tempValue--MHmYY']");
            var temperature = temperatureElement.InnerText.Trim();
            Console.WriteLine(temperature);

            // Get the conditions
            var conditionElement = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='CurrentConditions--phraseValue--mZC_p']");
            var condition = conditionElement.InnerText.Trim();
            Console.WriteLine(condition);
        }
    }
}