﻿using CashFlow.Application.UseCases.Expenses.Reports.Pdf;
using CashFlow.Domain.Entities;
using CommonTestUtilities.Entities;
using CommonTestUtilities.LoggedUser;
using CommonTestUtilities.Repositories.Expenses;
using FluentAssertions;

namespace UseCases.Test.Expenses.Reports.Pdf
{
    public class GenerateExpensesReportPdfUseCaseTest
    {
        [Fact]
        public async Task Success()
        {
            var loggedUser = UserBuilder.Build();
            var expenses = ExpenseBuilder.Collection(loggedUser);

            var useCase = CreateUseCase(loggedUser, expenses);

            var result = await useCase.Execute(DateOnly.FromDateTime(DateTime.Today));

            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task Success_Empty()
        {
            var loggedUser = UserBuilder.Build();

            var useCase = CreateUseCase(loggedUser, []);

            var result = await useCase.Execute(DateOnly.FromDateTime(DateTime.Today));

            result.Should().BeEmpty();
        }

        private GenerateExpensesReportPdfUseCase CreateUseCase(User user, List<Expense> expenses)
        {
            var respository = new ExpensesReadOnlyRepositoryBuilder().FilterByMonth(user, expenses).Build();
            var loggedUser = LoggeduserBuilder.Build(user);

            return new GenerateExpensesReportPdfUseCase(respository, loggedUser);
        }
    }
}
