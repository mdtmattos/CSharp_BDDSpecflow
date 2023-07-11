using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace Test_BDDSpecflow.Pages
{
    public class ZipCodePages
    {
        public IWebDriver driver;
        //Elementos
        public IWebElement endereco => driver.FindElement(By.Id("endereco"));
        public IWebElement btnBuscar => driver.FindElement(By.Id("btn_pesquisar"));
        public IWebElement tituloPagina => driver.FindElement(By.Id("titulo_tela"));
        public IWebElement campoCEP => driver.FindElement(By.Name("tipoCEP"));
        public IWebElement mensagemresultado => driver.FindElement(By.Id("mensagem-resultado"));

        //Metodos
        public ZipCodePages(IWebDriver driver) => this.driver = driver;
        public void typeZipCode(string cepValido = "80320-110") => endereco.SendKeys(cepValido);
        public void typeInvalidZipCode(string cepInvalido = "8888888-110") => endereco.SendKeys(cepInvalido);
        public void clickBtnBuscar() => btnBuscar.Click();
        public void assertFields()
        {
            Assert.IsTrue(tituloPagina.Displayed);
            Assert.IsTrue(endereco.Displayed);
            Assert.IsTrue(campoCEP.Displayed);
            Assert.IsTrue(btnBuscar.Displayed);
        }
        public void assertMessage()
        {
            Thread.Sleep(3000);
            Assert.AreEqual("Não há dados a serem exibidos", mensagemresultado.Text);
        }
        public void closeBrowser()
        {
            driver.Quit();
        }
        public void assertZipCode()
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
