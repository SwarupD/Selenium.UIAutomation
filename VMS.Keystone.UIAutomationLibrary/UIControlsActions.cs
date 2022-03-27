using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace VMS.Keystone.UIAutomationLibrary
{
    public class UIControlsActions
    {
        public static void SetTextInTextBox(IWebDriver driver, string elementValue, string identifierType, string value)
        {
            IWebElement initialTextBox = null;

            if (identifierType == "Id")
            {
                if (driver.FindElement(By.Id(elementValue)).Displayed)
                {
                    initialTextBox = driver.FindElement(By.Id(elementValue));
                    initialTextBox.SendKeys(value);
                }
            }
            if (identifierType == "Name")
            {
                if (driver.FindElement(By.Name(elementValue)).Displayed)
                {
                    initialTextBox = driver.FindElement(By.Name(elementValue));
                    initialTextBox.SendKeys(value);
                }
            }
        }

        public static void SetDropDown(IWebDriver driver, string elementValue, string identifierType, string value)
        {
            if (identifierType == "Id")
            {
                if (driver.FindElement(By.Id(elementValue)).Displayed)
                {
                    new SelectElement(driver.FindElement(By.Id(elementValue))).SelectByText(value);
                }                
            }
            if (identifierType == "Name")
            {
                if (driver.FindElement(By.Name(elementValue)).Displayed)
                {
                    new SelectElement(driver.FindElement(By.Name(elementValue))).SelectByText(value);
                }                
            }
        }

        public static void SetRadioButton(IWebDriver driver, string elementValue, string identifierType)
        {
            IWebElement rbGender = null;

            if (identifierType == "Id")
            {
                if (driver.FindElement(By.Id(elementValue)).Displayed)
                {
                    rbGender = driver.FindElement(By.Id(elementValue));
                }                

                if (!rbGender.Selected)
                { rbGender.Click(); }
            }
            if (identifierType == "Name")
            {
                if (driver.FindElement(By.Name(elementValue)).Displayed)
                {
                    rbGender = driver.FindElement(By.Name(elementValue));
                }               

                if (!rbGender.Selected)
                { rbGender.Click(); }
            }
        }

        public static void SetCheckBox(IWebDriver driver, string elementValue, string identifierType)
        {
            IWebElement cbLanguageKnown = null;

            if (identifierType == "Id")
            {
                if (driver.FindElement(By.Id(elementValue)).Displayed)
                {
                    cbLanguageKnown = driver.FindElement(By.Id(elementValue));

                    cbLanguageKnown.Click();
                }
                
            }
            if (identifierType == "Name")
            {
                if (driver.FindElement(By.Name(elementValue)).Displayed)
                {
                    cbLanguageKnown = driver.FindElement(By.Name(elementValue));

                    cbLanguageKnown.Click();
                }
            }
        }

        public static void ClickButton(IWebDriver driver, string elementValue, string identifierType)
        {
            driver.FindElement(By.Name(elementValue)).Click();
        }

        public static void ClickLink(IWebDriver driver, string elementValue)
        {
            driver.FindElement(By.LinkText(elementValue)).Click();
        }
    }
}
