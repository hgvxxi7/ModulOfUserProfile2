using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulOfUserProfile2
{
    [TestFixture]
    // атрибут NUnita или указатель на тестовый сют
    public class EmptyClass
    //
    {
        //private object driver;

        // [Test] // атрибут nUnita указывающий на конкретный метод (функцию)
        //public void site_header_is_on_home_page() // тестовая функиця
        // {
        // IWebDriver browser = new ChromeDriver();
        //browser.Navigate().GoToUrl("http://olx.ua");
        //IWebElement button = browser.FindElement(By.CssSelector("#topLoginLink > span > strong"));
        //button.Click();
        //browser.Close();
        //}
        IWebDriver browser;

//------------------------------------------------------------------------------------------------
        [OneTimeSetUp]
        public void openBrowser()
        {
            browser = new ChromeDriver();
        }

//-----------------------------------------------------------------------------------------------

        [SetUp]
        public void goToURL()
        {
            browser.Navigate().GoToUrl("https://www.olx.ua/account/?ref%5B0%5D%5Baction%5D=myaccount&ref%5B0%5D%5Bmethod%5D=index");
        }

//-----------------------------------------------------------------------------------------------

        [Test] // атрибут nUnita указывающий на конкретный метод (функцию)
        public void registered_users_verifine() // тестовая функиця
        {

            IWebElement registrated_user_email = browser.FindElement(By.CssSelector("#userEmail"));
            registrated_user_email.SendKeys("hgvxxi7@gmail.com");

            IWebElement registrated_user_password = browser.FindElement(By.CssSelector("#userPass"));
            registrated_user_password.SendKeys("shvaiko1989");

            //IWebElement an_robot_confirmation = browser.FindElement(By.CssSelector("body > div.rc-anchor.rc-anchor-normal.rc-anchor-light > div.rc-anchor-content > div:nth-child(1) > div > div"));
            //an_robot_confirmation.Click();

            IWebElement registrated_user_sabmit = browser.FindElement(By.Id("se_userLogin"));
            registrated_user_sabmit.Click();

            IWebElement warningMassege = browser.FindElement(By.CssSelector("#loginForm > div > p"));

            Assert.True(warningMassege.Displayed);
        }

//-------------------------------------------------------------------------------------------------

        [Test]
        public void new_user_registration()
        {
            IWebDriver browser = new ChromeDriver();
            browser.Navigate().GoToUrl("https://www.olx.ua/account/?ref%5B0%5D%5Baction%5D=myaccount&ref%5B0%5D%5Bmethod%5D=index"); // url - как переменная???

            IWebElement click_registration_button = browser.FindElement(By.Id("register_tab"));
            click_registration_button.Click();

            IWebElement userEmailPhoneRegister = browser.FindElement(By.Id("userEmailPhoneRegister"));
            userEmailPhoneRegister.SendKeys("#!$%&’*+-/=?^_`{}|~@example.com");

            IWebElement user_password = browser.FindElement(By.Id("userPassRegister"));
            userEmailPhoneRegister.SendKeys("Abc123456");

            IWebElement accept_the_terms_of_use = browser.FindElement(By.CssSelector("#registerForm > div.login-form__checkbox > div > div > label.icon.f_checkbox.inlblk.vtop"));
            accept_the_terms_of_use.Click(); // - O_o CheckBox не ставится!!!

            IWebElement submit = browser.FindElement(By.Id("button_register"));
            submit.Click();

        }

//------------------------------------------------------------------------------------------------   

        [Test]
        
        public void email_confirmation()
        {
            /*List<string> l1;
            l1 = new List<string>();
            l1.Add("#!$%&’*+-/=?^_`{}|~@example.com");
            foreach (string ts in l1)
            {

            }
            */
            string [] emails;
            emails = new string [4];
            emails [0] = "#!$%&’*+-/=?^_`{}|~@example.com";
            emails [1] = "\"Abc\\@def\"@example.com";
            emails [2] = "\"Fred Bloggs\"@example.com";
            emails [3] = "\"Abc @def\"@example.com";

            for (int i = 0; i < emails.Length; i++)
            {

                IWebDriver browser = new ChromeDriver();
                browser.Navigate().GoToUrl("https://www.olx.ua/account/?ref%5B0%5D%5Baction%5D=myaccount&ref%5B0%5D%5Bmethod%5D=index"); // url - как переменная???

                IWebElement submit = browser.FindElement(By.Id("register_tab"));
                submit.Click();

                IWebElement userEmailPhoneRegister = browser.FindElement(By.Id("userEmailPhoneRegister"));
                userEmailPhoneRegister.SendKeys(emails[i]);

                //IWebElement warningMassege = browser.FindElement(By.CssSelector("#se_emailError > div > label"));

                //style="display: inline;"
                //style="display: none;"

                //Assert.False(warningMassege.Displayed); // Если валидатор не сработал то - ОК
            }
        }

//-------------------------------------------------------------------------------------------------

        [OneTimeTearDown]
        public void browserClose()
        {
            browser.Close();
        }
    }
}