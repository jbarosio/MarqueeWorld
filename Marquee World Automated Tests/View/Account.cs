using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util;
using OpenQA.Selenium;
using Marquee_World_Automated_Tests.Tests;

namespace Marquee_World_Automated_Tests.View
{
    public class Account
    {
        public void EditLasttName(string lastname)
        {
            Login login = new Login();
            login.LoginSuccesfullyGenearlUser();
            Browser.Driver.FindElement(By.Id("last")).Click();
            Browser.Driver.FindElement(By.Id("input_last")).Clear();
            IAlert alert = Browser.Driver.SwitchTo().Alert();
            alert.Accept();
            Browser.Driver.FindElement(By.Id("input_last")).SendKeys(lastname);
            Browser.Driver.FindElement(By.Id("input_last")).SendKeys(Keys.Enter);
        }
        public void EditFirstName(string name)
        {
            Login login = new Login();
            login.LoginSuccesfullyGenearlUser();
            Browser.Driver.FindElement(By.Id("first")).Click();
            Browser.Driver.FindElement(By.Id("input_first")).Clear();
            IAlert alert = Browser.Driver.SwitchTo().Alert();
            alert.Accept();
            Browser.Driver.FindElement(By.Id("input_first")).SendKeys(name);
            Browser.Driver.FindElement(By.Id("input_first")).SendKeys(Keys.Enter);
        }
        public void Editzip(string zip)
        {
            Login login = new Login();
            login.LoginSuccesfullyGenearlUser();
            Browser.Driver.FindElement(By.Id("zip")).Click();
            Browser.Driver.FindElement(By.Id("input_zip")).Clear();
            Browser.Driver.FindElement(By.Id("input_zip")).SendKeys(zip);
            Browser.Driver.FindElement(By.Id("input_zip")).SendKeys(Keys.Enter);
        }
        public void ChangeStateOfNewsLetter(bool news)
        {
            Login login = new Login();
            login.LoginSuccesfullyGenearlUser();
            string state = Browser.Driver.FindElement(By.CssSelector("div#newsletter div.table_column_right span.fake_link")).Text;
            if (news)
            {
                if (state == "subscribe")
                {
                    Browser.Driver.FindElement(By.Id("newsletter")).Click();
                }
            }
            else
            {
                if (state == "unsubscribe")
                {
                    Browser.Driver.FindElement(By.Id("newsletter")).Click();
                }
            }
        }
        public void EditArtistInfo(string name,string toedit)
        {
            Login login = new Login();
            login.LoginSuccesfullyArtistUser();
            Browser.Driver.FindElement(By.Id(toedit)).Click();
            Browser.Driver.FindElement(By.Id("input_"+toedit)).Clear();
            IAlert alert = Browser.Driver.SwitchTo().Alert();
            alert.Accept();
            Browser.Driver.FindElement(By.Id("input_"+toedit)).SendKeys(name);
            Browser.Driver.FindElement(By.Id("input_"+toedit)).SendKeys(Keys.Enter);
            Browser.Instance.Wait(2000);
        }
        public void EditEmail(string newemail, string confirmemail, bool submit)
        {
            Login login = new Login();
            login.LoginSuccesfullyArtistUser();
            Browser.Driver.FindElement(By.Id("text_email")).Click();
            Browser.Instance.Wait(By.Name("email1"));
            Browser.Driver.FindElement(By.Name("email1")).SendKeys(newemail);
            Browser.Driver.FindElement(By.Name("email2")).SendKeys(confirmemail);
            if (submit)
                Browser.Driver.FindElement(By.Name("submit")).Click();

        }
        public void EditPassword(string currentpassword, string password, string confirmpassword, bool submit)
        {
            Login login = new Login();
            login.LoginSuccesfullyArtistUser();
            Browser.Driver.FindElement(By.CssSelector("div#password div.table_column_middle")).Click();
            Browser.Instance.Wait(By.Name("current"));
            Browser.Driver.FindElement(By.Name("current")).SendKeys(currentpassword);
            Browser.Driver.FindElement(By.Name("password1")).SendKeys(password);
            Browser.Driver.FindElement(By.Name("password2")).SendKeys(confirmpassword);
            if (submit)
                Browser.Driver.FindElement(By.Name("submit")).Click();

        }
    }
}
