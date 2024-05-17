using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Obrazac stvaranja, metoda tvornica
namespace ZadacaFactoryMethod
{
    public class WebElement
    {
        string name;
        public WebElement(string name)
        {
            Console.WriteLine($"Found {name}");
            this.name = name;
        }
        public void Click()
        {
            Console.WriteLine($"Clicked {name}");
        }
    }

    public interface LoginPage
    {
        WebElement loginButton();
        WebElement usernameInput();
        WebElement passwordInput();
    }

    public class ChromeLoginPage : LoginPage
    {
        public WebElement loginButton()
        {
            return new WebElement("Login");
        }
        public WebElement usernameInput()
        {
            return new WebElement("Leonardo");
        }
        public WebElement passwordInput()
        {
            return new WebElement("123456");
        }
    }

    public abstract class LoginPageFactory
    {
        public abstract LoginPage CreatePage();
    }
    public class ChromeLoginPageFactory : LoginPageFactory
    {
        public override LoginPage CreatePage()
        {
            return new ChromeLoginPage();
        }
    }
    public class Client
    {
        public static void Main()
        {
            LoginPageFactory loginPageFactory = new ChromeLoginPageFactory();
            LoginPage loginPage = loginPageFactory.CreatePage();
            loginPage.passwordInput().Click();
            loginPage.usernameInput().Click();
            loginPage.loginButton().Click();
        }
    }
}
