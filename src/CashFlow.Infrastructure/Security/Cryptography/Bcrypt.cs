﻿using CashFlow.Domain.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace CashFlow.Infrastructure.Security.Cryptography
{
    public class Bcrypt : IPasswordEncrypter
    {
        public string Encrypt(string password)
        {
            string passwordHash = BC.HashPassword(password);

            return passwordHash;
        }

        public bool Verify(string password, string passwordHash) => BC.Verify(password, passwordHash);
    }
}
