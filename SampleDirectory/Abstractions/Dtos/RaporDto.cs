using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions.Dtos
{
    public class RaporDto:IDto
    {
        public string konum { get; set; }
        public long kisisayisi { get; set; }
        public long telefonsayisi { get; set; }

        public List<long> UserId { get; set; }
    }
}
