using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Project.Model;
using Project.Data;

namespace Project.Services
{
  public class ExpenseService : IExpenseService
  {
    public IRepository<Expense> Repository { get; }

    public ExpenseService(IRepository<Expense> repository) => Repository = repository;

    public Expense GetById(int id) => Repository.GetById(id);

    public IEnumerable<Expense> All => Repository.Table.Include(e => e.Category).ToList();

    public IEnumerable<Expense> AllUnexpiredExpenses =>
      Repository.Table.Include(e => e.Category.SubCategory)
      .Where(e => e.Date > DateTime.Now);

    public IEnumerable<Expense> ExpiredExpenses => null;

    public IEnumerable<Expense> RemoveExpiredExpenses => null;
  }
}
