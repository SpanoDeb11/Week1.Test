using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.Test
{
    public class WatcherEvent
    {
        public static void Event(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Sto gestendo l'evento {e.ChangeType}, premi 'c' per continuare");

            ReadFromFile(e);
        }

        private static void ReadFromFile(FileSystemEventArgs e)
        {
            try
            {
                using(StreamReader r = File.OpenText(e.FullPath))
                {
                    r.ReadLine(); // ignoro l'intestazione del file.
                    string line = r.ReadLine();
                    while (line != null)
                    {
                        string[] values = line.Split(";");
                        Expense expense = new Expense
                        {
                            ExpenseDate = DateTime.Parse(values[0]),
                            Category = values[1].Trim(),
                            Description = values[2].Trim(),
                            Amount = double.Parse(values[3])
                        };
                        Expense.Expenses.Add(expense); // aggiungo la spesa nella lista delle spese
                        line = r.ReadLine();
                    }
                }
            }
            catch (IOException ioex)
            {
                Console.WriteLine($"Errore IO: {ioex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }
        }
    }
}
