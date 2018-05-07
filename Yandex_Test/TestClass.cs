using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;


namespace Yandex_Test
{
    [TestFixture]
    public class TestClass
    {
        private static IWebDriver driver;
        private static String login = "kirukato203@yandex.ru";
        private static String password = "Rjcnz35610";
       

           [OneTimeSetUp] // вызывается перед началом запуска всех тестов
        public void OneTimeSetUp()
        {
            
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Url = "https://yandex.ru";


        }

        [OneTimeTearDown] //вызывается после завершения всех тестов
        public void OneTimeTearDown()
        {
            driver.Quit();
        }


        [Test]
        public void TEST_1_LogIn()
        {
            IWebElement sendButton1 = driver.FindElement(By.LinkText("Войти в почту"));
            sendButton1.Click();
           
            

            IWebElement loginField = driver.FindElement(By.Name("login"));
            loginField.SendKeys(login);

            IWebElement passwordField = driver.FindElement(By.Name("passwd"));
            passwordField.SendKeys(password);

            IWebElement sendButton2 = driver.FindElement(By.ClassName("passport-Button-Text"));
            sendButton2.Click();

            IWebElement Login = driver.FindElement(By.XPath("//div[@class='mail-User-Name']"));
            String LoginActual = Login.Text;
            Assert.AreEqual("kirukato203", LoginActual);
        }

     


        [Test]
        public void TEST_2_LogOut()
        {
            IWebElement sendButton3 = driver.FindElement(By.ClassName("mail-User-Name"));
            sendButton3.Click();

            IWebElement sendButton_Exit = driver.FindElement(By.LinkText("Выйти из сервисов Яндекса"));
            sendButton_Exit.Click();

            IWebElement buttonEntrance = driver.FindElement(By.LinkText("Войти в почту"));
            String buttonTextActual = buttonEntrance.Text;
            Assert.AreEqual("Войти в почту", buttonTextActual);
        }
    }
}
    