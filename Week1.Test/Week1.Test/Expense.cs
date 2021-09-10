using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.Test.Category;
using Week1.Test.Handler;

namespace Week1.Test
{
    public class Expense
    {
        public static List<Expense> Expenses = new List<Expense>();

        public DateTime ExpenseDate { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public bool Approved { get; set; }
        public IHandler ApprovalLevel { get; set; }

        // non ho messo questo metodo in "WatcherEvent" perchè non viene richiamato dall'evento
        public static void WriteToFile(string path, Expense expense, ICategory category)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(path))
                {
                    if (expense.Approved)
                    {
                        writer.WriteLine($"{expense.ExpenseDate};{expense.Category};{expense.Description};" +
                                          $"APPROVATA;{expense.ApprovalLevel.Name};{category.Repayment}");
                    }
                    else
                    {
                        writer.WriteLine($"{expense.ExpenseDate};{expense.Category};{expense.Description};" +
                                          $"RESPINTA;-;-");
                    }
                }
            }
            catch (IOException ioex)
            {
                Console.WriteLine($"Errore IO: {ioex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }
        }
    }
}
