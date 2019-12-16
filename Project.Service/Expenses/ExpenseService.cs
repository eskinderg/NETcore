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
    public IRepository<Expense> ExpenseRepository { get; }

    public ExpenseService(IRepository<Expense> expenseRepository) => ExpenseRepository = expenseRepository;

    public Expense GetById(int id) => ExpenseRepository.GetById(id);

    public IEnumerable<Expense> All => ExpenseRepository.Table.Include(e => e.Category).ToList();

    public IEnumerable<Expense> AllUnexpiredExpenses =>
      ExpenseRepository.Table.Include(e => e.Category.SubCategory)
      .Where(e => e.Date > DateTime.Now);
    public IEnumerable<Expense> ExpiredExpenses => null;

    public IEnumerable<Expense> RemoveExpiredExpenses => null;
  }
}
