using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace SeuProjetoDeTeste
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            try
            {
                // Configurações do Chrome
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--start-maximized");

                // Inicialização do driver do Chrome
                driver = new ChromeDriver(@"C:\Users\Eric Condé\Downloads\ProjetoBase2-main\ProjetoBase2-main\Driver", options);
            }
            catch (Exception ex)
            {
                // Encerra todos os testes em caso de erro na inicialização do driver
                Environment.Exit(1);
            }
        }

        [Test]
        public void LoginTest()
        {
            try
            {
                // Navega para a página de login
                driver.Navigate().GoToUrl("https://mantis-prova.base2.com.br/login_page.php");

                // Preenche o campo de usuário
                IWebElement usernameField = driver.FindElement(By.Name("username"));
                usernameField.SendKeys("eric.conde");
                usernameField.Submit();

                // Preenche o campo de senha
                IWebElement passwordField = driver.FindElement(By.Name("password"));
                passwordField.SendKeys("Ventilador@11");
                passwordField.Submit();

                // Aguarda a página carregar
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                Thread.Sleep(2500);

                // Verifica se o login foi bem-sucedido
                if (driver.Url.Contains("login_page.php?error"))
                {
                    Console.WriteLine("Login falhou. Encerrando todos os testes.");
                    TearDown();
                    Environment.Exit(1);
                }
            }
            catch (Exception ex)
            {
                // Encerra o teste em caso de exceção
                throw;
            }
        }

        [Test]
        public void MyVisionTest()
        {
            try
            {
                LoginTest();

                IWebElement myVisionMenu = driver.FindElement(By.XPath("//*[@id='sidebar']/ul/li[1]/a"));
                myVisionMenu.Click();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Test]
        public void AllBugs()
        {
            try
            {
                LoginTest();

                IWebElement allBugs = driver.FindElement(By.XPath("//*[@id='sidebar']/ul/li[2]"));
                allBugs.Click();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Test]
        public void CreateBugs()
        {
            try
            {
                LoginTest();

                IWebElement createBugs = driver.FindElement(By.XPath("//*[@id='sidebar']/ul/li[3]"));
                createBugs.Click();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Test]
        public void Changes()
        {
            try
            {
                LoginTest();

                IWebElement changes = driver.FindElement(By.XPath("//*[@id='sidebar']/ul/li[4]"));
                changes.Click();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Test]
        public void Planning()
        {
            try
            {
                LoginTest();

                IWebElement planning = driver.FindElement(By.XPath("//*[@id='sidebar']/ul/li[5]"));
                planning.Click();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Test]
        public void CollapseSidebar()
        {
            try
            {
                LoginTest();

                IWebElement collapse = driver.FindElement(By.Id("sidebar-btn"));
                collapse.Click();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Test]
        public void SelectProject()
        {
            try
            {
                LoginTest();

                IWebElement dropdownProjects = driver.FindElement(By.Id("dropdown_projects_menu"));
                dropdownProjects.Click();

                IWebElement project = driver.FindElement(By.XPath("//a[contains(text(), 'Teste')]"));
                project.Click();
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Test]
        public void CreateNewBug()
        {
            try
            {
                CreateBugs();

                IWebElement dropdownFrequency = driver.FindElement(By.XPath("//*[@id='reproducibility']"));
                dropdownFrequency.Click();

                IWebElement frequency = driver.FindElement(By.XPath("//*[@id='reproducibility']/option[1]"));
                frequency.Click();

                IWebElement dropdownGravity = driver.FindElement(By.XPath("//*[@id='severity']"));
                dropdownGravity.Click();

                IWebElement gravity = driver.FindElement(By.XPath("//*[@id='severity']/option[3]"));
                gravity.Click();

                IWebElement dropdownPriority = driver.FindElement(By.XPath("//*[@id='priority']"));
                dropdownPriority.Click();

                IWebElement priority = driver.FindElement(By.XPath("//*[@id='priority']/option[4]"));
                priority.Click();

                IWebElement summaryField = driver.FindElement(By.Id("summary"));
                summaryField.SendKeys("Teste de automação por Selenium");

                IWebElement descriptionField = driver.FindElement(By.Id("description"));
                descriptionField.SendKeys("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed lobortis nibh sit amet consequat cursus. Sed egestas consectetur hendrerit. Aliquam vitae magna eu lectus efficitur maximus vitae ut magna. Integer nec nunc eu est scelerisque dapibus ac sit amet purus. Aliquam erat volutpat. Aenean nec mi lobortis, imperdiet nunc vitae, dictum lectus. Praesent efficitur odio mollis justo tincidunt consequat. Proin tristique, ex vel scelerisque posuere, dui purus pulvinar ante, a suscipit augue turpis in diam. Aenean euismod quis sapien id tempus. Nam lobortis sed odio eget sodales. Sed pellentesque scelerisque velit id pulvinar. Integer sed nunc dui. Mauris efficitur, libero eget tristique ornare, metus lorem vulputate nisi, vel maximus metus neque non enim. Suspendisse in erat sed dui eleifend vehicula.");

                IWebElement createBug = driver.FindElement(By.XPath("//*[@id='report_bug_form']/div/div[2]/div[2]/input"));
                createBug.Click();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Test]
        public void SeeBugsFilters()
        {
            try
            {
                AllBugs();

                IWebElement severityFilter = driver.FindElement(By.Id("show_severity_filter"));
                severityFilter.Click();
                Thread.Sleep(1500);

                IWebElement severityTarget = driver.FindElement(By.XPath("//*[@id='show_severity_filter_target']/select"));
                severityTarget.Click();
                Thread.Sleep(1500);

                string optionText = "texto";
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript($"arguments[0].value = '{optionText}';", severityTarget);
                Thread.Sleep(1500);

                string targetValue = "Aplicar Filtro";
                IWebElement confirmFilters = driver.FindElement(By.CssSelector($"[value='{targetValue}']"));
                confirmFilters.Click();
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                try
                {
                    // Encerra o driver do Chrome
                    driver.Quit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao fechar o driver: " + ex.Message);
                }
            }
        }
    }
}
