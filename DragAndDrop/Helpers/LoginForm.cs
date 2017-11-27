using System;
using OpenQA.Selenium;


namespace DragAndDrop
{
    class LoginForm
    {
        private IWebDriver driver;

        private By signIn = By.XPath(String.Format("//a[contains(text(), 'Signin')]"));
        private By loginEdit = By.XPath("//div[@id='login']/form[@id='load_form']//input[@name='username']");
        private By passwordEdit = By.XPath("//div[@id='login']/form[@id='load_form']//input[@name='password']");
        private By buutonSubmit = By.XPath("//div[@id='login']/form[@id='load_form']//input[@value='Submit']");

        public LoginForm(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Login(string login, string password)
        {
            driver.FindElement(signIn).Click();
            driver.FindElement(loginEdit).SendKeys(login);
            driver.FindElement(passwordEdit).SendKeys(password);
            driver.FindElement(buutonSubmit).Click();
        }
    }
}
