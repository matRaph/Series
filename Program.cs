using System;
using static System.Console;

namespace Series
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();
            while(userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSeries();
                        break;
                    case "3":
                        //UpdateSeries();
                        break;
                    case "4":
                        //DeleteSeries();
                        break;
                    case "5":
                        //SeriesOverview();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOption = GetUserOption();
            }
        }
        private static string GetUserOption()
        {
            WriteLine();
            WriteLine("This is your serie editor");
            WriteLine("What woud you like to do?");
            WriteLine("1 - List series");
            WriteLine("2 - Insert new serie");
            WriteLine("3 - Update serie");
            WriteLine("4 - Delete serie");
            WriteLine("5 - Serie overview");
            WriteLine("C - Clean screen");
            WriteLine("x - Exit");
            WriteLine();

            string userOption = ReadLine().ToUpper();
            WriteLine();
            return userOption;
        }

        private static void ListSeries()
        {
            WriteLine("List series");
            var list = repository.List();

            if (list.Count == 0)
            {
                WriteLine("No series registered\n");
                
            }

            foreach (var serie in list)
            {
                WriteLine("#ID {0}: - {1}", serie.ReturnID(), serie.ReturnTitle());
            }
        }

        private static void InsertSeries()
        {
            WriteLine("Insert new series");
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }
            WriteLine("Enter the genre from the options above: ");
            int inputGenre = int.Parse(ReadLine());

            WriteLine("Enter the series title: ");
            string inputTitle = ReadLine();

            WriteLine("Enter the series year: ");
            int inputYear = int.Parse(ReadLine());

            WriteLine("Enter the series description: ");
            string inputDescription = ReadLine();

            Series newSeries = new  Series(ID: repository.NextID(), Genre: (Genre)inputGenre,
                                           Title: inputTitle, Description: inputDescription, 
                                           Year: inputYear);
            repository.Insert(newSeries);
        }
    }
}
