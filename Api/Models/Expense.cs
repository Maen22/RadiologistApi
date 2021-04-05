using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        public decimal ExpenseValue { get; set; }
        public string ExpenseDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; }

        public int ExpenseTypeId { get; set; }
        public virtual ExpenseType ExpenseType { get; set; }
    }
}