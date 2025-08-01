﻿using CashFlow.Application.UseCases.Users.Update;
using CashFlow.Exception;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace Validators.Test.Users.Update
{
    public class UpdateUserValidatorTest
    {
        [Fact]
        public void Success()
        {
            var validator = new UpdateUserValidator();
            var request = RequestUpdateUserJsonBuilder.Build();

            var result = validator.Validate(request);

            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("    ")]
        public void Error_Name_Empty(string name)
        {
            var validator = new UpdateUserValidator();
            var request = RequestUpdateUserJsonBuilder.Build();
            request.Name = name;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(error =>
                error.ErrorMessage.Equals(ResourceErrorMessages.NAME_EMPTY));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("    ")]
        public void Error_Email_Empty(string email)
        {
            var validator = new UpdateUserValidator();
            var request = RequestUpdateUserJsonBuilder.Build();
            request.Email = email;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(error =>
                error.ErrorMessage.Equals(ResourceErrorMessages.EMAIL_EMPTY));
        }

        [Fact]
        public void Error_Email_Invalid()
        {
            var validator = new UpdateUserValidator();
            var request = RequestUpdateUserJsonBuilder.Build();
            request.Email = "harrypotter.com";

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(error =>
                error.ErrorMessage.Equals(ResourceErrorMessages.EMAIL_INVALID));
        }
    }
}
