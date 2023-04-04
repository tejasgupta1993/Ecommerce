﻿using Ecommerce.Interface;
using System;
using System.Security.Cryptography;

namespace Ecommerce.Repository
{
    public class RefreshTokenGenerator : IRefreshTokenGenerator
    {
        public string GenerateToken()
        {
            var randomNumber = new byte[32];

            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
