using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using UnitTestProject1.Settings;

namespace UnitTestProject1.Pages
{
    class OrderConfirmationPage
    {
        public OrderConfirmationPage()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.TagName, Using = "button")]
        public IList<IWebElement> btnConfirmOrder { get; set; }

        public void clickConfirmOrder()
        {
            btnConfirmOrder[1].Click();
        }
    }
}
