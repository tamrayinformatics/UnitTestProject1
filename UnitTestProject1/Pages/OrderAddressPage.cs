using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UnitTestProject1.Settings;

namespace UnitTestProject1.Pages
{
    class OrderAddressPage
    {
        public OrderAddressPage()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.Name, Using = "processAddress")]
        public IWebElement btnProceedtoCheckout { get; set; }

        public OrderShippingPage clickProceedToCheckout()
        {
            btnProceedtoCheckout.Click();
            return new OrderShippingPage();
        }
    }
}
