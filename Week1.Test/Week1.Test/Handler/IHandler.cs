using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.Test.Handler
{
    public interface IHandler
    {
        public string Name { get; set; }
        IHandler SetNext(IHandler handler);
        string Handle(Expense expense);
    }
}
