using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium.UIAutomationLibrary
{
    public class UIFactory
    {
        public IWebDriver driver = null;

        public UIFactory()
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
            UIControlsAction.SetDropDown(driver, "TitleId", "Id", "Mr.");
            UIControlsAction.SetTextInTextBox(driver, "Initial", "Name", "SD");
            UIControlsAction.SetTextInTextBox(driver, "FirstName", "Name", "Swarup");
            UIControlsAction.SetTextInTextBox(driver, "MiddleName", "Name", "Dukuria");
            UIControlsAction.SetRadioButton(driver, "Female", "Name");
            UIControlsAction.SetCheckBox(driver, "Hindi", "Name");
            UIControlsAction.SetCheckBox(driver, "english", "Name");
        }

        public void FillUserPopUpForm()
        {
            UIControlsAction.SetDropDown(driver, "TitleId", "Id", "Mr.");
            UIControlsAction.SetTextInTextBox(driver, "Initial", "Name", "SD");
            UIControlsAction.SetTextInTextBox(driver, "FirstName", "Name", "Swarup");
            UIControlsAction.SetTextInTextBox(driver, "MiddleName", "Name", "Dukuria");
            UIControlsAction.SetTextInTextBox(driver, "LastName", "Name", "SwarupLastName");
            UIControlsAction.SetDropDown(driver, "Country", "Id", "India");
        }

        public void OpenPopUpFormAndFillUserForm()
        {
            string mainWindowHandle = driver.CurrentWindowHandle;
            UIControlsAction.ClickLink(driver, "HtmlPopup");
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
            UIControlsAction.ClickButton(driver, "Save", "Name");
        }

        public void GenerateAlertAndHandle(string actionToPerform, out string alertValue)
        {
            UIControlsAction.ClickButton(driver, "generate", "Name");
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
