using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ValidationException:Exception
    {
        public required IEnumerable<string> Errors { get; set; }
        public ValidationException(string message = "Bad Request") : base(message)
        { }
    }
}
