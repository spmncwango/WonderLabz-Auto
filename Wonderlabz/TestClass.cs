using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Wonderlabz
{
    [TestFixture]
    public class TestClass
    {
        IWebDriver driver = new ChromeDriver();
        string url = "https://rahulshettyacademy.com/AutomationPractice/";

      
        [Test]
        public void RadioButtons()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IList<IWebElement> oRadioButton = (IList<IWebElement>)wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible((By)driver.FindElement(By.Name("RadioButton"))));
            bool bValue = false;
            oRadioButton.ElementAt(3).Click();
            bValue = (oRadioButton.ElementAt(1).Selected&& oRadioButton.ElementAt(2).Selected);
            if (bValue == false)
            {
                Console.WriteLine("Only radio button 3 is clicked");
            }
            oRadioButton.ElementAt(1).Click();
            bValue = (oRadioButton.ElementAt(0).Selected && oRadioButton.ElementAt(2).Selected);
            if (bValue == false)
            {
                Console.WriteLine("Only radio button 2 is clicked");
            }
        }
        [Test]
        public void Suggestion()
        {
            driver.Url = url;  
            IWebElement txtField = driver.FindElement(By.Id("autocomplete"));
            txtField.SendKeys("South");
            SelectElement select = new SelectElement(txtField);
            select.SelectByValue("South Africa");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            txtField.Clear();
            txtField.SendKeys("Republic");
        }
        [Test]
        public void CheckBox()
        {
            driver.Url = url;
            IWebElement checkBox1 = driver.FindElement(By.Id("checkBoxOption1"));
            IWebElement checkBox2 = driver.FindElement(By.Id("checkBoxOption2"));
            IWebElement checkBox3 = driver.FindElement(By.Id("checkBoxOption3"));
            checkBox1.Click();
            checkBox2.Click();
            checkBox3.Click();

            if (checkBox1.Selected&& checkBox2.Selected&& checkBox3.Selected)
            {
                Console.WriteLine("All check box selected");
                
            }
            checkBox1.Click();
            if (checkBox2.Selected && checkBox3.Selected)
            {
                Console.WriteLine("check box 2 and 3 selected");
            }
        }

        [Test]
        public void ShowHide()
        {
            Actions actions = new Actions(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = url;
            IWebElement showBtn = driver.FindElement(By.Id("show-textbox"));
            IWebElement hideBtn = driver.FindElement(By.Id("hide-textbox"));
            IWebElement txtbox = driver.FindElement(By.Id("displayed-text"));
            actions.MoveToElement(hideBtn);
            actions.Perform();
            hideBtn.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            if (!txtbox.Displayed)
            {
                Console.WriteLine("textbox is hidden");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            }

            showBtn.Click();
            if (txtbox.Displayed)
            {
                Console.WriteLine("textbox is not hidden");
            }


        }
        [Test]
        public void WebTable()
        {
            driver.Url = url;
            IWebElement btn1 = driver.FindElement(By.XPath("/html/body/div[@id='abId0.3628651852531759']/div[@id='abId0.31869495696029126']/fieldset[2]/div[@class='tableFixHead']/table[@id='product']/tbody/tr[1]/td[1]"));
            string txt1 = btn1.GetAttribute("value");


        }
        [Test]
        public void iFrame()
        {
            driver.Url = url;
            Actions actions = new Actions(driver);
            IWebElement frame=driver.FindElement(By.TagName("iframe"));
            actions.MoveToElement(frame);
            actions.Perform();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            int count = driver.FindElements(By.TagName("iframe")).Count();
            if (count == 0)
            {
                Console.WriteLine("No iframe");         
            }
            else
            {
                Console.WriteLine("iframe present");

            }


        }
    }
   

   
}
