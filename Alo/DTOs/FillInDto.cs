using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alo.DTOs
{
    public class FillInDto
    {
        public int Id { get; set; }
        public string Vergadering { get; set; }
        public int FillInRequesterId { get; set; }
        public string FillInRequesterName { get; set; }
        public string FillInRequesterTak { get; set; }
        public int FillerId { get; set; }
        public string FillerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public bool Accepted { get; set; }
    }
}
