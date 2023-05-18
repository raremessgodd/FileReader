using System;
using FileReaderProgram.model;

namespace FileReaderProgram
{
	public static class Checker
	{

        public static int getMonthAmount(int monthNumber, bool isExpense)
        {
            int amount = 0;
            foreach (MonthlyReport report in FileReader.allMonthsReports)
            {
                foreach (MonthProduct product in report.GetMonthReport)
                {
                    if (product.IsExpense == isExpense)
                    {
                        amount += product.GetAmount;
                    }
                }
            }
            return amount;
        }

        public static int getYearAmount(int yearNumber, int monthNumber, bool isExpense)
        {
            int amount = 0;

            foreach (YearlyReport report in FileReader.allYearsReports)
            {
                foreach (MonthInfo info in report.GetYearReport)
                {
                    if (info.IsExpense == isExpense && info.GetMonthNumber == monthNumber)
                    {
                        amount = info.GetAmount;
                    }
                }
            }
            return amount;
        }

        public static void check()
        {
            foreach (YearlyReport yearReport in FileReader.allYearsReports)
            {
                foreach (MonthlyReport monthReport in FileReader.allMonthsReports)
                {
                    int monthTrueValue = getMonthAmount(monthReport.GetMonthNumber, true);
                    int monthFalseValue = getMonthAmount(monthReport.GetMonthNumber, false);
                    int yearTrueValue = getYearAmount(yearReport.GetYearNumber, monthReport.GetMonthNumber, true);
                    int yearFalseValue = getYearAmount(yearReport.GetYearNumber, monthReport.GetMonthNumber, false);

                    if (monthTrueValue != yearTrueValue || monthFalseValue != yearFalseValue)
                    {
                        Console.WriteLine("Отчет за " + monthReport.GetMonthNumber + "-ый месяц " + yearReport.GetYearNumber + "-ого года не совпадает с годовым.");
                    }
                    else
                    {
                        Console.WriteLine("Отчет за " + monthReport.GetMonthNumber + "-ый месяц " + yearReport.GetYearNumber + "-ого года совпадает с годовым.");
                    }
                }
            }
        }
    }
}

