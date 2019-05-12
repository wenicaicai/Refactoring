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
        ///客户会在六个月 也就是180天内修改需求
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
        /// Step 2:
        /// Step 3:
        /// Step 4:
        /// Step 5:
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
                            if (rental.getDaysRented() > 2)
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
                            if (rental.getDaysRented() > 3)
                            {
                                thisAmount += (rental.getDaysRented() - 3) * 1.5;
                            }
                        }
                        break;
                }

                frequentRenterPoints++;
                if (rental.getMovie().getPriceCode() == 1
                    && rental.getDaysRented() > 1)
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

        public decimal amountFor()
        {
            return 0;
        }
    }
}
