﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using No8.Solution;
using No8.Solution.Fabrics;
using No8.Solution.Printers;
using static System.Console;

namespace No8.Solution.Console
{
    public class Program
    {
        private static PrinterManager manager = PrinterManager.GetInstance;
        private static Factory factory = new Factory();

        [STAThread]
        public static void Main(string[] args)
        {
            manager.Add(new EpsonPrinter("1234"));
            manager.Add(new CanonPrinter("18x-6"));

            bool flag = true;

            while (flag)
            {
                var printers = manager.GetPrinters();
                var uniqueNames = UniqueNames(printers);

                ShowMenu(uniqueNames);

                var key = ReadKey();
                WriteLine();

                flag = ActMenu(key, printers, uniqueNames, 2);
            }
        }

        private static void Print(Printer printer)
        {
            manager.Print(printer, @"E:\SourceFile.txt");
        }

        private static void CreatePrinter()
        {
            WriteLine("Enter printer name: ");
            string name = ReadLine();

            WriteLine("Enter printer model: ");
            string model = ReadLine();

            manager.Add(factory.CreatePrinter(name, model));
        }

        private static void ShowMenu(List<string> list)
        {
            WriteLine("Select your choice:");
            WriteLine("1:Add new printer");

            int index = 2;

            foreach (var name in list)
            {
                WriteLine($"{index++}:Print on {name};");
            }

            WriteLine($"{index}:Exit.");
        }

        private static bool ActMenu(ConsoleKeyInfo key, IReadOnlyCollection<Printer> printers, List<string> names, int pointToElement)
        {
            int valueKey = (int) Char.GetNumericValue(key.KeyChar);

            if (valueKey >= 1 && valueKey <= names.Count + pointToElement)
            {
                if (valueKey == 1)
                {
                    CreatePrinter();
                }
                else if (valueKey == names.Count + pointToElement)
                {
                    return false;
                }
                else
                {
                    string printerName = names.ElementAt(valueKey - pointToElement);
                    List<Printer> models = new List<Printer>(printers.Where(p => p.Name == printerName));
                    ShowModels(models);

                    var newKey = ReadKey();

                    int newValueKey = (int) Char.GetNumericValue(newKey.KeyChar);
                    ;

                    if (newValueKey > 0 && newValueKey <= models.Count)
                    {
                        Print(models.ElementAt(newValueKey - 1));
                    }
                    else
                    {
                        WriteLine("Invalid chose.\nTry again.\n");
                    }
                }
            }
            else
            {
                WriteLine("Invalid chose.\nTry again.\n");
            }

            return true;
        }

        private static void ShowModels(IEnumerable<Printer> models)
        {
            int index = 1;
            WriteLine("Select model: ");
            foreach (var printer in models)
            {
                WriteLine($"{index++}. {printer.Name}: {printer.Model};");
            }
        }

        private static List<string> UniqueNames(IReadOnlyCollection<Printer> printers)
        {
            List<string> uniqueNames = new List<string>();

            foreach (var printer in printers)
            {
                if (!uniqueNames.Contains(printer.Name))
                {
                    uniqueNames.Add(printer.Name);
                }
            }

            return uniqueNames;
        }

        private static List<Printer> ModelOfPrinter(string name, List<Printer> printers)
        {
            return new List<Printer>(printers.Where(p => p.Name == name));
        }
    }
}