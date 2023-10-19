using CalculatorSelenium.Specs.Drivers;
using CalculatorSelenium.Specs.PageObjects;
using Newtonsoft.Json;
using Specflowtest.StepDefinitions;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class TestSequence2StepDefinitions
    {
        public bool isParameters;
        public string JsonParameters;
        public string browsertype;
        public string filledSwishPaymentReference;
        public string password;
        public string phonenumber;
        public string startPage;
        public string bookID;
        public string bookQRcode;
        // These are the parameters to be filled into the hidden test form

        public string amount;
        public string averagePrice;
        public string averagePricePlusExtra;
        public string paymentReference;
       
        BrowserDriverEdge browserDriverEdge;
        BrowserDriver browserDriver;
        BrowserDriverMozilla browserDriverMozilla;
        // The PageObject that inteacts with the webpages. It is located in testPageObject.cs
        public CalculatorPageObject _calculatorPageObject;
        TestSequence2StepDefinitions()

        {
            isParameters = false;
            JsonParameters = "";
            try
            {//Comment away the two lines below if you want to run with default parameters 
                JsonParameters = File.ReadAllText(Path.GetTempPath() + "JsonParameters1.txt");
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
            // Only password for an existing account is used for these tests
            if (isParameters == true)
            {
                if ((jsonParameters.ExistingPassword != "") && (jsonParameters.ExistingPassword != null))
                { password = jsonParameters.ExistingPassword; }
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
        [Given(@"The QR code is scanned and the browser is taken to ta emot page")]
        public void GivenTheQRCodeIsScannedAndTheBrowserIsTakenToTaEmotPage()
        {
            _calculatorPageObject.GotoPage1();
        }

        [When(@"Ta emot is clicked")]
        public void WhenTaEmotIsClicked()
        {
            _calculatorPageObject.ClickTa_emot();
        }

        [Then(@"The browser is logged in")]
        public void ThenTheBrowserIsLoggedIn()
        {
            _calculatorPageObject.StatePhoneNumber(phonenumber);
            _calculatorPageObject.StatePassWord(password);
            _calculatorPageObject.ClickLoginButton();
            if (_calculatorPageObject.CurrentURL() == $"{startPage}/book/leave-book?BookId=" + bookID)
            {
                string desired_page = "https://reink.se/book/leave-book?BookId=6c6d0395-c667-4bf9-b5f5-0d13ca706b27";
                string actualResult = _calculatorPageObject.CurrentURL();
                actualResult.Should().Be(desired_page);
            }
            else
            {
                _calculatorPageObject.ClickTa_emot();
                string desired_page2 = "https://reink.se/book/book-registered";
                string actualResult2 = _calculatorPageObject.CurrentURL();
                actualResult2.Should().Be(desired_page2);
            }
        }

        [Given(@"The browser return to ta emot page")]
        public void GivenTheBrowserReturnToTaEmotPage()
        {

            if (_calculatorPageObject.CurrentURL() != $"{startPage}/book/register-qr?QrCode=" + bookQRcode)
            { _calculatorPageObject.GotoPage6(bookQRcode); }
        }

        [When(@"Ta emot is clicked again")]
        public void WhenTaEmotIsClickedAgain()
        {//Login should not be necessary here?
            _calculatorPageObject.ClickTa_emot();
           
            _calculatorPageObject.StatePhoneNumber(phonenumber);
            _calculatorPageObject.StatePassWord(password);
            _calculatorPageObject.ClickLoginButton();
            //_calculatorPageObject.ClickTa_emot();
        }

        [Then(@"It should now read bok registrerad")]
        public void ThenItShouldNowReadBokRegistrerad()
        {
            _calculatorPageObject.GotoPage7();//For test purposes with non registrable books only.Line should be commented away. 
            bool result = _calculatorPageObject.VerifyBookregistered();
            int actualResult = 0;
            if (result) { actualResult = 1; }
            actualResult.Should().Be(1);
        }

        [Given(@"The browser is logged out")]
        public void GivenTheBrowserIsLoggedOut()
        {//Browser is normally logged out at start
            _calculatorPageObject.GotoPage10();
            //_calculatorPageObject.ClickMittKonto();
            //_calculatorPageObject.ClickLogoutElement();
        }

        [When(@"The QR koden is scanned")]
        public void WhenTheQRKodenIsScanned()
        {
            _calculatorPageObject.GotoPage2(bookID);
        }

        [Then(@"It must now read jag är klar")]
        public void ThenItMustNowReadJagArKlar()
        {
            string desired_page2 = $"{startPage}/book/leave-book?BookId="+bookID;
            string actualResult2 = _calculatorPageObject.CurrentURL();
            actualResult2.Should().Be(desired_page2);
        }

        [Given(@"The browser is now on the page jag är klar")]
        public void GivenTheBrowserIsNowOnThePageJagArKlar()
        {
            _calculatorPageObject.GotoPage2(bookID);
        }

        [When(@"Click nästa and login")]
        public void WhenClickNastaAndLogin()
        {
            _calculatorPageObject.ClickNästaButton();
            _calculatorPageObject.StatePhoneNumber(phonenumber);
            _calculatorPageObject.StatePassWord(password);
            _calculatorPageObject.ClickLoginButton();
        }

        [Then(@"The browser is now on the page betala")]
        public void ThenTheBrowserIsNowOnThePageBetala()
        {
            string desired_page = $"{startPage}/account/payment-swish?BookId=" + bookID;
            string actualResult = _calculatorPageObject.CurrentURL();
            actualResult.Should().Contain(desired_page);
        }

        [Given(@"The browser moves to the the swish payment page")]
        public void GivenTheBrowserMovesToTheTheSwishPaymentPage()
        {
            {
                if ($"{startPage}/account/payment-swish?BookId="+bookID != _calculatorPageObject.CurrentURL())
                { _calculatorPageObject.GotoPage4(bookQRcode);
                    _calculatorPageObject.StatePhoneNumber(phonenumber);
                    _calculatorPageObject.StatePassWord(password);
                    _calculatorPageObject.ClickLoginButton();
                }
                //_calculatorPageObject.StatePhoneNumber(phonenumber);
                //_calculatorPageObject.StatePassWord(password);
                //_calculatorPageObject.ClickLoginButton();
            }
        }
            [When(@"The hidden test form is filled")]
        public void WhenTheHiddenTestFormIsFilled()
        {
            _calculatorPageObject.MoveSlider();// Moves the priceslider to 1 kr

            //The hidden form is filled in

            _calculatorPageObject.StateSwishAmount(amount);

            _calculatorPageObject.StateSwishBookID(bookID);
            //Uncomment the lines below to state more parameters.
            //_calculatorPageObject.StateSwishAveragePrice(averagePrice)
            //_calculatorPageObject.StateSwishAveragePricePlusExtra(averagePricePlusExtra);
            //Uncomment the line below if you want to also set the paymentreference number"
            // _calculatorPageObject.StateSwishPaymentReference(paymentReference);
            // Gets the prefilled or user stated payment reference number
            // filledSwishPaymentReference= _calculatorPageObject.GetValueSwishPaymentReference();
            //The phone number is filled in (Altough is should already be autofilled) and the "Betala" is clicked.
            if (browsertype == "mozilla")
            { _calculatorPageObject.StateSwishnumber("46" + phonenumber); }
            else { _calculatorPageObject.StateSwishnumber("+46" + phonenumber); }
            
            _calculatorPageObject.ClickBetalaSwish();
        }

        [Then(@"The hidden test form is read on the swish confirmation page")]
        public void ThenTheHiddenTestFormIsReadOnTheSwishConfirmationPage()
        {

            // The values in the hidden form on the payment confirmation page are verified

            // string testamount= _calculatorPageObject.GetValueSwishTestAmount();

            string teststatus = _calculatorPageObject.GetValueSwishTestStatus();
            string testcode = _calculatorPageObject.GetValueSwishTestCode();
            string testticket = _calculatorPageObject.GetValueSwishTestTicket();
            _calculatorPageObject.StateSwishTestAmount(amount);
            _calculatorPageObject.StateSwishTestCode();
            _calculatorPageObject.SubmitHiddenForm();
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


        }

        [Given(@"The browser is again on the page jag är klar")]
        public void GivenTheBrowserIsAgainOnThePageJagArKlar()
        {
            _calculatorPageObject.GotoPage2(bookID);
            _calculatorPageObject.ClickLämmnaPåAddressButton();
        }

        [When(@"Click lämna boken på en addres and login")]
        public void WhenClickLamnaBokenPaEnAddresAndLogin()
        {
            _calculatorPageObject.StatePhoneNumber(phonenumber);
            _calculatorPageObject.StatePassWord(password);
            _calculatorPageObject.ClickLoginButton();
        }

        [Then(@"The jag är klar page with adress should be visible")]
        public void ThenTheJagArKlarPageWithAdressShouldBeVisible()
        {
            string desired_page = $"{startPage}/book/leave-book-on-map?code=" + bookQRcode;
            string actualResult = _calculatorPageObject.CurrentURL();
            actualResult.Should().Be(desired_page);
            _calculatorPageObject.ClickNästaButtonLämna2();
        }

        [Given(@"The nästa button is clicked and the browser is taken to the payment page where the slider is moved and phone number stated")]
        public void GivenTheNastaButtonIsClickedAndTheBrowserIsTakenToThePaymentPageWhereTheSliderIsMovedAndPhoneNumberStated()
        {

            if ($"{startPage}/account/payment-swish?BookId=" + bookID != _calculatorPageObject.CurrentURL())
            { _calculatorPageObject.GotoPage4(bookQRcode);
                _calculatorPageObject.StatePhoneNumber(phonenumber);
                _calculatorPageObject.StatePassWord(password);
                _calculatorPageObject.ClickLoginButton();
         }
        }

        [When(@"The hidden test form is filled and avsluta is clicked")]
        public void WhenTheHiddenTestFormIsFilledAndAvslutaIsClicked()
        {
            _calculatorPageObject.MoveSlider();// Moves the priceslider to 1 kr
            //The hidden form is filled in
            _calculatorPageObject.StateSwishAmount(amount);
            _calculatorPageObject.StateSwishBookID(bookID);
            //Uncomment the lines below to state more parameters.
            //_calculatorPageObject.StateSwishAveragePrice(averagePrice)
            //_calculatorPageObject.StateSwishAveragePricePlusExtra(averagePricePlusExtra);
            //Uncomment the line below if you want to also set the paymentreference number"
            // _calculatorPageObject.StateSwishPaymentReference(paymentReference);
            // Gets the prefilled or user stated payment reference number
            // filledSwishPaymentReference= _calculatorPageObject.GetValueSwishPaymentReference();
            //The phone number is filled in (Altough is should already be autofilled) and the "Betala" is clicked.
            if (browsertype == "mozilla")
            { _calculatorPageObject.StateSwishnumber("46" + phonenumber); }
            else { _calculatorPageObject.StateSwishnumber("+46" + phonenumber); }
           

            _calculatorPageObject.ClickBetalaSwish();
        }

        [Then(@"The data from test form is read on the swish confirmation page")]
        public void ThenTheDataFromTestFormIsReadOnTheSwishConfirmationPage()
        {
            // The values in the hidden form on the payment confirmation page are verified

            // string testamount= _calculatorPageObject.GetValueSwishTestAmount();

            string teststatus = _calculatorPageObject.GetValueSwishTestStatus();

            string testcode = _calculatorPageObject.GetValueSwishTestCode();

            string testticket = _calculatorPageObject.GetValueSwishTestTicket();

            _calculatorPageObject.StateSwishTestAmount(amount);

            _calculatorPageObject.StateSwishTestCode();
            _calculatorPageObject.SubmitHiddenForm();

            string pagesource = _calculatorPageObject.GetSource();

            dynamic jsonPage = _calculatorPageObject.ExtractJsonObject(pagesource);

            int controlnumber = 0;

            if (jsonPage.amount == amount)

            { controlnumber = controlnumber + 1; }

            if (jsonPage.status == teststatus)

            { controlnumber = controlnumber + 1; }

            //if (jsonPage.payeePaymentReference == "61a7754f65f64c5c9b13a06dbb8980b7" ) 
            //
            //{ controlnumber = controlnumber + 1; }

            //if (jsonPage.id == "61a7754f65f64c5c9b13a06dbb8980b7") 

            //{ controlnumber = controlnumber + 1; }

            int actualResult = controlnumber;

            actualResult.Should().Be(2);


        }
    }
}
