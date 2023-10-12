using CalculatorSelenium.Specs.Drivers;
using CalculatorSelenium.Specs.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class TestSequence2StepDefinitions
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
        public TestSequence2StepDefinitions(BrowserDriverEdge browserDriverEdge)
        //public TestSequence2StepDefinitions(BrowserDriver browserDriver)
        // public TestSequence2StepDefinitions(BrowserDriverMozilla browserDriverMozilla)
        {
            _calculatorPageObject = new CalculatorPageObject(browserDriverEdge.Current);
            // _calculatorPageObject = new CalculatorPageObject(browserDriver.Current);
            //_calculatorPageObject = new CalculatorPageObject(browserDriverMozilla.Current);
            browsertype = "mozilla";
          //  browsertype = "chrome";
            startPage = _calculatorPageObject.GiveStart();
            password = "Koopa11Kiipa";//User password
            phonenumber = "730622401";//User phone
            bookQRcode = "eebe74a8-56ce-4e10-a8a2-6e4f6ef6c8cd";
            amount = "1";
            bookID = "6c6d0395-c667-4bf9-b5f5-0d13ca706b27"; //The book QR code number  
            averagePrice = "1";
            averagePricePlusExtra = "1";
            paymentReference = "3AF9E317B9E54B5ABF481F85E8A96D45";//Probably should be the user GUID?
            filledSwishPaymentReference = "";

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

            //_calculatorPageObject.StateSwishAveragePrice(averagePrice)
            //_calculatorPageObject.StateSwishAveragePricePlusExtra(averagePricePlusExtra);
            //Uncomment the line below if you want to also set the paymentreference number"
            // _calculatorPageObject.StateSwishPaymentReference(paymentReference);
            // Gets the prefilled or user stated payment reference number
            // filledSwishPaymentReference= _calculatorPageObject.GetValueSwishPaymentReference();
            //The phone number is filled in (Altough is hould already be autofilled) an the "Betala" is clicked.
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
            //_calculatorPageObject.StateSwishAveragePrice(averagePrice)
            //_calculatorPageObject.StateSwishAveragePricePlusExtra(averagePricePlusExtra);
            //Uncomment the line below if you want to also set the paymentreference number"
            // _calculatorPageObject.StateSwishPaymentReference(paymentReference);
            // Gets the prefilled or user stated payment reference number
            // filledSwishPaymentReference= _calculatorPageObject.GetValueSwishPaymentReference();
            //The phone number is filled in (Altough is hould already be autofilled) an the "Betala" is clicked.
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

            _calculatorPageObject.ClickAvslutaButton();

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
