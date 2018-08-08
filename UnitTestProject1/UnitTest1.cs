using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UnitTestProject1.Pages;
using UnitTestProject1.Settings;

namespace UnitTestProject1
{
    [TestFixture]

    public class UnitTest1
    {
        string url = "http://automationpractice.com";
        string strEmailAddress = "mudassir@intBJSS.com";
        string strPassword = "BJSSTest";

        [OneTimeSetUp]
        
        public void SettingUpReport()
        {
            Reporting.SetupReporting();
        }

        [SetUp]
        public void Initialize()
        {
            PropertiesCollection.driver = new ChromeDriver();
            PropertiesCollection.driver.Manage().Window.Maximize();
            PropertiesCollection.driver.Navigate().GoToUrl(url);
        }

        [Test, Order(1)]
        public void OrderingItems()
        {
            //Landing Home Page for Automation Practice
            HomePage pgHome = new HomePage();

            //Click on Quick view on Home Page for first item returns the QuickView Page
            QuickViewPage pgQuickView = pgHome.quickViewProduct("Faded Short Sleeve T-shirts");
            pgQuickView.selectSize("M"); //Selecting size as M on QuickView Page

            //Clicking on Add to Basket returns the Checkout Page
            CheckoutPage pgCheckout = pgQuickView.clickAddtoCart();
            PropertiesCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(16); //wait for the checkout window to appear
            string item1ProdPrice = pgCheckout.GetProdPrice(); //returning price of first product
            string item1ShipPrice = pgCheckout.GetProdShipPrice(); //returning shipping price of first product
            string item1TotalPrice = pgCheckout.GetProdCartTotal(); //returning total price of first product

            //Clicking on Continue Shopping returns to HomePPage
            pgHome = pgCheckout.clickContinueShopping();

            //Click on Quick view on Home Page for second item returns the QuickView Page
            pgQuickView = pgHome.quickViewProduct("Blouse");
            pgQuickView.selectSize("S"); //Selecting default on QuickView Page

            //Clicking on Add to Basket returns the Checkout Page
            pgCheckout = pgQuickView.clickAddtoCart();
            string item2ProdPrice = pgCheckout.GetProdPrice(); //returning price of second product
            string item2ShipPrice = pgCheckout.GetProdShipPrice(); //returning shipping price of second product
            string item2TotalPrice = pgCheckout.GetProdCartTotal(); //returning total price of second product

            //Clicking on Proceed to checkout returns Order Summary Window
            OrderSummaryPage pgOrderSummary = pgCheckout.clickProceedtoCheckout();
            string strItem1Size = pgOrderSummary.getItemSize("Faded Short Sleeve T-shirts"); //returning size of first item product

            Reporting.AssertTrue("M", strItem1Size, "OrderingItems", "Verify Size");

            string strItem1Price = pgOrderSummary.getItemPrice("Faded Short Sleeve T-shirts"); //returning price of first product from order page

            Reporting.AssertTrue(item1ProdPrice, strItem1Price, "OrderingItems", "Verify first item price");

            string strItem2Price = pgOrderSummary.getItemPrice("Blouse"); //returning price of second product from order page

            Reporting.AssertTrue(item2ProdPrice, strItem2Price, "OrderingItems", "Verify second item price");

            string strTotalProductPrice = pgOrderSummary.getTotalProduct();//returning price of both product from order page
            string strTotalShippingPrice = pgOrderSummary.getShipping(); //returning price of shipping for product from order page
            string strTotalAmount = pgOrderSummary.getTotalAmount(); //returning price of shipping and both product from order page

            //Clicking on Proceed to Checkout returns Sign In Window
            OrderSignInPage pgSignin = pgOrderSummary.clickProceedToCheckout();

            //Signining in the applicatin return Address  confirmation window
            OrderAddressPage pgAddress = pgSignin.SignIn(strEmailAddress, strPassword);

            //Clicking on Proceed to Checkout returns Shipping In Window
            OrderShippingPage pgShipping = pgAddress.clickProceedToCheckout();

            //Clicking on Proceed to Checkout returns Payment Window
            OrderPaymentPage pgPayment = pgShipping.clickProceedtoCheckout();

            //Select Payment Type as Wire returns confirmation Window
            OrderConfirmationPage pgConfirmation = pgPayment.clickBankWirePayment();
            pgConfirmation.clickConfirmOrder(); //Confirming Paying

            }

        [Test, Order(2)]
        public void AddCommentToOrder()
        {
            //Landing Home Page for Automation Practice
            HomePage pgHome = new HomePage();

            //Clicking on SignIn button on HomePage returns SignIn Page
            MainSignInPage pgSignInMain = pgHome.clickSignin();

            //Signing in with username and password returns Account Details page
            AccountDetailPage pgAccountDetail = pgSignInMain.SignIn(strEmailAddress, strPassword);

            //Clicking on Order History Returns Order History Page
            OrderHistoryPage pgOrderHistory = pgAccountDetail.clickOrderHistory();

            //Selecting most recent order and adding a message
            string strLatestMessage = pgOrderHistory.AddMessage("Please update the order");

            Reporting.AssertTrue("Please update the order", strLatestMessage, "AddCommentToOrder", "Verify comments are updated");

        }

        [Test, Order(3)]
        public void VerifyColourOfOrder()
        {

            //Landing Home Page for Automation Practice
            HomePage pgHome = new HomePage();

            //Clicking on SignIn button on HomePage returns SignIn Page
            MainSignInPage pgSignInMain = pgHome.clickSignin();

            //Signing in with username and password returns Account Details page
            AccountDetailPage pgAccountDetail = pgSignInMain.SignIn(strEmailAddress, strPassword);

            //Clicking on Order History Returns Order History Page
            OrderHistoryPage pgOrderHistory = pgAccountDetail.clickOrderHistory();

            //Returning the colour
            string strItemColour = pgOrderHistory.GettingColourofOrder();

            Reporting.AssertTrue("Red", strItemColour, "VerifyColourOfOrder", "Colour is Red");
        }

       [TearDown]
        
        public void CloseBrowser()
        {
            PropertiesCollection.driver.FindElement(By.LinkText("Sign out"));
            PropertiesCollection.driver.Close();
        }

        [OneTimeTearDown]
        public void ReportGeneration()
        {
            Reporting.GenerateReport();
        }
    }
}
