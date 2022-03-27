using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace VMS.Keystone.UIAutomationLibrary
{
    public class UIFactoryClass
    {
        public IWebDriver driver = null;

        public UIFactoryClass()
        {
            driver = new ChromeDriver(@"C:\1ProjectRelated\ForTestVSTSProjects");
        }

        public void LaunchAndNavigatetoURL()
        {
            driver.Navigate().GoToUrl("https://demosite.executeautomation.com/index.html?UserName=&Password=&Login=Login");
            driver.Manage().Window.Maximize();
        }

        public void FillUserForm()
        {
            UIControlsActions.SetDropDown(driver, "TitleId", "Id", "Mr.");
            UIControlsActions.SetTextInTextBox(driver, "Initial", "Name", "SD");
            UIControlsActions.SetTextInTextBox(driver, "FirstName", "Name", "Swarup");
            UIControlsActions.SetTextInTextBox(driver, "MiddleName", "Name", "Dukuria");
            UIControlsActions.SetRadioButton(driver, "Female", "Name");
            UIControlsActions.SetCheckBox(driver, "Hindi", "Name");
            UIControlsActions.SetCheckBox(driver, "english", "Name");
        }

        public void FillUserPopUpForm()
        {
            UIControlsActions.SetDropDown(driver, "TitleId", "Id", "Mr.");
            UIControlsActions.SetTextInTextBox(driver, "Initial", "Name", "SD");
            UIControlsActions.SetTextInTextBox(driver, "FirstName", "Name", "Swarup");
            UIControlsActions.SetTextInTextBox(driver, "MiddleName", "Name", "Dukuria");
            UIControlsActions.SetTextInTextBox(driver, "LastName", "Name", "SwarupLastName");
            UIControlsActions.SetDropDown(driver, "Country", "Id", "India");
        }

        public void OpenPopUpFormAndFillUserForm()
        {
            string mainWindowHandle = driver.CurrentWindowHandle;
            UIControlsActions.ClickLink(driver, "HtmlPopup");
            Thread.Sleep(4000);
            var windowHandles = driver.WindowHandles;
            foreach (var handle in windowHandles)
            {
                if (handle != mainWindowHandle)
                {
                    driver.SwitchTo().Window(handle);
                    FillUserPopUpForm();
                    Thread.Sleep(4000);

                    //Just for fun going back to mainWindowHandle
                    driver.SwitchTo().Window(mainWindowHandle);
                    FillUserForm();
                }
            }

        }

        public void SaveForm()
        {
            UIControlsActions.ClickButton(driver, "Save", "Name");
        }

        public void GenerateAlertAndHandle(string actionToPerform, out string alertValue)
        {
            UIControlsActions.ClickButton(driver, "generate", "Name");
            if (actionToPerform == "OK")
            {
                driver.SwitchTo().Alert().Accept();              
            }
            else
            {
                driver.SwitchTo().Alert().Dismiss();
            }
            alertValue = driver.SwitchTo().Alert().Text;
        }

        public void ClickOnAlertButton()
        {
            driver.SwitchTo().Alert().Accept();
        }

        public void CloseBrowser()
        {
            driver.Quit();
            Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");

            foreach (var chromeDriverProcess in chromeDriverProcesses)
            {
                chromeDriverProcess.Kill();
            }
        }
    }
}
