/*
 * It's a simple .NET 6 Blazor Server application allowing to create a list of expenses.
 * It's a part of self-learning Blazor Server.
 * Author: Marat Nikitin
 * When: June 2022
 * This file contains the Entry class.
 */

namespace BudgetBookDemo.Data
{
    public class Entry
    {
        public decimal Amount { get; set; }
        public string? Description { get; set; }
    }
}
