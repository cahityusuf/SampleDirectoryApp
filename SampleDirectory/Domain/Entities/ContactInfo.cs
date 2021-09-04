using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractions.Data;

namespace Domain.Entities
{
    [Table("ContactInfo", Schema = "DirectoryContactInfo")]
    public class ContactInfo : IEntity
    {
        public ContactInfo()
        {
            User = new HashSet<User>();
        }
        public long Id { get; set; }
        public int ContactTypeId { get; set; }
        public ContactType ContactType { get; set; }
        public string Description { get; set; }

        public ICollection<User> User { get; set; }
    }
}
