using Bank.Models;
using Bank.TransactionNS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bank.AppNS
{
    public class Menu
    {
        public App App { get; set; }

        public Menu(App App) {
            this.App = App;
        }

        /// <summary>
        /// Show menu when application starts
        /// </summary>
        public void Initialize()
        {
            ShowMenu(App.LoggedIn);
        }

        /// <summary>
        /// Capture selected menu item number
        /// </summary>
        /// <returns>Returns selected menu item number</returns>
        public int SelectMenuItem()
        {
            return int.Parse(Console.ReadKey().KeyChar.ToString());
        }

        /// <summary>
        /// Displays different main menu based on user login status
        /// </summary>
        /// <param name="LoggedIn">If a user is logged in</param>
        public void ShowMenu(bool LoggedIn)
        {
            try
            {
                int selection;
                Console.Clear();

                // display different menu based on user login status
                if (!LoggedIn)
                {
                    Console.WriteLine(
                        "\n\t\tWelcome to the World's BEST Banking Ledger! " +
                        "\n\n Enter an option" +
                        "\n--------------------------\n");
                    Console.WriteLine(
                        "1. Log in\n"
                        + "2. Create Account\n"
                        + "0. Exit");

                    selection = SelectMenuItem();

                    switch (selection)
                    {
                        case 1:
                            ShowLogin();
                            break;
                        case 2:
                            ShowRegister();
                            break;
                        case 0:
                            ShowLogout(true);
                            break;
                        default:
                            ShowMenu(LoggedIn);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine(
                        "\n\t\tBanking Ledger - Logged in as " + App.CurrentUser.Username
                         + "\n\n Enter an option"
                         + "\n--------------------------\n");
                    Console.WriteLine(
                        "1. Make Deposit\n"
                        + "2. Make Withdraw\n"
                        + "3. Check Account Balance\n"
                        + "4. View Transaction History\n"
                        + "5. Logout\n"
                        + "0. Exit");

                    selection = SelectMenuItem();

                    switch (selection)
                    {
                        case 1:
                            ShowRecordTransaction(TransactionType.Deposit);
                            break;
                        case 2:
                            ShowRecordTransaction(TransactionType.Withdraw);
                            break;
                        case 3:
                            ShowAccountBalance();
                            break;
                        case 4:
                            ShowTransactionHistory();
                            break;
                        case 5:
                            ShowLogout(false);
                            break;
                        case 0:
                            ShowLogout(true);
                            break;
                        default:
                            ShowMenu(LoggedIn);
                            break;
                    }
                }
            }
            catch (Exception)
            {
                ShowMenu(LoggedIn);
                Console.WriteLine("\nInvalid Selection.");
            }
        }

        /// <summary>
        /// Displays Login form and calls PerformLogin method
        /// </summary>
        public void ShowLogin()
        {
            Console.Clear();
            Console.WriteLine("\n\t\tLog in to existing account.");

            // capture request info
            LoginRequestModel request = new LoginRequestModel();
            Console.WriteLine("\nEnter Username:");
            request.Username = Console.ReadLine();
            Console.WriteLine("\nEnter Password:");
            request.Password = Console.ReadLine();

            if (App.PerformLogin(request))
            {
                Console.WriteLine("Login Success! Press Any Key to Continue...");
                Console.ReadKey(true);
                ShowMenu(App.LoggedIn);
            }
            else
            {
                Console.WriteLine("Error. Invalid Username or Password. " +
                    "\n\n(Press any key to Retry, Press Esc to return to Menu)");

                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    ShowMenu(App.LoggedIn);
                }
                else
                {
                    ShowLogin();
                }
            }
            Console.ReadLine();
            ShowMenu(App.LoggedIn);
        }

        /// <summary>
        /// Displays Register form and calls PerformRegister method
        /// </summary>
        public void ShowRegister()
        {
            Console.Clear();
            Console.WriteLine("\n\t\tCreate a new Account.");

            // capture request info
            RegisterRequestModel request = new RegisterRequestModel();

            // capture and replace all spaces for username
            Console.WriteLine("\nEnter Username:");
            string userInput = Console.ReadLine();
            request.Username = Regex.Replace(userInput, @"\s+", "");

            // capture user passwords
            Console.WriteLine("\nEnter Password:");
            request.Password = Console.ReadLine();
            Console.WriteLine("\nConfirm Password:");
            request.ConfirmPassword = Console.ReadLine();
  
            if (App.PerformRegister(request))
            {
                Console.WriteLine("\nAccount Created! Press Any Key to Continue...");
                Console.ReadKey(true);
                ShowMenu(App.LoggedIn);
            }
            else
            {
                string error = request.Password != request.ConfirmPassword || request.Password.Length < 7
                    ? "Both Password fields must match and be at least 7 characters long." : "The username already exists.";
                Console.WriteLine("Error. {0} \n\n(Press any key to Retry, Press Esc to return to Menu)", error);

                if(Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    ShowMenu(App.LoggedIn);
                }
                else
                {
                    ShowRegister();
                }
            }

            ShowMenu(App.LoggedIn);
        }

        /// <summary>
        /// Displays transaction form based on passed TransactionType
        /// </summary>
        /// <param name="type">TransactionType, Deposit or Withdraw</param>
        public void ShowRecordTransaction(TransactionType type)
        {
            Console.Clear();
            string view = type == TransactionType.Deposit ? "Deposit" : "Withdraw";
            Console.WriteLine("\n\t\tMake a {0}", view);
            Console.WriteLine("\nEnter transaction amount:");

            try
            {
                decimal amount = decimal.Parse(Console.ReadLine());
                if(type == TransactionType.Withdraw && amount > App.CurrentBankAccount.GetBalance())
                {
                    throw new Exception("Error. Insufficient Funds.");
                }
                else
                {
                    // make transaction
                    App.CurrentBankAccount.MakeTransaction(new TransactionRequestModel {
                        Type = type,
                        Amount = amount
                    });
                    Console.WriteLine("A {0} of ${1} has been made. " +
                        "\n\nPress Any Key to Return to Menu...", view, amount);
                    Console.ReadKey(true);
                }
          
            }
            catch(Exception e)
            {
                // capture and display any error messages from input
                string error = e.Message.Length > 0 ? e.Message + "\n" : "There was an unexpected Error.";
                Console.WriteLine("\n{0}" + "\n\n(Press any key to Retry, Press Esc to return to Menu)", error);

                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    ShowMenu(App.LoggedIn);
                }
                else
                {
                    ShowRecordTransaction(type);
                }
            }
            ShowMenu(App.LoggedIn);
        }

        /// <summary>
        /// Displays AccountBalance view and the current bank account balance
        /// </summary>
        public void ShowAccountBalance()
        {
            Console.Clear();
            Console.WriteLine("\n\t\tCurrent Balance");
            Console.WriteLine("\nYour current Balance is ${0}", App.CurrentBankAccount.GetBalance());
            Console.WriteLine("\n\nPress Any Key to Return to Menu...");
            Console.ReadKey(true);
            ShowMenu(App.LoggedIn);
        }

        /// <summary>
        /// Displays transaction history view that 
        /// displays information of each transaction made of the current bank account
        /// </summary>
        public void ShowTransactionHistory()
        {
            Console.Clear();
            Console.WriteLine("\n\t\tTransaction History");

            var transactions = App.CurrentBankAccount.Transactions;
            for (int i = 0; i < transactions.Count; i++)
            {
                var t = transactions[i];
                var type = t.Type == TransactionType.Deposit ? "Deposit" : "Withdraw";
                Console.WriteLine("\n{0}. ${1} {2} made on {3}", i, t.Amount, type, t.Created);
            }

            Console.WriteLine("\n\nPress Any Key to Return to Menu...");
            Console.ReadKey(true);
            ShowMenu(App.LoggedIn);
        }

        /// <summary>
        /// Prompts user for logout/exit confirmation
        /// </summary>
        /// <param name="exit">Bool - true if prompt for exit application</param>
        public void ShowLogout(bool exit)
        {
            Console.Clear();

            string option = exit ? "Exit" : "Logout";
            Console.WriteLine("Are you sure you wish to {0}? (Y/N)", option);
            char input = Console.ReadKey().KeyChar;

            if (input.ToString().ToLower() == "y")
            {
                if (exit)
                {
                    Environment.Exit(1);
                }
                else
                {
                    App.PerformLogout();
                }
            }
            ShowMenu(App.LoggedIn);
        }
    }
}
