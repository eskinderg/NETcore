using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Project.Model;
using Project.Data;

namespace Project.Services
{
    public class ExpenseService: IExpenseService
    {
        private readonly IRepository<Expense> _expenseRepository;

        public ExpenseService(IRepository<Expense> expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public Expense GetById(int id)
        {
            return _expenseRepository.GetById(id);
            //return GetById(id);
        }

        public IEnumerable<Expense> All()
        {
            return _expenseRepository.Table.Include(e => e.Category).ToList();
            //return Select().Include(e => e.Category.SubCategory);
        }

        public IEnumerable<Expense> GetAllUnexpiredExpenses()
        {

            return _expenseRepository.Table.Include(e => e.Category.SubCategory)
                                                .Where(e => e.Date > DateTime.Now);
            //return Select().Include(e => e.Category.SubCategory)
            //                                    .Where(e => e.Date > DateTime.Now);
        }

        public IEnumerable<Expense> GetExpiredExpenses()
        {
            return null;
            //return Select().Include(e => e.Category.SubCategory)
             //                                   .Where(e => e.Date < DateTime.Now);
        }

        public IEnumerable<Expense> RemoveExpiredExpenses()
        {
            return null;
            //var expiredExpenses = GetExpiredExpenses();
            //return DeleteRange(expiredExpenses, true);
        }
    }
}
