using CalculatorSelenium.Specs.Drivers;
using CalculatorSelenium.Specs.PageObjects;
using Newtonsoft.Json;
using Specflowtest.StepDefinitions;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class Test5StepDefinitions
    {
        public bool isParameters;
        public string JsonParameters;
        public string browsertype;
        public string filledSwishPaymentReference;
        public string password;
        public string phonenumber;
        public string startPage;
        // These are the parameters to be filled into the hidden test form

        public string amount;
        public string bookID;
        public string averagePrice;
        public string averagePricePlusExtra;
        public string paymentReference;
        public string bookQRcode;

        // The PageObject that inteacts with the webpages. It is located in testPageObject.cs

        BrowserDriverEdge browserDriverEdge;
        BrowserDriver browserDriver;
        BrowserDriverMozilla browserDriverMozilla;
        public CalculatorPageObject _calculatorPageObject;
        Test5StepDefinitions()
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
            // Only password for an existing account is used for these tests
            if (isParameters == true)
            {
                if ((jsonParameters.ExistingPassword != "") && (jsonParameters.ExistingPassword != null))
                { password = jsonParameters.ExinstingPassword; }
                else if (defaultParameters.Existingpassword != null) { password = defaultParameters.Existingpassword; }
            }
            else { password = defaultParameters.Existingpassword; }
            // Only phonenumber for an existing account is used for these tests
            if (isParameters == true)
            {
                if ((jsonParameters.ExistingPhone != "") && (jsonParameters.ExistingPhone != null))
                { phonenumber = jsonParameters.ExistingPhone; }
                else if (defaultParameters.Existingphone != null) { phonenumber = defaultParameters.Existingphone; }
            }
            else { phonenumber = defaultParameters.Existingphone; }

            if (isParameters == true)
            {
                if ((jsonParameters.Amount != "") && (jsonParameters.Amount != null))
                { amount = jsonParameters.Amount; }
                else if (defaultParameters.Amount != null) { amount = defaultParameters.Amount; }
            }
            else { amount = defaultParameters.Amount; }

            if (isParameters == true)
            {
                if ((jsonParameters.ReservedBookID != "") && (jsonParameters.ReservedBookID != null))
                { bookID = jsonParameters.BookID; }
                else if (defaultParameters.ReservedBookID != null) { bookID = defaultParameters.ReservedBookID; }
            }
            else { bookID = defaultParameters.ReservedBookID; }

            if (isParameters == true)
            {
                if ((jsonParameters.ReservedBookQRcode != "") && (jsonParameters.ReservedBookQRcode != null))
                { bookQRcode = jsonParameters.ReservedBookQRcode; }
                else if (defaultParameters.ReservedbookQRcode != null) { bookQRcode = defaultParameters.ReservedbookQRcode; }
            }
            else { bookQRcode = defaultParameters.ReservedbookQRcode; }

            if (isParameters == true)
            {
                if ((jsonParameters.AveragePrice != "") && (jsonParameters.AveragePrice != null))
                { averagePrice = jsonParameters.AveragePrice; }
                else if (defaultParameters.AveragePrice != null) { averagePrice = defaultParameters.AveragePrice; }
            }
            else { averagePrice = defaultParameters.AveragePrice; }

            if (isParameters == true)
            {
                if ((jsonParameters.AveragePricePlusExtra != "") && (jsonParameters.AveragePricePlusExtra != null))
                { averagePricePlusExtra = jsonParameters.AveragePricePlusExtra; }
                else if (defaultParameters.AveragePricePlusExtra != null) { averagePricePlusExtra = defaultParameters.AveragePricePlusExtra; }
            }
            else { averagePricePlusExtra = defaultParameters.AveragePricePlusExtra; }

            if (isParameters == true)
            {
                if ((jsonParameters.PaymentReference != "") && (jsonParameters.PaymentReference != null))
                { paymentReference = jsonParameters.PaymentReference; }
                else if (defaultParameters.PaymentReference != null) { paymentReference = defaultParameters.PaymentReference; }
            }
            else { paymentReference = defaultParameters.PaymentReference; }

            if (isParameters == true)
            {
                if ((jsonParameters.FilledSwishPaymentReference != "") && (jsonParameters.FilledSwishPaymentReference != null))
                { filledSwishPaymentReference = jsonParameters.FilledSwishPaymentReference; }
                else if (defaultParameters.FilledSwishPaymentReference != null) { filledSwishPaymentReference = defaultParameters.FilledSwishPaymentReference; }
            }
            else { filledSwishPaymentReference = defaultParameters.FilledSwishPaymentReference; }

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
