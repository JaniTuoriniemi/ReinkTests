

using CalculatorSelenium.Specs.Drivers;

using CalculatorSelenium.Specs.PageObjects;
using FluentAssertions;
using System;

using TechTalk.SpecFlow;

using Newtonsoft.Json;
using OpenQA.Selenium;
using Specflowtest.StepDefinitions;

namespace SpecFlowProject1.StepDefinitions

{

    [Binding]

    public class SwishtestStepDefinitions

    {
        public bool isParameters;
        public string JsonParameters;
        public string JsonReserveParameters;
        public string browsertype;
        public string filledSwishPaymentReference;
        public string password;
        public string phonenumber;

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
        SwishtestStepDefinitions()
       
        {
            isParameters = false;
            JsonParameters = "";
            try
            {//Comment away the two lines below if you want to run with default parameters 
             JsonParameters= File.ReadAllText(Path.GetTempPath() + "JsonParameters1.txt");
             if (JsonParameters != "") { isParameters = true; }
            }
            catch { 
                 
                }
             dynamic jsonParameters = JsonConvert.DeserializeObject(JsonParameters);  
            DefaultParameters defaultParameters = new DefaultParameters();
           
            if (isParameters == true)
            { if ((jsonParameters.browsertype != "") && (jsonParameters.browsertype != null))
                { browsertype = jsonParameters.browsertype; }
              else if (defaultParameters.browsertype!=null) { browsertype = defaultParameters.browsertype; }
            }
            else { browsertype = defaultParameters.browsertype; }
  
            if (isParameters == true)
            {
                if ((jsonParameters.ExistingPassword != "") && (jsonParameters.ExistingPassword != null))
                { password = jsonParameters.ExistingPassword; }
                else if (defaultParameters.existingpassword != null) { browsertype = defaultParameters.existingpassword; }
            }
            else { password = defaultParameters.existingpassword; }

            if (isParameters == true)
            {
                if ((jsonParameters.ExistingPhone != "") && (jsonParameters.ExistingPhone != null))
                { phonenumber = jsonParameters.ExistingPhone; }
                else if (defaultParameters.existingphone != null) { phonenumber = defaultParameters.existingphone; }
            }
            else { phonenumber = defaultParameters.existingphone; }

            if (isParameters == true)
            {
                if ((jsonParameters.Amount != "") && (jsonParameters.Amount != null))
                { amount = jsonParameters.Amount; }
                else if (defaultParameters.amount != null) { amount= defaultParameters.amount; }
            }
            else { amount = defaultParameters.amount; }

            if (isParameters == true)
            {
                if ((jsonParameters.BookID != "") && (jsonParameters.BookID != null))
                { bookID = jsonParameters.BookID; }
                else if (defaultParameters.bookID != null) { bookID = defaultParameters.bookID; }
            }
            else { bookID = defaultParameters.bookID; }

            if (isParameters == true)
            {
                if ((jsonParameters.BookQRcode != "") && (jsonParameters.BookQRcode != null))
                { bookQRcode = jsonParameters.BookQRcode; }
                else if (defaultParameters.bookQRcode != null) { browsertype = defaultParameters.bookQRcode; }
            }
            else { bookQRcode = defaultParameters.bookQRcode; }
          
            if (isParameters == true)
            {
                if ((jsonParameters.AveragePrice != "") && (jsonParameters.AveragePrice != null))
                { averagePrice = jsonParameters.AveragePrice; }
                else if (defaultParameters.averagePrice != null) { averagePrice = defaultParameters.amount; }
            }
            else { averagePrice = defaultParameters.averagePrice; }

            if (isParameters == true)
            {
                if ((jsonParameters.AveragePricePlusExtra != "") && (jsonParameters.AveragePricePlusExtra != null))
                { averagePricePlusExtra = jsonParameters.AveragePricePlusExtra; }
                else if (defaultParameters.averagePricePlusExtra != null) { averagePricePlusExtra = defaultParameters.averagePricePlusExtra; }
            }
            else { averagePricePlusExtra = defaultParameters.averagePricePlusExtra; }

            if (isParameters == true)
            {
                if ((jsonParameters.PaymentReference != "") && (jsonParameters.PaymentReference != null))
                { paymentReference = jsonParameters.PaymentReference; }
                else if (defaultParameters.paymentReference != null) { paymentReference = defaultParameters.paymentReference; }
            }
            else { paymentReference = defaultParameters.paymentReference; }

            if (isParameters == true)
            {
                if ((jsonParameters.FilledSwishPaymentReference != "") && (jsonParameters.FilledSwishPaymentReference != null))
                { filledSwishPaymentReference = jsonParameters.FilledSwishPaymentReference; }
                else if (defaultParameters.filledSwishPaymentReference != null) { filledSwishPaymentReference = defaultParameters.filledSwishPaymentReference; }
            }
            else { filledSwishPaymentReference = defaultParameters.filledSwishPaymentReference; }
            browsertype = "chromgge";
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
            {  browserDriver = new BrowserDriver(); 
               _calculatorPageObject = new CalculatorPageObject(browserDriver.Current);}


                // _calculatorPageObject = new CalculatorPageObject(browserDriver.Current);
                // _calculatorPageObject = new CalculatorPageObject(browserDriverMozilla.Current);
                // browsertype = "mozilla";
                //browsertype = "chrome";
                // The tester should modify the parameters below to suit the test.

                // password = "Koopa11Kiipa";//User password
                // phonenumber = "730622401";//User phone
                //bookQRcode = "eebe74a8-56ce-4e10-a8a2-6e4f6ef6c8cd";
                //amount = "1";
                //bookID = "6c6d0395-c667-4bf9-b5f5-0d13ca706b27"; //The book QR code number  
                //averagePrice = "1";

                // averagePricePlusExtra = "1";

                //            paymentReference = "3AF9E317B9E54B5ABF481F85E8A96D45";//Probably should be the user GUID?

                //  filledSwishPaymentReference = "";

            }

            [Given(@"The browser goes to the the payment page")]

        public void GivenTheBrowserIsOnThePaymentPage()

        {

            _calculatorPageObject.GotoPage4(bookQRcode);

            // The user is logged in

            _calculatorPageObject.StatePhoneNumber(phonenumber);

            _calculatorPageObject.StatePassWord(password);

            _calculatorPageObject.ClickLoginButton();



        }

        [When(@"The test form is filled")]

        public void WhenTheTestFormIsFilled()

        {

            _calculatorPageObject.MoveSlider();// Moves the priceslider to 1 kr

            //The hidden form is filled in

            _calculatorPageObject.StateSwishAmount(amount);

            _calculatorPageObject.StateSwishBookID(bookID);

            //_calculatorPageObject.StateSwishAveragePrice(averagePrice);

            //_calculatorPageObject.StateSwishAveragePricePlusExtra(averagePricePlusExtra);

            //Uncomment the line below if you want to also set the paymentreference number"

            // _calculatorPageObject.StateSwishPaymentReference(paymentReference);

            // Gets the prefilled or user stated payment reference number

            // filledSwishPaymentReference= _calculatorPageObject.GetValueSwishPaymentReference();

            //The phone number is filled in (Altough is hould already be autofilled) an the "Betala" is clicked.

            if (browsertype == "mozilla")
            { _calculatorPageObject.StateSwishnumber("46" + phonenumber); }
            else { _calculatorPageObject.StateSwishnumber("+46" + phonenumber); };

            _calculatorPageObject.ClickBetalaSwish();

        }

        [Then(@"The test form is read on the swish confirmation page")]

        public void ThenTheTestFormIsReadOnTheSwishConfirmationPage()

        {



            // The values in the hidden form on the payment confirmation page are verified

            // string testamount= _calculatorPageObject.GetValueSwishTestAmount();

            string teststatus = _calculatorPageObject.GetValueSwishTestStatus();

            string testcode = _calculatorPageObject.GetValueSwishTestCode();

            string testticket = _calculatorPageObject.GetValueSwishTestTicket();

            _calculatorPageObject.StateSwishTestAmount(amount);

            _calculatorPageObject.ClickAvslutaButton();

            string pagesource = _calculatorPageObject.GetSource();

            dynamic jsonPage = _calculatorPageObject.ExtractJsonObject(pagesource);

            int controlnumber = 0;

            if (jsonPage.amount == amount)

            { controlnumber = controlnumber + 1; }

            if (jsonPage.status == teststatus)

            { controlnumber = controlnumber + 1; }

            //if (jsonPage.payeePaymentReference == "61a7754f65f64c5c9b13a06dbb8980b7" ) 

            //{ controlnumber = controlnumber + 1; }

            //if (jsonPage.id == "61a7754f65f64c5c9b13a06dbb8980b7") 

            //{ controlnumber = controlnumber + 1; }

            int actualResult = controlnumber;

            actualResult.Should().Be(2);



            //{ controlnumber=controlnumber+1; }

            //int controlnumber = 0;

            //if (testamount == "4")

            //{ controlnumber=controlnumber+1; }

            // if (teststatus == "PAID")

            //{ controlnumber = controlnumber + 1; }

            //if (testcode == "enter code")

            // { controlnumber = controlnumber + 1; }

            //if (testticket == filledSwishPaymentReference.ToLower() )

            //{ controlnumber = controlnumber + 1; }

            //int actualResult = controlnumber;

            //actualResult.Should().Be(4);//If the hidden test form is filled in as expected the control sum should be 4.

            //  "203e782c967d4350a21a4d3e5538e469"

            // "3af9e317b9e54b5abf481f85e8a96d45"

            //457643B8C6E044049B4C73F3CA303F68

            // 457643b8c6e044049b4c73f3ca303f68

        }

    }

}

