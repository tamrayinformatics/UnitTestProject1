using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UnitTestProject1.Settings;

namespace UnitTestProject1.Pages
{
    class OrderPaymentPage
    {
        public OrderPaymentPage()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.PartialLinkText, Using = "Pay by bank wire")]
        public IWebElement btnPayBankWire { get; set; }

        public OrderConfirmationPage clickBankWirePayment()
        {
            btnPayBankWire.Click();
            return new OrderConfirmationPage();
        }
    }
}
