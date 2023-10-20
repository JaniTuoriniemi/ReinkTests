using CalculatorSelenium.Specs.Drivers;
using CalculatorSelenium.Specs.PageObjects;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Newtonsoft.Json;
using System;
using TechTalk.SpecFlow;

namespace Specflowtest.StepDefinitions
{
    [Binding]
    public class Test7StepDefinitions
    {
        public string message;
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
        // The PageObject that inteacts with the webpages. It is located in testPageObject.cs
        public CalculatorPageObject _calculatorPageObject;
        Test7StepDefinitions()
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
            ////The tests are run with default parameters if custom parameters are not found.
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
                if ((jsonParameters.ExistingPassword != "") && (jsonParameters.ExistingPassword != null))
                { password = jsonParameters.ExistingPassword; }
                else if (defaultParameters.Existingpassword != null) { password = defaultParameters.Existingpassword; }
            }
            else { password = defaultParameters.Existingpassword; }
            // Only phonenumber for an  account to be created is used for these tests
            if (isParameters == true)
            {
                if ((jsonParameters.ExistingPhone != "") && (jsonParameters.ExistingPhone != null))
                { phonenumber = jsonParameters.ExistingPhone; }
                else if (defaultParameters.Existingphone != null) { phonenumber = defaultParameters.Existingphone; }
            }
            else { phonenumber = defaultParameters.Existingphone; }

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
        [Given(@"User loggs in and goes to a message thread")]
        public void GivenUserLoggsInAndGoesToAMessageThread()
        {
            //Goes to a conversation page. Test currently only works with default parameters.
            _calculatorPageObject.GotoPage12();
            _calculatorPageObject.StatePhoneNumber(phonenumber);
            _calculatorPageObject.StatePassWord(password);
            _calculatorPageObject.ClickLoginButton();
        }

        [When(@"A message containing a random number is sent to the thread")]
        public void WhenAMessageContainingARandomNumberIsSentToTheThread()
        {
           
           //Posts a random number on the message thread
            message =_calculatorPageObject.RandomMessage();
            _calculatorPageObject.PostMessage(message);
           

        }

        [Then(@"It is verified that the message is posted")]
        public void ThenItIsVerifiedThatTheMessageIsPosted()
        { //Verifies that the random number from the previous step is posted
            bool posted = _calculatorPageObject.MessageExists(message);
            posted.Should().Be(true);
           
        }
    }
}
