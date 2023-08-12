using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NocauteBets.Scrapper
{
    public static class FighterStatisticsScrapper
    {
        public static void Scrap()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            int winsByKnockout = 0, winsBySubmission = 0, firstRoundWins = 0;
            using (IWebDriver driver = new ChromeDriver(options))
            {
                // Navega para a página do lutador
                driver.Navigate().GoToUrl("https://www.ufc.com.br/athlete/gunnar-nelson");

                var statElements = driver.FindElements(By.ClassName("athlete-stats__stat-text"));
                var statValueElements = driver.FindElements(By.ClassName("athlete-stats__stat-numb"));

                for (int i = 0; i < statElements.Count; i++)
                {
                    string statText = statElements[i].Text;
                    string statValueText = statValueElements[i].Text;

                    if (string.IsNullOrEmpty(statText) || string.IsNullOrEmpty(statValueText))
                        continue;

                    if (statText.ToUpper().Contains("KNOCKOUT"))
                        winsByKnockout = int.Parse(new string(statValueText.Where(char.IsDigit).ToArray()));

                    if (statText.ToUpper().Contains("SUBMISSION"))
                        winsBySubmission = int.Parse(new string(statValueText.Where(char.IsDigit).ToArray()));

                    if (statText.ToUpper().Contains("FIRST ROUND"))
                        firstRoundWins = int.Parse(new string(statValueText.Where(char.IsDigit).ToArray()));

                }
            }

            Console.WriteLine($"{winsByKnockout} {winsBySubmission} {firstRoundWins}");
        }
    }
}
