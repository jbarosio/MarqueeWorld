﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Marquee_World_Automated_Tests.View;
using OpenQA.Selenium;

namespace Marquee_World_Automated_Tests.Tests
{
    [TestClass]
    public class Login
    {
        [TestInitialize]
        public void InitTest()
        {
            Browser.Instance.Init();
        }

        [TestCleanup]
        public void TeardownTest(){
            Browser.Instance.Close();
        }

        //
        //Make a log in with a valid Artist
        //
        [TestMethod]
        public void LoginSuccesfullyArtistUser()
        {
            Home HomePage = new Home();
            HomePage.Login(ConfigUtil.GetString("Marquee.user.artist"), ConfigUtil.GetString("Marquee.pass.artist"));
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.CssSelector("div#login_hp a[href='logout.php']"), "Log Out"));
        }
        //
        //Make a log in with a valid General user
        //
        [TestMethod]
        public void LoginSuccesfullyGenearlUser()
        {
            Home HomePage = new Home();
            HomePage.Login(ConfigUtil.GetString("Marquee.user.general"), ConfigUtil.GetString("Marquee.pass.general"));
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.CssSelector("div#login_hp a[href='logout.php']"), "Log Out"));
        }
        //
        //
        //
        [TestMethod]
        public void LoginPasswordEmpty()
        {
            Home HomePage = new Home();
            HomePage.Login(ConfigUtil.GetString("Marquee.user.general"), "");
            Assert.IsTrue(Browser.Instance.IsElementPresent(By.Id("")));
        }
        //
        //
        //
        [TestMethod]
        public void LoginUserEmpty()
        {
            Home HomePage = new Home();
            HomePage.Login("", ConfigUtil.GetString("Marquee.pass.general"));
            Assert.IsTrue(Browser.Instance.IsElementPresent(By.Id("")));
        }
        //
        //
        //
        [TestMethod]
        public void LoginUserAndPasswordEmpty()
        {
            Home HomePage = new Home();
            HomePage.Login("", "");
            Assert.IsTrue(Browser.Instance.IsElementPresent(By.Id("")));
        }
        //
        //
        //
        [TestMethod]
        public void LoginGeneralPasswordWrong()
        {
            Home HomePage = new Home();
            HomePage.Login(ConfigUtil.GetString("Marquee.user.general"), "WrongPassword");
            Assert.IsTrue(Browser.Instance.IsElementPresent(By.Id("")));
        }
        //
        //
        //
        [TestMethod]
        public void LoginGeneralUserWrong()
        {
            Home HomePage = new Home();
            HomePage.Login("UserName@worng.com", ConfigUtil.GetString("Marquee.pass.general"));
            Assert.IsTrue(Browser.Instance.IsElementPresent(By.Id("")));
        }
        //
        //
        //
        [TestMethod]
        public void LoginArtistPasswordWrong()
        {
            Home HomePage = new Home();
            HomePage.Login(ConfigUtil.GetString("Marquee.user.artist"), "WrongPassword");
            Assert.IsTrue(Browser.Instance.IsElementPresent(By.Id("")));
        }
        //
        //
        //
        [TestMethod]
        public void LoginArtistUserWrong()
        {
            Home HomePage = new Home();
            HomePage.Login("UserName@worng.com", ConfigUtil.GetString("Marquee.pass.artist"));
            Assert.IsTrue(Browser.Instance.IsElementPresent(By.Id("")));
        }        
    }
}
