﻿using Bogus;
using CashFlow.Domain.Enums;
using CashFlow.Domain.Entities;

namespace CommonTestUtilities.Entities
{
    public class ExpenseBuilder
    {
        public static List<Expense> Collection(User user, uint count = 2)
        {
            var list = new List<Expense>();

            if (count == 0)
                count = 1;

            var expenseId = 1;

            for (int i = 0; i < count; i++)
            {
                var expense = Build(user);
                expense.Id = expenseId++;

                list.Add(expense);
            }
            return list;
        }

        public static Expense Build(User user)
        {
            return new Faker<Expense>()
                   .RuleFor(u => u.Id, _ => 1)
                   .RuleFor(u => u.Title, faker => faker.Commerce.ProductName())
                   .RuleFor(r => r.Description, faker => faker.Commerce.ProductDescription())
                   .RuleFor(r => r.Date, faker => faker.Date.Past())
                   .RuleFor(r => r.Amount, faker => faker.Random.Decimal(min: 1, max: 1000))
                   .RuleFor(r => r.PaymentType, faker => faker.PickRandom<PaymentType>())
                   .RuleFor(r => r.UserId, _ => user.Id)
                   .RuleFor(r => r.Tags, faker => faker.Make(1, () => new CashFlow.Domain.Entities.Tag
                   {
                       Id = 1,
                       Value = faker.PickRandom<CashFlow.Domain.Enums.Tag>(),
                       ExpenseId = 1
                   }));
        }
    }
}
