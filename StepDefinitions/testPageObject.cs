using System;

using System.Drawing.Printing;

using System.Security.Policy;

using OpenQA.Selenium;

using OpenQA.Selenium.Interactions;

using OpenQA.Selenium.Support.UI;

using Newtonsoft.Json;

using System.Collections.Generic;
using OpenQA.Selenium.Remote;

namespace CalculatorSelenium.Specs.PageObjects

{

    /// <summary>

    /// Calculator Page Object

    /// </summary>

    public class CalculatorPageObject

    {

        public string GiveStart()
        { string start = reink_start;
            return start;
        }

        //The URLs involved in the tests

        string reink_login = $"{reink_start}/auth/login";

        const string reink_start = "https://reink.se";

        // const string reink_start = "http://localhost:5510";

        string reink_code = $"{reink_start}/book/register-qr?QrCode=eebe74a8-56ce-4e10-a8a2-6e4f6ef6c8cd";
        string bok_upptagen = $"{reink_start}/book/unavailave-book?Id=";
        
        string logga_in_code = $"{reink_start}/auth/login?ReturnUrl=%2Fbook%2Fcode-access%3Fcode%3Deebe74a8-56ce-4e10-a8a2-6e4f6ef6c8cd";

        string registrera_bok = $"{reink_start}/book/register-qr?QrCode=eebe74a8-56ce-4e10-a8a2-6e4f6ef6c8cd";

        string bok_registrerad = $"{reink_start}/book/book-registered";

        string är_klar = $"{reink_start}/book/leave-book?BookId=";

        string lämna_boken_till_en_vän = $"{reink_start}/auth/login?ReturnUrl=%2Fbook%2Fleave-book-to-friend%3Fcode%3Deebe74a8-56ce-4e10-a8a2-6e4f6ef6c8cd";

        string betala_swish = $"{reink_start}/account/payment-swish?BookId=6c6d0395-c667-4bf9-b5f5-0d13ca706b27&Status=started%2BleaveBookToFriend&InstructionUUID=41B16BE962B044CF9606576961779519";

        string min_profil = $"{reink_start}/account/myprofile";

        string är_klar_address = $"{reink_start}/book/leave-book-on-map?code=eebe74a8-56ce-4e10-a8a2-6e4f6ef6c8cd";

        string betala_swish_är_klar_address = $"{reink_start}/account/payment-swish?BookId=6c6d0395-c667-4bf9-b5f5-0d13ca706b27&Status=started%2BleaveBookOnMap&InstructionUUID=0A14B4EB2C554A62BC57A95D72A9FDC5";

        //The Selenium web driver to automate the browser

        public static IWebDriver _webDriver;

        //The default wait time in seconds for wait.Until

        public const int DefaultWaitInSeconds = 5;

        public CalculatorPageObject(IWebDriver webDriver)

        {

            _webDriver = webDriver;

            //   EnsureCalculatorIsOpenAndReset();

        }

        //Finding elements by ID

        private IWebElement Login => _webDriver.FindElement(By.ClassName("u-link"));

        private IWebElement Ta_emot => _webDriver.FindElement(By.Id("qr-register"));

        private IWebElement Telephone_input => _webDriver.FindElement(By.Id("phone"));

        private IWebElement Password_input => _webDriver.FindElement(By.Id("Password"));

        private IWebElement LoginButton => _webDriver.FindElement(By.ClassName("btn-primary"));

        private IWebElement LogOutButton => _webDriver.FindElement(By.PartialLinkText("/auth/logout"));

        private IWebElement NästaButton => _webDriver.FindElement(By.XPath("//*[text()='Nästa']"));

        private IWebElement LämmnaPåAddressButton => _webDriver.FindElement(By.Id("bok-address"));

        private IWebElement LämmnaPåAddressNästaButton => _webDriver.FindElement(By.LinkText("/book/leave-book-to-friend?code=eebe74a8-56ce-4e10-a8a2-6e4f6ef6c8cd"));

        private IWebElement PriceSlider => _webDriver.FindElement(By.ClassName("well"));

        private IWebElement BetalaSwish => _webDriver.FindElement(By.Id("betalaText"));

        private IWebElement NästaButtonLämna => _webDriver.FindElement(By.XPath("//*[text()='Nästa']"));

        private IWebElement NästaButtonLämna2 => _webDriver.FindElement(By.XPath("//*[contains(text(),'Nästa')]"));

        private IWebElement Bookregistered => _webDriver.FindElement(By.XPath("//*[text()='Bok Registrerad']"));

        private IWebElement SwishPhone => _webDriver.FindElement(By.Id("txtSwishMobileNumber"));

        private IWebElement SwishAmount => _webDriver.FindElement(By.Id("Amount"));

        private IWebElement SwishBookID => _webDriver.FindElement(By.Id("BookId"));

        private IWebElement AvslutaButton => _webDriver.FindElement(By.XPath("//*[text()='avsluta']"));

        private IWebElement SwishAveragePrice => _webDriver.FindElement(By.Id("AveragePrice"));

        private IWebElement SwishAveragePricePlusExtra => _webDriver.FindElement(By.Id("AveragePricePlusExtra"));

        private IWebElement SwishPaymentReference => _webDriver.FindElement(By.Id("PaymentReference"));

        private IWebElement SwishTestAmount => _webDriver.FindElement(By.Id("test-amount"));

        private IWebElement SwishTestStatus => _webDriver.FindElement(By.Id("test-status"));

        private IWebElement SwishTestCode => _webDriver.FindElement(By.Id("test-code"));

        private IWebElement SwishTestTicket => _webDriver.FindElement(By.Id("test-ticket"));

        //Create account

        private IWebElement Ingetkonto => _webDriver.FindElement(By.LinkText("Inget konto? Registrera dig"));

        private IWebElement VerifieraButton1 => _webDriver.FindElement(By.Id("submitBtn"));

        private IWebElement CheckBox => _webDriver.FindElement(By.Id("rememberme"));

        private IWebElement VerifikationsNr1 => _webDriver.FindElement(By.Id("OTP1"));

        private IWebElement VerifikationsNr2 => _webDriver.FindElement(By.Id("OTP2"));

        private IWebElement VerifikationsNr3 => _webDriver.FindElement(By.Id("OTP3"));

        private IWebElement VerifikationsNr4 => _webDriver.FindElement(By.Id("OTP4"));

        //private IWebElement VerifieraButton2 => _webDriver.FindElement(By.Id("SubmitBtn"));

        private IWebElement Passwordbox => _webDriver.FindElement(By.Id("Password"));

        private IWebElement ConfirmPasswordbox => _webDriver.FindElement(By.Id("ConfirmPassword"));

        // private IWebElement SavePassword => _webDriver.FindElement(By.Id("SubmitBtn"));

        private IWebElement MittKonto => _webDriver.FindElement(By.LinkText("/account/myprofile"));
       // private IWebElement TaBortKonto => _webDriver.FindElement(By.LinkText("/account/delete-account"));

        private IWebElement BekräftaTaBortKonto => _webDriver.FindElement(By.XPath("//*[text()='Ta bort']"));
        private IWebElement LoginElement => _webDriver.FindElement(By.ClassName("logg"));
        private IWebElement LogoutElement => _webDriver.FindElement(By.XPath("//*[text()='Logga Ut']"));
        public string GetValueSwishTestAmount()

        {
            string testAmount = SwishTestAmount.GetAttribute("value");
            return testAmount;
        }
        
        public string GetValueSwishTestStatus()

        {

            string testStatus = SwishTestStatus.GetAttribute("value");

            return testStatus;

        }

        public string GetValueSwishTestCode()

        {

            string testCode = SwishTestCode.GetAttribute("value");

            return testCode;

        }

        public string GetValueSwishTestTicket()

        {

            string testTicket = SwishTestTicket.GetAttribute("value");

            return testTicket;

        }

        public string GetValueSwishPaymentReference()

        {

            string filledSwishPaymentReference = SwishPaymentReference.GetAttribute("value");

            return filledSwishPaymentReference;

        }

        public bool VerifyBookregistered()
        {
            bool result;
            try
            {
                _webDriver.FindElement(By.XPath("//*[text()='Bok Registrerad']"));
                result = true;
            }

            catch (NoSuchElementException)

            {

                result = false;

            }

            return result;

        }
        public void ClickLogoutElement()
        { LogoutElement.Click(); }
        public void ClickBekräftaTaBortKonto()
        {
            BekräftaTaBortKonto.Click();
        }
        public void ClickTaBortKonto()
        {
            BekräftaTaBortKonto.Click();
        }
        public void ClickMittKonto()
        {
            MittKonto.Click();
        }
        public void ClickNästaButtonLämna()
        {
            NästaButtonLämna.Click();
        }
        public void ClickNästaButtonLämna2()
        {
            NästaButtonLämna2.Click();
        }
        public void Clicklogin()
        {
            Login.Click();
        }
        public void ClickTa_emot()

        {
            Ta_emot.Click();
        }
        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public void ClickLogOutButton()
        {
            LogOutButton.Click();
        }
        public bool ExistsLogin()

        {try
            {
                _webDriver.FindElement(By.ClassName("logg"));
                return true;

            }
            catch { return false; }
          
        }


        //public bool ExistsTa_emot()

        //{

        //if (Ta_emot== OpenQA.Selenium.NoSuchElementException)

        //  return false;

        //else return true;   

        // }
        public void ClickSavepassword()
        { 
        VerifieraButton1.Click();
        }
        public void ClickIngetKonto()
        {
           Ingetkonto.Click();
        }
        public void ClickCheckbox() 
        { CheckBox.Click(); }
        public void ClickVerifiera1()
        {
            VerifieraButton1.Click();
        }
        public void ClickVerifiera2()
        {
            VerifieraButton1.Click();
        }
        public void ClickNästaButton()
        {
            NästaButton.Click();
        }
        public void ClickAvslutaButton()
        {
            AvslutaButton.Click();
        }
        public void ClickLämmnaPåAddressButton()
        {
            LämmnaPåAddressButton.Click();
        }
        public void ClickLämmnaPåAddressNästaButton()

        {

            LämmnaPåAddressNästaButton.Click();

        }

        public void ClickBetalaSwish()

        {

            BetalaSwish.Click();

        }

        public void StateSwishAmount(string amount)

        {

            //IJavaScriptExecutor js = (IJavaScriptExecutor)_webDriver;

            // js.ExecuteScript("var myVar = arguments[0]; console.log(myVar);", amount);

            ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].value=arguments[1];", SwishAmount, amount);

            //Clear text box

            // SwishAmount.Clear();

            //Enter text

            //SwishAmount.SendKeys(amount);

        }
        public void StateVerificationCode()
        {
            VerifikationsNr1.SendKeys("0");
            VerifikationsNr2.SendKeys("0");
            VerifikationsNr3.SendKeys("0");
            VerifikationsNr4.SendKeys("0");
        }
        public void StateSwishBookID(string bookID)

        {

            ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].value=arguments[1];", SwishBookID, bookID);



        }

        public void StateSwishAveragePrice(string averageprice)

        {

            ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].value=arguments[1];", SwishAveragePrice, averageprice);



        }

        public void StateSwishAveragePricePlusExtra(string averagepriceplusextra)

        {

            ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].value=arguments[1];", SwishAveragePricePlusExtra, averagepriceplusextra);



        }

        public void StateSwishPaymentReference(string paymentreference)

        {

            ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].value=arguments[1];", SwishPaymentReference, paymentreference);



        }

        public void StateSwishTestAmount(string amount)

        {

            ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].value=arguments[1];", SwishTestAmount, amount);

        }

        public void StateSwishTestStatus(string teststatus)

        {

            ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].value=arguments[1];", SwishTestStatus, teststatus);

        }

        public void StateSwishTestCode(string testcode)

        {

            ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].value=arguments[1];", SwishTestCode, testcode);

        }

        public void StateSwishTestTicket(string testticket)

        {

            ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].value=arguments[1];", SwishTestTicket, testticket);

        }

        public string GetSource()

        {

            _webDriver.SwitchTo().Window(_webDriver.WindowHandles[1]);

            string source = _webDriver.PageSource;

            return source;

        }

        public void StatePhoneNumber(string number)

        {

            //Clear text box

            Telephone_input.Clear();

            //Enter text

            Telephone_input.SendKeys(number);

        }

        public void MoveSlider()

        {

            Actions action = new Actions(_webDriver);

            int slidersizewidth = PriceSlider.Size.Width;

            action.ClickAndHold(PriceSlider);

            action.MoveByOffset(-322, 0).Build().Perform();

        }
        public void CreatePassWord(string password)
        {
            Passwordbox.SendKeys(password);
            ConfirmPasswordbox.SendKeys(password);

        }
        public void StatePassWord(string word)

        {

            //Clear text box

            Password_input.Clear();

            //Enter text

            Password_input.SendKeys(word);

        }

        public void StateSwishnumber(string word)

        {

            //Clear text box

            SwishPhone.Clear();

            //Enter text

            SwishPhone.SendKeys(word);

        }

        public void StatePrice(string number)

        {

            PriceSlider.SendKeys(number);

        }

        public string CurrentURL()

        {

            string CurrentURL = _webDriver.Url;

            return CurrentURL;

        }

        public void EnterFirstNumber(string number)

        {

            //Clear text box

            //FirstNumberElement.Clear();

            //Enter text

            //FirstNumberElement.SendKeys(number);

        }

        public void EnterSecondNumber(string number)

        {

            //Clear text box

            //  SecondNumberElement.Clear();

            //Enter text

            //SecondNumberElement.SendKeys(number);

        }

        public void ClickAdd()

        {

            //Click the add button

            //    AddButtonElement.Click();

        }

        public void GotoPage1()

        {

            //Open the page for the first test

            _webDriver.Url = reink_code;

        }

        public void GotoPage2(string bookID)
        {
            _webDriver.Url = är_klar+bookID;
        }

        public void GotoPage3()

        {

            _webDriver.Url = betala_swish;

        }

        public void GotoPage4(string bookQRcode)

        {

            string page = $"{reink_start}/auth/login?ReturnUrl=%2Fbook%2Fleave-book-to-friend%3Fcode%3D" + bookQRcode;

            _webDriver.Url = page;

            // _webDriver.Url = lämna_boken_till_en_vän;

        }

        public void GotoPage5()

        {

            _webDriver.Url = reink_login;

        }

        public void GotoPage6(string bookQRcode)

        {

            string page = $"{reink_start}/book/register-qr?QrCode=" + bookQRcode;

            _webDriver.Url = page;

            // _webDriver.Url = lämna_boken_till_en_vän;

        }

        public void GotoPage7()

        {
            _webDriver.Url = bok_registrerad;
        }
        public void GotoPage8(string bookID)

        {
            _webDriver.Url = $"{reink_start}/book/leave-book?BookId=" + bookID;
        }
        public void GotoPage9()
        {
            _webDriver.Url = $"{reink_start}/account/register"; 
        }
        public void GotoPage10()
        { _webDriver.Url = $"{reink_start}"; }

        public object ExtractJsonObject(string pagesource)

        {

            for (var i = pagesource.IndexOf('{'); i > -1; i = pagesource.IndexOf('{', i + 1))

            {

                for (var j = pagesource.LastIndexOf('}'); j > -1; j = pagesource.LastIndexOf("}", j - 1))

                {

                    var jsonProbe = pagesource.Substring(i, j - i + 1);

                    try

                    {

                        return JsonConvert.DeserializeObject(jsonProbe);

                    }

                    catch

                    {

                    }

                }

            }

            return null;

        }

        public void EnsureCalculatorIsOpenAndReset()

        {

            //Open the calculator page in the browser if not opened yet

            if (_webDriver.Url != reink_start)

                //Open the calculator page in the browser if not opened yet

                if (_webDriver.Url != reink_start)

                {

                    _webDriver.Url = reink_start;

                }

                //Otherwise reset the calculator by clicking the reset button

                else

                {

                    //Click the rest button

                    // ResetButtonElement.Click();

                    //Wait until the result is empty again

                    // WaitForEmptyResult();

                }

        }

        //string WaitForNonEmptyResult()

        //{

        //Wait for the result to be not empty

        // return WaitUntil(

        //() => ResultElement.GetAttribute("value"),

        //result => !string.IsNullOrEmpty(result));

        //}

        //public string WaitForEmptyResult()

        //{

        //Wait for the result to be empty

        //  return WaitUntil(

        //    () => ResultElement.GetAttribute("value"),

        ///  result => result == string.Empty);

        // }

        /// <summary>

        /// Helper method to wait until the expected result is available on the UI

        /// </summary>

        /// <typeparam name="T">The type of result to retrieve</typeparam>

        /// <param name="getResult">The function to poll the result from the UI</param>

        /// <param name="isResultAccepted">The function to decide if the polled result is accepted</param>

        /// <returns>An accepted result returned from the UI. If the UI does not return an accepted result within the timeout an exception is thrown.</returns>

        private T WaitUntil<T>(Func<T> getResult, Func<T, bool> isResultAccepted) where T : class

        {

            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(DefaultWaitInSeconds));

            return wait.Until(driver =>

            {

                var result = getResult();

                if (!isResultAccepted(result))

                    return default;

                return result;

            });

        }

    }

}











