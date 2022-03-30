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
                        UpdateSeries();
                        break;
                    case "4":
                        DeleteSeries();
                        break;
                    case "5":
                        OverviewSeries();
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
            WriteLine("5 - Series overview");
            WriteLine("C - Clean screen");
            WriteLine("x - Exit\n");

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
                var excluded = serie.ReturnExcluded();
                WriteLine("#ID {0}: - {1} {2}", serie.ReturnID(), serie.ReturnTitle(), (excluded ? "*Removed*" : ""));
            }
        }

        private static void InsertSeries()
        {
            WriteLine("Insert new series");
            //List genre enum by name
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

            Series newSeries = new Series(ID: repository.NextID(), Genre: (Genre)inputGenre,
                                           Title: inputTitle, Description: inputDescription, 
                                           Year: inputYear);
            repository.Insert(newSeries);
        }
        
        private static void UpdateSeries()
        {
            Console.WriteLine("Insert series ID: ");
            int seriesIndex = int.Parse(Console.ReadLine());
            WriteLine("Insert new series");
            //List genre enum by name
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

            Series updateSeries = new Series(ID: seriesIndex, Genre: (Genre)inputGenre,
                                           Title: inputTitle, Description: inputDescription,
                                           Year: inputYear);
            repository.Update(seriesIndex, updateSeries);

        }

        private static void DeleteSeries()
        {
            Console.WriteLine("Insert series ID: ");
            int serieIndex = int.Parse(Console.ReadLine());

            repository.Remove(serieIndex);
        }

        private static void OverviewSeries()
        {
            Console.WriteLine("Insert series ID: ");
            int seriesIndex = int.Parse(Console.ReadLine());

            var series = repository.ReturnByID(seriesIndex);
            Console.WriteLine(series);
        }
    }
}
