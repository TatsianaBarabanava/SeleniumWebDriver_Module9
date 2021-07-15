﻿using OpenQA.Selenium;

namespace SeleniumWebDriver
{
    public class BaseMailPage : BasePage
    {
        private static readonly By inboxLinkXpath = By.XPath("//span[text()='Входящие']");
        public BaseElement inboxLink = new BaseElement(inboxLinkXpath);
        public BaseElement sendLink = new BaseElement(By.XPath("//span[text()='Отправленные']"));
        public BaseElement deletedLink = new BaseElement(By.XPath("//span[text()='Удалённые']"));
        public BaseElement draftLink = new BaseElement(By.XPath("//span[text()='Черновики']"));
        public BaseElement resendLink = new BaseElement(By.XPath("//div[@title='Переслать (f)']"));
        public BaseElement createDraftIcon = new BaseElement(By.XPath("//span[text()='Создать шаблон']"));
        public BaseElement mailTopicField = new BaseElement(By.XPath("//span[contains(@class,'mail-MessageSnippet-Item_subject')]"));
        public BaseElement contentField = new BaseElement(By.XPath("//span[contains(@class,'mail-MessageSnippet-Item_firstline')]"));
        public BaseElement sendButton = new BaseElement(By.XPath("//button//div[contains(@class,'ComposeSendButton-Text')]"));
        public BaseElement sendNotification = new BaseElement(By.XPath("//span[text()='Письмо отправлено']"));
        public BaseElement checkboxEmailsList = new BaseElement(By.XPath("//div[@class=' js-messages-item-checkbox mail-MessageSnippet-CheckboxNb-Container']"));

        protected BaseMailPage(By TitleLocator, string Title) : base(TitleLocator, Title)
        {
            titleLocator = TitleLocator;
            title = titleForm = Title;
            WaitIsOpen();
        }

        public BaseMailPage() : base(inboxLinkXpath, "Inbox Mail")
        { 
        }

        public void SelectEmailByNumber(int Number, string Email)
        {
            GetRecepientFieldXPath(Email).WaitForIsVisible(); ;
            checkboxEmailsList.GetElements()[Number].Click();
        }

        private BaseElement GetRecepientFieldXPath(string Email)
        {
            return new BaseElement(By.XPath("//span[contains(@title,'" + Email + "')]"));
        }

        public string GetTextFromRecepientField(string Email)
        {
            GetRecepientFieldXPath(Email).WaitForIsVisible();
            return GetRecepientFieldXPath(Email).GetText();
        }

        public string GetTextFromMailTopicField()
        {
            return mailTopicField.GetText();
        }

        public string GetTextFromContentField()
        {
            return contentField.GetText();
        }

        public void ClickOnSendButtonWithActions()
        {
            sendButton.ClickWithAction();
            sendNotification.WaitForIsVisible();
        }
        
        public void ClickOnRecepientField(string Email)
        {
            GetRecepientFieldXPath(Email).WaitForIsVisible();
            GetRecepientFieldXPath(Email).Click();
        }

        public DeletePage ClickOnDeleteFolder()
        {
            deletedLink.Click();
            return new DeletePage();
        }

        public SendPage ClickOnSendFolder()
        {
            createDraftIcon.WaitForIsVisible();
            sendLink.Click();
            return new SendPage();
        }

        public ReceivePage ClickOnInboxFolder()
        {
            createDraftIcon.WaitForIsVisible();
            inboxLink.Click();
            return new ReceivePage();
        }

        public DraftPage ClickOnDraftLink()
        {
            resendLink.WaitForIsVisible();
            draftLink.Click();
            return new DraftPage();
        }

        public int CountEmails(string Email)
        {
            try
            {
                GetRecepientFieldXPath(Email).WaitForIsVisible();
                int number = GetRecepientFieldXPath(Email.Split('@')[0]).Count();
                return number;
            }
            catch
            {
                return 0;
            }
        }

        public int CountEmailsWWithWait(string Email)
        {
            return GetRecepientFieldXPath(Email.Split('@')[0]).Count();
        }
    }
}