using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BDDSpecflow.Util
{
    class TestConfig
    {
        #region Browser
        public static RemoteWebDriver GetBrowserLocal(RemoteWebDriver driver, string browser)
        {
            switch (browser)
            {
                case "Firefox":
                    driver = new FirefoxDriver();
                    driver.Manage().Window.Maximize();
                    break;
                case "Edge":
                    driver = new EdgeDriver();
                    driver.Manage().Window.Maximize();
                    break;
                default:
                    driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    driver.Navigate().GoToUrl("https://buscacepinter.correios.com.br/app/endereco/index.php");
                    break;
            }
            return driver;
        }

        public static RemoteWebDriver GetBrowserRemote(RemoteWebDriver driver, string browser, string uri)
        {
            switch (browser)
            {
                case "Firefox":
                    FirefoxOptions firefoxoptions = new FirefoxOptions();
                    driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), firefoxoptions);
                    driver.Navigate().GoToUrl("https://buscacepinter.correios.com.br/app/endereco/index.php");
                    driver.Manage().Window.Maximize();
                    break;
                case "Edge":
                    EdgeOptions edgeoptions = new EdgeOptions();
                    driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), edgeoptions);
                    driver.Navigate().GoToUrl("https://buscacepinter.correios.com.br/app/endereco/index.php");
                    driver.Manage().Window.Maximize();
                    break;
                default:
                    ChromeOptions chromeoptions = new ChromeOptions();
                    driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), chromeoptions);
                    driver.Navigate().GoToUrl("https://buscacepinter.correios.com.br/app/endereco/index.php");
                    driver.Manage().Window.Maximize();
                    break;
            }
            return driver;
        }
        public static RemoteWebDriver GetBrowserMobile(RemoteWebDriver driver, string browser)
        {
            switch (browser)
            {
                case "Firefox":
                    driver = new FirefoxDriver();
                    driver.Manage().Window.Maximize();
                    break;
                case "Edge":
                    driver = new EdgeDriver();
                    driver.Manage().Window.Maximize();
                    break;
                default:
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.EnableMobileEmulation("Galaxy S5");
                    driver = new ChromeDriver(chromeOptions);
                    driver.Navigate().GoToUrl("https://buscacepinter.correios.com.br/app/endereco/index.php");
                    driver.Manage().Window.Maximize();
                    break;
            }
            return driver;
        }
        public static RemoteWebDriver GetBrowserRemoteMobile(RemoteWebDriver driver, string browser, string uri)
        {
            switch (browser)
            {
                case "Firefox":
                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), firefoxOptions);
                    driver.Navigate().GoToUrl("https://buscacepinter.correios.com.br/app/endereco/index.php");
                    driver.Manage().Window.Maximize();
                    break;
                case "Edge":
                    driver = new EdgeDriver();
                    driver.Manage().Window.Maximize();
                    break;
                default:
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.EnableMobileEmulation("Galaxy S5");
                    driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), chromeOptions);
                    driver.Navigate().GoToUrl("https://buscacepinter.correios.com.br/app/endereco/index.php");
                    driver.Manage().Window.Maximize();
                    break;
            }
            return driver;
        }
        #endregion

        #region JavaScript
        public static void ExecuteJavaScript(RemoteWebDriver driver, string script)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(script);
        }
        #endregion
    }
}
