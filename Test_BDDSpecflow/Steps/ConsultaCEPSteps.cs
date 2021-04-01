using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using Test_BDDSpecflow.Pages;
using Test_BDDSpecflow;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
using Test_BDDSpecflow.Util;
using System.Configuration;

namespace Test_BDDSpecflow.Steps
{
    [Binding]
    public class ConsultaCEPSteps
    {
        //Anti-Context
        public RemoteWebDriver driver;
       
        //Step Definitions
        [Given(@"que estou na pagina para consultar CEP")]
        public void DadoqueestounapaginaparaconsultarCEP()
        {
            driver = TestConfig.GetBrowserMobile(driver, ConfigurationManager.AppSettings["browser"]);//, ConfigurationManager.AppSettings["uri"]);
        }

        [When(@"insiro um CEP válido")]
        public void QuandoInsiroUmCEPValido()
        {

            CepPages cepPages = new CepPages(driver);
            cepPages.ValidarCampos();
            cepPages.DigitarCEP();
            cepPages.ClicarBtnBuscar();

        }

        [When(@"insiro um CEP inválido")]
        public void QuandoInsiroUmCEPInvalido()
        {
            CepPages cepPages = new CepPages(driver);
            cepPages.DigitarCEPInvalido();
            cepPages.ClicarBtnBuscar();
        }

        [Then(@"valido os dados do CEP")]
        public void EntaoValidoOsDadosDoCEP()
        {
            CepPages cepPages = new CepPages(driver);
            cepPages.ValidarCEP();
            cepPages.FecharBrowser();
        }

        [Then(@"valido a mensagem de retorno")]
        public void EntaoValidoAMensagemDeRetorno()
        {
            CepPages cepPages = new CepPages(driver);
            cepPages.ValidarMensagemResultado();
            cepPages.FecharBrowser();
        }
    }
}
