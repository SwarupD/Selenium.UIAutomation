 using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Selenium.UIAutomationLibrary;

namespace VMS.Keystone.UIAutomationTests
{
    [TestClass]
    public class UnitTest1
    {
        UIFactory factoryClass = new UIFactory();

        [TestMethod]
        public void VerifyUserFormFilled()
        {
            try
            {
                factoryClass.LaunchAndNavigatetoURL();

                factoryClass.FillUserForm();
                factoryClass.SaveForm();
                //Verification pending
            }
            finally
            {
                factoryClass.CloseBrowser();
            }
        }

        [TestMethod]
        public void VerifyPopupFormFilled()
        {
            try
            {
                factoryClass.LaunchAndNavigatetoURL();

                factoryClass.OpenPopUpFormAndFillUserForm();

                factoryClass.FillUserForm();
            }
            finally
            {
                factoryClass.CloseBrowser();
            }
        }

        [TestMethod]
        public void VerifyAlertPopAndClickOK()
        {
            string alertValue = string.Empty;
            try
            {
                factoryClass.LaunchAndNavigatetoURL();

                factoryClass.GenerateAlertAndHandle("OK", out alertValue);
                Assert.AreEqual("You pressed OK!", alertValue);
                factoryClass.ClickOnAlertButton();

                factoryClass.GenerateAlertAndHandle("Cancel", out alertValue);
                Assert.AreEqual("You pressed Cancel!", alertValue);
                factoryClass.ClickOnAlertButton();
            }
            finally
            {
                factoryClass.CloseBrowser();
            }
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            
        }
    }
}
