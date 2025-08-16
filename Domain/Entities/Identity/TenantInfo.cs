using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Identity
{
    public class TenantInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ConnectionString { get; set; }
        public int UserId {  get; set; }

        public  CustomUserIdentity? UserIdentity { get; set; }

        public static Result<TenantInfo> Instance(string name, string connectionString)
        {

            if (string.IsNullOrEmpty(connectionString))
            {
                return Result.Failure<TenantInfo>("connectionString is Requried");
            }

            var result = new TenantInfo
            {
                Name = name,
                ConnectionString = connectionString
            };

            return result;
        }
    }
}
