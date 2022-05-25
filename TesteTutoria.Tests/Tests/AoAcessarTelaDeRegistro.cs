using Xunit;
using OpenQA.Selenium;
using TesteTutoria.Tests.Helpers;
using TesteTutoria.Tests.Fixture;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace TesteTutoria.Tests
{
    [Collection("Chrome Driver")]
    public class AoAcessarTelaDeRegistro
    {
        private IWebDriver driver;

        public AoAcessarTelaDeRegistro(TestFixture fixture)
        {
            driver = fixture.Driver;
            var nav = driver.Navigate();
            nav.GoToUrl(TestHelpers.UrlPaginaRegistro);
        }

        [Fact]
        public void DadoOChromeAbertoDeveConterBotaoComTextoCriarConta()
        {
            var textoBotaoCriarConta = driver.FindElement(By.TagName("button")).Text;

            Thread.Sleep(1000);
            // assert
            Assert.Contains("Criar Conta", textoBotaoCriarConta);
        }

        [Theory]
        [InlineData("", "UFRPE", "teste@ufrpe.br", "123@teste", "123@teste")]
        [InlineData("Jon Doe", "", "teste@ufrpe.br", "123@teste", "123@teste")]
        [InlineData("Jon Doe", "UFRPE", "", "123@teste", "123@teste")]
        [InlineData("Jon Doe", "UFRPE", "teste@ufrpe.br", "", "123@teste")]
        [InlineData("Jon Doe", "UFRPE", "teste@ufrpe.br", "123@teste", "12@teste")]
        public void DadoOChromeAbertoDeveImpedirCadastroComInformacoesIncorretas(
               string nome,
               string instituicao,
               string email,
               string senha,
               string confirmacaoSenha
            )
        {
            // arrange
            var nomeInput = driver.FindElement(By.Name("name"));
            var instituicaoInput = driver.FindElement(By.Name("university"));
            var emailInput = driver.FindElement(By.Name("email"));
            var senhaInput = driver.FindElement(By.Name("password"));
            var confirmacaoSenhaInput = driver.FindElement(By.Name("passwordConfirm"));

            // act
            nomeInput.SendKeys(nome);
            instituicaoInput.SendKeys(instituicao);
            emailInput.SendKeys(email);
            senhaInput.SendKeys(senha);
            confirmacaoSenhaInput.SendKeys(confirmacaoSenha);

            Actions actions = new Actions(driver);

            actions.KeyDown(Keys.Enter);
            actions.Perform();

            Thread.Sleep(2000);

            // assert
            Assert.Contains("Criar Conta", driver.PageSource);
        }

        [Fact]
        public void DadoOChromeAbertoDeveMostrarErroSeUsuarioJaExiste()
        {
            // arrange
            var nomeInput = driver.FindElement(By.Name("name"));
            var instituicaoInput = driver.FindElement(By.Name("university"));
            var emailInput = driver.FindElement(By.Name("email"));
            var senhaInput = driver.FindElement(By.Name("password"));
            var confirmacaoSenhaInput = driver.FindElement(By.Name("passwordConfirm"));

            var name = "John Doe";
            var university = "UFRPE";
            var email = "john.doe@urfpe.br";
            var password = "123@teste";
            var confirmPassword = "123@teste";

            // act
            nomeInput.SendKeys(name);
            instituicaoInput.SendKeys(university);
            emailInput.SendKeys(email);
            senhaInput.SendKeys(password);
            confirmacaoSenhaInput.SendKeys(confirmPassword);

            Actions actions = new Actions(driver);

            actions.KeyDown(Keys.Enter);
            actions.Perform();

            Thread.Sleep(2000);

            // assert
            Assert.Contains("Usuário já existe!", driver.PageSource);
        }

        [Fact]
        public void DadoOChromeAbertoDeveRedirecionarParaPáginaInicialAoRegistrarComSucesso()
        {
            // arrange
            var nomeInput = driver.FindElement(By.Name("name"));
            var instituicaoInput = driver.FindElement(By.Name("university"));
            var emailInput = driver.FindElement(By.Name("email"));
            var senhaInput = driver.FindElement(By.Name("password"));
            var confirmacaoSenhaInput = driver.FindElement(By.Name("passwordConfirm"));

            var name = "Alice";
            var university = "UFRPE";
            var email = "alice@urfpe.br";
            var password = "123@teste";
            var confirmPassword = "123@teste";

            // act
            nomeInput.SendKeys(name);
            instituicaoInput.SendKeys(university);
            emailInput.SendKeys(email);
            senhaInput.SendKeys(password);
            confirmacaoSenhaInput.SendKeys(confirmPassword);

            Actions actions = new Actions(driver);

            actions.KeyDown(Keys.Enter);
            actions.Perform();

            Thread.Sleep(5000);

            // assert
            Assert.Contains("Minha conta", driver.PageSource);
        }
    }
}