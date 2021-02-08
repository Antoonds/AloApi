using Alo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alo.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public int Age { get; set; }

        public string KnownAs { get; set; }

        public string Gender { get; set; }
        public PhotoDto Photo { get; set; }
    }
}
