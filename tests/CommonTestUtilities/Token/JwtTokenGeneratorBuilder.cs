using CashFlow.Domain.Entities;
using CashFlow.Domain.Security.Tokens;
using Moq;

namespace CommonTestUtilities.Token
{
    public class JwtTokenGeneratorBuilder
    {
        public static IAccessTokenGenerator Build()
        {
            var mock = new Mock<IAccessTokenGenerator>();

            mock.Setup(accessTokenGenerator =>
                accessTokenGenerator.Generate(It.IsAny<User>())).Returns("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlJpY2hhcmQiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zaWQiOiI4NWJhYjMxYi01YjViLTQ5OWMtOWIzOS03MjNhYWE3OTgzMTciLCJuYmYiOjE3MzYwMTA3MzEsImV4cCI6MTczNjA3MDczMSwiaWF0IjoxNzM2MDEwNzMxfQ.5lioZPjLUBYg7CIC7CJaRi7TvtFkEhD35Xzx7-E9siw");

            return mock.Object;
        }
    }
}
