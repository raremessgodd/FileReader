using System;
using FileReaderProgram.model;

namespace FileReaderProgram
{
	public static class FileReader
	{
        public static List<MonthlyReport> allMonthsReports = new List<MonthlyReport>();
        public static List<YearlyReport> allYearsReports = new List<YearlyReport>();

        public static String ReadFile(String path)
        {
            String file = File.ReadAllText(path);
            return file;
        }

        public static bool ReadMonthFile(string path, int year, int month)
        {
            string file = ReadFile(path);

            string monthName = GetMonthName(month);
            if (monthName.Equals("NO_SUCH_MONTH"))
            {
                return false;
            }

            MonthlyReport monthReport;
            try
            {
                monthReport = new MonthlyReport(file, monthName, month, year);
            }
            catch (FormatException)
            {
                return false;
            }

            allMonthsReports.Add(monthReport);

            return true;
        }

        public static bool ReadYearFile(string path, int year)
        {
            string file = ReadFile(path); 

            YearlyReport yearReport;
            try
            {
                yearReport = new YearlyReport(file, year);
            }
            catch (FormatException)
            {
                return false;
            }

            allYearsReports.Add(yearReport);

            return true;
        }

        public static void PrintMonthReport(int year)
        {
            MonthlyReport monthReport = null!;
            foreach (MonthlyReport report in allMonthsReports)
            {
                if (report.GetYearNumber == year)
                {
                    monthReport = report;

                    Console.WriteLine("\n" + monthReport.GetMonthName + ":");

                    int income = monthReport.GetTheBiggestIncome().GetAmount;
                    Console.WriteLine("Самый прибыльный товар: " +
                        monthReport.GetTheBiggestIncome().GetItemName + " - " + income + " р.");

                    int expense = monthReport.GetTheBiggestExpense().GetAmount;
                    Console.WriteLine("Самая большая трата: " +
                        monthReport.GetTheBiggestExpense().GetItemName + " - " + expense + " р.");
                }
            }

            if (monthReport == null)
            {
                Console.WriteLine("Месячных отчетов за указанный год нет.");
                return;
            }
        }

        public static void PrintYearReport(int year)
        {
            YearlyReport yearReport = null!;
            foreach (YearlyReport report in allYearsReports)
            {
                if (report.GetYearNumber == year)
                {
                    yearReport = report;
                }
            }

            if (yearReport == null)
            {
                Console.WriteLine("Годовых отчетов за указанный год нет.");
                return;
            }

            Console.WriteLine("\nГод " + yearReport.GetYearNumber + ":");

            foreach (MonthlyReport monthReport in allMonthsReports)
            {
                int income = yearReport.GetIncome(monthReport.GetMonthNumber);
                Console.WriteLine("Доход за " + monthReport.GetMonthName.ToLower() +
                    " - " + income + " р.");
            }

            Console.WriteLine("Средний доход за " + yearReport.GetYearNumber +
                "-ый год - " + yearReport.GetAverage(false) + " р.");

            Console.WriteLine("Средняя трата за " + yearReport.GetYearNumber +
                "-ый год - " + yearReport.GetAverage(true) + " р.");
        }

        private static string GetMonthName(int monthNumber)
        {
            string[] months = { "Январь", "Февраль", "Март",
                "Апрель", "Май", "Июнь",
                "Июль", "Август", "Сентябрь",
                "Октябрь", "Ноябрь", "Декабрь" };

            if (monthNumber >= months.Length)
            {
                return "NO_SUCH_MONTH";
            }
            else
            {
                return months[monthNumber - 1];
            }
        }
    }
}