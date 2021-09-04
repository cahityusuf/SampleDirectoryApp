using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions.Dtos
{
    public class ContactInfoDto:IDto
    {
        public long Id { get; set; }
        //public UserDto User { get; set; }
        public long UserId { get; set; }
        public int ContactTypeId { get; set; }
        public ContactTypeDto ContactType { get; set; }
        public string Description { get; set; }
    }
}
