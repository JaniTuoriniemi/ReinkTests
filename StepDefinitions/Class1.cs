

using System;

using OpenQA.Selenium;

using OpenQA.Selenium.Interactions;

using OpenQA.Selenium.Support.UI;

namespace CalculatorSelenium.Specs.PageObjects

{

    /// <summary>

    /// Calculator Page Object

    /// </summary>

    public class SecondPageObject

    {





        //The URLs involved in the tests

        string reink_start = "https://reink.se/";

        string reink_code = "https://reink.se/book/register-qr?QrCode=eebe74a8-56ce-4e10-a8a2-6e4f6ef6c8cd";

        string logga_in_code = "https://reink.se/auth/login?ReturnUrl=%2Fbook%2Fcode-access%3Fcode%3Deebe74a8-56ce-4e10-a8a2-6e4f6ef6c8cd";

        string registrera_bok = "https://reink.se/book/register-qr?QrCode=eebe74a8-56ce-4e10-a8a2-6e4f6ef6c8cd";

        string bok_registrerad = "https://reink.se/book/book-registered";

        string är_klar = "https://reink.se/book/leave-book?BookId=6c6d0395-c667-4bf9-b5f5-0d13ca706b27";

        string lämna_boken_till_en_vän = "https://reink.se/auth/login?ReturnUrl=%2Fbook%2Fleave-book-to-friend%3Fcode%3Deebe74a8-56ce-4e10-a8a2-6e4f6ef6c8cd";

        string betala_swish = "https://reink.se/account/payment-swish?BookId=6c6d0395-c667-4bf9-b5f5-0d13ca706b27&Status=started%2BleaveBookToFriend&InstructionUUID=41B16BE962B044CF9606576961779519";

        string min_profil = "https://reink.se/account/myprofile";

        string är_klar_address = "https://reink.se/book/leave-book-on-map?code=eebe74a8-56ce-4e10-a8a2-6e4f6ef6c8cd";

        string betala_swish_är_klar_address = "https://reink.se/account/payment-swish?BookId=6c6d0395-c667-4bf9-b5f5-0d13ca706b27&Status=started%2BleaveBookOnMap&InstructionUUID=0A14B4EB2C554A62BC57A95D72A9FDC5";

        //The Selenium web driver to automate the browser

        public static IWebDriver _webDriver;

        //The default wait time in seconds for wait.Until

        public const int DefaultWaitInSeconds = 5;

        public SecondPageObject(IWebDriver webDriver)

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

        private IWebElement NästaButton => _webDriver.FindElement(By.LinkText("/book/leave-book-to-friend?code=eebe74a8-56ce-4e10-a8a2-6e4f6ef6c8cd"));

        private IWebElement LämmnaPåAddressButton => _webDriver.FindElement(By.Id("bok-address"));

        private IWebElement LämmnaPåAddressNästaButton => _webDriver.FindElement(By.LinkText("/book/leave-book-to-friend?code=eebe74a8-56ce-4e10-a8a2-6e4f6ef6c8cd"));

        private IWebElement PriceSlider => _webDriver.FindElement(By.ClassName("well"));

        private IWebElement BetalaSwish => _webDriver.FindElement(By.Id("betalaText"));

        private IWebElement NästaButtonLämna => _webDriver.FindElement(By.XPath("//*[text()='Nästa']"));

        private IWebElement SwishPhone => _webDriver.FindElement(By.Id("txtSwishMobileNumber"));

        public void ClickNästaButtonLämna()

        {

            NästaButtonLämna.Click();

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

        //public bool ExistsTa_emot()

        //{

        //if (Ta_emot== OpenQA.Selenium.NoSuchElementException)

        //  return false;

        //else return true;   

        // }

        public void ClickNästaButton()

        {

            NästaButton.Click();

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

        public void GotoPage2()

        {

            _webDriver.Url = är_klar;

        }

        public void GotoPage3()

        {

            _webDriver.Url = betala_swish;

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

