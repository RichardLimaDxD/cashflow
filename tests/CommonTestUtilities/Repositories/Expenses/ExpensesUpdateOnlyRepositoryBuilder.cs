﻿using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Moq;

namespace CommonTestUtilities.Repositories.Expenses
{
    public class ExpensesUpdateOnlyRepositoryBuilder
    {
        private readonly Mock<IExpensesUpdateOnlyRepository> _repository;

        public ExpensesUpdateOnlyRepositoryBuilder()
        {
            _repository = new Mock<IExpensesUpdateOnlyRepository>();
        }

        public ExpensesUpdateOnlyRepositoryBuilder GetById(CashFlow.Domain.Entities.User user, Expense? expense)
        {
            if (expense is not null)
                _repository.Setup(repository => repository.GetById(user, expense.Id)).ReturnsAsync(expense);

            return this;
        }

        public IExpensesUpdateOnlyRepository Build() => _repository.Object;

    }
}
