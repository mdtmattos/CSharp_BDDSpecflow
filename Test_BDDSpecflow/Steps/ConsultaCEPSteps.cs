using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Test_BDDSpecflow.Pages;
using Test_BDDSpecflow.Util;
using System.Configuration;

namespace Test_BDDSpecflow.Steps
{
    [Binding]
    public class ConsultaCEPSteps
    {
        //Anti-Context
        public IWebDriver driver;
       
        //Step Definitions
        [Given(@"que estou na pagina para consultar CEP")]
        public void DadoqueestounapaginaparaconsultarCEP()
        {
            driver = TestConfig.GetBrowserLocal(driver, ConfigurationManager.AppSettings["browser"]);//, ConfigurationManager.AppSettings["uri"]);
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
