using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace TesteTutoria.Tests.Fixture
{
    public class TestFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        //Setup
        public TestFixture()
        {
            Driver = new ChromeDriver();
        } 

        //TearDown
        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
