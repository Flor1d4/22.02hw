using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _22._02cl.Program;

namespace _22._02cl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BaseBankomat baseBankomat = new BaseBankomat();
            Bankomat bankomat = new Bankomat(baseBankomat);
            bankomat.Deposit(1000);
            bankomat.Withdraw(500);
            Console.WriteLine($"Баланс: {bankomat.GetBalance()}");

            PrintedTextBankomat printedTextBankomat = new PrintedTextBankomat();
            bankomat = new Bankomat(printedTextBankomat);
            bankomat.Deposit(1000);
            bankomat.Withdraw(500);

            ElectronicTextBankomat electronicTextBankomat = new ElectronicTextBankomat();
            bankomat = new Bankomat(electronicTextBankomat);
            bankomat.Deposit(1000);
            bankomat.Withdraw(500);

            CurrencySelectionBankomat currencySelectionBankomat = new CurrencySelectionBankomat();
            bankomat = new Bankomat(currencySelectionBankomat);
            bankomat.Deposit(1000);
            bankomat.Withdraw(500);

        }
        public class Bankomat
        {
            private IBankomat _bankomat;

            public Bankomat(IBankomat bankomat)
            {
                _bankomat = bankomat;
            }

            public decimal GetBalance()
            {
                return _bankomat.GetBalance();
            }

            public void Deposit(decimal amount)
            {
                _bankomat.Deposit(amount);
            }

            public bool Withdraw(decimal amount)
            {
                return _bankomat.Withdraw(amount);
            }
        }



        public interface IBankomat
        {
            decimal GetBalance(); // получить баланс
            void Deposit(decimal amount); // внести деньги
            bool Withdraw(decimal amount); // снять деньги
        }
        public class BaseBankomat : IBankomat
        {
            private decimal _balance;

            public decimal GetBalance()
            {
                return _balance;
            }

            public void Deposit(decimal amount)
            {
                _balance += amount;
            }

            public bool Withdraw(decimal amount)
            {
                if (amount <= _balance)
                {
                    _balance -= amount;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class PrintedTextBankomat : IBankomat
        {
            private decimal _balance;

            public decimal GetBalance()
            {
                return _balance;
            }

            public void Deposit(decimal amount)
            {
                _balance += amount;
            }

            public bool Withdraw(decimal amount)
            {
                if (amount <= _balance)
                {
                    _balance -= amount;
                    Console.WriteLine($"Вы сняли {amount} гривен. Баланс: {_balance} гривен.");
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class ElectronicTextBankomat : IBankomat
        {
            private decimal _balance;

            public decimal GetBalance()
            {
                return _balance;
            }

            public void Deposit(decimal amount)
            {
                _balance += amount;
            }

            public bool Withdraw(decimal amount)
            {
                if (amount <= _balance)
                {
                    _balance -= amount;
                    // Отправка сообщения в электронном виде
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class CurrencySelectionBankomat : IBankomat
        {
            private decimal _balance;

            public decimal GetBalance()
            {
                return _balance;
            }

            public void Deposit(decimal amount)
            {
                _balance += amount;
            }

            public bool Withdraw(decimal amount)
            {
                // Выбор валюты перед снятием денег
                if (amount <= _balance)
                {
                    _balance -= amount;
                    Console.WriteLine($"Вы сняли {amount} гривен. Баланс: {_balance} гривен.");
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
