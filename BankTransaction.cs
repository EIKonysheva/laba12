using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba12
{
    class BankTransaction
    {
       readonly DateTime time;
       readonly decimal sum;
      public BankTransaction( decimal sum) 
        {
           this.sum =sum;
            time = DateTime.Now;            
        }
        public override string ToString()
        {
            return $"{time} {sum}";
        }
    }
}
