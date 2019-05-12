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
        public Movie(String title,int priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }

        public int getPriceCode()
        {
            return _priceCode;
        }

        public void setPriceCode(int arg)
        {
            _priceCode = arg;
        }

        public String getTitle()
        {
            return _title;
        }

    }
}
