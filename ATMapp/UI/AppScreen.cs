using ATMapp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATMapp.UI
{
    public static class AppScreen
    {
        internal static void Welcome()
        {
            Console.Clear();
            Console.Title = "My ATM App";
            Console.ForegroundColor = ConsoleColor.White;
            //set wellcome message
            Console.WriteLine("\n\n----------------Welcome to my ATM app----------------\n");
            Console.WriteLine("Please insert your ATM card");
            Console.WriteLine("Note: Actual ATM machine will accept and validate a physical ATM card, read the card number and validate it.");

            Utility.PressEnterToContinue();
        }
        internal  static UserAccount UserLoginForm()
        {
            UserAccount tempUserAccount = new UserAccount();
            tempUserAccount.CardNumber = Valdator.Convert<long>("your card number.");
            tempUserAccount.CardPin = Convert.ToInt32(Utility.GetSecretInpout("Enter youer card PIN"));
            return tempUserAccount;
        }

        internal static void LoginProgress()
        {
            Console.WriteLine("\nChecking card number and PIN...");
            Utility.PrintDotAnimation();
        }
        internal static void PrintLockScreen() {
            Console.Clear();
            Utility.PrintMessage("your account is locked. pleass go to the nearest branch to unlock your account. Thank you ,true  ");
            Utility.PressEnterToContinue();
            Environment.Exit(1);
                }


    }
}
