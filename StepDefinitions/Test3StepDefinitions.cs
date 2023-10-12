using CalculatorSelenium.Specs.Drivers;

using CalculatorSelenium.Specs.PageObjects;

using System;

using TechTalk.SpecFlow;

using static System.Net.WebRequestMethods;

namespace SpecFlowProject1.StepDefinitions

{

    [Binding]

    public class Test3StepDefinitions

    {

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

        public CalculatorPageObject _calculatorPageObject;
        public Test3StepDefinitions(BrowserDriverEdge browserDriverEdge)
       // public Test3StepDefinitions(BrowserDriver browserDriver)
        //public Test3StepDefinitions(BrowserDriverMozilla browserDriverMozilla)
        {

           // _calculatorPageObject = new CalculatorPageObject(browserDriver.Current);
            /// _calculatorPageObject = new CalculatorPageObject(browserDriverMozilla.Current);
            _calculatorPageObject = new CalculatorPageObject(browserDriverEdge.Current);
            //browsertype = "chrome";
            browsertype = "mozilla";
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

        [Given(@"The Browser is directed to the login page and the user is logged in")]

        public void GivenTheBrowserIsDirectedToTheLoginPageAndTheUserIsLoggedIn()

        {

            _calculatorPageObject.GotoPage5();

            _calculatorPageObject.StatePhoneNumber(phonenumber);

            _calculatorPageObject.StatePassWord(password);

            _calculatorPageObject.ClickLoginButton();

        }

        [When(@"The browser is directed to the book registering page as if its QR code was scanned and the nästa button is clicked")]

        public void WhenTheBrowserIsDirectedToTheBookRegisteringPageAsIfItsQRCodeWasScannedAndTheNastaButtonIsClicked()

        {

            _calculatorPageObject.GotoPage6(bookQRcode);

            _calculatorPageObject.ClickTa_emot();

        }

        [Then(@"The browser should now show the boken är registrerad confirmation page")]

        public void ThenTheBrowserShouldNowShowTheBokenArRegistreradConfirmationPage()

        {

            _calculatorPageObject.GotoPage7();//For test purposes with non registrable books only.Line should be commented away. 

            bool result = _calculatorPageObject.VerifyBookregistered();

            int actualResult = 0;

            if (result) { actualResult = 1; }

            actualResult.Should().Be(1);

        }

        [Given(@"The browser moves to the page where it is directed to when the books QR code is scanned again and lämna boken på en adress is clicked")]

        public void GivenTheBrowserMovesToThePageWhereItIsDirectedToWhenTheBooksQRCodeIsScannedAgainAndLamnaBokenPaEnAdressIsClicked()

        {

            _calculatorPageObject.GotoPage8(bookID);

            _calculatorPageObject.ClickLämmnaPåAddressButton();

            _calculatorPageObject.StatePhoneNumber(phonenumber);

            _calculatorPageObject.StatePassWord(password);

            _calculatorPageObject.ClickLoginButton();

        }

        [When(@"When the browser is taken to the leave book on a adress page the nästa button is clicked")]

        public void WhenWhenTheBrowserIsTakenToTheLeaveBookOnAAdressPageTheNastaButtonIsClicked()

        {



            _calculatorPageObject.ClickNästaButtonLämna2();

        }

        [Then(@"The browser is taken to the payment page")]

        public void ThenTheBrowserIsTakenToThePaymentPage()

        {

            string actualResult = _calculatorPageObject.CurrentURL();

            string desired_page = "/account/payment-swish?BookId=" + bookID;

            actualResult.Should().Contain(desired_page);

        }

        [Given(@"The browser is on the payment page-")]

        public void GivenTheBrowserIsOnThePaymentPage_()

        {
              string start = _calculatorPageObject.GiveStart();
            if (_calculatorPageObject.CurrentURL() != $"{start}/account/payment-swish?BookId=" + bookID)

            {

                _calculatorPageObject.GotoPage4(bookQRcode);

                _calculatorPageObject.StatePhoneNumber(phonenumber);

                _calculatorPageObject.StatePassWord(password);

                _calculatorPageObject.ClickLoginButton();

            }

        }

        [When(@"The payment test form is filled")]

        public void WhenThePaymentTestFormIsFilled()

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
            { _calculatorPageObject.StateSwishnumber("46"+phonenumber); }
            else { _calculatorPageObject.StateSwishnumber("+46" + phonenumber); }

            _calculatorPageObject.ClickBetalaSwish();

        }

        [Then(@"The test form is read on the Swish confirmation page")]

        public void ThenTheTestFormIsReadOnTheSwishConfirmationPage()

        {

            string teststatus = _calculatorPageObject.GetValueSwishTestStatus();

            string testcode = _calculatorPageObject.GetValueSwishTestCode();

            string testticket = _calculatorPageObject.GetValueSwishTestTicket();

            _calculatorPageObject.StateSwishTestAmount(amount);

            _calculatorPageObject.ClickAvslutaButton();

            string pagesource = _calculatorPageObject.GetSource();

            //File.WriteAllText("C:/Users/Jani/Documents/pagecontents.txt", pagesource);

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

            // 457643b8c6e044049b4c73f3ca303f68 throw new PendingStepException(); 

        }

    }

}


















