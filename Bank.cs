using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace laba12
{
    class Bank
    {
        public enum account { incorrect, saving, current };
        private Queue<BankTransaction> bankTransactions = new Queue<BankTransaction>();
        private int number;
        private account type;
        private decimal balance;
        private static int num = 1;
        public Bank()
        {

        }
        public Bank(decimal balance, account type)
        {
            this.balance = balance;
            this.type = type;
            IncreaseNum();
        }
        public Bank(decimal balance)
        {
            this.balance = balance;
            IncreaseNum();
        }
        public Bank(account type)
        {
            this.type = type;
            IncreaseNum();
        }
        public void Dispose(string file) 
        {
            StreamWriter stream = new StreamWriter(file);
            foreach (BankTransaction item in bankTransactions)
            {
                stream.WriteLine(item.ToString());
            }
            stream.Close();
            GC.SuppressFinalize(stream);

        }
        public void PutItOnTheAccount(decimal temp)
        {
            BankTransaction bankT = new BankTransaction(temp);
            balance += temp;
            bankTransactions.Enqueue(bankT);
        }
        public void WithdrawFromTheAccount(decimal temp)
        {
            
            if (temp <= balance)
            {
                balance -= temp;
                BankTransaction bankT = new BankTransaction(temp);
                bankTransactions.Enqueue(bankT);
            }
            else if (temp > balance)
            {
                Console.WriteLine("Недостаточно средств");
            }
            else
            {
                Console.WriteLine("Ошибка при вводе баланса");
            }
        }
        public void IncreaseNum()
        {
            number = num++;
        }
        public void Print()
        {
            Console.WriteLine($"Account number: {number}" +
                            $"\n        balance: {balance}" +
                            $" \n        type: {type}");

        }
        public void GetBank_Account()
        {
            Console.WriteLine("Введите баланс:");
            bool result = decimal.TryParse(Console.ReadLine(), out decimal temp1);
            if (result)
            {
                balance = temp1;
            }
            else
            {
                Console.WriteLine("Ошибка при вводе баланса");
            }
            Console.WriteLine("Выберите тип счета: saving или current\nВведите 1 или 2");
            result = Int32.TryParse(Console.ReadLine(), out int temp);
            switch (temp)
            {
                case 1:
                    type = account.saving;
                    break;
                case 2:
                    type = account.current;
                    break;
                default:
                    Console.WriteLine("Нужно вводить только 1 или 2");
                    break;
            }
        }
        public void Transfer(ref Bank from, decimal sum)
        {
            if (sum <= from.balance)
            {
                from.WithdrawFromTheAccount(sum);
                PutItOnTheAccount(sum);
            }
            else
            {
                Console.WriteLine("не получается");
            }

        }
        public static bool operator ==(Bank acc1, Bank acc2)
        {
            return acc1.number == acc2.number && acc1.type == acc2.type && acc1.balance == acc2.balance;           
        } 
        public static bool operator !=(Bank acc1, Bank acc2) 
        {
            return acc1.number != acc2.number || acc1.type != acc2.type || acc1.balance != acc2.balance;
        }
        public override bool Equals(object acc)
        {
            if (acc is Bank)
            {
                return this == (acc as Bank);
            }
            else
            {
                return false;
            }
        }
            public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return $"Tип {type} и баланс счета {balance}";
        }
        
    }
}
