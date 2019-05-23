﻿// ReSharper disable VirtualMemberCallInConstructor
namespace TraineesPaymentSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;
    using TraineesPaymentSystem.Data.Common.Models;

    public class TraineesPaymentSystemUser : IdentityUser, IAuditInfo
    {
        public TraineesPaymentSystemUser()
        {
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
        }

        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual  ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual  ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual  ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
