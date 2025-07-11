﻿using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using DocumentFormat.OpenXml.Spreadsheet;
using Moq;
using PdfSharp.Drawing;

namespace CommonTestUtilities.Repositories.Expenses
{
    public class ExpensesReadOnlyRepositoryBuilder
    {
        private readonly Mock<IExpensesReadOnlyRepository> _repository;

        public ExpensesReadOnlyRepositoryBuilder()
        {
            _repository = new Mock<IExpensesReadOnlyRepository>();
        }

        public ExpensesReadOnlyRepositoryBuilder GetAll(CashFlow.Domain.Entities.User user, List<Expense> expenses)
        {
            _repository.Setup(repository => repository.GetAll(user)).ReturnsAsync(expenses);

            return this;
        }

        public ExpensesReadOnlyRepositoryBuilder GetById(CashFlow.Domain.Entities.User user, Expense? expense)
        {
            if (expense is not null)
                _repository.Setup(repository => repository.GetById(user, expense.Id)).ReturnsAsync(expense);

            return this;
        }

        public ExpensesReadOnlyRepositoryBuilder FilterByMonth(CashFlow.Domain.Entities.User user, List<Expense> expenses)
        {
            _repository.Setup(repository => repository.FilterByMonth(user, It.IsAny<DateOnly>())).ReturnsAsync(expenses);

            return this;
        }

        public IExpensesReadOnlyRepository Build() => _repository.Object;
    }
}
