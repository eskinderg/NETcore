using System.Collections.Generic;
using Project.Model;

namespace Project.Services
{
  public interface IExpenseService : IService<Expense>
  {
    Expense GetById(int id);

    IEnumerable<Expense> All                   { get; }

    IEnumerable<Expense> AllUnexpiredExpenses  { get; }

    IEnumerable<Expense> ExpiredExpenses       { get; }

    IEnumerable<Expense> RemoveExpiredExpenses { get; }
  }
}
