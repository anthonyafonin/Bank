using Bank.BankAccountNS;
using Bank.UserNS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.AppNS
{
    public class App
    {
        private bool LoggedIn { get; set; }
        private User CurrentUser { get; set; }
        private BankAccount CurrentBankAccount { get; set; }

        public App() { }

        /// <summary>
        /// 
        /// </summary>
        public void Initialize() 
        {
            LoggedIn = false;
            ShowMenu();
        }

        /// <summary>
        /// 
        /// </summary>
        public void ShowMenu()
        {
            ConsoleKeyInfo UserInput;
            int selection;

            Console.Clear();
            Console.WriteLine(
                "\n\t\tWelcome to the World's BEST Banking Ledger! " +
                "\n\n Enter an option" +
                "\n--------------------------\n");

            try
            {
                if (!LoggedIn)
                {
                    Console.WriteLine(
                        "1. Log in\n"
                        + "2. Create Account\n"
                        + "0. Exit");

                    selection = SelectMenuItem();

                    switch (selection)
                    {
                        case 1:
                            Console.WriteLine("login view");
                            break;
                        case 2:
                            Console.WriteLine("created acc view");
                            break;
                        case 0:
                            break;
                        default:
                            ShowMenu();
                            break;
                    }
                }
                else
                {

                }
            }
            catch(Exception)
            {
                ShowMenu();
            }
            Debug.WriteLine("Test");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int SelectMenuItem()
        {
            return int.Parse(Console.ReadKey().KeyChar.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        public void Login()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public void Register()
        {

        }
    }
}
