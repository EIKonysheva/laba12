using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba12
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank acc1 = new Bank(3556, Bank.account.current);
            Bank acc2 = new Bank(5434, Bank.account.current);
            Console.WriteLine(acc1);
            Console.WriteLine("Equals " + acc1.Equals(acc2)+
                "\n== "+ (acc1==acc2)+
                "\n!= "+(acc1!=acc2)+
                "\nGetHashCode " + acc1.GetHashCode()+
                "\nToString "+acc1.ToString());
            
        }
    }
}
