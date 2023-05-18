using System;

namespace FileReaderProgram.model
{
	public class YearlyReport
	{
        private int yearNumber;
        private List<MonthInfo> yearReport = new List<MonthInfo>();

        public List<MonthInfo> GetYearReport { get => yearReport; }

        public int GetYearNumber { get => yearNumber; }

        public YearlyReport(string file, int yearNumber)
        {
            this.yearNumber = yearNumber;
            String[] lines = file.Split("\n");
            for (int line = 1; line < lines.Length; line++)
            {
                String[] columns = lines[line].Split(",");

                if (columns.Length != 3)
                {
                    throw new FormatException();
                }

                int monthNumber = Int32.Parse(columns[0]);
                int amount = Int32.Parse(columns[1]);
                bool isExpense = Boolean.Parse(columns[2]);

                MonthInfo monthInfo = new MonthInfo(isExpense, monthNumber, amount);

                yearReport.Add(monthInfo);
            }
        }

        public int GetIncome(int monthNumber)
        {
            int income = 0;
            foreach (MonthInfo monthInfo in yearReport)
            {
                if (monthInfo.GetMonthNumber == monthNumber)
                {
                    if (monthInfo.IsExpense)
                    {
                        income -= monthInfo.GetAmount;
                    }
                    else
                    {
                        income += monthInfo.GetAmount;
                    }
                }
            }
            return income;
        }

        public int GetAverage(bool isExpense)
        {
            int average = 0;
            foreach (MonthInfo monthInfo in yearReport)
            {
                if (monthInfo.IsExpense == isExpense)
                {
                    average += monthInfo.GetAmount;
                }
            }
            return average / (yearReport.Count / 2);
        }
    }
}

