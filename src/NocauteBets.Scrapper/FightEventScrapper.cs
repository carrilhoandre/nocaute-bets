using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NocauteBets.Domain.Models;

namespace NocauteBets.Scrapper
{
    public static class FightEventScrapper
    {
        public static void Scrap()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            using (IWebDriver driver = new ChromeDriver(options))
            {
                driver.Navigate().GoToUrl("https://www.ufc.com.br/event/ufc-fight-night-august-12-2023");

                var statElements = driver.FindElements(By.ClassName("c-listing-fight__content-row"));

                for (int i = 0; i < statElements.Count; i++)
                {

                    var fightDetails = statElements[i].FindElement(By.ClassName("c-listing-fight__details"));
                    var category = fightDetails.FindElement(By.ClassName("c-listing-fight__class-text")).GetAttribute("innerText").Replace("Luta ", "");
                    var redCorner = statElements[i].FindElement(By.ClassName("c-listing-fight__corner-name--red"));
                    var blueCorner = statElements[i].FindElement(By.ClassName("c-listing-fight__corner-name--blue"));

                    var redNameElement = redCorner.FindElement(By.TagName("a"));
                    string redName = redNameElement.Text;
                    string redHref = redNameElement.GetAttribute("href");

                    var blueNameElement = blueCorner.FindElement(By.TagName("a"));
                    string blueName = blueNameElement.Text;
                    string blueHref = blueNameElement.GetAttribute("href");

                    Console.WriteLine($"Category: {category} Red: {redName} X Blue: {blueName}");

                }
            }
        }
    }
}
