using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TesteTutoria.Tests.Helpers;
using System;

namespace TesteTutoria.Tests
{
    public class AoNavegarParaTelaDeCadastro : IDisposable
    {
        private readonly IWebDriver driver;

        public AoNavegarParaTelaDeCadastro()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(TestHelpers.UrlPaginaCadastro);
        }

        public void Dispose()
        {
            driver.Quit();
        }

        [Fact]
        public void DadoOChromeAbertoDeveConterBotaoComTextoCriarConta()
        {
         
            var buttonText = driver.FindElement(By.TagName("button")).Text;

            // assert
            Assert.Contains("Criar Conta", buttonText);
        }

        [Fact]
        public void DadoOChromeAbertoDeveImpedirCadastroComNomeVazio()
        {

        }
    }
}