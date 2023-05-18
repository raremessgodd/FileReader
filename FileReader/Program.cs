using FileReaderProgram;

namespace FileReaderProgram;
public class Program
{
    public static void Main(String[] args)
    {
        int year, month;
        string path;
        bool isAdded;

        //меню самой программы должно +- повторять данный код
        //меню не должно быть сложным, я не оч хочу разбираться в формах,
        //а отчет писать все равно надо будет

        while (true)
        {
            printMenu();
            int command = Int32.Parse(Console.ReadLine()!);

            switch (command)
            {
                case 1:
                    Console.WriteLine("Отчет какого года вы хотите внести?");
                    year = Int32.Parse(Console.ReadLine()!);

                    Console.WriteLine("За какой месяц будет отчет?");
                    month = Int32.Parse(Console.ReadLine()!);

                    path = "/Users/macbookpro/Projects/FileReader/FileReader/resourses/month.txt";

                    isAdded = FileReader.ReadMonthFile(path, year, month);

                    if (isAdded)
                    {
                        Console.WriteLine("Файл " + path + " успешно добавлен.");
                    }
                    else
                    {
                        Console.WriteLine("Файл " + path + " передан в неверном формате.");
                    }

                    break;
                case 2:
                    Console.WriteLine("Отчет какого года вы хотите внести?");
                    year = Int32.Parse(Console.ReadLine()!);

                    path = "/Users/macbookpro/Projects/FileReader/FileReader/resourses/year.txt";

                    isAdded = FileReader.ReadYearFile(path, year);

                    if (isAdded)
                    {
                        Console.WriteLine("Файл " + path + " успешно добавлен.");
                    }
                    else
                    {
                        Console.WriteLine("Файл " + path + " передан в неверном формате.");
                    }

                    break;
                case 3:
                    if (FileReader.allYearsReports.Count == 0
                        || FileReader.allMonthsReports.Count == 0)
                    {
                        Console.WriteLine("Сначала нужно считать файлы.");
                    }
                    else
                    {
                        Checker.check();
                    }
                    break;
                case 4:
                    if (FileReader.allYearsReports.Count == 0
                        || FileReader.allMonthsReports.Count == 0)
                    {
                        Console.WriteLine("Сначала нужно считать файлы.");
                    }
                    else
                    {
                        Console.WriteLine("Отчетность за какой год вы хотите увидеть?");
                        year = Int32.Parse(Console.ReadLine()!);

                        FileReader.PrintMonthReport(year);
                    }
                    break;
                case 5:
                    if (FileReader.allYearsReports.Count == 0
                        || FileReader.allMonthsReports.Count == 0)
                    {
                        Console.WriteLine("Сначала нужно считать файлы.");
                    }
                    else
                    {
                        Console.WriteLine("Отчетность за какой год вы хотите увидеть?");
                        year = Int32.Parse(Console.ReadLine()!);

                        FileReader.PrintYearReport(year);
                    }
                    break;
                case 546:
                    return;
                default:
                    Console.WriteLine("Такой команды пока нет.");
                    break;
            }
        }
    }

    public static void printMenu()
    {
        Console.WriteLine("\n1 - Считать месячные файлы\n" +
                "2 - Считать годовые файлы\n" +
                "3 - Сверить отчеты\n" +
                "4 - Отчет за все месяца\n" +
                "5 - Отчет за год\n" +
                "Чтобы выйти введите: 546");
    }
}

