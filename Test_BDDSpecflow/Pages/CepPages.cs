using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Test_BDDSpecflow.Pages
{
    public class CepPages
    {
        public IWebDriver driver;
        //Elementos
        public IWebElement endereco => driver.FindElement(By.Id("endereco"));
        public IWebElement btnBuscar => driver.FindElement(By.Id("btn_pesquisar"));
        public IWebElement tituloPagina => driver.FindElement(By.Id("titulo_tela"));
        public IWebElement campoCEP => driver.FindElement(By.Name("tipoCEP"));
        public IWebElement mensagemresultado => driver.FindElement(By.Id("mensagem-resultado"));

        //Metodos
        public CepPages(IWebDriver driver) => this.driver = driver;
        public void DigitarCEP(string cepValido = "80320-110") => endereco.SendKeys(cepValido);
        public void DigitarCEPInvalido(string cepInvalido = "8888888-110") => endereco.SendKeys(cepInvalido);
        public void ClicarBtnBuscar() => btnBuscar.Click();
        public void ValidarCampos()
        {
            Assert.IsTrue(tituloPagina.Displayed);
            Assert.IsTrue(endereco.Displayed);
            Assert.IsTrue(campoCEP.Displayed);
            Assert.IsTrue(btnBuscar.Displayed);
        }
        public void ValidarMensagemResultado()
        {
            Thread.Sleep(3000);
            Assert.AreEqual("Não há dados a serem exibidos", mensagemresultado.Text);
        }
        public void FecharBrowser()
        {
            driver.Quit();
        }
        public void ValidarCEP()
        {
            var table = driver.FindElement(By.Id("resultado-DNEC"));
            var rows = table.FindElements(By.TagName("tr"));
            foreach (var row in rows)
            {
                if (row.Text.Contains("Rua Professor Veríssimo Antônio de Souza"))
                {
                    Assert.AreEqual("Rua Professor Veríssimo Antônio de Souza", driver.FindElement(By.XPath("//td[contains(text(),'Rua Professor Veríssimo Antônio de Souza')]")).Text);
                }
            }
        }

    }
}
