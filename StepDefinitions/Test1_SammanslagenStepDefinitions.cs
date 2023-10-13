using CalculatorSelenium.Specs.Drivers;
using CalculatorSelenium.Specs.PageObjects;
using OpenQA.Selenium.DevTools;
using System;
using System.Text;
using System.IO;
using TechTalk.SpecFlow;
using static System.Net.WebRequestMethods;
using FluentAssertions;
namespace SpecFlowProject1.StepDefinitions
{

    [Binding]
    public class Test1_SammanslagenStepDefinitions
    {
        public string phone;
        public string startPage;
        public string password;
        public string phonenumber;
        public string bookID;
        public string bookQRcode;
        public CalculatorPageObject _calculatorPageObject;
        Test1_SammanslagenStepDefinitions(BrowserDriverEdge browserDriverEdge)
        //  public Test1_SammanslagenStepDefinitions(BrowserDriver browserDriver)
        //public Test1_SammanslagenStepDefinitions(BrowserDriverMozilla browserDriverMozilla)
        {
            _calculatorPageObject = new CalculatorPageObject(browserDriverEdge.Current);
            //  _calculatorPageObject = new CalculatorPageObject(browserDriver.Current);
            //_calculatorPageObject = new CalculatorPageObject(browserDriverMozilla.Current);
            startPage = _calculatorPageObject.GiveStart();
            password = "Koopa11Kiipa";//User password
            phonenumber = "735458020";//User phone
            bookQRcode = "eebe74a8-56ce-4e10-a8a2-6e4f6ef6c8cd";
            bookID = "6c6d0395-c667-4bf9-b5f5-0d13ca706b27"; //The book QR code number
            phone = parameters.GivePhone();
        }

        [Given(@"Account is created")]
        public void GivenAccountIsCreated()
        {
            _calculatorPageObject.GotoPage6(bookQRcode);
            _calculatorPageObject.ClickTa_emot();
            _calculatorPageObject.ClickIngetKonto();
            _calculatorPageObject.StatePhoneNumber(phonenumber);
            _calculatorPageObject.ClickCheckbox();
            _calculatorPageObject.ClickVerifiera1();
            _calculatorPageObject.StateVerificationCode();
            _calculatorPageObject.ClickVerifiera2();
            _calculatorPageObject.CreatePassWord(password);
            _calculatorPageObject.ClickSavepassword();
        }
        [When(@"Account is deleted")]
        public void WhenAccountIsDeleted()
        {// The browser is directed to "my account" page rather than "registrera bok"
            if (_calculatorPageObject.CurrentURL() != $"{startPage}/account/myprofile")
            { _calculatorPageObject.ClickMittKonto(); }
            _calculatorPageObject.ClickTaBortKonto();
            _calculatorPageObject.ClickBekräftaTaBortKonto();
        }
        [Then(@"It is verified that account is deleted")]
        public void ThenItIsVerifiedThatAccountIsDeleted()
        {
            int actualResult = 0;
            if (_calculatorPageObject.ExistsLogin())
            { actualResult++; }
            string a = _calculatorPageObject.CurrentURL();
           // System.IO.File.WriteAllText("C:/Users/jiti0001/Documents/testprint.txt", a);

            if ($"{startPage}/"==_calculatorPageObject.CurrentURL())
            { actualResult++; }
            actualResult.Should().Be(2);
        }
    }

}