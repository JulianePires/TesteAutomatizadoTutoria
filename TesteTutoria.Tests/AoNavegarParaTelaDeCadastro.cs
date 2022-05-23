using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TesteTutoria.Tests
{
    public class AoNavegarParaTelaDeCadastro
    {
        [Fact]
        public void DeveConterBotaoComTextoCriarConta()
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
        public void DeveImpedirCadastroComNomeVazio()
        {

        }
    }
}