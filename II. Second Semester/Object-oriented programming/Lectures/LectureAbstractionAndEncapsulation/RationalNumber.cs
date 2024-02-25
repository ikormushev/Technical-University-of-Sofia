using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureAbstractionAndEncapsulation
{
    internal class RationalNumber
    {
        private long num; // number
        private long denom; // denominator

        public RationalNumber()
        {
            num = 0;
            denom = 1; // It's easier to use 1 as a denominator

            MakeCanonical(); // not required to be here
        }

        // Constructor
        public RationalNumber(long aNum, long aDenom)
        {
            num = aNum;
            denom = aDenom;

            MakeCanonical();
        }

        // We need to make the valid operations
        public static RationalNumber operator +(RationalNumber a, RationalNumber b)
        {
            var greatestCommonDivisor = GreatestCommonDivisor(a.denom, b.denom);

            // the division has to be before the multiplication, because there could be a case with large numbers
            var newDenom = (a.denom / greatestCommonDivisor) * b.denom;
            var newNum = a.num * (b.denom / greatestCommonDivisor) + b.num * (a.denom / greatestCommonDivisor);

            return new RationalNumber(newNum, newDenom);
        }

        public static RationalNumber operator -(RationalNumber a, RationalNumber b)
        {
            // First way - return a + new RationalNumber(-b.num, b.denom); // we just reuse the addition

            // But because we have created a unary minus, we can use it instead
            return a + (-b);
        }

        public static RationalNumber operator -(RationalNumber a) // Unary minus
        {
            return new RationalNumber(-a.num, a.denom);
        }

        public static RationalNumber operator *(RationalNumber a, RationalNumber b)
        {
            // Not so efficient way?
            // var greatestCommonDivisor = GreatestCommonDivisor(a.denom, b.denom);

            // var newDemon = a.denom * b.denom;
            // var newNum = a.num * b.num;

            var greatestCommonDivisor1 = GreatestCommonDivisor(a.num, b.denom);
            var greatestCommonDivisor2 = GreatestCommonDivisor(b.num, a.denom);

            var newDenom = (a.denom / greatestCommonDivisor2) * (b.denom / greatestCommonDivisor1);
            var newNum = (a.num / greatestCommonDivisor1) * (b.num / greatestCommonDivisor2);
            return new RationalNumber(newNum, newDenom);

        }

        public static RationalNumber operator /(RationalNumber a, RationalNumber b)
        {
            return a * new RationalNumber(b.denom, b.num);
        }

        // In order to check if two rational numbers are the same, we need to create a method for that
        public static bool operator ==(RationalNumber a, RationalNumber b)
        {
            return a.num == b.num && a.denom == b.denom;
        }

        // Because we have declared the == operator, we need to also declare the != operator
        public static bool operator !=(RationalNumber a, RationalNumber b)
        {
            return !(a == b); // this way we call the == operator, which usage we have declared above
        }

        public static bool operator <(RationalNumber a, RationalNumber b)
        {
            return (a - b).num < 0;
        }

        public static bool operator >(RationalNumber a, RationalNumber b)
        {
            return !(a < b || a == b);
        }

        public static bool operator >=(RationalNumber a, RationalNumber b)
        {
            return !(a < b);
        }

        public static bool operator <=(RationalNumber a, RationalNumber b)
        {
            return !(a > b);
        }

        // In order to use the .Equals method, we need to override it
        public override bool Equals(object obj)
        {
            var rationalNumber = obj as RationalNumber;
            if (rationalNumber is null) return false;
            return rationalNumber == this; // == is OUR operator for checking rational numbers
        }

        // Method for changing a number to rational one
        public static implicit operator RationalNumber(long a)
        {
            // Implicit allows us to swap values from int to long without saying so
            // Explicit requires us to say it -> (RationalNumber)...
            return new RationalNumber(a, 1);
        }

        // GetHashCode does not work for rational numbers, so we have to override it
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public static explicit operator decimal(RationalNumber a)
        {
            return (decimal)a.num / a.denom;
        }

        public static explicit operator RationalNumber(decimal a)
        {
            long denom = 1;
            long num = (long)a;

            while (num != a)
            {
                denom *= 10;
                a *= 10;
                num = (long)a;
            }

            return new RationalNumber(num, denom);
        }

        // In order to return our number as a string, we need this override method
        public override string ToString()
        {
            if (denom == 1) return string.Format($"{num}");
            else return string.Format($"{num}/{denom}");
        }

        // Only we need to be able to access the methods below, that's why they're private
        private void MakeCanonical()
        {
            if (denom == 0)
                throw new DivideByZeroException("Division by 0 is not supported.");

            // There could be cases where the num is 0
            if (num == 0) denom = 1;

            var greatestCommonDivisior = GreatestCommonDivisor(num, denom);
            num /= greatestCommonDivisior;
            denom /= greatestCommonDivisior;

            // There could be cases where only the denominator is negative, we want to make sure the numerator is always the one to be negative
            if (denom < 0)
            {
                num = -num;
                denom = -denom;
            }
        }

        private static long GreatestCommonDivisor(long a, long b)
        {
            // Алгоритъм на Евклид
            while (b != 0)
            {
                var temp = b; // temp = 4, a = 12
                b = a % b; // b = 12 % 4 = 0
                a = temp; // a = 4
            }

            return a;
        }
    }
}
