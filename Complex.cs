using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba12
{
    class Complex
    {
        public double Re;
        public double Im;
        public Complex(double real, double imaginary)
        {
            Re = real;
            Im = imaginary;
        }

        public override string ToString()
        {
            double x = Re, y = Im;
            if (y == 0)
            {
                return $"{x}";
            }
            else if (y > 0)
            {
                return $"{x} + {y}i";
            }
            else
            {
                return $"{x} - {-y}i";
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            double number;
            if (obj is Complex)
            {
                return Re == (obj as Complex).Re && Im == (obj as Complex).Im;
            }
            else if (Im == 0 && double.TryParse(obj.ToString(), out number))
            {
                return Re == number;
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(Complex c1, Complex c2)
        {
            return c1.Re == c2.Re && c1.Im == c2.Im;
        }

        public static bool operator !=(Complex x, Complex y)
        {
            return x.Re != y.Re && x.Im != y.Im;
        }

        public static Complex operator +(Complex x, Complex y)
        {
            return new Complex(x.Re + y.Re, x.Im + y.Im);
        }

        public static Complex operator -(Complex x, Complex y)
        {
            return new Complex(x.Re - y.Re, x.Im - y.Im);
        }

        public static Complex operator *(Complex x, Complex y)
        {
            return new Complex(x.Re * y.Re - x.Im * y.Im,
                x.Re * y.Im + x.Im * y.Re);
        }
    }
}
