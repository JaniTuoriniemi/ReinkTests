using CalculatorSelenium.Specs.Drivers;
using CalculatorSelenium.Specs.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class Test6StepDefinitions
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
        public Test6StepDefinitions(BrowserDriverEdge browserDriverEdge)
        // public Test6StepDefinitions(BrowserDriver browserDriver)
        //public Test6StepDefinitions(BrowserDriverMozilla browserDriverMozilla)
        {
            // _calculatorPageObject = new CalculatorPageObject(browserDriver.Current);
            //browsertype = "chrome";
            _calculatorPageObject = new CalculatorPageObject(browserDriverEdge.Current);
            //_calculatorPageObject = new CalculatorPageObject(browserDriverMozilla.Current);
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
        [Given(@"The user loggs in")]
        public void GivenTheUserLoggsIn()
        {
            _calculatorPageObject.GotoPage6(bookQRcode); _calculatorPageObject.ClickTa_emot();
            _calculatorPageObject.StatePhoneNumber(phonenumber);
            _calculatorPageObject.StatePassWord(password);
            _calculatorPageObject.ClickLoginButton();

        }

        [When(@"The user scans the QR code of the book")]
        public void WhenTheUserScansTheQRCodeOfTheBook()
        {//One has to click the nästa button to get to the book unavailable page
           _calculatorPageObject.GotoPage8(bookID);
            _calculatorPageObject.ClickNästaButton();
        }

        [Then(@"The user is directed to the book unavailable page")]
        public void ThenTheUserIsDirectedToTheBookUnavailablePage()
        {
            string desired_page = $"{startPage}/book/unavailave-book?Id=" + bookID;
            string actualResult = _calculatorPageObject.CurrentURL();
            actualResult.Should().Be(desired_page);
        }
    }
}
