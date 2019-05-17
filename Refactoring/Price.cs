using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
    public abstract class Price
    {
        public abstract int getPriceCode();

        public abstract double getCharge(int daysRented);

        public int getFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }

    public class ChildrensPrice : Price
    {
        public override int getPriceCode()
        {
            return 2;
        }

        public override double getCharge(int daysRented)
        {
            double result = 2;
            if (daysRented > 2)
            {
                result += (daysRented - 2) * 1.5;
            }
            return result;
        }
    }

    public class NewReleasePrice : Price
    {
        public override int getPriceCode()
        {
            return 1;
        }
        public override double getCharge(int daysRented)
        {
            double result = 2;
            if (daysRented > 3)
            {
                result += (daysRented - 3) * 1.5;
            }
            return result;
        }

        public int getFrequentRenterPoints(int daysRented)
        {
            return (daysRented > 1) ? 2 : 1;
        }
    }

    public class RegularPrice : Price
    {
        public override int getPriceCode()
        {
            return 0;
        }
        public override double getCharge(int daysRented)
        {
            return daysRented * 3;
        }
    }

}
