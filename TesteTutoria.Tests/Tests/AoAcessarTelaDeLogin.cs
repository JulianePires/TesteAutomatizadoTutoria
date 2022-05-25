using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TesteTutoria.Tests.Fixture;
using TesteTutoria.Tests.Helpers;
using Xunit;

namespace TesteTutoria.Tests.Tests
{
    [Collection("Chrome Driver")]
    public class AoAcessarTelaDeLogin
    {
        private IWebDriver driver;

        public AoAcessarTelaDeLogin(TestFixture fixture)
        {
            driver = fixture.Driver;
            var nav = driver.Navigate();
            nav.GoToUrl(TestHelpers.UrlPaginaLogin);
        }

        [Fact]
        public void DadoOChromeAbertoDeveConterBotaoComTextoEntrar()
        {
            var textoBotaoCriarConta = driver.FindElement(By.TagName("button")).Text;

            Thread.Sleep(1000);
            // assert
            Assert.Contains("Entrar", textoBotaoCriarConta);
        }


        [Theory]
        [InlineData("", "123@teste")]
        [InlineData("teste@ufrpe.br", "123@teste")]
        public void DadoOChromeAbertoDeveImpedirLoginComInformacoesAusentes(
               string email,
               string senha
            )
        {
            // arrange
            var emailInput = driver.FindElement(By.Name("username"));
            var senhaInput = driver.FindElement(By.Name("password"));

            // act
            emailInput.SendKeys(email);
            senhaInput.SendKeys(senha);

            Actions actions = new Actions(driver);

            actions.KeyDown(Keys.Enter);
            actions.Perform();

            Thread.Sleep(2000);

            // assert
            Assert.Contains("Entrar", driver.PageSource);
        }

        [Fact]
        public void DadoOChromeAbertoDeveMostrarErroSeUsuarioNaoExiste()
        {
            // arrange
            var emailInput = driver.FindElement(By.Name("username"));
            var senhaInput = driver.FindElement(By.Name("password"));

            var email = "alguem@urfpe.br";
            var password = "123@teste";

            // act
            emailInput.SendKeys(email);
            senhaInput.SendKeys(password);

            Actions actions = new Actions(driver);

            actions.KeyDown(Keys.Enter);
            actions.Perform();

            Thread.Sleep(2000);

            // assert
            Assert.Contains("Unable to log in with provided credentials.", driver.PageSource);
        }

        [Fact]
        public void DadoOChromeAbertoDeveRedirecionarParaPáginaInicialAoLogarComSucesso()
        {
            // arrange
            var emailInput = driver.FindElement(By.Name("username"));
            var senhaInput = driver.FindElement(By.Name("password"));

            var email = "testesoftwaretutoria@gmail.com";
            var password = "parceirademaely";

            // act
            emailInput.SendKeys(email);
            senhaInput.SendKeys(password);

            Actions actions = new Actions(driver);

            actions.KeyDown(Keys.Enter);
            actions.Perform();

            Thread.Sleep(5000);

            // assert
            Assert.Contains("Minha conta", driver.PageSource);
        }
    }
}
