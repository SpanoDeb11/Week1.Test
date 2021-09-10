using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.Test.Handler
{
    public class Manager : AbstractHandler
    {
        public Manager()
        {
            Name = "Manager";
        }
        public override string Handle(Expense expense)
        {
            if(expense.Amount <= 400.0 && expense.Amount >= 0.0) 
            {
                expense.Approved = true; // setto a true l'approvazione
                expense.ApprovalLevel = this; // setto il livello di approvazione
                return $"La spesa di {expense.Amount} euro è stata approvata è verrà gestita dal Manager";
            }
            return base.Handle(expense);
        }
    }
}
