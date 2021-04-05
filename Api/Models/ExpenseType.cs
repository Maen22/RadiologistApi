using System.Collections;
using System.Collections.Generic;

namespace Api.Models
{
    public class ExpenseType
    {
        public int ExpenseTypeId { get; set; }
        public string ExpenseTypeName { get; set; }
        public string UserId { get; set; }
        
        public virtual IEnumerable<Expense> Expenses { get; set; }
    }
}