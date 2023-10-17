using CalculatorSelenium.Specs.Drivers;
using CalculatorSelenium.Specs.PageObjects;
using OpenQA.Selenium.DevTools;
using System;
using System.Text;
using System.IO;
using TechTalk.SpecFlow;
using static System.Net.WebRequestMethods;
using FluentAssertions;
using Newtonsoft.Json;
using Specflowtest.StepDefinitions;

namespace SpecFlowProject1.StepDefinitions
{

    [Binding]
    public class Test1_SammanslagenStepDefinitions
    {
        public bool isParameters;
        public string JsonParameters;
        public string browsertype;
        public string password;
        public string phonenumber;
        public string startPage;
        public string bookID;
        public string bookQRcode;

        BrowserDriverEdge browserDriverEdge;
        BrowserDriver browserDriver;
        BrowserDriverMozilla browserDriverMozilla;
        public CalculatorPageObject _calculatorPageObject;
        Test1_SammanslagenStepDefinitions()

        {
            isParameters = false;
            JsonParameters = "";
            try
            {//Comment away the two lines below if you want to run with default parameters 
                JsonParameters = System.IO.File.ReadAllText(Path.GetTempPath() + "JsonParameters1.txt");
                if (JsonParameters != "") { isParameters = true; }
            }
            catch
            {

            }
            dynamic jsonParameters = JsonConvert.DeserializeObject(JsonParameters);
            DefaultParameters defaultParameters = new DefaultParameters();

            if (isParameters == true)
            {
                if ((jsonParameters.Browsertype != "") && (jsonParameters.Browsertype != null))
                { browsertype = jsonParameters.Browsertype; }
                else if (defaultParameters.Browsertype != null) { browsertype = defaultParameters.Browsertype; }
            }
            else { browsertype = defaultParameters.Browsertype; }
            // Only new password for an account to be created is used for these tests
            if (isParameters == true)
            {
                if ((jsonParameters.NewPassword != "") && (jsonParameters.NewPassword != null))
                { password = jsonParameters.NewPassword; }
                else if (defaultParameters.NewPassword != null) { password = defaultParameters.NewPassword; }
            }
            else { password = defaultParameters.NewPassword; }
            // Only phonenumber for an  account to be created is used for these tests
            if (isParameters == true)
            {
                if ((jsonParameters.NewPhone != "") && (jsonParameters.NewPhone != null))
                { phonenumber = jsonParameters.NewPhone; }
                else if (defaultParameters.NewPhone != null) { phonenumber = defaultParameters.NewPhone; }
            }
            else { phonenumber = defaultParameters.NewPhone; }

            if (isParameters == true)
            {
                if ((jsonParameters.BookID != "") && (jsonParameters.BookID != null))
                { bookID = jsonParameters.BookID; }
                else if (defaultParameters.BookID != null) { bookID = defaultParameters.BookID; }
            }
            else { bookID = defaultParameters.BookID; }

            if (isParameters == true)
            {
                if ((jsonParameters.BookQRcode != "") && (jsonParameters.BookQRcode != null))
                { bookQRcode = jsonParameters.BookQRcode; }
                else if (defaultParameters.BookQRcode != null) { bookQRcode = defaultParameters.BookQRcode; }
            }
            else { bookQRcode = defaultParameters.BookQRcode; }


            if (browsertype == "edge")
            {
                browserDriverEdge = new BrowserDriverEdge();
                _calculatorPageObject = new CalculatorPageObject(browserDriverEdge.Current);
            }
            if (browsertype == "mozilla")
            {
                browserDriverMozilla = new BrowserDriverMozilla();
                _calculatorPageObject = new CalculatorPageObject(browserDriverMozilla.Current);
            }
            if (browsertype == "chrome")
            {
                browserDriver = new BrowserDriver();
                _calculatorPageObject = new CalculatorPageObject(browserDriver.Current);
            }
            startPage = _calculatorPageObject.GiveStart();
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