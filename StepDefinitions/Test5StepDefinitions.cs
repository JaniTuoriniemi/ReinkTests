using CalculatorSelenium.Specs.Drivers;
using CalculatorSelenium.Specs.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class Test5StepDefinitions
    {
        public string browsertype;
        public string filledSwishPaymentReference;
        public string password;
        public string phonenumber;
        // These are the parameters to be filled into the hidden test form
        public string amount;
        public string startPage;
        public string bookID;
        public string averagePrice;
        public string averagePricePlusExtra;
        public string paymentReference;
        public string bookQRcode;
        public CalculatorPageObject _calculatorPageObject;


        public Test5StepDefinitions(BrowserDriverEdge browserDriverEdge)
       // public Test5StepDefinitions(BrowserDriver browserDriver)
       // public Test5StepDefinitions(BrowserDriverMozilla browserDriverMozilla)
        {
            //_calculatorPageObject = new CalculatorPageObject(browserDriver.Current);
          //  _calculatorPageObject = new CalculatorPageObject(browserDriverMozilla.Current);
            _calculatorPageObject = new CalculatorPageObject(browserDriverEdge.Current);
            //  browsertype = "chrome";
            browsertype = "mozilla";
            startPage = _calculatorPageObject.GiveStart();
            password = "Koopa11Kiipa";//User password
            phonenumber = "730622401";//User phone
            bookQRcode = "79B113F8-DA26-43F6-800C-F17C731F02AF";
            amount = "1";
            bookID = "033b655c-33cf-4175-b3f0-08db638c642c"; //The book QR code number  
            averagePrice = "1";
            averagePricePlusExtra = "1";
            paymentReference = "3AF9E317B9E54B5ABF481F85E8A96D45";//Probably should be the user GUID?
            filledSwishPaymentReference = "";
        }
        [Given(@"The user scans the book QR code")]
        public void GivenTheUserScansTheBookQRCode()
        {
            _calculatorPageObject.GotoPage8(bookID); ;
            _calculatorPageObject.ClickNästaButton();
        }

        [When(@"The user clicks nästa and logs in with his credentials")]
        public void WhenTheUserClicksNastaAndLogsInWithHisCredentials()
        {
            _calculatorPageObject.StatePhoneNumber(phonenumber);
            _calculatorPageObject.StatePassWord(password);
            _calculatorPageObject.ClickLoginButton();
        }

        [Then(@"The user is redirected to the book is not available page")]
        public void ThenTheUserIsRedirectedToTheBookIsNotAvailablePage()
        {
            string desired_page = $"{startPage}/book/unavailave-book?Id=" + bookID;
            string actualResult = _calculatorPageObject.CurrentURL();
            actualResult.Should().Be(desired_page);
        }
    }
}
