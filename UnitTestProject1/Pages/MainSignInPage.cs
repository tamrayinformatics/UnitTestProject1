using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UnitTestProject1.Settings;

namespace UnitTestProject1.Pages
{
    class MainSignInPage
    {
        public MainSignInPage()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement txtEmailAddress { get; set; }

        [FindsBy(How = How.Id, Using = "passwd")]
        public IWebElement txtPassword { get; set; }

        [FindsBy(How = How.Id, Using = "SubmitLogin")]
        public IWebElement btnSignIn { get; set; }

        public AccountDetailPage SignIn(string strEmail, string strPassword)
        {
            txtEmailAddress.SendKeys(strEmail);
            txtPassword.SendKeys(strPassword);
            btnSignIn.Click();
            return new AccountDetailPage();
        }
    }
}
