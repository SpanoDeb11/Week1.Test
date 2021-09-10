using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.Test.Handler
{
    public class OperationalManager : AbstractHandler
    {
        public OperationalManager()
        {
            Name = "OperationalManager";
        } 

        public override string Handle(Expense expense)
        {
            if (expense.Amount <= 1000.0)
            {
                expense.Approved = true; // setto a true l'approvazione
                expense.ApprovalLevel = this; // setto il livello di approvazione
                return $"La spesa di {expense.Amount} euro è stata approvata è verrà gestita dal Operational Manager";
            }
            return base.Handle(expense);
        }
    }
}
