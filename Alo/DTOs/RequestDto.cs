using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alo.DTOs
{
    public class RequestDto
    {
        public int Id { get; set; }
        public string Vergadering { get; set; }        
        public int RequesterId { get; set; }
        public string RequesterName { get; set; }
        public string RequesterTak { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public bool Accepted { get; set; } = false;
    }
}
