﻿using CashFlow.Application.UseCases.Users.Delete;
using CashFlow.Domain.Entities;
using CommonTestUtilities.Entities;
using CommonTestUtilities.LoggedUser;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Repositories.User;
using FluentAssertions;

namespace Validators.Test.Users.Delete
{
    public class DeleteUserAccountUseCaseTest
    {
        [Fact]
        public async Task Success()
        {
            var user = UserBuilder.Build();
            var useCase = CreateUseCase(user);

            var act = async () => await useCase.Execute();

            await act.Should().NotThrowAsync();
        }

        private DeleteUserAccountUseCase CreateUseCase(User user)
        {
            var repository = UserWriteOnlyRepositoryBuilder.Build();
            var loggedUser = LoggeduserBuilder.Build(user);
            var unitOfWork = UnitOfWorkBuilder.Build();

            return new DeleteUserAccountUseCase(unitOfWork, repository, loggedUser);
        }
    }
}
