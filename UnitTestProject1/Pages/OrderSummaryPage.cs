using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using UnitTestProject1.Settings;

namespace UnitTestProject1.Pages
{
    class OrderSummaryPage
    {
        public OrderSummaryPage()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }
        public string strItemSize, strItemPrice;

        [FindsBy(How = How.TagName, Using = "tbody")]
        public IWebElement tableBody { get; set; }

        [FindsBy(How = How.Id, Using = "total_product")]
        public IWebElement totalProductPrice { get; set; }

        [FindsBy(How = How.Id, Using = "total_shipping")]
        public IWebElement totalShipping { get; set; }

        [FindsBy(How = How.Id, Using = "total_price")]
        public IWebElement totalPriceandShipping { get; set; }

        [FindsBy(How = How.LinkText, Using = "Proceed to checkout")]
        public IWebElement btnProceedtoCheckout { get; set; }

        public string getItemSize(string strProductName)
        {
            
            IList<IWebElement> tableRow = tableBody.FindElements(By.TagName("tr"));
            IList<IWebElement> rowTD;
            foreach (var row in tableRow)
            {
                rowTD = row.FindElements(By.TagName("td"));
                IWebElement productName = rowTD[1].FindElement(By.ClassName("product-name"));

                if (Equals(productName.Text, strProductName))
                {
                    IList<IWebElement> productDetail = rowTD[1].FindElements(By.TagName("small"));
                    strItemSize = productDetail[1].Text.Substring(productDetail[1].Text.Length - 1, 1);
                    
                } ;
                
            }
            return strItemSize;
        }


        public string getItemPrice(string strProductName)
        {

            IList<IWebElement> tableRow = tableBody.FindElements(By.TagName("tr"));
            IList<IWebElement> rowTD;
            foreach (var row in tableRow)
            {
                rowTD = row.FindElements(By.TagName("td"));
                IWebElement productName = rowTD[1].FindElement(By.ClassName("product-name"));

                if (Equals(productName.Text, strProductName))
                {
                    IWebElement productDetail = rowTD[3].FindElement(By.ClassName("price"));
                    strItemPrice = productDetail.Text;

                };

            }
            return strItemPrice;
        }

        public string getTotalProduct()
        {
            return totalProductPrice.Text;
        }

        public string getShipping()
        {

            return totalShipping.Text;
        }


        public string getTotalAmount()
        {

            return totalPriceandShipping.Text;
        }

        public OrderSignInPage clickProceedToCheckout()
        {
            btnProceedtoCheckout.Click();
            return new OrderSignInPage();
        }

    }
}
