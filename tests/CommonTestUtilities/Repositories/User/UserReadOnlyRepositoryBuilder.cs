using CashFlow.Domain.Repositories.User;
using Moq;

namespace CommonTestUtilities.Repositories.User
{
    public class UserReadOnlyRepositoryBuilder
    {
        private readonly Mock<IUserReadOnlyRepository> _repository;

        public UserReadOnlyRepositoryBuilder()
        {
            _repository = new Mock<IUserReadOnlyRepository>();
        }

        public IUserReadOnlyRepository Build() => _repository.Object;
    }
}
