using System;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using TraineesPaymentSystem.Data.Common.Models;

namespace TraineesPaymentSystem.Data.Models
{
    public class TraineesPaymentSystemRole : IdentityRole<string>, IAuditInfo
    {
        public TraineesPaymentSystemRole()
        {
            
        }

        public TraineesPaymentSystemRole(string name)
        : base(name)
        {

        }

        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}