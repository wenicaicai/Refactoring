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
    }
}
