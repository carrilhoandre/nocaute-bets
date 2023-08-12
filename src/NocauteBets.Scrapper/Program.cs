// See https://aka.ms/new-console-template for more information
using NocauteBets.Domain.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.Json;

Console.WriteLine("Hello, World!");



var options = new ChromeOptions();
options.AddArgument("--headless");
IWebDriver driver = new ChromeDriver(options);
var pageNumber = 1;
var finish = false;
var fighters = new List<Fighter>();
try
{
    do
    {
        string url = $"https://www.ufc.com.br/athletes/all?gender=1&search=&filters%5B0%5D=status%3A23&page={pageNumber}";
        driver.Navigate().GoToUrl(url);
        System.Threading.Thread.Sleep(2000);

        var fighterElements = driver.FindElements(By.CssSelector(".l-flex__item"));

        if(fighterElements == null || !fighterElements.Any())
        {
            finish = true;
        }

        foreach (var fighterElement in fighterElements)
        {
            try
            {
                var thumbnailElement = fighterElement.FindElement(By.CssSelector(".c-listing-athlete__thumbnail img"));
                var nicknameElement = fighterElement.FindElement(By.CssSelector(".c-listing-athlete__nickname"));
                var nameElement = fighterElement.FindElement(By.CssSelector(".c-listing-athlete__name"));
                var categoryElement = fighterElement.FindElement(By.CssSelector(".c-listing-athlete__title .field__item"));
                var cartelElement = fighterElement.FindElement(By.CssSelector(".c-listing-athlete__record"));

                string thumbnailUrl = thumbnailElement.GetAttribute("src");
                string nickname = nicknameElement.Text.Trim();
                string name = nameElement.Text.Trim();
                string category = categoryElement.Text.Trim();
                string cartel = cartelElement.Text.Trim();


                fighters.Add(new Fighter(name, nickname, thumbnailUrl, cartel, category));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        pageNumber++;
    }
    while (!finish);

    var jsonString = JsonSerializer.Serialize(fighters);
    System.IO.File.WriteAllText(@"C:\Users\Andre\dev\output\fighters.json", jsonString);
}
catch (Exception ex)
{
    Console.WriteLine("Ocorreu um erro: " + ex.Message);
}
finally
{
    driver.Quit();
}