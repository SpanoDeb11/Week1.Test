using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.Test.Category;

namespace Week1.Test
{
    class CategoryFactory
    {
        public Expense Expense { get; }

        public CategoryFactory(Expense expense)
        {
            Expense = expense;
        }

        public ICategory GetCategory()
        {
            ICategory categoryClass = null;

            switch (Expense.Category)
            {
                case "Travel":
                    categoryClass = new Travel
                    {
                        Repayment = Expense.Amount + 50.0
                    };
                    break;
                case "House":
                    categoryClass = new House
                    {
                        Repayment = Expense.Amount
                    };
                    break;
                case "Vitto":
                    categoryClass = new Vitto
                    {
                        Repayment = (Expense.Amount * 70) / 100
                    };
                    break;
                default:
                    categoryClass = new Other
                    {
                        Repayment = (Expense.Amount * 10) / 100
                    };
                    break;
            }
            return categoryClass;
        }
    }
}
