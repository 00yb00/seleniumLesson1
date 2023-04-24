using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WindowsForm
{
    public partial class Form1 : Form
    {
        //ben ,ben@gmail.com,ben123
        //anna ,ben@gmail.com,ben123
        string url= "https://zionet-selenium.bubbleapps.io/version-test";

        public Form1()
        {
            InitializeComponent();
        }
        public void Puse(int mili=10000)
        {
            System.Threading.Thread.Sleep(mili);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (IWebDriver webDriver=new ChromeDriver())
            {
                webDriver.Navigate().GoToUrl(url);
                Puse();
              IWebElement aTag=webDriver.FindElement(By.CssSelector("div[class='bubble-element Image baTaGzaW']"));


                if (aTag != null)
                {
                    aTag.Click();
                     webDriver.FindElement(By.CssSelector("input[placeholder='Username']")).SendKeys("ben");
                     webDriver.FindElement(By.CssSelector("input[placeholder='Email Address']")).SendKeys("ben@gmail.com");
                     webDriver.FindElement(By.CssSelector("input[placeholder='Password']")).SendKeys("ben123");
                     webDriver.FindElement(By.CssSelector("input[placeholder='Confirm Password']")).SendKeys("ben123");
                    IWebElement sendButton = webDriver.FindElement(By.CssSelector("div[class='bubble-element Text baTaHaMaI bubble-r-vertical-center clickable-element']"));
                    if (sendButton != null)
                    {
                        sendButton.Click();
                        Puse();
                        webDriver.Close();
                    }
                    else
                    {
                        Console.WriteLine("error button not found");
                    }
                }
                else
                {
                    Console.WriteLine("error button not found");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] namesArr = new string[10] { "david", "shira", "bar", "dor", "shosh,", "dora", "gal", "bracha", "shilat", "dan" };
            for (int i = 7; i < namesArr.Length; i++)
            {
                using (IWebDriver webDriver = new ChromeDriver())
                {
                    webDriver.Navigate().GoToUrl(url);
                    Puse();
                    IWebElement aTag = webDriver.FindElement(By.CssSelector("div[class='bubble-element Image baTaGzaW']"));


                    if (aTag != null)
                    {
                        aTag.Click();
                        Puse();
                        IWebElement name = webDriver.FindElement(By.CssSelector("input[placeholder='Username']"));
                        if(name != null)
                        {
                            name.SendKeys(namesArr[i]);   
                        }
                        IWebElement email = webDriver.FindElement(By.CssSelector("input[placeholder='Email Address']"));
                        if (email != null)
                        {
                            email.SendKeys(namesArr[i] + "@gmail.com");
                        }
                        IWebElement password = webDriver.FindElement(By.CssSelector("input[placeholder='Password']"));
                        if (password != null)
                        {
                            password.SendKeys(namesArr[i] + "123");
                        }
                        IWebElement secPassword = webDriver.FindElement(By.CssSelector("input[placeholder='Confirm Password']"));
                        if (secPassword != null)
                        {
                            secPassword.SendKeys(namesArr[i] + "123");
                        }
                        IWebElement sendButton = webDriver.FindElement(By.CssSelector("div[class='bubble-element Text baTaHaMaI bubble-r-vertical-center clickable-element']"));
                        if (sendButton != null)
                        {
                            sendButton.Click();
                            Puse();
                            string s = webDriver.Url;
                            if (url+ "/signup-login-connect?section=connect_wallet"== webDriver.Url)
                            {
                                Console.WriteLine("create new account secsuss");
                            }
                            else
                            {
                                Console.WriteLine("create new account falid");
                            }
                            Puse();
                            webDriver.Close();
                        }
                        else
                        {
                            Console.WriteLine("error button not found");
                        }
                    }
                    else
                    {
                        Console.WriteLine("error button not found");
                    }
                }
            }
        }
    }
}
