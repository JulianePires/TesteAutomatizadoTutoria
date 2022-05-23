using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TesteTutoria.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void NavegarParaPaginaDeCadastro()
        {
            // arrange
            IWebDriver driver = new ChromeDriver();

            // act
            driver.Navigate().GoToUrl("https://dev.tutor-ia.com/register");
            var buttonText = driver.FindElement(By.TagName("button")).Text;

            // assert
            Assert.Contains("Criar Conta", buttonText);
        }

        [Fact]
        public void ImpedirCadastroComNomeVazio()
        {

        }
    }
}