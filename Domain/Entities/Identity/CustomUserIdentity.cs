using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Identity
{
    public class CustomUserIdentity:IdentityUser<int>
    {
        public string DisplayName { get; set; }
        public int TenantId { get; set; }

        public TenantInfo TenantInfo { get; set; }
            public static Result<CustomUserIdentity> Instance(string displayName,
                                                  string email,
                                                  string phoneNumber,
                                                  string connectionString)
        {
            if (string.IsNullOrEmpty(displayName))
            {
                return Result.Failure<CustomUserIdentity>("display Name is Requried");
            }

            if (string.IsNullOrEmpty(email))
            {
                return Result.Failure<CustomUserIdentity>("email is Requried");
            }

            if (string.IsNullOrEmpty(phoneNumber))
            {
                return Result.Failure<CustomUserIdentity>("phoneNumber is Requried");
            }

            var tanentInfo = TenantInfo.Instance(Guid.NewGuid().ToString(), connectionString);
            if (tanentInfo.IsFailure)
            {
                return Result.Failure<CustomUserIdentity>(tanentInfo.Error);
            }

            var user = new CustomUserIdentity()
            {
                DisplayName = displayName,
                Email = email,
                UserName = email,
                PhoneNumber = phoneNumber,
                TenantInfo = tanentInfo.Value,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            return user;

        }


    }
}
