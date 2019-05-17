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
            return _movie.getCharge(_daysRented);
        }

        public int getFrequentRenterPoints()
        {
            return _movie.getFrequentRenterPoints(_daysRented);
        }


    }
}
