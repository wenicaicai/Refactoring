using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
    class Movie
    {
        private String _title;
        private int _priceCode;

        private static int CHILDRENS = 2;
        private static int REGULAR = 0;
        private static int NEW_RELEASE = 1;

        private Price _price;
        public Movie(String title,int priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }

        public int getPriceCode()
        {
            return _priceCode;
        }

        //before refactoring
        //public void setPriceCode(int arg)
        //{
        //    _priceCode = arg;
        //}

        public void setPriceCode(int arg)
        {
            switch (arg)
            {
                //case REGULAR: why ican not use it
                case 0:
                    {
                        _price = new RegularPrice();
                    }
                    break;
                case 1:
                    {
                        _price = new ChildrensPrice();
                    }
                    break;
                case 2:
                    {
                        _price = new NewReleasePrice();
                    }
                    break;

            }
        }

        public String getTitle()
        {
            return _title;
        }

        public double getCharge(int daysRented)
        {
            double result = 0;
            switch (getPriceCode())
            {
                case 0:
                    {
                        result += 2;
                        if (daysRented > 2)
                        {
                            result += (daysRented - 2) * 1.5;
                        }
                    }
                    break;
                case 1:
                    {
                        result += daysRented * 3;
                    }
                    break;
                case 2:
                    {
                        result += 1.5;
                        if (daysRented > 3)
                        {
                            result += (daysRented - 3) * 1.5;
                        }
                    }
                    break;
            }
            return result;
        }

        public int getFrequentRenterPoints(int daysRented)
        {
            if (getPriceCode() == 1
                && daysRented > 1)
            {
                return 2;
            }
            return 1;
        }


    }
}
