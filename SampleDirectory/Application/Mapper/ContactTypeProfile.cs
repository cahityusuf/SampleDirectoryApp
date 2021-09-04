using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractions.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class ContactTypeProfile:Profile
    {
        public ContactTypeProfile()
        {
            CreateMap<ContactType, ContactTypeDto>().ReverseMap();
        }
    }
}
