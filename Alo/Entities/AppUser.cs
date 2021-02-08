using Alo.Extensions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alo.Entities
{
    public class AppUser :  IdentityUser<int>
    {
        public DateTime DateOfBirth { get; set; }

        public string KnownAs { get; set; }

        public string Tak { get; set; }

        public string Gender { get; set; }

        public Photo Photo { get; set; }

        public ICollection<AppUserRole> UserRoles { get; set; }

        public ICollection<Request> Requests { get; set; }

        public ICollection<FillIn> FillInRequests { get; set; }

        public ICollection<FillIn> FillIns { get; set; }

        public int GetAge()
        {
            return DateOfBirth.CalculateAge();
        }
    }
}
