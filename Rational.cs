using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba12
{
    class Rational
    {
       public int numerator;
       public int denominator;
       public Rational(int num, int denom)
        { 
            if (denom == 0) 
            {
                throw new DivideByZeroException();
            }
        } 
       public static bool operator == (Rational rat1, Rational rat2)
        {
            if ((double)(rat1.numerator / rat1.denominator) == (double)(rat2.numerator / rat2.denominator)) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(Rational rat1, Rational rat2)
        {
            if ((double)(rat1.numerator / rat1.denominator) != (double)(rat2.numerator / rat2.denominator))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override bool Equals(object rat)
        {
            if (rat is Rational)
            {
                return this == (rat as Rational);
            }
            else
            {
                return false;
            }
        }
        public static bool operator <(Rational rat1, Rational rat2) 
        {
            if((double)(rat1.numerator / rat1.denominator) < (double)(rat2.numerator / rat2.denominator))
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
        public static bool operator >(Rational rat1, Rational rat2)
        {
            if ((double)(rat1.numerator / rat1.denominator) > (double)(rat2.numerator / rat2.denominator))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator <=(Rational rat1, Rational rat2)
        {
            if ((double)(rat1.numerator / rat1.denominator) <= (double)(rat2.numerator / rat2.denominator))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator >=(Rational rat1, Rational rat2)
        {
            if ((double)(rat1.numerator / rat1.denominator) >= (double)(rat2.numerator / rat2.denominator))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Rational operator +(Rational rat1, Rational rat2)
        {
            int num = rat1.numerator * rat2.denominator + rat2.numerator * rat1.denominator;
            int denom = rat1.denominator* rat2.denominator;
                return  new Rational (num, denom);            
        }
        public static Rational operator -(Rational rat1, Rational rat2)
        {
            int num = rat1.numerator * rat2.denominator - rat2.numerator * rat1.denominator;
            int denom = rat1.denominator * rat2.denominator;
            return new Rational(num, denom);
        }
        public static Rational operator ++(Rational rat1)
        {
            int num = rat1.numerator + rat1.denominator;
            int denom = rat1.denominator;
            return new Rational(num, denom);
        }
        public static Rational operator --(Rational rat1)
        {
            int num = rat1.numerator - rat1.denominator;
            int denom = rat1.denominator;
            return new Rational(num, denom);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }
        public static Rational operator *(Rational rat1, Rational rat2)
        {
            return new Rational(rat1.numerator * rat2.numerator, rat1.denominator * rat2.denominator);
        }

        public static Rational operator /(Rational rat1, Rational rat2)
        {
            return new Rational(rat1.numerator * rat2.denominator, rat1.denominator * rat2.numerator);
        }
        public static int Method(float num)
        {
            string str = num.ToString();
            if (str.Contains(","))
            {
                return str.Length - str.IndexOf(',') - 1;
            }
            else
            {
                return 0;
            }
        }
        public static explicit operator Rational(float x)
        {
            int factor = (int)Math.Pow(10, Method(x) );
            return new Rational(Convert.ToInt32(x * factor), factor);
        }

        public static explicit operator Rational(int x)
        {
            return new Rational(x, 1);
        }

        public static explicit operator float(Rational x)
        {
            return Convert.ToSingle(x.numerator) / x.denominator;
        }

        public static explicit operator int(Rational x)
        {
            return x.numerator / x.denominator;
        }



    }
}
