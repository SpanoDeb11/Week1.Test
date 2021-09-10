using System;
using System.Collections.Generic;
using System.IO;
using Week1.Test.Handler;

namespace Week1.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\debora.spano\Desktop\Week1\Test";
            // utilizzo i file watcher per monitorare i file "spese.txt"
            FileSystemWatcher fileSW = new FileSystemWatcher
            {
                Path = path,
                Filter = "spese.txt"
            };
            fileSW.EnableRaisingEvents = true;
            fileSW.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName;
            fileSW.Created += WatcherEvent.Event;

            Console.WriteLine("Inserisci il file nel path");
            while (Console.Read() != 'c') ;

            // creo la chain of responsibility
            IHandler manager = new Manager();
            IHandler operationalManager = new OperationalManager();
            IHandler ceo = new CEO();

            manager.SetNext(operationalManager).SetNext(ceo);
            foreach(Expense ex in Expense.Expenses)
            {
                string result = manager.Handle(ex);
                Console.WriteLine(result);
            }

            // gestisco le categoria con la factory e stampo su file
            using (StreamWriter writer = File.CreateText(path + @"\spese_elaborate.txt"))
            {
                // stampo l'intestazione
                writer.WriteLine("Data - Categoria - Descrizioni - Approvazione - LvlApprv - Importo Rimborso");
            }
            foreach (Expense ex in Expense.Expenses)
            {
                CategoryFactory factory = new CategoryFactory(ex);
                Expense.WriteToFile(path + @"\spese_elaborate.txt", ex, factory.GetCategory());
            }
        }

        
    }
}
