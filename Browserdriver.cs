using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;

namespace CalculatorSelenium.Specs.Drivers
{
    /// <summary>
    /// Manages a browser instance using Selenium
    /// </summary>
    public class BrowserDriver : IDisposable// Comment away IDisposable to not close browser after test
    {
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;
        private bool _isDisposed;

        public BrowserDriver()
        {
            _currentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver);

        }

        /// <summary>
        /// The Selenium IWebDriver instance
        /// </summary>
        public IWebDriver Current => _currentWebDriverLazy.Value;

        /// <summary>
        /// Creates the Selenium web driver (opens a browser)
        /// </summary>
        /// <returns></returns>
        private IWebDriver CreateWebDriver()
        {
            //We use the Chrome browser
            var chromeDriverService = ChromeDriverService.CreateDefaultService();

            var chromeOptions = new ChromeOptions();
           // chromeOptions.AddArgument("--headless=new");//Comment away this line to make browser visible
            var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);

            return chromeDriver;
        }
        /// <summary>
        /// Disposes the Selenium web driver (closing the browser) after the Scenario completed
        /// </summary>
        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            if (_currentWebDriverLazy.IsValueCreated)
            {
                Current.Quit();
            }

            _isDisposed = true;
        }
    }
        public class BrowserDriverMozilla : IDisposable// Comment away IDisposable to not close browser after test
        {
            private readonly Lazy<IWebDriver> _currentWebDriverLazy;
            private bool _isDisposed;

            public BrowserDriverMozilla()
            {
                _currentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver);

            }
            /// <summary>
            /// The Selenium IWebDriver instance
            /// </summary>
            public IWebDriver Current => _currentWebDriverLazy.Value;

            /// <summary>
            /// Creates the Selenium web driver (opens a browser)
            /// </summary>
            /// <returns></returns>
            private IWebDriver CreateWebDriver()
            {
            //We use the Mozilla browser
            var firefoxDriverService = FirefoxDriverService.CreateDefaultService();

            var firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddArgument("--headless=new");//Comment away this line to make browser visible
            var firefoxDriver = new FirefoxDriver(firefoxDriverService, firefoxOptions);

            return firefoxDriver;

            }
            /// <summary>
            /// Disposes the Selenium web driver (closing the browser) after the Scenario completed
            /// </summary>
            public void Dispose()
            {
                if (_isDisposed)
                {
                    return;
                }

                if (_currentWebDriverLazy.IsValueCreated)
                {
                    Current.Quit();
                }

                _isDisposed = true;
            }
        }
    public class BrowserDriverEdge// : IDisposable// Comment away IDisposable to not close browser after test
    {
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;
        private bool _isDisposed;

        public BrowserDriverEdge()
        {
            _currentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver);

        }
        /// <summary>
        /// The Selenium IWebDriver instance
        /// </summary>
        public IWebDriver Current => _currentWebDriverLazy.Value;

        /// <summary>
        /// Creates the Selenium web driver (opens a browser)
        /// </summary>
        /// <returns></returns>
        private IWebDriver CreateWebDriver()
        {
            //We use the Mozilla browser
            var edgeDriverService = EdgeDriverService.CreateDefaultService();

            var edgeOptions = new EdgeOptions();
           // edgeOptions.AddArgument("--headless=new");//Comment away this line to make browser visible
            var edgeDriver = new EdgeDriver(edgeDriverService, edgeOptions);

            return edgeDriver;

        }
        /// <summary>
        /// Disposes the Selenium web driver (closing the browser) after the Scenario completed
        /// </summary>
        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            if (_currentWebDriverLazy.IsValueCreated)
            {
                Current.Quit();
            }

            _isDisposed = true;
        }
    }



}
