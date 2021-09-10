using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.Test.Handler
{
    public class CEO : AbstractHandler
    {
        public CEO()
        {
            Name = "CEO";
        }
        public override string Handle(Expense expense)
        {
            if (expense.Amount <= 2500.0)
            {
                expense.Approved = true; // setto a true l'approvazione
                expense.ApprovalLevel = this; // setto il livello di approvazione
                return $"La spesa di {expense.Amount} euro è stata approvata è verrà gestita dal CEO";
            }
            return base.Handle(expense);
        }
    }
}
