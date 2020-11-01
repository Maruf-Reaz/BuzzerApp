using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamo.Model.Common.Authentication
{
    public class ApplicationUser : IdentityUser
    {
        public int? EmployeeId { get; set; }
    }
}
