using CalculatorSelenium.Specs.Drivers;
using CalculatorSelenium.Specs.PageObjects;
using Newtonsoft.Json;
using Specflowtest.StepDefinitions;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
   
        [Binding]
    public class Test4StepDefinitions
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
        Test4StepDefinitions()
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
                if ((jsonParameters.NewPassword != "") && (jsonParameters.NewPassword != null))
                { password = jsonParameters.NewPassword; }
                else if (defaultParameters.NewPassword != null) { password = defaultParameters.NewPassword; }
            }
            else { password = defaultParameters.NewPassword; }
            // Only phonenumber for an existing account is used for these tests
            if (isParameters == true)
            {
                if ((jsonParameters.NewPhone != "") && (jsonParameters.NewPhone != null))
                { phonenumber = jsonParameters.NewPhone; }
                else if (defaultParameters.NewPhone != null) { phonenumber = defaultParameters.NewPhone; }
            }
            else { phonenumber = defaultParameters.NewPhone; }

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
