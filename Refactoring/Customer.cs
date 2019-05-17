using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
    class Customer
    {
        private String _name;
        private List<Rental> _rentals;

        public Customer(String name,List<Rental> rentals)
        {
            _name = name;
            _rentals = rentals;
        }

        public void addRental(Rental rental)
        {
            _rentals.Add(rental);
        }

        public String getName()
        {
            return _name;
        }

        /// <summary>
        /// 待重构的代码
        /// 客户会修改需求 影片 种类判断 积分计算
        /// 而且代码如果输出的格式需要修改，则无法复用
        /// 客户会在六个月 也就是180天内修改需求
        /// 拆分代码块
        /// 
        /// 注意： Pay Attention:
        /// 差劲的代码难以修改
        /// 
        /// 作者曰：可靠的测试环境 + 遵循好重构手法
        /// 重构手法，让它如呼吸一般自然
        /// 
        /// 测试：有自我检测的功能
        /// 
        /// Step 1:分解+重组
        /// Step 2:把使用到对应对象的函数 放在对应的类内部
        /// Step 3:找出函数引用点
        /// Step 4:去掉旧函数 thisAmount 变量变得多余了... 使用RemoveMethod
        /// Step 5:计算积分 Extract Method
        /// Step 6:去掉临时变量 totalAmount
        /// 
        /// </summary>
        /// <returns></returns>
        public String statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            List<Rental> rentals = _rentals;

            StringBuilder rentalResult = new StringBuilder();

            rentalResult.Append($"Rental record for{_name}\n");

            foreach (var rental in _rentals)
            {
                double thisAmount = 0;
                switch (rental.getMovie().getPriceCode())
                {
                    case 0:
                        {
                            thisAmount += 2;
                            if (rental.getDaysRented()>2)
                            {
                                thisAmount += (rental.getDaysRented() - 2) * 1.5;
                            }
                        }
                        break;
                    case 1:
                        {
                            thisAmount += rental.getDaysRented() * 3;
                        }
                        break;
                    case 2:
                        {
                            thisAmount += 1.5;
                            if (rental.getDaysRented()>3)
                            {
                                thisAmount += (rental.getDaysRented() - 3) * 1.5;
                            }
                        }
                        break;
                }

                frequentRenterPoints++;
                if (rental.getMovie().getPriceCode()==1 
                    && rental.getDaysRented()>1)
                {
                    rentalResult.Append($"\t {rental.getMovie().getTitle()}" +
                        $"\t{thisAmount}\n");
                    totalAmount += thisAmount;
                }
            }

            rentalResult.Append($"Amount owed is {totalAmount}\n");
            rentalResult.Append($"You earned {frequentRenterPoints} " +
                $"frequent renter points");


            return rentalResult.ToString();
        }

        //Let 重构
        public String statementRefactoring()
        {
            List<Rental> rentals = _rentals;

            StringBuilder rentalResult = new StringBuilder();

            rentalResult.Append($"Rental record for{_name}\n");

            foreach (var rental in _rentals)
            {
                //它变得多余了
                //但是调用几次就消耗几次性能
                //Martin 言：在类中可容易优化，牛呀！
                //合理的组织+管理
                //double thisAmount = 0;

                #region 移除了switch
                //thisAmount = amountFor(rental);
                #endregion 

                

                rentalResult.Append($"\t {rental.getMovie().getTitle()}" +
                        //$"\t{thisAmount}\n");
                        $"\t{rental.getCharge()}\n");
                //totalAmount += thisAmount;
            }

            rentalResult.Append($"Amount owed is {getTotalCharge()}\n");
            rentalResult.Append($"You earned {getTotalFrequentRenterPoints()} " +
                $"frequent renter points");


            return rentalResult.ToString();
        }

        /// <summary>
        /// the author make a mistake
        /// at the return type make double to int
        /// and he say:
        /// "Java无怨无忧地把double类型转为int类型
        /// ，而且还愉快地做了取整动作[Java Spec]"
        /// 
        /// Author：Martin Fowler
        /// Translator : 熊节
        /// 修改变量名称
        /// "好的代码应该清晰地表达自己的功能"
        /// Martin Fowler·作者曰："任何一个傻瓜都能写出计算机能够理解的代码，
        /// 唯有写出人类容易理解的代码，才是优秀的程序员"
        /// 
        /// 代码应该可以表现自己的，这个目的，应该是
        /// 在一位业务小白面前也可以清晰的知道代码，在干什么。_2019.05.12
        /// 母亲节·节日，果然是个好东西，它带动着气氛，促进人，去做事~
        /// 
        /// </summary>
        /// <param name="rental"></param>
        /// <returns></returns>
        //public double amountFor(Rental aRental)
        //{
        //    double result = 0;
        //    switch (aRental.getMovie().getPriceCode())
        //    {
        //        case 0:
        //            {
        //                result += 2;
        //                if (aRental.getDaysRented() > 2)
        //                {
        //                    result += (aRental.getDaysRented() - 2) * 1.5;
        //                }
        //            }
        //            break;
        //        case 1:
        //            {
        //                result += aRental.getDaysRented() * 3;
        //            }
        //            break;
        //        case 2:
        //            {
        //                result += 1.5;
        //                if (aRental.getDaysRented() > 3)
        //                {
        //                    result += (aRental.getDaysRented() - 3) * 1.5;
        //                }
        //            }
        //            break;
        //    }
        //    return result;
        //}

        public double amountFor(Rental aRental)
        {
            return aRental.getCharge();
        }

        public double getTotalCharge()
        {
            double result = 0;
            foreach (var rental in _rentals)
            {
                result += rental.getCharge();
            }
            return result;
        }

        public int getTotalFrequentRenterPoints()
        {
            int result = 0;
            foreach (var rental in _rentals)
            {
                result += rental.getFrequentRenterPoints();
            }
            return result;
        }
    }
}
