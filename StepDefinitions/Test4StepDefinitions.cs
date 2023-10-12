using CalculatorSelenium.Specs.Drivers;
using CalculatorSelenium.Specs.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
   
        [Binding]
    public class Test4StepDefinitions
    {
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
        public Test4StepDefinitions(BrowserDriverEdge browserDriverEdge)
        // public Test4StepDefinitions(BrowserDriver browserDriver)
       // public Test4StepDefinitions(BrowserDriverMozilla browserDriverMozilla)
        { 
        _calculatorPageObject = new CalculatorPageObject(browserDriverEdge.Current);
        //_calculatorPageObject = new CalculatorPageObject(browserDriver.Current);
        //_calculatorPageObject = new CalculatorPageObject(browserDriverMozilla.Current);
            startPage = _calculatorPageObject.GiveStart();
            password = "Koopa11Kiipa";//User password
            phonenumber = "730727581";//User phone
            bookQRcode = "79B113F8-DA26-43F6-800C-F17C731F02AF";
            amount = "1";
            bookID = "033b655c-33cf-4175-b3f0-08db638c642c"; //The book QR code number  
            averagePrice = "1";
            averagePricePlusExtra = "1";
            paymentReference = "3AF9E317B9E54B5ABF481F85E8A96D45";//Probably should be the user GUID?
            filledSwishPaymentReference = "";
        }
            [Given(@"The user scans the book and login screen appears")]
            
        public void GivenTheUserScansTheBookAndLoginScreenAppears()
        {
            _calculatorPageObject.GotoPage8(bookID); ;
            _calculatorPageObject.ClickNästaButton();
            
        }

        [When(@"User creates an new account")]
        public void WhenUserCreatesAnNewAccount()
        {
            _calculatorPageObject.ClickIngetKonto();
            _calculatorPageObject.StatePhoneNumber(phonenumber);
            _calculatorPageObject.ClickCheckbox();
            _calculatorPageObject.ClickVerifiera1();
            _calculatorPageObject.StateVerificationCode();
            _calculatorPageObject.ClickVerifiera2();
            _calculatorPageObject.CreatePassWord(password);
            _calculatorPageObject.ClickSavepassword();
        }

        [Then(@"The boken är redan upptagen screen should appear")]
        public void ThenTheBokenArRedanUpptagenScreenShouldAppear()
        {      //user is directed to the my account
            _calculatorPageObject.GotoPage8(bookID); ;
            _calculatorPageObject.ClickNästaButton();
            string desired_page = $"{startPage}/book/unavailave-book?Id="+bookID;
            string actualResult = _calculatorPageObject.CurrentURL();
            actualResult.Should().Be(desired_page);
        }
    }
}
