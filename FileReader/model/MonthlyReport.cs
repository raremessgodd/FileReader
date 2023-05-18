using System;

namespace FileReaderProgram.model
{
	public class MonthlyReport
	{
        private int yearNumber;
        private int monthNumber;
        private String monthName;
        private List<MonthProduct> monthReport = new List<MonthProduct>();

        public List<MonthProduct> GetMonthReport { get => monthReport; }
        public String GetMonthName { get => monthName; }
        public int GetMonthNumber { get => monthNumber; }
        public int GetYearNumber { get => yearNumber; }

        public MonthlyReport(string file, string monthName,
            int monthNumber, int yearNumber)
        {
            this.monthName = monthName;
            this.monthNumber = monthNumber;
            this.yearNumber = yearNumber;

            string[] lines = file.Split("\n");
            for (int line = 1; line < lines.Length; line++)
            {
                string[] columns = lines[line].Split(",");

                if (columns.Length != 4)
                {
                    throw new FormatException();
                }

                string itemName = columns[0];
                bool isExpense = Boolean.Parse(columns[1].ToLower());
                int quantity = Int32.Parse(columns[2]);
                int sumOfOne = Int32.Parse(columns[3]);

                MonthProduct product = new MonthProduct(isExpense, itemName, quantity, sumOfOne);

                monthReport.Add(product);
            }
        }

        public MonthProduct GetTheBiggestIncome()
        {
            int income = 0;
            MonthProduct theBiggestIncomeProduct = null!;
            foreach (MonthProduct product in monthReport)
            {
                int productIncome = product.GetQuantity * product.GetSumOfOne;
                if (!product.IsExpense && productIncome > income)
                {
                    income = productIncome;
                    theBiggestIncomeProduct = product;
                }
            }
            return theBiggestIncomeProduct;
        }

        public MonthProduct GetTheBiggestExpense()
        {
            int expense = 0;
            MonthProduct theBiggestExpenseProduct = null!;
            foreach (MonthProduct product in monthReport)
            {
                int productExpense = product.GetQuantity * product.GetSumOfOne;
                if (product.IsExpense && productExpense > expense)
                {
                    expense = productExpense;
                    theBiggestExpenseProduct = product;
                }
            }
            return theBiggestExpenseProduct;
        }
    }
}

