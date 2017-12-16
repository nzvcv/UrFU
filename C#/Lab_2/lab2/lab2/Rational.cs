using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public struct Rational
    {
        public int Numerator { get; private set; }

        public int Denominator { get; private set; }

        public int Base
        {
            get { return Numerator / Denominator; }
        }

        public int Fraction
        {
            get { return Numerator % Denominator; }
        }

        public Rational Add(Rational c)
        {
            Rational add = new Rational();
            add.Numerator = this.Denominator * c.Numerator + c.Denominator * this.Numerator;
            add.Denominator = this.Denominator * c.Denominator;
            add.Even();

            return add;
        }

        public static Rational operator +(Rational x, Rational c) => x.Add(c);

        public Rational Negate()
        {
            Rational negative = new Rational();
            negative.Numerator = -this.Numerator;
            negative.Denominator = this.Denominator;

            return negative;
        }

        public Rational Sub(Rational c)
        {
            Rational sub = new Rational();
            sub.Numerator = this.Numerator * c.Denominator - c.Numerator * this.Denominator;
            sub.Denominator = this.Denominator * c.Denominator;
            Console.WriteLine(sub.ToString());
            sub.Even();

            return sub;
        }

        public static Rational operator -(Rational x, Rational c) => x.Sub(c);

        public Rational Multiply(Rational x)
        {
            Rational mul = new Rational();
            mul.Numerator = this.Numerator * x.Numerator;
            mul.Denominator = this.Denominator + x.Denominator;
            mul.Even();

            return mul;
        }

        public static Rational operator *(Rational x, Rational c) => x.Multiply(c);

        public Rational DivideBy(Rational x)
        {
            Rational div = new Rational();

            if (x.Numerator < 0)
            {
                div.Numerator = this.Numerator * x.Denominator;
                div.Denominator = this.Denominator * (-x.Numerator);
                div = div.Negate();
            }
            else if (x.Numerator > 0)
            {
                div.Numerator = this.Numerator * x.Denominator;
                div.Denominator = this.Denominator * x.Numerator;
            }
            else
            {
                throw new DivideByZeroException();
            }

            div.Even();
            return div;
        }

        public static Rational operator /(Rational x, Rational c) => x.DivideBy(c);
        
        public override string ToString()
        {
            if (this.Fraction == 0)
            {
                return Base.ToString();
            }
            else if (Base == 0)
            {
                return $"{this.Fraction}:{this.Denominator}";
            }
            return  $"{this.Base}.{Math.Abs(this.Fraction)}:{this.Denominator}";
        }

        public static bool TryParse(string input, out Rational result)
        {
            result = new Rational();
            
            if (input.LastIndexOf('-') > 0)
            {
                return false;
            }

            string[] fullNumber = input.Split('.');

            if (fullNumber.Length > 2)
            {
                return false;
            }

            if (fullNumber.Length == 1 && !fullNumber[0].Contains(":"))
            {
                try
                {
                    result.Numerator = int.Parse(fullNumber[0]);
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }

            if (fullNumber.Length == 1)
            {
                try
                {
                    var fraction = fullNumber[0].Split(':');
                    result.Numerator = int.Parse(fraction[0]);
                    result.Denominator = int.Parse(fraction[1]);

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            try
            {
                var fraction = fullNumber[1].Split(':');

                if (fraction.Length > 2)
                {
                    return false;
                }

                int sign = 1;

                if (input.LastIndexOf('-') == 0)
                {
                    sign = -1;
                }


                int z = int.Parse(fullNumber[0]);
                int numerator = int.Parse(fraction[0]);
                int denumerator = int.Parse(fraction[1]);


                result.Denominator = denumerator;
                result.Numerator = z * denumerator + sign * numerator;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void Even()
        {
            var divider = GetBiggestDivider(Numerator, Denominator);
            Numerator /= divider;
            Denominator /= divider;
        }

        private int GetBiggestDivider(int firstNumber, int secondNumber)
        {
            firstNumber = Math.Abs(firstNumber);
            secondNumber = Math.Abs(secondNumber);

            return secondNumber == 0 ? firstNumber : GetBiggestDivider(secondNumber, 
                firstNumber % secondNumber);
        }

        public static explicit operator int(Rational v) => v.Numerator / v.Denominator;

        public static implicit operator Rational(int v)
        {
            Rational transformed = new Rational();
            transformed.Numerator = v;
            transformed.Denominator = 1;
            return transformed;
        }
    }
}
