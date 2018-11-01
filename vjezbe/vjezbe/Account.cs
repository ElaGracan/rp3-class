using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace vjezbe
{
    class Account
    {

        public ManualResetEvent a = new ManualResetEvent(false);
        public void Radi()
        {
            Console.WriteLine("{0} poceo cekanje", Thread.CurrentThread.Name);
            a.WaitOne(3000);
            Thread.Sleep(200);
            Console.WriteLine("{0} zavrsio cekanje", Thread.CurrentThread.Name);
            a.WaitOne(3000);
            Console.WriteLine("{0} zavrsio 2 cekanje",
           Thread.CurrentThread.Name);
        }
        public Object thisLock = new Object();
        public int balance;
        public Random r = new Random();
        //public Account(int initial) { balance = initial; }
        int Withdraw(int amount)
        { // Ovo se nece dogoditi ako je lock aktivan
            if (balance < 0) { throw new Exception("Negativno stanje"); }
            // Komentirajte sljedecu liniju
            lock (thisLock)
            {
                if (balance >= amount)
                {
                    Console.WriteLine("Stanje prije : " + balance);
                    Console.WriteLine("Iznos koji se podize : -" + amount);
                    balance = balance - amount;
                    Console.WriteLine("Stanje nakon : " + balance);
                    return amount;
                }
                else
                {
                    return 0; // transakcija odbijena }
                }
            }
            
        }
        public void DoTransactions()
        {
            for (int i = 0; i < 100; i++)
                Withdraw(r.Next(1, 100));
        }
    }
    }

