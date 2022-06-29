/*
 * It's a simple .NET 6 Blazor Server application allowing to create a list of expenses.
 * It's a part of self-learning Blazor Server.
 * Author: Marat Nikitin
 * When: June 2022
 * This file contains async methods for working with user entries.
 */

namespace BudgetBookDemo.Data
{
    public class BudgetBookService
    {
        private static List<Entry> mockDb = new List<Entry>()
        {
            //new Entry(){Description="Test", Amount = 4.99m}
        };

        public async Task<bool> AddEntry(Entry newEntry)
        {
            mockDb.Add(newEntry);
            return true;
        }

        public async Task<List<Entry>> GetAllEntries()
        {
            return mockDb;
        }
                
    }
}
