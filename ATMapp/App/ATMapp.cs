using ATMapp.UI;
using System;
using System.Collections.Generic;
using ATMapp.Domain.Entities;
using ATMapp.Domain.Interfacese;
using System.Threading;

namespace ATMapp
{
    class ATMapp :IUserLogin
    {
        private List<UserAccount> userAccountList;
        private UserAccount selectedAccount;

        public void InitializeData() 
        {
            userAccountList = new List<UserAccount> {
               
                new UserAccount{Id=1, FullName = "Obinna Ezeh", AccountNumber=123456,CardNumber =321321, CardPin=123123,AccountBalance=50000.00m,IsLocked=false},
                new UserAccount{Id=2, FullName = "Amaka Hope", AccountNumber=456789,CardNumber =654654, CardPin=456456,AccountBalance=4000.00m,IsLocked=false},
                new UserAccount{Id=3, FullName = "Femi Sunday", AccountNumber=123555,CardNumber =987987, CardPin=789789,AccountBalance=2000.00m,IsLocked=true},
            };
        }
        public void CheckUserCardNumAndPassword()
        {
            bool isCorrectLogin = false;
            while (isCorrectLogin == false)
            {
                UserAccount inputAccunt = AppScreen.UserLoginForm();
                AppScreen.LoginProgress();
                foreach (UserAccount account in userAccountList) {
                    selectedAccount = account;
                    if (inputAccunt.CardNumber.Equals(selectedAccount.CardNumber))
                    {
                        selectedAccount.TotalLogin++;
                        if (inputAccunt.CardPin.Equals(selectedAccount.CardPin))
                        {
                            selectedAccount = account;
                            if (selectedAccount.IsLocked || selectedAccount.TotalLogin > 3)
                            {
                                AppScreen.PrintLockScreen();
                            }
                            else
                            {
                                selectedAccount.TotalLogin = 0;
                                isCorrectLogin = true;
                                break;

                            }
                        }
                    }
                    if (isCorrectLogin == false)
                    {
                        Utility.PrintMessage("\n Invalid card number or PIN.", false);
                        selectedAccount.IsLocked = selectedAccount.TotalLogin == 3;
                        if (selectedAccount.IsLocked)
                        {
                            AppScreen.PrintLockScreen();
                        }
                    }
                    Console.Clear();
                }
            }
            
            
        }
        public void Welcome()
        {
            Console.WriteLine($"Welcom back,{selectedAccount.FullName }");

        }

        
    }
}
