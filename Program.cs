using System;
using System.Collections.Generic;
using System.IO;

namespace s10205253_practical_4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<SavingsAccount> SavingsAccList = new List<SavingsAccount>();
            InitAcc(SavingsAccList);
            string option = "";
            while (option != "0")
            {
                DisplayMenu();
                Console.Write("Enter option: ");
                option = Console.ReadLine();
                if (option == "0")
                {
                    Console.WriteLine("Goodbye!");
                }
                else if (option == "1")
                {
                    Console.WriteLine("\n");
                    DisplayAll(SavingsAccList);
                    Console.WriteLine("\n");
                }
                else if (option == "2")
                {
                    Console.Write("Enter savings acc no: ");
                    string accno = Console.ReadLine();
                    SavingsAccount sa = SearchAcc(SavingsAccList, accno);
                    if (sa == null)
                    {
                        Console.WriteLine("Unable to find account number. Please try again." + "\n");
                    }
                    else
                    {
                        Console.Write("Amount to deposit: ");
                        double amt = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("${0} deposited successfully", amt);
                        sa.Deposit(amt);
                        Console.WriteLine(sa +  "\n");
                    }
                }
                else if (option == "3")
                {
                    Console.Write("Enter savings acc no: ");
                    string accno = Console.ReadLine();
                    SavingsAccount sa = SearchAcc(SavingsAccList, accno);
                    if (sa == null)
                    {
                        Console.WriteLine("Unable to find account number. Please try again." + "\n");
                    }
                    else
                    {
                        Console.Write("Enter amount to withdraw: ");
                        double amt = Convert.ToDouble(Console.ReadLine());
                        if (sa.Withdraw(amt))
                        {
                            Console.WriteLine("${0} withdrawn successfully", amt);
                            Console.WriteLine(sa + "\n");
                        }
                        else
                        {
                            Console.WriteLine("Insufficient funds." + "\n");
                        }
                    }

                }
                
            }
        }
        static void InitAcc(List<SavingsAccount> salist)
        {
            string[] csvline = File.ReadAllLines("savings_account.csv");
            for (int i = 1; i < csvline.Length; i++)
            {
                string[] data = csvline[i].Split(',');
                salist.Add(new SavingsAccount(data[0], data[1], Convert.ToDouble(data[2]), Convert.ToDouble(data[3])));
            }
            
        }
        static void DisplayMenu()
        {
            Console.WriteLine("Menu" +
                "\n[1] Display all accounts" +
                "\n[2] Deposit" +
                "\n[3] Withdraw" +
                "\n[0] Exit");
        }
        static void DisplayAll(List<SavingsAccount> salist)
        {
            foreach (SavingsAccount s in salist)
            {
                Console.WriteLine(s);
            }
        }
        static SavingsAccount SearchAcc(List<SavingsAccount> salist, string accno)
        {
            foreach (SavingsAccount s in salist)
            {
                if (s.AccNo == accno)
                {
                    return s;
                }
            }
            return null;
        }
    }
}
