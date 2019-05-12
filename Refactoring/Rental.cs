using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
    class Rental
    {
        private Movie _movie;
        private int _daysRented;

        public Rental(Movie movie,int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }

        public int getDaysRented()
        {
            return _daysRented;
        }

        public Movie getMovie()
        {
            return _movie;
        }

        /// <summary>
        /// 计算金额
        /// 
        /// 把amountFor 转为 getCharge,修改参数名 and 去掉参数
        /// 
        /// tips：使用了MoveMethod
        /// 
        /// </summary>
        /// <param name="aRental"></param>
        /// <returns></returns>
        public double getCharge()
        {
            double result = 0;
            switch (getMovie().getPriceCode())
            {
                case 0:
                    {
                        result += 2;
                        if (getDaysRented() > 2)
                        {
                            result += (getDaysRented() - 2) * 1.5;
                        }
                    }
                    break;
                case 1:
                    {
                        result += getDaysRented() * 3;
                    }
                    break;
                case 2:
                    {
                        result += 1.5;
                        if (getDaysRented() > 3)
                        {
                            result += (getDaysRented() - 3) * 1.5;
                        }
                    }
                    break;
            }
            return result;
        }

        public int getFrequentRenterPoints()
        {
            if (getMovie().getPriceCode() == 1
                && getDaysRented() > 1)
            {
                return 2;
            }
            return 1;
        }


    }
}
