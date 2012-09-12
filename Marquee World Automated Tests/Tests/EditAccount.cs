using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marquee_World_Automated_Tests.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util;
using OpenQA.Selenium;

namespace Marquee_World_Automated_Tests.Tests
{
    [TestClass]
    public class EditAccount
    {
        [TestInitialize]
        public void InitTest()
        {
            Browser.Instance.Init();
        }

        [TestCleanup]
        public void TeardownTest()
        {
            Browser.Instance.Close();
        }
        //
        //Edit name Succesfully
        //
        [TestMethod]
        public void EditNameSuccesfully()
        {
            Account accountView = new Account();
            //Setting a different name to check after the edition
            string newname= ConfigUtil.GetString("Marquee.account.name")+" " + new Random().Next(1000);
            accountView.EditFirstName(newname);
            string aux= string.Empty;
            while (aux != "display: none;")
            {
                aux = Browser.Driver.FindElement(By.Id("input_first")).GetAttribute("Style");
            }
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("text_first"), newname));
        }
        //
        //Edit name leaving the input emtpy
        //
        [TestMethod]
        public void EditNameEmtpy()
        {
            Account accountView = new Account();
            accountView.EditFirstName("");
            //Check if it leave in blank
            Assert.AreEqual(Browser.Driver.FindElement(By.Id("input_first")).GetAttribute("Style"), "display: inline;");
            //Click on any where to change the focus from the input
            Browser.Driver.FindElement(By.Id("box_form")).Click();
            //Check if it was saved corectly
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_first"),""));
        }
        //
        //Edit long name
        //
        [TestMethod]
        public void EditlongName()
        {
            Account accountView = new Account();
            accountView.EditFirstName("loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooongname");
            //Can not check because is not checking the name size
            //Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_first"), ""));
        }
        //
        //Edit name with invalid chars
        //
        [TestMethod]
        public void EditNameInvalid()
        {
            Account accountView = new Account();
            accountView.EditFirstName("!#$%&/()=?=)(/&%&/()=?@☺☻♥♦♣♠•◘○");
            //Can not check because is not checking the name inupts
            //Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_first"), ""));
        }
        //
        //Edit Lastname Succesfully
        //
        [TestMethod]
        public void EditLastNameSuccesfully()
        {
            Account accountView = new Account();
            //Setting a different name to check after the edition
            string newname = ConfigUtil.GetString("Marquee.account.lastname") + " " + new Random().Next(1000);
            accountView.EditLasttName(newname);
            string aux = string.Empty;
            while (aux != "display: none;")
            {
                aux = Browser.Driver.FindElement(By.Id("input_last")).GetAttribute("Style");
            }
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("text_last"), newname));
        }
        //
        //Edit Lastname leaving the input emtpy
        //
        [TestMethod]
        public void EditLastNameEmtpy()
        {
            Account accountView = new Account();
            accountView.EditLasttName("");
            //Check if it leave in blank
            Assert.AreEqual(Browser.Driver.FindElement(By.Id("input_last")).GetAttribute("Style"), "display: inline;");
            //Click on any where to change the focus from the input
            Browser.Driver.FindElement(By.Id("box_form")).Click();
            //Check if it was saved corectly
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_last"), ""));
        }
        //
        //Edit long Lastname
        //
        [TestMethod]
        public void EditlongLastName()
        {
            Account accountView = new Account();
            accountView.EditLasttName("loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooongname");
            //Can not check because is not checking the name size
            //Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_last"), ""));
        }
        //
        //Edit Lastname with invalid chars
        //
        [TestMethod]
        public void EditLastNameInvalid()
        {
            Account accountView = new Account();
            accountView.EditLasttName("!#$%&/()=?=)(/&%&/()=?@☺☻♥♦♣♠•◘○");
            //Can not check because is not checking the name inupts
            //Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_last"), ""));
        }
        //
        //Edit Zip Succesfully
        //
        [TestMethod]
        public void EditZipSuccesfully()
        {
            Account accountView = new Account();
            //Setting a different name to check after the edition
            string newname = new Random().Next(10000,99999).ToString();
            accountView.Editzip(newname);
            string aux = string.Empty;
            while (aux != "display: none;")
            {
                aux = Browser.Driver.FindElement(By.Id("input_zip")).GetAttribute("Style");
            }
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("text_zip"), newname));
        }
        //
        //Edit Zip leaving the input emtpy
        //
        [TestMethod]
        public void EditZipEmtpy()
        {
            Account accountView = new Account();
            accountView.Editzip("");
            //Click on any where to change the focus from the input
            Browser.Driver.FindElement(By.Id("box_form")).Click();
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("error_zip"), "INVALID ZIP!"));
        }
        //
        //Edit long Zip
        //
        [TestMethod]
        public void EditLongZip()
        {
            Account accountView = new Account();
            accountView.Editzip("123132132132132132132132131313231321321321323213213213");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("error_zip"), "INVALID ZIP!"));
        }
        //
        //Edit Zip with invalid chars
        //
        [TestMethod]
        public void EditZipInvalid()
        {
            Account accountView = new Account();
            accountView.Editzip("!#$%&/()=?=)(/&%&/()=?@☺☻♥♦♣♠•◘○");
            //Can not check because is not checking the name inupts
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("error_zip"), "INVALID ZIP!"));
        }
        //
        //Edit Zip with Letters
        //
        [TestMethod]
        public void EditZipLetters()
        {
            Account accountView = new Account();
            accountView.Editzip("ZipCode");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("error_zip"), "INVALID ZIP!"));
        }
        //
        //Edit NewsLetter to true
        //
        [TestMethod]
        public void SuscribeToNewsLetter()
        {
            Account accountView = new Account();
            accountView.ChangeStateOfNewsLetter(true);
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.CssSelector("div#newsletter div.table_column_right span.fake_link"), "unsubscribe"));
        }
        //
        //Edit NewsLetter to false
        //
        [TestMethod]
        public void UnSuscribeToNewsLetter()
        {
            Account accountView = new Account();
            accountView.ChangeStateOfNewsLetter(false);
            string state = Browser.Driver.FindElement(By.CssSelector("div#newsletter div.table_column_right span.fake_link")).Text;
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.CssSelector("div#newsletter div.table_column_right span.fake_link"), "subscribe"));
        }
        //
        //Edit Artist name succesfully
        //
        [TestMethod]
        public void EditArtistNameSuccesfully()
        {
            string toedit = "band";
            Account accountView = new Account();
            //Setting a different name to check after the edition
            string newname = ConfigUtil.GetString("Marquee.register.artist.name") + new Random().Next(10000, 99999);
            accountView.EditArtistInfo(newname,toedit);
            string aux = string.Empty;
            while (aux != "display: none;")
            {
                aux = Browser.Driver.FindElement(By.Id("input_"+toedit)).GetAttribute("Style");
            }
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("text_"+toedit), newname));
        }
        //
        //Edit Artist leaving the field name empty
        //
        [TestMethod]
        public void EditArtistNameEmtpy()
        {
            string toedit = "band";
            Account accountView = new Account();
            accountView.EditArtistInfo("",toedit);
            //Click on any where to change the focus from the input
            Browser.Driver.FindElement(By.Id("box_form")).Click();
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_"+toedit), ""));
        }
        //
        //Edit Artist with a long name
        //
        [TestMethod]
        public void EditLongArtistName()
        {
            string toedit = "band";
            Account accountView = new Account();
            string name = "123132132132132132132132131313231321321321323213213213";
            accountView.EditArtistInfo(name,toedit);
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_"+toedit), name));
        }
        //
        //Edit Artist name with invalid chars
        //
        [TestMethod]
        public void EditArtistNameInvalid()
        {
            string toedit="band";
            Account accountView = new Account();
            string name = "!#$%&/()=?=)(/&%&/()=?@☺☻♥♦♣♠•◘○";
            accountView.EditArtistInfo(name,toedit);
            //Can not check because is not checking the name inupts
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_"+toedit), name));
        }
        //
        //Edit Artist website succesfully
        //
        [TestMethod]
        public void EditArtistWebsiteSuccesfully()
        {
            string toedit = "website";
            Account accountView = new Account();
            //Setting a different name to check after the edition
            string newname = ConfigUtil.GetString("Marquee.register.artist.website") + new Random().Next(10000, 99999);
            accountView.EditArtistInfo(newname,toedit);
            Browser.Instance.Wait(5000);
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("text_"+toedit), newname));
        }
        //
        //Edit Artist leaving the field website empty
        //
        [TestMethod]
        public void EditArtistWebsiteEmtpy()
        {
            string toedit = "website";
            Account accountView = new Account();
            accountView.EditArtistInfo("",toedit);
            //Click on any where to change the focus from the input
            Browser.Driver.FindElement(By.Id("box_form")).Click();
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_"+toedit), ""));
        }
        //
        //Edit Artist with a long website
        //
        [TestMethod]
        public void EditLongArtistWebsite()
        {
            string toedit = "website";
            Account accountView = new Account();
            string name = "123132132132132132132132131313231321321321323213213213";
            accountView.EditArtistInfo(name,toedit);
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_"+toedit), name));
        }
        //
        //Edit Artist website with invalid chars
        //
        [TestMethod]
        public void EditArtistWebsiteInvalid()
        {
            string toedit = "website";
            Account accountView = new Account();
            string name = "!#$%&/()=?=)(/&%&/()=?@☺☻♥♦♣♠•◘○";
            accountView.EditArtistInfo(name,toedit);
            //Can not check because is not checking the name inupts
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_"+toedit), name));
        }
        //
        //Edit Artist facebook succesfully
        //
        [TestMethod]
        public void EditArtistFacebookSuccesfully()
        {
            string toedit = "facebook";
            Account accountView = new Account();
            //Setting a different name to check after the edition
            string newname = ConfigUtil.GetString("Marquee.register.artist.facebook") + new Random().Next(10000, 99999);
            accountView.EditArtistInfo(newname,toedit);
            Browser.Instance.Wait(5000);
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("text_"+toedit), newname));
        }
        //
        //Edit Artist leaving the field facebook empty
        //
        [TestMethod]
        public void EditArtistFacebookEmtpy()
        {
            string toedit = "facebook";
            Account accountView = new Account();
            accountView.EditArtistInfo("", toedit);
            //Click on any where to change the focus from the input
            Browser.Driver.FindElement(By.Id("box_form")).Click();
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_" + toedit), ""));
        }
        //
        //Edit Artist with a long facebook
        //
        [TestMethod]
        public void EditLongArtistFacebook()
        {
            string toedit = "facebook";
            Account accountView = new Account();
            string name = "123132132132132132132132131313231321321321323213213213";
            accountView.EditArtistInfo(name, toedit);
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_" + toedit), name));
        }
        //
        //Edit Artist facebook with invalid chars
        //
        [TestMethod]
        public void EditArtistFacebookInvalid()
        {
            string toedit = "facebook";
            Account accountView = new Account();
            string name = "!#$%&/()=?=)(/&%&/()=?@☺☻♥♦♣♠•◘○";
            accountView.EditArtistInfo(name, toedit);
            //Can not check because is not checking the name inupts
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_" + toedit), name));
        }
        //
        //Edit Artist myspace succesfully
        //
        [TestMethod]
        public void EditArtistMySpaceSuccesfully()
        {
            string toedit = "myspace";
            Account accountView = new Account();
            //Setting a different name to check after the edition
            string newname = ConfigUtil.GetString("Marquee.register.artist.myspace") + new Random().Next(10000, 99999);
            accountView.EditArtistInfo(newname, toedit);
            Browser.Instance.Wait(5000);
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("text_" + toedit), newname));
        }
        //
        //Edit Artist leaving the field myspace empty
        //
        [TestMethod]
        public void EditArtistMySpaceEmtpy()
        {
            string toedit = "myspace";
            Account accountView = new Account();
            accountView.EditArtistInfo("", toedit);
            //Click on any where to change the focus from the input
            Browser.Driver.FindElement(By.Id("box_form")).Click();
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_" + toedit), ""));
        }
        //
        //Edit Artist with a long myspace
        //
        [TestMethod]
        public void EditLongArtistMySpace()
        {
            string toedit = "myspace";
            Account accountView = new Account();
            string name = "123132132132132132132132131313231321321321323213213213";
            accountView.EditArtistInfo(name, toedit);
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_" + toedit), name));
        }
        //
        //Edit Artist myspace with invalid chars
        //
        [TestMethod]
        public void EditArtistMySpaceInvalid()
        {
            string toedit = "myspace";
            Account accountView = new Account();
            string name = "!#$%&/()=?=)(/&%&/()=?@☺☻♥♦♣♠•◘○";
            accountView.EditArtistInfo(name, toedit);
            //Can not check because is not checking the name inupts
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_" + toedit), name));
        }
        //
        //Edit Artist twitter succesfully
        //
        [TestMethod]
        public void EditArtistTwitterSuccesfully()
        {
            string toedit = "twitter";
            Account accountView = new Account();
            //Setting a different name to check after the edition
            string newname = ConfigUtil.GetString("Marquee.register.artist.myspace") + new Random().Next(10000, 99999);
            accountView.EditArtistInfo(newname, toedit);
            Browser.Instance.Wait(5000);
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("text_" + toedit), newname));
        }
        //
        //Edit Artist leaving the field twitter empty
        //
        [TestMethod]
        public void EditArtistTwitterEmtpy()
        {
            string toedit = "twitter";
            Account accountView = new Account();
            accountView.EditArtistInfo("", toedit);
            //Click on any where to change the focus from the input
            Browser.Driver.FindElement(By.Id("box_form")).Click();
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_" + toedit), ""));
        }
        //
        //Edit Artist with a long myspace
        //
        [TestMethod]
        public void EditLongArtistTwitter()
        {
            string toedit = "twitter";
            Account accountView = new Account();
            string name = "123132132132132132132132131313231321321321323213213213";
            accountView.EditArtistInfo(name, toedit);
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_" + toedit), name));
        }
        //
        //Edit Artist twitter with invalid chars
        //
        [TestMethod]
        public void EditArtistTwitterInvalid()
        {
            string toedit = "twitter";
            Account accountView = new Account();
            string name = "!#$%&/()=?=)(/&%&/()=?@☺☻♥♦♣♠•◘○";
            accountView.EditArtistInfo(name, toedit);
            //Can not check because is not checking the name inupts
            Assert.IsFalse(Browser.Instance.IsTextPresent(By.Id("text_" + toedit), name));
        }
        //
        //Edit Email Account
        //
        [TestMethod]
        public void EditEmailSuccesfully()
        {
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            Account accountView = new Account();
            Browser.Instance.TakeScreenshot("EditEmailSuccesfully");
            accountView.EditEmail(email,ConfigUtil.GetString("Marquee.user.artist"),true);
            // Unable to validate this test case because there is a bug when trying to change the email account
            Browser.Instance.TakeScreenshot("EditEmailSuccesfully");
            Assert.IsTrue(false);
        }
        //
        //Edit Email Account Empty
        //
        [TestMethod]
        public void EditEmailEmpty()
        {
            string email = ConfigUtil.GetString("Marquee.register.email").Replace("@", "+" + (new Random()).Next(1000).ToString() + "@");
            Account accountView = new Account();
            Browser.Instance.TakeScreenshot("EditEmailEmpty");
            accountView.EditEmail("", ConfigUtil.GetString("Marquee.user.artist"), true);
            Browser.Instance.TakeScreenshot("EditEmailEmpty");
            Assert.IsTrue(Browser.Instance.IsElementPresent(By.Name("email1")));
        }
        //
        //Edit Email Account Long Name
        //
        [TestMethod]
        public void EditEmailLongName()
        {
            string email = "emailtestemailtestemailtestemailtestemailtestemailtestemailtest@email.com";
            Account accountView = new Account();
            accountView.EditEmail(email,ConfigUtil.GetString("Marquee.user.artist"), false);
            //Unable to validate assert because there is a bug when validating the lenght of "New Email" field"
            Browser.Instance.TakeScreenshot("EditEmailLongName");
            Assert.AreEqual(Browser.Driver.FindElement(By.Name("email1")).GetAttribute("value").Length, 60);
        }
        //
        //Edit Email Account Invalid Name
        //
        [TestMethod]
        public void EditEmailInvalidName()
        {
            string email = "!#$%#$%$@email.com";
            Account accountView = new Account();
            Browser.Instance.TakeScreenshot("EditEmailInvalidName");
            accountView.EditEmail(email, ConfigUtil.GetString("Marquee.user.artist"), true);
            // Unable to validate this test case because there is a bug when trying to enter invalid characters to the email account
            Browser.Instance.TakeScreenshot("EditEmailInvalidName");
            Assert.IsTrue(false);
        }
        //
        //Edit Email Account Same New Email Name
        //
        [TestMethod]
        public void EditEmailAccountSameNewEmailName()
        {
            string email = "cpecora+199@makingsense.com";
            Account accountView = new Account();
            Browser.Instance.TakeScreenshot("EditEmailSameNewEmailName");
            accountView.EditEmail(email, ConfigUtil.GetString("Marquee.user.artist"), true);
            // Unable to validate this test case because there is a bug when trying to enter same email name
            Browser.Instance.TakeScreenshot("EditEmailSameNewEmailName");
            Assert.IsTrue(false);
        }
        //
        //Edit Current Password Field Succesfully
        //
        [TestMethod]
        public void EditCurrentPasswordFieldSuccesfully()
        {
            string currentpassword = ConfigUtil.GetString("Marquee.pass.artist");
            string password = ConfigUtil.GetString("Marquee.account.password");
            Account accountView = new Account();
            Browser.Instance.TakeScreenshot("EditCurrentPasswordFieldSuccesfully");
            accountView.EditPassword(password, currentpassword, currentpassword, true);
            Browser.Instance.TakeScreenshot("EditCurrentPasswordFieldSuccesfully");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.Id("med_box"),"Your password has been updated. Please make a note!"));
        }
        //
        //Edit Current Password Field Empty
        //
        [TestMethod]
        public void EditCurrentPasswordFieldEmpty()
        {
            string currentpassword = "";
            string password = ConfigUtil.GetString("Marquee.account.password");
            Account accountView = new Account();
            Browser.Instance.TakeScreenshot("EditCurrentPasswordFieldEmpty");
            accountView.EditPassword(currentpassword, password, password, true);
            Browser.Instance.TakeScreenshot("EditCurrentPasswordFieldEmpty");
            Assert.IsTrue(Browser.Instance.IsElementPresent(By.Name("current")));
        }
        //
        //Edit Current Password Field Long Characters
        //
        [TestMethod]
        public void EditCurrentPasswordFieldLongCharacters()
        {
            string currentpassword = "carlitos1carlitos1carlitos1carlitos1carlitos1carlitos1carlitos1carlitos1";
            string password = ConfigUtil.GetString("Marquee.account.password");
            Account accountView = new Account();
            accountView.EditPassword(currentpassword, password, password, false);
            Browser.Instance.TakeScreenshot("EditCurrentPasswordFieldLongCharacters");
            Assert.AreEqual(Browser.Driver.FindElement(By.Name("current")).GetAttribute("value").Length, 20);
        }
        //
        //Edit Current Password Field Invalid Characters
        //
        [TestMethod]
        public void EditCurrentPasswordFieldInvalidCharacters()
        {
            string currentpassword = ConfigUtil.GetString("Marquee.pass.artist");
            string password = "%&/()==)(/&%$%^+/()(($%";
            Account accountView = new Account();
            Browser.Instance.TakeScreenshot("EditCurrentPasswordFieldInvalidCharacters");
            accountView.EditPassword(currentpassword, password, password, true);
            Browser.Instance.TakeScreenshot("EditCurrentPasswordFieldInvalidCharacters");
            Assert.IsTrue(Browser.Instance.IsTextPresent(By.XPath("/html/body/div/div/section/p[2]"), "Please enter a valid password!"));
        }
    }
}
