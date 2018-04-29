using System.Collections.Generic;
using Project.Model;

namespace Project.Services
{
    public interface IExpenseService
    {
        Expense GetById(int id);

        IEnumerable<Expense> All();

        IEnumerable<Expense> GetAllUnexpiredExpenses();

        IEnumerable<Expense> GetExpiredExpenses();

        IEnumerable<Expense> RemoveExpiredExpenses();

    }
}
