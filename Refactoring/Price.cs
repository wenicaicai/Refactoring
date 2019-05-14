using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
    public abstract class Price
    {
        public abstract int getPriceCode();
    }

    public class ChildrensPrice : Price
    {
        public override int getPriceCode()
        {
            return 2;
        }
    }

    public class NewReleasePrice : Price
    {
        public override int getPriceCode()
        {
            return 1;
        }
    }

    public class RegularPrice : Price
    {
        public override int getPriceCode()
        {
            return 0;
        }
    }

}
