using ATMapp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMapp.App
{
    class Entry
    {
        static void Main(string[] args)
        {
            AppScreen.Welcome();
            ATMapp atmApp = new ATMapp();
            atmApp.InitializeData();
            atmApp.CheckUserCardNumAndPassword();
            atmApp.Welcome();

            Utility.PressEnterToContinue();


        }
    }
}
