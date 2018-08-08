using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using UnitTestProject1.Settings;

namespace UnitTestProject1.Pages
{
    class HomePage
    {
        public HomePage()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "product-name")]
        public IList<IWebElement> collProducts { get; set; }

        [FindsBy(How = How.LinkText, Using = "Quick view")]
        public IWebElement ViewProduct { get; set; }

        [FindsBy(How = How.LinkText, Using = "Sign in")]
        public IWebElement lnkSignIn { get; set; }

        public void selectProduct(string strProductName)
        {
            foreach (var Product in collProducts)
            {
                if (Product.GetAttribute("title") == strProductName)
                {
                    Product.Click();
                    break;
                }
            }
        }


        public QuickViewPage quickViewProduct(string strProductName)
        {
            foreach (var Product in collProducts)
            {
                if (Product.GetAttribute("title") == strProductName)
                {
                    Actions action = new Actions(PropertiesCollection.driver);
                    action.MoveToElement(Product).Perform();
                    break;
                }
            }
            Thread.Sleep(6000);
            WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(16));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Quick view")));
            ViewProduct.Click();
            return new QuickViewPage();
        }

        public MainSignInPage clickSignin()
        {
            lnkSignIn.Click();
            return new MainSignInPage();
        }
    }
}
