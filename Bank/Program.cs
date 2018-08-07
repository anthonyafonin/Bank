using System;
using Bank.AppNS;

namespace Bank
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Instantiate and Initialize application
            Menu Menu = new Menu(App.GetApp());
            Menu.Initialize();
        }
    }
}
