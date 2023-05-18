using System;

namespace FileReaderProgram.model
{
    public class MonthProduct 
    {
        private string? itemName;
        private int quantity;
        private int sumOfOne;
        private bool isExpense;

        public MonthProduct(bool isExpense, string? itemName,int quantity, int sumOfOne)
        {
            this.itemName = itemName;
            this.quantity = quantity;
            this.sumOfOne = sumOfOne;
            this.isExpense = isExpense;
        }

        public string? GetItemName { get => itemName; }
        public int GetQuantity { get => quantity; }
        public int GetSumOfOne { get => sumOfOne; }
        public int GetAmount { get => sumOfOne * quantity; }
        public bool IsExpense { get => isExpense; }
    }
}

