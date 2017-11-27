using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace DragAndDrop
{
    class PageHelpers
    {
        private IWebDriver driver;
        private By sourceBlock = By.Id("draggable");
        private By targetBlock = By.Id("droppable");
        private By defaultFunctionality = By.XPath("//a[contains(text(), 'Default functionality')]");
        private By targetBlockText = By.XPath("//*[@id='droppable']/p");
        private By imageDropable = By.XPath("//img[@src=\"images/droppable.jpg\"]");

        public PageHelpers(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void DragAndDrop()
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(defaultFunctionality));
            driver.SwitchTo().Frame(0);
            Actions actions = new Actions(driver);
            actions.DragAndDrop(driver.FindElement(sourceBlock), driver.FindElement(targetBlock)).Perform();
        }

        public string GetDragAndDropResult()
        {
            return driver.FindElement(targetBlockText).Text;
        }

        public void OpenDroppablePage()
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(imageDropable));
            driver.FindElement(imageDropable).Click();
        }
    }
}
