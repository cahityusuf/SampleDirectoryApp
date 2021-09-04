using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions.Dtos
{
    public class ContactTypeDto:IDto
    {
        public ContactTypeDto()
        {
            ContactInfo = new HashSet<ContactInfoDto>();
        }
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<ContactInfoDto> ContactInfo { get; set; }
    }
}
