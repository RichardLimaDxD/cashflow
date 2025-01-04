using CashFlow.Domain.Security.Cryptography;
using Moq;

namespace CommonTestUtilities.Cryptography
{
    public class PasswordEncrypterBuilder
    {
        private readonly Mock<IPasswordEncrypter> _mock;

        public PasswordEncrypterBuilder()
        {
            _mock = new Mock<IPasswordEncrypter>();

            _mock.Setup(passwordEncripter =>
                passwordEncripter.Encrypt(It.IsAny<string>())).Returns("@%!%SGAVHGV!%$$@#$");
        }

        public PasswordEncrypterBuilder Verify(string? password)
        {
            if (!string.IsNullOrWhiteSpace(password))
                _mock.Setup(PasswordEncrypter => PasswordEncrypter.Verify(password, It.IsAny<string>())).Returns(true);

            return this;
        }

        public IPasswordEncrypter Build() => _mock.Object;
    }
}
