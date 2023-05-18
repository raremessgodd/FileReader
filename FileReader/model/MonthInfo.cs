using System;

namespace FileReaderProgram.model
{
    public class MonthInfo 
	{
        private int monthNumber;
        private int amount;
        private bool isExpense;

        public MonthInfo(bool isExpense, int monthNumber, int amount)
        {
            this.isExpense = isExpense;
            this.monthNumber = monthNumber;
            this.amount = amount;
        }

        public int GetMonthNumber { get => monthNumber; }
        public int GetAmount { get => amount; }
        public bool IsExpense { get => isExpense; }
    }
}

