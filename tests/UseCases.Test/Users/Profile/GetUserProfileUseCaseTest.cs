using CashFlow.Application.UseCases.Users.Profile;
using CashFlow.Domain.Entities;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;
using CommonTestUtilities.Entities;
using CommonTestUtilities.LoggedUser;
using CommonTestUtilities.Mapper;
using FluentAssertions;

namespace UseCases.Test.Users.Profile
{
    public class GetUserProfileUseCaseTest
    {
        [Fact]
        public async Task Success()
        {
            var user = UserBuilder.Build();
            var useCase = CreateUseCase(user);

            var result = await useCase.Execute();

            result.Should().NotBeNull();
            result.Name.Should().Be(user.Name);
            result.Email.Should().Be(user.Email);
        }

        [Fact]
        public async Task User_Not_Found()
        {
            var loggedUser = UserBuilder.Build();

            var useCase = CreateUseCase(null);

            var act = async () => await useCase.Execute();

            var result = await act.Should().ThrowAsync<NotFoundException>();

            result.Where(ex => ex.GetErrors().Count == 1 &&
                ex.GetErrors().Contains(ResourceErrorMessages.USER_NOT_FOUND));
        }

        private GetUserProfileUseCase CreateUseCase(User? user = null)
        {
            var mapper = MapperBuilder.Build();
            var loggedUser = LoggeduserBuilder.Build(user!);

            return new GetUserProfileUseCase(loggedUser, mapper);
        }
    }
}
