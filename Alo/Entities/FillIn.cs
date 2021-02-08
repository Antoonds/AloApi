using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alo.Entities
{
    public class FillIn
    {
        public int Id { get; set; }
        public string Vergadering { get; set; }
        public AppUser FillInRequester { get; set; }
        public int FillInRequesterId { get; set; }
        public AppUser Filler { get; set; }
        public int FillerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public bool Accepted { get; set; }
    }
}
