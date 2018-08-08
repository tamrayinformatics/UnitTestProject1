using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UnitTestProject1.Settings;

namespace UnitTestProject1.Pages
{
    class AccountDetailPage
    {
        public AccountDetailPage()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//a[contains(@title,'Orders')]")]
        public IWebElement btnOrderHistory { get; set; }

        public OrderHistoryPage clickOrderHistory()
        {
            //Thread.Sleep(10000);
            btnOrderHistory.Click();
            return new OrderHistoryPage();
        }
    }
}
