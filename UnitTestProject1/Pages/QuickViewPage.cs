using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using UnitTestProject1.Settings;

namespace UnitTestProject1.Pages
{
    class QuickViewPage
    {
        public QuickViewPage()
        {
			PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.Id, Using = "group_1")]
        public IWebElement ddlSize { get; set; }

        [FindsBy(How = How.Name, Using = "Submit")]
        public IWebElement btnAddtocart { get; set; }

        public void selectSize(string strSize)
        {
            PropertiesCollection.driver.SwitchTo().Frame(4);
            var selectSize = new SelectElement(ddlSize);
            selectSize.SelectByText(strSize);
        }

        public CheckoutPage clickAddtoCart()
        {
            //PropertiesCollection.driver.SwitchTo().Frame(4);
            btnAddtocart.Click();
            PropertiesCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(16); //wait for the checkout window to appear
            return new CheckoutPage();
        }
    }
}
