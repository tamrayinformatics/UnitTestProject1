using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using UnitTestProject1.Settings;

namespace UnitTestProject1.Pages
{
    class CheckoutPage
    {
        public CheckoutPage()
        {
             PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//span[contains(@title,'Continue shopping')]")]
        public IWebElement btnContinueShopping { get; set; }

        [FindsBy(How = How.XPath, Using = ".//a[contains(@title,'Proceed to checkout')]")]
        public IWebElement btnProceedtoCheckout { get; set; }

        [FindsBy(How = How.ClassName, Using = "ajax_block_products_total")]
        public IWebElement txtProdPrice { get; set; }

        [FindsBy(How = How.ClassName, Using = "ajax_cart_shipping_cost")]
        public IWebElement txtShipPrice { get; set; }

        [FindsBy(How = How.ClassName, Using = "ajax_block_cart_total")]
        public IWebElement txtCartTotal { get; set; }

        public HomePage clickContinueShopping()
        {
            btnContinueShopping.Click();
            return new HomePage();
        }

        public OrderSummaryPage clickProceedtoCheckout()
        {
            WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(16));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(".//a[contains(@title,'Proceed to checkout')]")));
            btnProceedtoCheckout.Click();
            return new OrderSummaryPage();
        }

        public string GetProdPrice()
        {
            return txtProdPrice.Text;
        }

        public string GetProdShipPrice()
        {
            return txtShipPrice.Text;
        }
        public string GetProdCartTotal()
        {
            return txtCartTotal.Text;
        }
    }
}
