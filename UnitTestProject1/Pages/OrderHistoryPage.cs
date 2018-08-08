using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnitTestProject1.Settings;

namespace UnitTestProject1.Pages
{
    class OrderHistoryPage
    {
        public OrderHistoryPage()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.PartialLinkText, Using = "Details")]
        public IList<IWebElement> btnHistoryDetails { get; set; }

        [FindsBy(How = How.Name, Using = "id_product")]
        public IWebElement ddlProduct { get; set; }

        [FindsBy(How = How.Name, Using = "msgText")]
        public IWebElement txtMessageBox { get; set; }

        [FindsBy(How = How.XPath, Using = ".//button[contains(@name,'submitMessage')]")]
        public IWebElement btnSend { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#order-detail-content > table.table.table-bordered > tbody > tr.item > td.bold")]
        public IWebElement firstItemDetails { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='block-order-detail']/div[5]/table/tbody/tr/td[2]")]
        public IWebElement latestMessage { get; set; }

        public string strItemColour;

        public string AddMessage(string strMessage)
        {
            btnHistoryDetails[0].Click();
            PropertiesCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //wait for the checkout window to appear
            var selectProduct = new SelectElement(ddlProduct);
            selectProduct.SelectByIndex(1);
            txtMessageBox.SendKeys(strMessage);
            PropertiesCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //wait for the checkout window to appear
            btnSend.Click();
            return latestMessage.Text;
        }

        public string GettingColourofOrder()
        {
            btnHistoryDetails[0].Click();
            PropertiesCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //wait for the checkout window to appear
            string[] words = Regex.Split(firstItemDetails.Text, "Color : ");
            string[] iTemColor = Regex.Split(words[1], ",");
            return iTemColor[0];


        }
    }
}
