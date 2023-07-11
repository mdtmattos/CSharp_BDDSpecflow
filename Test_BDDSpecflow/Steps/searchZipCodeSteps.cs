using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Test_BDDSpecflow.Pages;
using Test_BDDSpecflow.Util;
using System.Configuration;

namespace Test_BDDSpecflow.Steps
{
    [Binding]
    public class Searchzipcode
    {
        //Anti-Context
        public IWebDriver driver;
       
        //Step Definitions
        [Given(@"I am on the page to check Zip code")]
        public void GivenIamonthepagetocheckZipcode()
        {
            driver = TestConfig.GetBrowserLocal(driver, ConfigurationManager.AppSettings["browser"]);//, ConfigurationManager.AppSettings["uri"]);
        }

        [When(@"I enter a valid zip code")]
        public void WhenIenteravalidzipcode()
        {

            ZipCodePages cepPages = new ZipCodePages(driver);
            cepPages.assertFields();
            cepPages.typeZipCode();
            cepPages.clickBtnBuscar();

        }

        [When(@"I enter a invalid zip code")]
        public void WhenIenterainvalidzipcode()
        {
            ZipCodePages cepPages = new ZipCodePages(driver);
            cepPages.typeInvalidZipCode();
            cepPages.clickBtnBuscar();
        }

        [Then(@"I validate the zip code data")]
        public void ThenIvalidatethezipcodedata()
        {
            ZipCodePages cepPages = new ZipCodePages(driver);
            cepPages.assertZipCode();
            cepPages.closeBrowser();
        }

        [Then(@"I validate the return message")]
        public void ThenIvalidatethereturnmessage()
        {
            ZipCodePages cepPages = new ZipCodePages(driver);
            cepPages.assertMessage();
            cepPages.closeBrowser();
        }
    }
}
