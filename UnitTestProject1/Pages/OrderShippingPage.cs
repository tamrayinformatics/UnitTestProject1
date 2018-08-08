using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UnitTestProject1.Settings;

namespace UnitTestProject1.Pages
{
    class OrderShippingPage
    {
        public OrderShippingPage()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.Name, Using = "cgv")]
        public IWebElement chkTermsCond { get; set; }

        [FindsBy(How = How.Name, Using = "processCarrier")]
        public IWebElement btnProceedtoCheckout { get; set; }

        public OrderPaymentPage clickProceedtoCheckout()
        {
            chkTermsCond.Click();
            btnProceedtoCheckout.Click();
            return new OrderPaymentPage();
        }
    }
}
