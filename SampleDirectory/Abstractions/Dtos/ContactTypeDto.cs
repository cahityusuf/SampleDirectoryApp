using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions.Dtos
{
    public class ContactTypeDto:IDto
    {
        public long Id { get; set; }
        public string Description { get; set; }
    }
}
