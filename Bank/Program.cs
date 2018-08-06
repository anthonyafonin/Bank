using System;
using Bank.AppNS;

namespace Bank
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Instantiate and Initialize applciation
            Menu Menu = new Menu(App.GetApp());
            Menu.Initialize();
        }
    }
}
