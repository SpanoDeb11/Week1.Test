using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.Test.Handler
{
    public abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;
        public string Name { get; set; }
        public virtual string Handle(Expense expense)
        {
            if(_nextHandler != null)
            {
                return _nextHandler.Handle(expense);
            }
            expense.Approved = false; // se la richiesta non è approvata
            return null;
        }

        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return _nextHandler;
        }
    }
}
